using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.API.Models;

namespace CRM.API.Data.Interfaces
{
    public interface IUserRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetAll();
         Task<User> Get(int id);
    }
}