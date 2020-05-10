using Microsoft.AspNetCore.Identity;

namespace CRM.API.Models
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}