using CodeFirst.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace CodeFirst.Repository
{
    public class AdminRepositoryService : IAdminRepositoryService
    {
        private readonly CodeFirstDataContext _CodeFirstDataContext = null;

        public AdminRepositoryService(CodeFirstDataContext CodeFirstDataContext = null)
        {
            _CodeFirstDataContext = CodeFirstDataContext ?? new CodeFirstDataContext();
        }

        public void Save()
        {
            _CodeFirstDataContext.SaveChanges();
        }

        #region Roles
        public UsersRole AddRoles(UsersRole request)
        {
            UsersRole role = new UsersRole();
            if (request.Id == 0)
            {
                role.RoleName = request.RoleName;
                role.CreatedOn = DateTime.Now;
                role.ModifyOn = DateTime.Now;
                role.CreatedBy = 1;
                role.ModifyBy = 1;
                _CodeFirstDataContext.UserRoles.Add(role);
            }
            else
            {
                role = _CodeFirstDataContext.UserRoles.SingleOrDefault(x => x.Id == request.Id);
                role.RoleName = request.RoleName;
                role.CreatedOn = DateTime.Now;
                role.ModifyOn = DateTime.Now;
                role.CreatedBy = 1;
                role.ModifyBy = 1;
                _CodeFirstDataContext.Entry(role).State = System.Data.EntityState.Modified;
            }


            Save();

            return role;

        }

        public List<UsersRole> GetRoles()
        {
            List<UsersRole> roles = _CodeFirstDataContext.UserRoles.ToList();
            return roles;
        }

        public void DeleteRole(UsersRole request)
        {
            UsersRole role = _CodeFirstDataContext.UserRoles.SingleOrDefault(x => x.Id == request.Id);
            _CodeFirstDataContext.UserRoles.Remove(role);
            Save();

        }

        public UsersRole GetOne(string roleName)
        {
            UsersRole role = _CodeFirstDataContext.UserRoles.SingleOrDefault(x => x.RoleName.Equals(roleName));
            return role;
        }

        #endregion

        #region Users
        public UsersInfo AddNewUsers(UsersInfo request)
        {
            UsersInfo info = new UsersInfo()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = request.Password,
                Email = request.Email,
                RoleId = request.RoleId,
            };
            _CodeFirstDataContext.UsersInfos.Add(info);
            Save();
            return info;

        }
        #endregion

        #region Category
        public Category AddNewCategory(Category request)
        {
            Category cat = new Category()
            {
                CagtegoryName = request.CagtegoryName
            };
            _CodeFirstDataContext.Categories.Add(cat);
            Save();
            return cat;
        }
        #endregion

        #region Product
        public Product AddNewProduct(Product product)
        {
            Product _product = new Product()
            {
                ProductCode = product.ProductCode,
                ItemName = product.ItemName,
                Price = product.Price,
                Description = product.Description,
                Status = product.Status,
                ImageName=product.ImageName,
            };

            _CodeFirstDataContext.Products.Add(_product);
            Save();
            return _product;
        }

        public Product GetProductByProductCode(string productcode)
        {
            return _CodeFirstDataContext.Products.SingleOrDefault(x => x.ProductCode.Equals(productcode));
        }
        #endregion

        #region Sales
        public Bills AddInPrintBill(Bills bill)
        {
            Bills printbill = new Bills()
            {
                SessionId = bill.SessionId,
                UserId = bill.UserId,
                ItemName = bill.ItemName,
                Price = bill.Price,
                Qty = bill.Qty,
                Status = bill.Status,
                Total = bill.Qty * bill.Price,
                BillDate = DateTime.Now,
                ProductId=bill.ProductId
            };


            _CodeFirstDataContext.PrintBills.Add(printbill);
            Save();
            return printbill;

        }

        public List<Bills> GetBillData(Bills bill)
        {
            List<Bills> CurrrentBill = _CodeFirstDataContext.PrintBills.Where(x => x.UserId == bill.UserId && x.Status.Equals("PENDING") && x.SessionId.Equals(HttpContext.Current.Session.SessionID)).ToList();
            return CurrrentBill;
        }
        #endregion


        public IQueryable<object> GetAllUsers()
        {


            IQueryable<object> query = (from u in _CodeFirstDataContext.UsersInfos
                        join r in _CodeFirstDataContext.UserRoles on u.RoleId equals r.Id
                        select new
                        {
                            u.FirstName,
                            u.LastName,
                            u.Email,
                            u.UserName,
                            u.Password,
                            r.RoleName

                        });


            return query;
        }

        
        public UsersInfo UserAuthentication(UserLogin info)
        {
            return _CodeFirstDataContext.UsersInfos.SingleOrDefault(x => x.UserName.Equals(info.UserNmame) && x.Password.Equals(info.Password));
        }
        
        public UsersRole GetRoleByRoleId(int id)
        {
            return _CodeFirstDataContext.UserRoles.SingleOrDefault(x => x.Id.Equals(id));
        }
        
        public void DeleteFromPrintBill(Bills bill)
        {
            List<Bills> TempBills = _CodeFirstDataContext.PrintBills.Where(x => x.UserId.Equals(bill.UserId) && x.Status.Equals("PENDING") && x.SessionId.Equals(HttpContext.Current.Session.SessionID)).ToList();
            foreach (var item in TempBills)
            {
                _CodeFirstDataContext.PrintBills.Remove(item);
            }
            Save();
        }


        public void AddNewBillAfterPrint(Bills bill)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_DupmDataInto_SalesBillHistory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId", bill.UserId);
                    cmd.Parameters.AddWithValue("@SessionId", bill.SessionId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }


        public List<Product> GetAllProducts()
        {
            return _CodeFirstDataContext.Products.ToList();
        }
    }
}