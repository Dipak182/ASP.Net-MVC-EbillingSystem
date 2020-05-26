using CodeFirst.Models.Admin;
using CodeFirst.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.ApplicationService
{
    public class ApplicationService : IApplicationService
    {
        IAdminRepositoryService _adminRepositoryService = null;
        public ApplicationService(IAdminRepositoryService adminRepositoryService = null)
        {
            _adminRepositoryService = adminRepositoryService ?? new AdminRepositoryService();
        }

        public UsersRole AddRoles(UsersRole request)
        {
            return _adminRepositoryService.AddRoles(request);
        }


        public IQueryable<object> GetAllUsers()
        {
            return _adminRepositoryService.GetAllUsers();
        }
    }
}