using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TEAM13SEP.Areas.User.Controllers;

using TEAM13SEP.Models;
using TEAM13SEP;

namespace TEAM13SEP.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreate()
        {
            var controller = new GopYController();

            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);

        }
    }
}
