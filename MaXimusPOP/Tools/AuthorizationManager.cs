using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaXimusPOP.Enum;
using MaXimusPOP.Models.forms;

namespace MaXimusPOP.Tools
{
    public class AuthorizationManager : AuthorizeAttribute
    {
        private RoleEnum[] MyRoles;

        public AuthorizationManager()
        {
            this.MyRoles = (RoleEnum[])System.Enum.GetValues(typeof(RoleEnum));
        }

        public AuthorizationManager(params RoleEnum[] MyRoles)
        {
            this.MyRoles = MyRoles;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            CustomerSession user = SessionManager.Instance.LoggedUser;

            if (user.UserId <= 0)
            {
                filterContext.Result = new RedirectResult("/User/Login");
            }
            else if (!MyRoles.Any(r => r == user.Role))
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

        }
    }
}