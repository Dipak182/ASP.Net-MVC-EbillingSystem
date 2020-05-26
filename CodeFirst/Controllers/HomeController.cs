using CodeFirst.Models.Admin;
using CodeFirst.Repository;
using CodeFirst.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(UserLogin login)
        {
            IAdminRepositoryService _adminRepositoryService = new AdminRepositoryService();
            UsersInfo info = _adminRepositoryService.UserAuthentication(login);
            if (info != null)
            {
                UsersRole role = _adminRepositoryService.GetRoleByRoleId(Convert.ToInt32(info.RoleId));
                if (role.RoleName.Equals("SuperUser") || role.RoleName.Equals("Admin"))
                {
                    Session["RoleName"] = role.RoleName;
                    Session["RoleId"] = info.UserId;

                    CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                    serializeModel.UserId = info.UserId;
                    serializeModel.UserName = info.UserName;
                    serializeModel.roles = new string[] { role.RoleName };

                    string userData = JsonConvert.SerializeObject(serializeModel);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                             1,
                            info.UserName,
                             DateTime.Now,
                             DateTime.Now.AddMinutes(5),
                             false,
                             userData);

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);

                    return RedirectToAction("Index", "Admin");
                }
            }
            return View();
        }

        public ActionResult Products()
        {
            IAdminRepositoryService _adminRepositoryService = new AdminRepositoryService();
            List<Product> Products = _adminRepositoryService.GetAllProducts();

            return View(Products);
        }

    }
}
