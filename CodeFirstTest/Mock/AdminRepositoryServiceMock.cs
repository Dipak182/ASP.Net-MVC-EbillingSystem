using CodeFirst.Models.Admin;
using CodeFirst.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTest.Mock
{
    public class AdminRepositoryServiceMock : IAdminRepositoryService
    {
        public void Save()
        {
            throw new NotImplementedException();
        }

        public UsersRole AddRoles(CodeFirst.Models.Admin.UsersRole request)
        {
            return new UsersRole
            {
                Id = 1,
                RoleName = "Adnin",
                CreatedOn = DateTime.Now,
                CreatedBy = 1,
                ModifyBy = 1,
                ModifyOn = DateTime.Now
            };
        }

        public List<UsersRole> GetRoles()
        {
            List<UsersRole> roles = new List<UsersRole>();

            UsersRole rol = new UsersRole()
            {
                Id = 1,
                RoleName = "Adnin",
                CreatedOn = DateTime.Now,
                CreatedBy = 1,
                ModifyBy = 1,
                ModifyOn = DateTime.Now
            };
            UsersRole rol1 = new UsersRole()
            {
                Id = 2,
                RoleName = "SuperUser",
                CreatedOn = DateTime.Now,
                CreatedBy = 1,
                ModifyBy = 1,
                ModifyOn = DateTime.Now
            };

            roles.Add(rol);
            roles.Add(rol1);
            return roles;
        }

        public void DeleteRole(UsersRole request)
        {
            throw new NotImplementedException();
        }

        public UsersRole GetOne(string roleName)
        {
            return new UsersRole()
            {
                Id = 1,
                RoleName = "Adnin",
                CreatedOn = DateTime.Now,
                CreatedBy = 1,
                ModifyBy = 1,
                ModifyOn = DateTime.Now

            };
        }

        public UsersRole GetRoleByRoleId(int id)
        {
            throw new NotImplementedException();
        }

        public UsersInfo AddNewUsers(CodeFirst.Models.Admin.UsersInfo request)
        {
            throw new NotImplementedException();
        }

        public List<UsersInfo> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UsersInfo UserAuthentication(CodeFirst.Models.Admin.UserLogin info)
        {
            throw new NotImplementedException();
        }

        public Category AddNewCategory(CodeFirst.Models.Admin.Category request)
        {
            throw new NotImplementedException();
        }

        public Product AddNewProduct(CodeFirst.Models.Admin.Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByProductCode(string productcode)
        {
            throw new NotImplementedException();
        }

        public Bills AddInPrintBill(CodeFirst.Models.Admin.Bills bill)
        {
            throw new NotImplementedException();
        }

        public List<Bills> GetBillData(CodeFirst.Models.Admin.Bills bill)
        {
            throw new NotImplementedException();
        }

        public void DeleteFromPrintBill(Bills bill)
        {
            throw new NotImplementedException();
        }

        public void AddNewBillAfterPrint(Bills bill)
        {
            throw new NotImplementedException();
        }


        IQueryable<object> IAdminRepositoryService.GetAllUsers()
        {
            throw new NotImplementedException();
        }


        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
