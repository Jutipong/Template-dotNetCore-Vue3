using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Helpers
{
    public class AccessPermissionFilter : ActionFilterAttribute
    {
        private MenuPermission _menuPermission;
        public AccessPermissionFilter(MenuPermission menuPermission)
        {
            _menuPermission = menuPermission;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string action = (string)context.RouteData.Values["action"];
            string controller = (string)context.RouteData.Values["controller"];
            if (!_menuPermission.VerifyPermissionPage(action, controller))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "AccessDenied" }));
            }
            base.OnActionExecuting(context);
        }
    }
}
