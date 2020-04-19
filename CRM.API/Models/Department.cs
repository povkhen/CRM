using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.API.Models
{
    public partial class Department
    {
        public Department()
        {
            User = new HashSet<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? HeadId { get; set; }
        public string Phone { get; set; }

        public virtual User Head { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
