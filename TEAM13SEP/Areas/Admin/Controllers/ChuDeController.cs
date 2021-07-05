using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAM13SEP.Areas.Admin.Middleware;
using TEAM13SEP.Models;

namespace TEAM13SEP.Areas.Admin.Controllers
{
    [LoginVerification]
    public class ChuDeController : Controller
    {


        SEPEntities model = new SEPEntities();
        // GET: Admin/ChuDe
        public ActionResult Index()
        {
            var chude = model.CHUDEs.OrderByDescending(x => x.ID).ToList();
            return View(chude);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var chude = model.CHUDEs.OrderByDescending(x => x.ID).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CHUDE_CODE,CHUDE_NAME")]
                        CHUDE chude)
        {
            if (ModelState.IsValid)
            {
                var chude1 = new CHUDE();
                chude1.CHUDE_CODE = chude.CHUDE_CODE;
                chude1.CHUDE_NAME = chude.CHUDE_NAME;


                model.CHUDEs.Add(chude1);
                model.SaveChanges();

                Session["Success"] = true;
                return RedirectToAction("Index");
            }
            return View();



        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var chude = model.CHUDEs.FirstOrDefault(x => x.ID == id);
            return View(chude);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CHUDE c)
        {
            if (ModelState.IsValid)
            {
                var chude = model.CHUDEs.FirstOrDefault(x => x.ID == id);
                chude.CHUDE_CODE = c.CHUDE_CODE;
                chude.CHUDE_NAME = c.CHUDE_NAME;

                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var chude = model.CHUDEs.FirstOrDefault(x => x.ID == id);
            return View(chude);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ComfirmDelete(int id)
        {
            
            if (ModelState.IsValid)
            {
                var chude = model.CHUDEs.FirstOrDefault(x => x.ID == id);
                model.CHUDEs.Remove(chude);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("bug1", "CHỦ ĐỀ NÀY ĐANG NẰM TRONG CÁC GÓP Ý. VUI LÒNG THAY ĐỔI TRƯỚC KHI XOÁ");


                return View();
            }
        }
    }
}