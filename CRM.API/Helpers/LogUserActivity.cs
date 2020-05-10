using System;
using System.Security.Claims;
using System.Threading.Tasks;
using CRM.API.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();
            var userId = int.Parse(resultContext.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value);
            var repo = resultContext.HttpContext.RequestServices.GetService<IUserRepository>();
            var user = await repo.Get(userId, true);
            user.LastActive = DateTime.Now;
            await repo.SaveAll();

        }
    }
}