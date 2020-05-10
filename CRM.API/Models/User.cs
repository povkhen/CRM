using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CRM.API.Models
{    
    public class User : IdentityUser<int>
    {

        public string FullName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastActive { get; set; }
        public string Gender { get; set; }

        public string City { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Message> MessagesSent { get; set; }
        public virtual ICollection<Message> MessagesReceived { get; set; }
        public virtual ICollection<UserService> UserServices { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
     
    }
}