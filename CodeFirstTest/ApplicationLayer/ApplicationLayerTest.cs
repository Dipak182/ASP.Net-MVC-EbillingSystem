using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirst.ApplicationService;
using CodeFirstTest.Mock;
using CodeFirst.Models.Admin;
using System.Linq;
using System.Collections.Generic;

namespace CodeFirstTest.ApplicationLayer
{
    [TestClass]
    public class ApplicationLayerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //IApplicationService service = new ApplicationService(new AdminRepositoryServiceMock());
            IApplicationService service = new ApplicationService();
            //UsersRole roles = new UsersRole();
            //var respone = service.AddRoles(roles);
            //Assert.IsNotNull(respone);
            IQueryable<object> result = service.GetAllUsers().AsQueryable();

            foreach (var item in result)
            {
                //Assert.IsNotNull(item.UserName);
            }
        }
    }
}
