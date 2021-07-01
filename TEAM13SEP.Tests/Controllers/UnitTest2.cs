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
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestEdit()
        {
            var db = new SEPEntities();
            var controller = new GopYController();


            var GopY = db.GOPies.First();
            var result = controller.Edit(GopY.ID) as ViewResult;

            var Models = result.Model as GOPY;
            Assert.IsNotNull(result);
            Assert.AreEqual(GopY.TRANGTHAI.TRANGTHAI1, Models.TRANGTHAI.TRANGTHAI1);


        }
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
    }
}
