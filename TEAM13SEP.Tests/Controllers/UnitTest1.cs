using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TEAM13SEP.Areas.User.Controllers;
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
        public void TestIndex2()
        {
            var controller = new GopYController();

            var result = controller.Index2() as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as List<GOPY>;
            Assert.IsNotNull(model);

            var db = new SEPEntities();
            Assert.AreEqual(db.GOPies.Count(), model.Count);
        }
        [TestMethod]
        public void TestCreate()
        {
            var controller = new GopYController();



            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);



        }
    }
}
