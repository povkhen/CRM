using System.Collections.Generic;
using System.Linq;
using CRM.API.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace CRM.API.Data
{
    public class Seed
    {
        public static void SeedDepartments(DataContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (!context.Departments.Any())
            {
                var departmentData = System.IO.File.ReadAllText("Data/JsonSeed/DepartmentSeedData.json");
                var departments = JsonConvert.DeserializeObject<List<Department>>(departmentData);

                //create some roles

                var roles = new List<Role> 
                {
                    new Role {Name = "Member"},
                    new Role {Name = "Admin"},
                    new Role {Name = "Moderator"},
                    new Role {Name = "HR"}
                };

                foreach (var role in roles)
                {
                    roleManager.CreateAsync(role).Wait();
                }

                foreach (var department in departments)
                { 
                    foreach (var user in department.Users)
                    {
                        user.Photos.SingleOrDefault().IsApproved = true;
                        userManager.CreateAsync(user, "password").Wait();
                        userManager.AddToRoleAsync(user, "Member").Wait();
                    }
                    context.Departments.AddAsync(department);   
                }

                //create admin user

                var adminUser = new User
                {
                    UserName = "Admin"
                };

                var result = userManager.CreateAsync(adminUser, "password").Result;
                if (result.Succeeded)
                {
                    var admin = userManager.FindByNameAsync("Admin").Result;
                    userManager.AddToRolesAsync(admin, new[] {"Admin", "Moderator"}).Wait();
                }
                context.SaveChangesAsync();
            }
        }
        public static void SeedCustomers(DataContext context)
        {
            if (!context.Customers.Any())
            {
                var customerData = System.IO.File.ReadAllText("Data/JsonSeed/CustomerSeedData.json");
                var customers = JsonConvert.DeserializeObject<List<Customer>>(customerData);
                foreach (var customer in customers)
                { 
                    context.Customers.Add(customer);   
                }
                context.SaveChanges();
            }
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));   
            }
            
        }
    }
}