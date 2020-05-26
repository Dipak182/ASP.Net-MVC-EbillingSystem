using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace CodeFirst.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
       
        protected virtual CustomPrinciple CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrinciple; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!String.IsNullOrEmpty(Roles))
            {
                if (CurrentUser != null)
                {
                    if (!CurrentUser.IsInRole(Roles))
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Index" }));
                    }
                }
            }
        }
    }
}