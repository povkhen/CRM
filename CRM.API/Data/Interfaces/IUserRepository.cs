using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.API.Helpers;
using CRM.API.Models;

namespace CRM.API.Data.Interfaces
{
    public interface IUserRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<PagedList<User>> GetAll(UserParams userParams);
         Task<IEnumerable<string>> GetAllPositions();
         Task<User> Get(int id, bool isCurrentUser);
         Task<Photo> GetPhoto(int id);
         Task<Photo> GetMainPhotoForUser(int userId);
         
         Task<Message> GetMessage(int id);
         Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams);
         Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);
         
    }
}