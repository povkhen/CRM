using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.API.Data.Interfaces;
using CRM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.API.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        public ClientRepository(DataContext context)
        {
            _context = context;

        }


         public async Task<Order> GetOrder(int id)
        {
            var order = await _context.Orders.Include(o => o.Owner)
                                            .Include(v => v.Vendor)
                                            .Include(p => p.Payment)
                                            .FirstOrDefaultAsync(c => c.Id == id);
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            var orders = await _context.Orders.Include(o => o.Owner)
                                                .Include(v => v.Vendor)
                                                .Include(p => p.Payment)
                                                .ToListAsync();
            return orders;
        }

        public async Task<bool> NumberExists(string number)
        {
            if (await _context.Orders.AnyAsync(x => x.Number == number))
                return true;
            return false;
        }

        public async Task<Customer> Get(int id)
        {
            var customer = await _context.Customers.Include(o => o.Orders)
                                          .FirstOrDefaultAsync(c => c.Id == id);
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _context.Customers.Include(o => o.Orders).ToListAsync();
            return customers;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}