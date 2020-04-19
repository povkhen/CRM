using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM.API.Models;

namespace CRM.API.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            Department = new HashSet<Department>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public int? DepartmentId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
         public DateTime CreatedAt { get; set; }
        public string Gender { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
        
        public virtual Department DepartmentNavigation { get; set; }
        public virtual ICollection<Department> Department { get; set; }
    }    
}
