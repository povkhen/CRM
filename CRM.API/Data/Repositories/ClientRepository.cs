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
        public void Add<T>(T entity) where T: class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T: class
        {
            _context.Remove(entity);
        }

        public async Task<Customer> Get(int id)
        {
            var customer = await _context.Customer.Include(o => o.Orders)
                                          .FirstOrDefaultAsync(c => c.Id == id);
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _context.Customer.Include(o => o.Orders).ToListAsync();
            return customers;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        
    }
}