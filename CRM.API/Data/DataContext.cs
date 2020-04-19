using CRM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.API.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
                
            modelBuilder.Entity<Customer>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
