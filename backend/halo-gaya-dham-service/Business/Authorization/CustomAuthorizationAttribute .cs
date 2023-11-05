using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Business.Authorization
{
    public class CustomAuthorizationAttribute : TypeFilterAttribute
    {
        public CustomAuthorizationAttribute() : base(typeof(CustomAuthorizationFilter))
        {
        }
    }

    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var session = context.HttpContext.Session;
            var username = session.GetString("username");

            if (string.IsNullOrEmpty(username))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}