using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAM13SEP.Models;
using TEAM13SEP.Areas.Admin.Middleware;

namespace TEAM13SEP.Areas.Admin.Controllers
{
    [LoginVerification]
    public class AccountController : Controller
    {
        SEPEntities model = new SEPEntities();
        // GET: Admin/Account
        public ActionResult Index()
        {
            var account = model.ADMINs.OrderByDescending(x => x.ID).ToList();

            return View(account);
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
                
             

                model.ADMINs.Add(account);
                model.SaveChanges();

                Session["Success"] = true;
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var account = model.ADMINs.FirstOrDefault(x => x.ID == id);
            return View(account);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ADMIN c)
        {
            if (ModelState.IsValid)
            {
                var account = model.ADMINs.FirstOrDefault(x => x.ID == id);
                account.EMAIL = c.EMAIL;
                account.PASSWORD = c.PASSWORD;
                account.FULL_NAME = c.FULL_NAME;
                
                account.ROLE = c.ROLE;
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var account = model.ADMINs.FirstOrDefault(x => x.ID == id);
            return View(account);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ComfirmDelete(int id)
        {
            var account = model.ADMINs.FirstOrDefault(x => x.ID == id);
            model.ADMINs.Remove(account);
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Products/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {

            var account = model.ADMINs.FirstOrDefault(x => x.ID == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(account);

        }
    }
}