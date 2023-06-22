using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Atelier.Application.Interfaces.IBaseInfoServices;
using Microsoft.AspNetCore.Mvc;


namespace Atelier.Application.Security
{
    public class AuthorizeClaims : Attribute, IAuthorizationFilter
    {
        private IPermissionService _permissionService;
        private readonly int _permissionId;
        public AuthorizeClaims(int permissionId)
        {
            _permissionId = permissionId;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _permissionService = (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService));

            int currentUserId = context.HttpContext.User.GetUserId();

            if (!_permissionService.CheckPermission(_permissionId, currentUserId))
                context.Result = new RedirectResult("/Permission");
        }
    }
    public class AuthorizeProductClaims : Attribute, IAuthorizationFilter
    {
        private ISuperAdminService _superAdminService;
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _superAdminService = (ISuperAdminService)context.HttpContext.RequestServices.GetService(typeof(ISuperAdminService));
        }
    }


}
