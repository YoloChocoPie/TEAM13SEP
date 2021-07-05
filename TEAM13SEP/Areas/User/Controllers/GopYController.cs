
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
        public ActionResult Index3()
        {
            var gopy = model.GOPies.OrderByDescending(x => x.ID).ToList();
            return View(gopy);
        }
        public ActionResult Index4()
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
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GOPY_CODE,GOPY_TEN,CHUDE_ID,ADMIN_ID,nutLIKE,SINHVIEN_ID,NOIDUNG_GOPY,TRALOI_GOPY,GOPY_STATUS,DATE")]
                        GOPY gopy)
        {
            ViewBag.chude_id = model.CHUDEs.OrderByDescending(x => x.ID).ToList();
            ViewBag.status_id = model.TRANGTHAIs.OrderByDescending(x => x.ID).ToList();
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
                if ((int)Session["user-id1"] != gopy1.SINHVIEN_ID)
                {

                    ModelState.AddModelError("bug2", "Mã số sinh viên này không phải của bạn");
                    return View();
                }


                model.GOPies.Add(gopy1);
                model.SaveChanges();

                Session["Success"] = true;

               




                return RedirectToAction("Index");


            }
            else
            {
                ModelState.AddModelError("bug1", "Vui lòng kiểm tra lại trường thông tin");
                return View();
            }

        }
        [HttpGet]
        public ActionResult Create1()
        {
            ViewBag.chude_id = model.CHUDEs.OrderByDescending(x => x.ID).ToList();
            ViewBag.status_id = model.TRANGTHAIs.OrderByDescending(x => x.ID).ToList();
            return View();

        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create1([Bind(Include = "GOPY_CODE,GOPY_TEN,CHUDE_ID,ADMIN_ID,nutLIKE,SINHVIEN_ID,NOIDUNG_GOPY,TRALOI_GOPY,GOPY_STATUS,DATE")]
                        GOPY gopy)
        {
            ViewBag.chude_id = model.CHUDEs.OrderByDescending(x => x.ID).ToList();
            ViewBag.status_id = model.TRANGTHAIs.OrderByDescending(x => x.ID).ToList();
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
            else
            {
                ModelState.AddModelError("bug1", "Vui lòng kiểm tra lại trường thông tin");
                return View();
            }




        }

        public ActionResult Like(int id)
        {
            // cách này ổn, tuy nhiên vấn đề gặp phải là : Ai cũng like dc, ko coi được người like, like nhiều lần => đây là một tính năng :bonk:
            // đã xoá
            // đã xoá và thay đổi code mới ở dưới
            
            // khai báo hàm update và đặt điều kiện
            // nếu thuộc tính dalike = false thì cho phép người dùng like, và ngược lại
            GOPY update = model.GOPies.FirstOrDefault(x => x.ID == id);
            if (update.daLike == false)
            {
                update.nutLIKE += 1;
                update.daLike = true;
                model.SaveChanges();
            
            }








            // add logic to get the id of the post to increment the likes
        

            return RedirectToAction("Index");

        }
        public ActionResult unLike(int id)
        {
            // cách này ổn, tuy nhiên vấn đề gặp phải là : Ai cũng like dc, ko coi được người like, like nhiều lần => đây là một tính năng :bonk:
            // đã xoá
            // đã xoá và thay đổi code mới ở dưới

            // Tương tự như code LIKE tuy nhiên ngược lại câu lệnh điều kiện
            GOPY update = model.GOPies.FirstOrDefault(x => x.ID == id);
            if (update.daLike == true)
            {
                update.nutLIKE -= 1;
                update.daLike = false;
                model.SaveChanges();
              
            }





            return RedirectToAction("Index");


        }
        public ActionResult Like1(int id)
        {
            // cách này ổn, tuy nhiên vấn đề gặp phải là : Ai cũng like dc, ko coi được người like, like nhiều lần => đây là một tính năng :bonk:
            // đã xoá
            // đã xoá và thay đổi code mới ở dưới

            // khai báo hàm update và đặt điều kiện
            // nếu thuộc tính dalike = false thì cho phép người dùng like, và ngược lại
            GOPY update = model.GOPies.FirstOrDefault(x => x.ID == id);
            if (update.daLike == false)
            {
                update.nutLIKE += 1;
                update.daLike = true;
                model.SaveChanges();
          
            }








            // add logic to get the id of the post to increment the likes


            return RedirectToAction("Index2");

        }
        public ActionResult unLike1(int id)
        {
            // cách này ổn, tuy nhiên vấn đề gặp phải là : Ai cũng like dc, ko coi được người like, like nhiều lần => đây là một tính năng :bonk:
            // đã xoá
            // đã xoá và thay đổi code mới ở dưới

            // Tương tự như code LIKE tuy nhiên ngược lại câu lệnh điều kiện
            GOPY update = model.GOPies.FirstOrDefault(x => x.ID == id);
            if (update.daLike == true)
            {
                update.nutLIKE -= 1;
                update.daLike = false;
                model.SaveChanges();
             
            }





            return RedirectToAction("Index2");


        }

        public ActionResult Like3(int id)
        {
            // cách này ổn, tuy nhiên vấn đề gặp phải là : Ai cũng like dc, ko coi được người like, like nhiều lần => đây là một tính năng :bonk:
            // đã xoá
            // đã xoá và thay đổi code mới ở dưới

            // khai báo hàm update và đặt điều kiện
            // nếu thuộc tính dalike = false thì cho phép người dùng like, và ngược lại
            GOPY update = model.GOPies.FirstOrDefault(x => x.ID == id);
            if (update.daLike == false)
            {
                update.nutLIKE += 1;
                update.daLike = true;
                model.SaveChanges();

            }








            // add logic to get the id of the post to increment the likes


            return RedirectToAction("Index3");

        }
        public ActionResult unLike3(int id)
        {
            // cách này ổn, tuy nhiên vấn đề gặp phải là : Ai cũng like dc, ko coi được người like, like nhiều lần => đây là một tính năng :bonk:
            // đã xoá
            // đã xoá và thay đổi code mới ở dưới

            // Tương tự như code LIKE tuy nhiên ngược lại câu lệnh điều kiện
            GOPY update = model.GOPies.FirstOrDefault(x => x.ID == id);
            if (update.daLike == true)
            {
                update.nutLIKE -= 1;
                update.daLike = false;
                model.SaveChanges();

            }





            return RedirectToAction("Index3");


        }

        public ActionResult Like4(int id)
        {
            // cách này ổn, tuy nhiên vấn đề gặp phải là : Ai cũng like dc, ko coi được người like, like nhiều lần => đây là một tính năng :bonk:
            // đã xoá
            // đã xoá và thay đổi code mới ở dưới

            // khai báo hàm update và đặt điều kiện
            // nếu thuộc tính dalike = false thì cho phép người dùng like, và ngược lại
            GOPY update = model.GOPies.FirstOrDefault(x => x.ID == id);
            if (update.daLike == false)
            {
                update.nutLIKE += 1;
                update.daLike = true;
                model.SaveChanges();

            }








            // add logic to get the id of the post to increment the likes


            return RedirectToAction("Index4");

        }
        public ActionResult unLike4(int id)
        {
            // cách này ổn, tuy nhiên vấn đề gặp phải là : Ai cũng like dc, ko coi được người like, like nhiều lần => đây là một tính năng :bonk:
            // đã xoá
            // đã xoá và thay đổi code mới ở dưới

            // Tương tự như code LIKE tuy nhiên ngược lại câu lệnh điều kiện
            GOPY update = model.GOPies.FirstOrDefault(x => x.ID == id);
            if (update.daLike == true)
            {
                update.nutLIKE -= 1;
                update.daLike = false;
                model.SaveChanges();

            }





            return RedirectToAction("Index4");


        }

    }
}