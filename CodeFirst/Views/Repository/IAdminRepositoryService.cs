using CodeFirst.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Repository
{
    public interface IAdminRepositoryService
    {
        void Save();
        UsersRole AddRoles(UsersRole request);
        List<UsersRole> GetRoles();
        void DeleteRole(UsersRole request);
        UsersRole GetOne(string roleName);
        UsersRole GetRoleByRoleId(int id);
        

        UsersInfo AddNewUsers(UsersInfo request);
        IQueryable<object> GetAllUsers();
        UsersInfo UserAuthentication(UserLogin info);


        Category AddNewCategory(Category request);

        Product AddNewProduct(Product product);
        Product GetProductByProductCode(string productcode);
        List<Product> GetAllProducts();
        Bills AddInPrintBill(Bills bill);
        List<Bills> GetBillData(Bills bill);
        void DeleteFromPrintBill(Bills bill);
        void AddNewBillAfterPrint(Bills bill);


    }
}
