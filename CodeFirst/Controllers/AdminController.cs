using CodeFirst.Models;
using CodeFirst.Models.Admin;
using CodeFirst.Repository;
using CodeFirst.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Controllers
{
    [CustomAuthorize(Roles = "Admin,SuperUser")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private readonly IAdminRepositoryService _adminRepositoryService = new AdminRepositoryService();

        public ActionResult Index()
        {

            return View();
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult UersRole()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetRoles()
        {
            List<UsersRole> roles = _adminRepositoryService.GetRoles();
            return Json(roles, JsonRequestBehavior.AllowGet);
        }



        [CustomAuthorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult UersRole(UsersRole roles)
        {
            try
            {
                UsersRole request = new UsersRole();
                request.RoleName = roles.RoleName;
                request.Id = roles.Id;
                _adminRepositoryService.AddRoles(request);
                ViewData["message"] = CommonConstrant.save;
            }

            catch (Exception ex)
            {
                ViewData["message"] = ex.Message;
            }
            return View(roles);
        }


        [HttpPost]
        public JsonResult DeleteRole(UsersRole roles)
        {
            try
            {
                UsersRole request = new UsersRole();
                request.Id = roles.Id;
                _adminRepositoryService.DeleteRole(request);
                ViewData["message"] = CommonConstrant.Delete;
            }

            catch (Exception ex)
            {
                ViewData["message"] = ex.Message;
            }
            return Json(roles, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult UsersInfo()
        {
            ViewBag.Roles = GetUsersRoles();
            return View();
        }


        [HttpGet]
        public JsonResult GetAllUsers()
        {
            var infos = _adminRepositoryService.GetAllUsers();

            return Json(infos, JsonRequestBehavior.AllowGet);
        }


        public List<SelectListItem> GetUsersRoles()
        {
            List<SelectListItem> roles = new List<SelectListItem>();
            List<UsersRole> usersRoles = _adminRepositoryService.GetRoles();

            foreach (var item in usersRoles)
            {
                roles.Add(new SelectListItem { Text = item.RoleName, Value = item.Id.ToString() });
            }

            return roles;
        }

        [HttpPost]
        public ActionResult UsersInfo(UsersInfo info)
        {
            try
            {
                ViewBag.Roles = GetUsersRoles();
                UsersInfo response = _adminRepositoryService.AddNewUsers(info);
                ViewData["message"] = CommonConstrant.save;
            }
            catch (Exception ex)
            {
                ViewData["message"] = ex.Message;
            }
            return View(info);
        }

        [HttpGet]
        public ActionResult Category()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Category(Category cat)
        {
            _adminRepositoryService.AddNewCategory(cat);

            return View();
        }


        [HttpGet]
        public ActionResult Product()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Product(Product product, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string strPath = Server.MapPath("/Images/");
                file.SaveAs(Path.Combine(strPath, file.FileName));
                product.ImageName = file.FileName;

                _adminRepositoryService.AddNewProduct(product);
            }
            return View(product);
        }

        //[CustomAuthorize(Roles = "Sales,Admin")]
        [HttpGet]
        public ActionResult AddInBill()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddInBill(Bills bills)
        {
            string uid = string.Empty;
            if (Session["RoleId"] != null)
            {
                uid = Session["RoleId"].ToString();
            }

            bills.SessionId = Session.SessionID;
            bills.UserId = uid;
            bills.Status = ShippingStatus.PENDING.ToString();
            bills.ProductId = bills.ProductId;

            _adminRepositoryService.AddInPrintBill(bills);
            return Json(bills, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void PrintBill(Bills bill)
        {

        }

        [HttpPost]
        public void AddNewBill()
        {
            string uid = string.Empty;
            if (Session["RoleId"] != null)
            {
                uid = Session["RoleId"].ToString();
            }
            _adminRepositoryService.AddNewBillAfterPrint(new Bills { UserId = uid, SessionId = Session.SessionID });

        }
        public JsonResult GetProductByCode(string productCode)
        {
            Product product = new Product();
            product = _adminRepositoryService.GetProductByProductCode(productCode);
            return Json(product, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetCurrentBill(string userId)
        {
            string uid = string.Empty;
            if (Session["RoleId"] != null)
            {
                uid = Session["RoleId"].ToString();
            }

            List<Bills> CurrentBill = new List<Bills>();
            CurrentBill = _adminRepositoryService.GetBillData(new Bills { UserId = uid });

            decimal SumAmount = 0;
            foreach (var item in CurrentBill)
            {
                SumAmount += item.Total;
            }

            ViewData["GrandTotal"] = SumAmount;

            return Json(CurrentBill, JsonRequestBehavior.AllowGet);

        }

        public ActionResult SingOut()
        {

            string userId = string.Empty;
            if (Session["RoleId"] != null)
            {
                userId = Session["RoleId"].ToString();
            }
            Bills b = new Bills();
            b.UserId = userId;
            b.SessionId = Session.SessionID;
            _adminRepositoryService.DeleteFromPrintBill(b);
            Session.Abandon();
            return RedirectToAction("Index", "Home");

        }

    }
}
