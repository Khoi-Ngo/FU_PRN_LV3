using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace BusinessService
{
    public class PermissionAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        //private readonly string[] _roles;
        private readonly int[] _roles;

        //public PermissionAuthorizeAttribute(params string[] roles)
        //{
        //    _roles = roles;
        //}

        public PermissionAuthorizeAttribute(params int[] roles)
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

            //var role = context.HttpContext.User.FindFirst("RoleSave")?.Value;
            var roleClaim = context.HttpContext.User.FindFirst("RoleSave")?.Value;
            //if (role == null || !_roles.Contains(role))
            //{
            //    context.Result = new ForbidResult(); // 403
            //}
            if (string.IsNullOrEmpty(roleClaim) ||
                !int.TryParse(roleClaim, out int role) ||
                !_roles.Contains(role))
            {
                context.Result = new ForbidResult(); // 403 Forbidden
            }
        }
    }
}
