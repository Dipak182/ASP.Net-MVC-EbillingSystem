using CodeFirst.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.ApplicationService
{
    public interface IApplicationService
    {
        UsersRole AddRoles(UsersRole request);
        IQueryable<object> GetAllUsers();
    }
}
