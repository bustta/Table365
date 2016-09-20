using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Table365.Core.Models.POCO;
using Table365.Core.Models.Service;
using Table365.Core.Models.ViewModel;
using Table365.Site.Models;

namespace Table365.Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModels model)
        {
            User user;
            try
            {
                user = new UserService().VerifyUser(model.Email, model.Password);
                
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }

            Session.RemoveAll();
            var ticket = new FormsAuthenticationTicket(1,
              model.Email,//你想要存放在 User.Identy.Name 的值，通常是使用者帳號
              DateTime.Now,
              DateTime.Now.AddMinutes(30),
              false,//將管理者登入的 Cookie 設定成 Session Cookie
              user.Name,//userdata看你想存放啥
              FormsAuthentication.FormsCookiePath);

            string encTicket = FormsAuthentication.Encrypt(ticket);
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserViewModels userViewModel)
        {
            return View();
        }

        public ActionResult LoginOrRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginOrRegister(LoginRegisterCombineViewModels model)
        {
            return View();
        }

    }
}