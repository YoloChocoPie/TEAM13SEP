
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
    public class GopYController : Controller
    {
        // GET: Admin/GopY
        SEPEntities model = new SEPEntities();
        public ActionResult Index()
        {
            var gopy = model.GOPies.OrderByDescending(x => x.ID).ToList();
            return View(gopy);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.chude_id = model.CHUDEs.OrderByDescending(x => x.ID).ToList();
            ViewBag.status_id = model.TRANGTHAIs.OrderByDescending(x => x.ID).ToList();


            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GOPY_CODE,GOPY_TEN,CHUDE_ID,ADMIN_ID,nutLIKE,SINHVIEN_ID,NOIDUNG_GOPY,TRALOI_GOPY,GOPY_STATUS,DATE")]
                        GOPY gopy)
        {
            if (ModelState.IsValid)
            {
                var gopy1 = new GOPY();
                gopy1.GOPY_CODE = gopy.GOPY_CODE;
                gopy1.GOPY_TEN = gopy.GOPY_TEN;
                gopy1.CHUDE_ID = gopy.CHUDE_ID;
                gopy1.ADMIN_ID = gopy.ADMIN_ID;
                gopy1.nutLIKE = gopy.nutLIKE;
                gopy1.SINHVIEN_ID = gopy.SINHVIEN_ID;
                gopy1.NOIDUNG_GOPY = gopy.NOIDUNG_GOPY;
                gopy1.TRALOI_GOPY = gopy.TRALOI_GOPY;
                gopy1.GOPY_STATUS = gopy.GOPY_STATUS;
                gopy1.DATE = DateTime.Now;


                model.GOPies.Add(gopy1);
                model.SaveChanges();

                Session["Success"] = true;
                return RedirectToAction("Index");
            }
            ViewBag.chude_id = model.CHUDEs.OrderByDescending(x => x.ID).ToList();
            ViewBag.status_id = model.TRANGTHAIs.OrderByDescending(x => x.ID).ToList();
            return View();



        }

        [HttpGet]
        public ActionResult Edit(int id)
        {




            GOPY gopy = model.GOPies.Find(id);
            if (gopy == null)
            {
                return HttpNotFound();
            }
            ViewBag.chude_id = model.CHUDEs.OrderByDescending(x => x.ID).ToList();
            ViewBag.admin_id = model.ADMINs.OrderByDescending(x => x.ID).ToList();
            ViewBag.status_id = model.TRANGTHAIs.OrderByDescending(x => x.ID).ToList();
            return View(gopy);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
                        GOPY gopy, int id)
        {
            if (ModelState.IsValid)
            {
                var gopy1 = model.GOPies.FirstOrDefault(x => x.ID == id);

                gopy1.GOPY_TEN = gopy.GOPY_TEN;
                gopy1.CHUDE_ID = gopy.CHUDE_ID;
                gopy1.ADMIN_ID = gopy.ADMIN_ID;
                gopy1.nutLIKE = gopy.nutLIKE;
                gopy1.SINHVIEN_ID = gopy.SINHVIEN_ID;
                gopy1.NOIDUNG_GOPY = gopy.NOIDUNG_GOPY;
                gopy1.TRALOI_GOPY = gopy.TRALOI_GOPY;
                gopy1.GOPY_STATUS = gopy.GOPY_STATUS;
                gopy1.DATE = gopy.DATE;

                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var gopy = model.GOPies.FirstOrDefault(x => x.ID == id);
            return View(gopy);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ComfirmDelete(int id)
        {
            var gopy = model.GOPies.FirstOrDefault(x => x.ID == id);
            model.GOPies.Remove(gopy);
            model.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}