using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Pre_maritalCounSeling.BAL.Auth
{
    public class PermissionAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public PermissionAuthorizeAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity?.IsAuthenticated != true)
            {
                context.Result = new UnauthorizedResult(); // 401
                return;
            }

            var role = context.HttpContext.User.FindFirst("RoleName")?.Value;
            if (role == null || !_roles.Contains(role))
            {
                context.Result = new ForbidResult(); // 403
            }
        }
    }
}
