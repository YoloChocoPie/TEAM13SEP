using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAM13SEP.Models;

namespace TEAM13SEP.Areas.Admin.Controllers
{
    public class ChuDeController : Controller
    {
        SEPEntities model = new SEPEntities();
        // GET: Admin/ChuDe
        public ActionResult Index()
        {
            var chude = model.CHUDEs.OrderByDescending(x => x.ID).ToList();
            return View(chude);
        }
    }
}