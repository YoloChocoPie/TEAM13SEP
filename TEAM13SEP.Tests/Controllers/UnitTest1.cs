using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TEAM13SEP.Areas.Admin.Controllers;
using TEAM13SEP.Controllers;
using TEAM13SEP.Models;
using TEAM13SEP;



namespace TEAM13SEP.Tests.Controllers
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIndex()
        {
            var controller = new GopYController();



            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);



            var model = result.Model as List<GOPY>;
            Assert.IsNotNull(model);



            var db = new SEPEntities();
            Assert.AreEqual(db.GOPies.Count(), model.Count);
        }

        [TestMethod]
        public void TestEdit()
        {
            var db = new SEPEntities(); // khai báo database
            var controller = new GopYController(); // khai báo controller


            var GopY = db.GOPies.First(); // lấy 1 một góp ý đầu tiên hiện có trong database, và 
                                          // hệ thống sẽ giả lập môi trường ảo, thay đổi thuộc tính đó
            var result = controller.Edit(GopY.ID) as ViewResult; //Khai báo ActionResult Edit trong controller


            var Models = result.Model as GOPY;
            Assert.IsNotNull(result);
            Assert.AreEqual(GopY.TRALOI_GOPY, Models.TRALOI_GOPY);
        }
    }
}