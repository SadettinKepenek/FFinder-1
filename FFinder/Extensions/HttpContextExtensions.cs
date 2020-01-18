using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace FFinder.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetNameIdentifier(this HttpContext httpContext)
        {
            string id = httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?
                .Value;
            return id;
        }   
    }
}