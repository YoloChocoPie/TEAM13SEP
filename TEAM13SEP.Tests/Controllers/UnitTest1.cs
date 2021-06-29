using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TEAM13SEP.Areas.Admin.Controllers; // khai báo vì dùng bên area Admin
using TEAM13SEP.Controllers;
using TEAM13SEP.Models; // khai báo model 
using TEAM13SEP;

namespace TEAM13SEP.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIndex() // test hiển thị giao diện
        {
            var controller = new GopYController(); // Khai báo một biến có tên controller, cho nó truy cập vào controller 
                                                   // trong admin. Truy cập vào class GopYController.cs



            var result = controller.Index() as ViewResult; // ở đây, tạo 1 biến để cho kết nối được với ActionResult, cụ thể là Index
            Assert.IsNotNull(result); // kiểm tra xem, yêu cầu thoả phần test là phải hiển thị hết, không được null

            var model = result.Model as List<GOPY>; // kết nối với database
            Assert.IsNotNull(model); // kiểm tra xem trong table GopY, mình có đang null không
                                     // nghĩa là sao? Nghĩa là test sẽ sai, nếu mình ko có dữ liệu trong table GopY

            var db = new SEPEntities(); // giả lập, tạo một môi trường ảo để hệ thống làm việc
            Assert.AreEqual(db.GOPies.Count(), model.Count); // nó sẽ kiểm tra số lượng phần tử hiển thị ở môi trường ảo
                                                             // và so sánh với số lượng thực tế. Nếu fake = real => code đúng => test ok
                                                             // này, đây là lỗi ngày hôm qua. Mình đã biết cách khắc phục là
        }
        [TestMethod]
        public void TestEdit()
        {
            var db = new SEPEntities(); // khai báo database
            var controller = new GopYController(); // khai báo controller

            var GopY = db.GOPies.First(); // lấy 1 một góp ý đầu tiên hiện có trong database, và 
                                            // hệ thống sẽ giả lập môi trường ảo, thay đổi thuộc tính đó
            var result = controller.Edit(GopY.ID) as ViewResult; //Khai báo ActionResult Edit trong controller

            var Models = result.Model as GOPY; // giả lập môi trường
            Assert.IsNotNull(result); // kiểm tra là dữ liệu của mình có null không. Nếu null thì lấy j mà test => sai
            Assert.AreEqual(GopY.TRANGTHAI.TRANGTHAI1, Models.TRANGTHAI.TRANGTHAI1);// Ở ĐÂY, SẼ SO SÁNH 2 MÔI TRƯỜNG
                                                                // REAL VÀ FAKE. NẾU FAKE = REAL
                                                                // THÌ CHỨC NĂNG ĐÚNG
                                                                // CỤ THỂ LÀ THAY ĐỔI THUỘC TÍNH CỦA GÓP Ý Ở 2 MÔI TRƯỜNG

        }
    }
}
