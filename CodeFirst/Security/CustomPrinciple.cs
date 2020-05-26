using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace CodeFirst.Security
{
    public class CustomPrinciple : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public CustomPrinciple(string userName)
        {
            this.Identity = new GenericIdentity(userName);
        }

        public bool IsInRole(string role)
        {
            if (roles.Any(r => role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string[] roles { get; set; }

    }

    public class CustomPrincipalSerializeModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string[] roles { get; set; }
    }
}