using System.Collections.Generic;

namespace CRM.API.Models
{
    public partial class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
