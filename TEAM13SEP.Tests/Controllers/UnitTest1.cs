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
            var controller = new ChuDeController();
            
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as List<CHUDE> ;
            Assert.IsNotNull(model);

            var db = new SEPEntities();
            Assert.AreEqual(db.CHUDEs.Count(), model.Count);
        }
        [TestMethod]
        public void TestCreate()
        {
            var controller = new ChuDeController();

            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void TestEdit()
        {
            var db = new SEPEntities();
            var controller = new ChuDeController();

            var ChuDe = db.CHUDEs.First();
            var result = controller.Edit(ChuDe.ID) as ViewResult;

            var Models = result.Model as CHUDE;
            Assert.IsNotNull(result);
            Assert.AreEqual(ChuDe.CHUDE_NAME, Models.CHUDE_NAME);
            
        }
        [TestMethod]
        public void TestDelete()
        {
            var db = new SEPEntities();
            var controller = new ChuDeController();

            var ChuDe = db.CHUDEs.First();
            var result = controller.Delete(ChuDe.ID) as ViewResult;

            var Models = result.Model as CHUDE;
            Assert.IsNotNull(result);
            Assert.AreEqual(ChuDe.CHUDE_NAME, Models.CHUDE_NAME);
            Assert.AreEqual(ChuDe.CHUDE_CODE, Models.CHUDE_CODE);
        }

    }
}
