using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using TEAM13SEP.Models;

namespace TEAM13SEP.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        SEPEntities model = new SEPEntities();

        // GET: Admin/Auth
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password, ADMIN c)
        {
            var user = model.ADMINs.FirstOrDefault(u => u.EMAIL.Equals(email));

            bool Isvalid = model.ADMINs.Any(x => x.EMAIL == c.EMAIL && x.EmailConfirm == true &&
 x.PASSWORD == password);
            if (Isvalid)
            {

                Session["user-fullname"] = user.FULL_NAME;
                Session["user-id"] = user.ID;
                Session["user-role"] = user.ROLE;
                return RedirectToAction("Index2", "GopY");

            }
            else
            {
               
                ModelState.AddModelError("TN", "Email chưa được kích hoạt hoặc sai email/mật khẩu");
                return View();
            }


            
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ADMIN c)
        {

            if (ModelState.IsValid)
            {
                c.EmailConfirm = false;

                var check = IsEmailExists(c.EMAIL);
                if (check)
                {
                    ModelState.AddModelError("EmailExists", "Email đã tồn tại");
                    return View("Create");
                }
                c.ActivetionCode = Guid.NewGuid();



                model.ADMINs.Add(c);
                model.SaveChanges();

                SendEmailToUser(c.EMAIL, c.ActivetionCode.ToString());
                var Message = "Đăng kí thành công, check ib pls" + c.EMAIL;
                ViewBag.Message = Message;


                return View("Login");
            }
            else
            {
                ModelState.AddModelError("bug1", "Vui lòng kiểm tra lại trường thông tin");
       

                return View();
            }






            // cách đăng nhập mới. Ở đây, những thông tin cần nhập nằm bên view. Còn bên controller add những gì dev muốn

            // email not verified on registration time    
            

            // code kiểm tra xem liệu email đã được sử dụng hay chưa?

         
            // code kiểm tra xem liệu mssv đã được sử dụng hay chưa?
         


            //it generate unique code       
          
        }

        public bool IsEmailExists(string eMail)
        {
            var IsCheck = model.ADMINs.Where(email => email.EMAIL == eMail).FirstOrDefault();
            return IsCheck != null;
        }
      



        public ActionResult Logout()
        {
            Session["user-fullname"] = null;
            Session["user-id"] = null;
            Session["user-not-found"] = null;
            Session["password-incorrect"] = null;
            return RedirectToAction("Login");
        }


        public void SendEmailToUser(string emailId, string activationCode)
        {
            var GenarateUserVerificationLink = "/Admin/Auth/UserVerification/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, GenarateUserVerificationLink);

            var fromMail = new MailAddress("htgyteam13@gmail.com", "TEAM13"); // set your email    
            var fromEmailpassword = "vanlanguni"; // Set your password     
            var toEmail = new MailAddress(emailId);

            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword);

            var Message = new MailMessage(fromMail, toEmail);


            Message.Subject = " Hãy xác thực Email ";
            Message.Body = "<br/> Xin chào." +
                           "<br/> Hiện tại bạn đã đăng kí thành công ở Website Hộp thư góp ý dành cho sinh viên khoa CNTT của TEAM13." +
                           "<br/> Trạng thái tài khoản hiện tại là <b>Chưa kích hoạt</b>. " +
                           "<br/> Vui lòng nhấn vào đường link sau để xác thực tài khoản" +
                           "<br/><br/><a href=" + link + ">" + link + "</a>";
            Message.IsBodyHtml = true;
            smtp.Send(Message);
        }

        #region Verification from Email Account.    
        public ActionResult UserVerification(string id)
        {
            bool Status = false;

            model.Configuration.ValidateOnSaveEnabled = false; // Ignor to password confirmation     
            var IsVerify = model.ADMINs.Where(u => u.ActivetionCode == new Guid(id)).FirstOrDefault();

            if (IsVerify != null)
            {
                IsVerify.EmailConfirm = true;
                model.SaveChanges();
                ViewBag.Message = "Xác thực email thành công";
                Status = true;
            }
            else
            {
                ViewBag.Message = "Email xác thực không thành công";
                ViewBag.Status = false;
            }

            return View();
        }
        #endregion
    }
}