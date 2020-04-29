using System.Collections.Generic;

namespace CRM.API.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public virtual ICollection<UserService> UserServices { get; set; }

    }
}