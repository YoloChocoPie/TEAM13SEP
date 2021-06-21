
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAM13SEP.Models;

namespace TEAM13SEP.Areas.User.Controllers
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
            var user = model.SINHVIENs.FirstOrDefault(u => u.EMAIL.Equals(email));
            if (user != null)
            {
                if (user.PASSWORD.Equals(password))
                {
                    Session["user-fullname1"] = user.HOTEN_SV;
                    Session["user-id1"] = user.MSSV;


                    return RedirectToAction("Index", "GopY");

                }
                else
                {
                    Session["password-incorrect1"] = true;
                    return View();
                }
            }
            Session["user-not-found1"] = true;
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SINHVIEN c)
        {
            if (ModelState.IsValid)
            {
                var account = new SINHVIEN();
                account.MSSV = c.MSSV;
                account.EMAIL = c.EMAIL;
                account.PASSWORD = c.PASSWORD;
                account.HOTEN_SV = c.HOTEN_SV;



                model.SINHVIENs.Add(account);
                model.SaveChanges();

                Session["Success"] = true;
                return RedirectToAction("Login");
            }
            return View();

        }
        public ActionResult Logout()
        {
            Session["user-fullname1"] = null;
            Session["user-id1"] = null;
            return RedirectToAction("Login");
        }
    }
}