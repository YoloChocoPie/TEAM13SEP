using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAM13SEP.Models;

namespace TEAM13SEP.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        SEPEntities model = new SEPEntities();
        // GET: Admin/Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = model.ADMINs.FirstOrDefault(u => u.EMAIL.Equals(email));
            if (user != null)
            {
                if (user.PASSWORD.Equals(password))
                {
                    Session["user-fullname"] = user.FULL_NAME;
                    Session["user-id"] = user.ID;
                    Session["user-role"] = user.ROLE;
                    return RedirectToAction("Index", "ChuDe");

                }
                else
                {
                    Session["password-incorrect"] = true;
                    return View();
                }
            }
            Session["user-not-found"] = true;
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ADMIN c)
        {
            if (ModelState.IsValid)
            {
                var account = new ADMIN();
                account.EMAIL = c.EMAIL;
                account.PASSWORD = c.PASSWORD;
                account.FULL_NAME = c.FULL_NAME;

                account.ROLE = c.ROLE;

                model.ADMINs.Add(account);
                model.SaveChanges();

                Session["Success"] = true;
                return RedirectToAction("Login");
            }
            return View();

        }
        public ActionResult Logout()
        {
            Session["user-fullname"] = null;
            Session["user-id"] = null;
            return RedirectToAction("Login");
        }
    }
}