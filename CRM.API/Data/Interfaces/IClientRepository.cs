using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.API.Models;

namespace CRM.API.Data.Interfaces
{
    public interface IClientRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<Customer>> GetAll();
         Task<Customer> Get(int id);
    }
}