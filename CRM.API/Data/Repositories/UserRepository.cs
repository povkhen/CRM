using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.API.Data.Interfaces;
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

        public async Task<User> Get(int id)
        {
            var user = await _context.User.Include(p => p.Photos)
                                          .Include(d => d.Department)
                                          .Include(s => s.UserServices)
                                          .FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _context.User.Include(p => p.Photos)
                                           .Include(d => d.Department)
                                           .ToListAsync();
            return users;
        }

        public async Task<Photo> GetMainPhotoForUser(int userId)
        {
            return await _context.Photo.Where(u => u.UserId == userId)
                        .FirstOrDefaultAsync(m => m.IsMain);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photo.FirstOrDefaultAsync(p => p.Id ==id);
            return photo;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}