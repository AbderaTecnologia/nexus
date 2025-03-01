using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using static Microsoft.AspNetCore.Http.Results;

namespace Nexus.Core.Api.Filters.Authorization
{
    public class AuthorizationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var token = context.HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return null;
            }

            var user = context.HttpContext.User;
            if (user.Identity?.IsAuthenticated != true)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return Unauthorized();
            }
            else
            {
                return await next(context);
            }
        }
    }
}