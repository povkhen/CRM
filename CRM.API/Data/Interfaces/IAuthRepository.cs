using System.Threading.Tasks;
using CRM.API.Models;

namespace CRM.API.Data.Interfaces
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string login, string password);
         Task<bool> UserExists(string login);
    }
}