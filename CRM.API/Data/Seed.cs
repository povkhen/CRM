using System.Collections.Generic;
using System.Linq;
using CRM.API.Models;
using Newtonsoft.Json;

namespace CRM.API.Data
{
    public class Seed
    {
        public static void SeedDepartments(DataContext context)
        {
            if (!context.Department.Any())
            {
                var departmentData = System.IO.File.ReadAllText("Data/JsonSeed/DepartmentSeedData.json");
                var departments = JsonConvert.DeserializeObject<List<Department>>(departmentData);
                foreach (var department in departments)
                { 
                    foreach (var user in department.Users)
                    {
                        byte[] passwordHash, passwordSalt;
                        CreatePasswordHash("password", out passwordHash, out passwordSalt );
                        user.PasswordHash = passwordHash;
                        user.PasswordSalt = passwordSalt;
                        user.Login = user.Login.ToLower();
                    }
                    context.Department.Add(department);   
                }
                context.SaveChanges();
            }
        }
        public static void SeedCustomers(DataContext context)
        {
            if (!context.Customer.Any())
            {
                var customerData = System.IO.File.ReadAllText("Data/JsonSeed/CustomerSeedData.json");
                var customers = JsonConvert.DeserializeObject<List<Customer>>(customerData);
                foreach (var customer in customers)
                { 
                    context.Customer.Add(customer);   
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