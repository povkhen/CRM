using CRM.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRM.API.Data
{
    public partial class DataContext : IdentityDbContext<User, Role,
        int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<UserService> UserServices { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole => 
            {
                userRole.HasKey(ur => new {ur.UserId, ur.RoleId}); 
              
                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                  userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

             modelBuilder.Entity<UserService>(userService => 
            {
                userService.HasKey(us => new {us.UserId, us.ServiceId}); 
              
                userService.HasOne(us => us.Service)
                    .WithMany(r => r.UserServices)
                    .HasForeignKey(ur => ur.ServiceId);

                  userService.HasOne(ur => ur.User)
                    .WithMany(r => r.UserServices)
                    .HasForeignKey(ur => ur.UserId);
            });

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
                
            modelBuilder.Entity<Customer>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Order>()
                .Property(u => u.Sum)
                .HasColumnType("money");

            modelBuilder.Entity<Payment>()
                .Property(u => u.Sum)
                .HasColumnType("money");

            modelBuilder.Entity<Service>()
                .Property(u => u.Price)
                .HasColumnType("money");

            modelBuilder.Entity<Photo>().HasQueryFilter(p => p.IsApproved);
        }
    }
}
