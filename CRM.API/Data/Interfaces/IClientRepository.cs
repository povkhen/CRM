using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.API.Models;

namespace CRM.API.Data.Interfaces
{
    public interface IClientRepository
    {
         Task<bool> SaveAll();
         Task<Order> AddOrder(Order order);
         void DeleteOrder(Order order);
         Task<IEnumerable<Order>> GetAllOrders();
         Task<Order> GetOrder(int id);
         Task<bool> NumberExists(string number);
         Task<IEnumerable<Customer>> GetAll();
         Task<Customer> Get(int id);
    }
}