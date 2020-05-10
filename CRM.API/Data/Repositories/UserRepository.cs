using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.API.Data.Interfaces;
using CRM.API.Helpers;
using CRM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.API.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T: class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T: class
        {
            _context.Remove(entity);
        }

        public async Task<User> Get(int id, bool isCurrentUser)

        {
            var query = _context.Users.Include(p => p.Photos)
                                          .Include(d => d.Department)
                                          .Include(s => s.UserServices)
                                          .AsQueryable();
            if (isCurrentUser)
                query = query.IgnoreQueryFilters();
            
            var user = await query.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<PagedList<User>> GetAll(UserParams userParams)
        {
            var users = _context.Users.Include(p => p.Photos)
                                     .Include(d => d.Department)
                                     .OrderByDescending(u => u.LastActive)
                                     .AsQueryable();

            //without active
            users = users.Where(u => u.Id != userParams.UserId);
            
            //filtering
            if (userParams.Position == "null")
                users = users.Where(u => u.Position == null);
            else if (!string.IsNullOrEmpty(userParams.Position))
                users = users.Where(u => u.Position == userParams.Position);

            //sorting
            if(!string.IsNullOrEmpty(userParams.OrderBy))
            {
                switch (userParams.OrderBy)
                {
                    case "created": 
                        users = users.OrderByDescending(u => u.CreatedAt);
                        break;
                    default: 
                        users = users.OrderByDescending(u => u.LastActive);
                        break;
                }
            }

            return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize); 

        }

        public async Task<IEnumerable<string>> GetAllPositions()
        {
            var users = await _context.Users.ToListAsync();
            return users.Select(p => p.Position).Distinct().Where(x => x != null);
        }

        public async Task<Photo> GetMainPhotoForUser(int userId)
        {
            return await _context.Photos.Where(u => u.UserId == userId)
                        .FirstOrDefaultAsync(m => m.IsMain);
        }

        public async Task<Message> GetMessage(int id)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams)
        {
            var messages = _context.Messages.Include(u => u.Sender)
                                           .ThenInclude(u => u.Photos)
                                           .Include(r => r.Recipient)
                                           .ThenInclude(r => r.Photos)
                                           .AsQueryable();
            switch(messageParams.MessageContainer)
            {
                case "Inbox":
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId
                        && u.RecipientDeleted == false);
                    break;
                case "Outbox":
                    messages = messages.Where(u => u.SenderId == messageParams.UserId
                        && u.SenderDeleted == false);
                    break;
                default:
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId 
                        && u.RecipientDeleted == false && u.IsRead == false);
                    break;
            }
            messages = messages.OrderByDescending(d => d.MessageSent);
            return await PagedList<Message>.CreateAsync(messages, messageParams.PageNumber, messageParams.PageSize);
        }

        public async Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId)
        {
            var messages = await _context.Messages.Include(u => u.Sender)
                                           .ThenInclude(u => u.Photos)
                                           .Include(r => r.Recipient)
                                           .ThenInclude(r => r.Photos)
                                           .Where(m => m.RecipientId == userId && m.RecipientDeleted == false
                                                       && m.SenderId == recipientId ||
                                                       m.RecipientId == recipientId && m.SenderDeleted == false
                                                       && m.SenderId == userId)
                                           .OrderByDescending(m => m.MessageSent)
                                           .ToListAsync();
            return messages;
            

        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.IgnoreQueryFilters().FirstOrDefaultAsync(p => p.Id ==id);
            return photo;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}