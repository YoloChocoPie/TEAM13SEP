
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAM13SEP.Areas.User.Middleware;
using TEAM13SEP.Models;

namespace TEAM13SEP.Areas.User.Controllers
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
        public ActionResult Index2()
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



        public ActionResult Like(int id)
        {
            // cách này ổn, tuy nhiên vấn đề gặp phải là : Ai cũng like dc, ko coi được người like, like nhiều lần => đây là một tính năng :bonk:

            GOPY update = model.GOPies.ToList().Find(u => u.ID == id);
            update.nutLIKE += 1;
            model.SaveChanges();
            return RedirectToAction("Index");


            // cách dưới làm sml vẫn ko ra


            /* var postIDforLike = model.GOPies.Find(id);// add logic to get the id of the post to increment the likes
             using (var _gopy = new SEPEntities())
             {

                 var addLikeSql = "update GOPY set nutLike = nutLike + 1 where ID = @id";
                 var paramID = new SqlParameter("id", postIDforLike);
                 _gopy.Database.ExecuteSqlCommand(addLikeSql, postIDforLike);
             }
             return RedirectToAction("Index");*/
        }
        public ActionResult Like1(int id)
        {
            // cách này ổn, tuy nhiên vấn đề gặp phải là : Ai cũng like dc, ko coi được người like, like nhiều lần => đây là một tính năng :bonk:
            // này là like khi đã dc trả lời

            GOPY update = model.GOPies.ToList().Find(u => u.ID == id);
            update.nutLIKE += 1;
            model.SaveChanges();
            Session["like"] = true;
            return RedirectToAction("Index2");


            
        }


        // dưới này là controller cho cách like mới

    }
}