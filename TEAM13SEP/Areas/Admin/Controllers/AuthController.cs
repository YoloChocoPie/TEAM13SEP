﻿using System;
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
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = model.ADMINs.FirstOrDefault(u => u.EMAIL.Equals(email));
            if (user != null)
            {
                if (user.PASSWORD.Equals(password))
                {
                    Session["user-fullname"] = user.FULL_NAME;
                    Session["user-id"] = user.ID;
                    Session["user-role"] = user.ROLE;
                    return RedirectToAction("Index", "ChuDe");

                }
                else
                {
                    Session["password-incorrect"] = true;
                    return View();
                }
            }
            Session["user-not-found"] = true;
            return View();
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


              // cách đăng nhập mới. Ở đây, những thông tin cần nhập nằm bên view. Còn bên controller add những gì dev muốn

                // email not verified on registration time    
                c.EmailConfirm = false;

            // code kiểm tra xem liệu email đã được sử dụng hay chưa?

            var check = IsEmailExists(c.EMAIL);
            if (check)
            {
                ModelState.AddModelError("EmailExists", "Email đã tồn tại");
                return View("Create");
            }

                
                //it generate unique code       
                c.ActivetionCode = Guid.NewGuid();

                model.ADMINs.Add(c);
                model.SaveChanges();

                SendEmailToUser(c.EMAIL, c.ActivetionCode.ToString());
                var Message = "Đăng kí thành công, check ib pls" + c.EMAIL;
                ViewBag.Message = Message;


            return View("Login");
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


            Message.Subject = "Registration Completed-Demo";
            Message.Body = "<br/> Your registration completed succesfully." +
                           "<br/> please click on the below link for account verification" +
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
                ViewBag.Message = "Email Verification completed";
                Status = true;
            }
            else
            {
                ViewBag.Message = "Invalid Request...Email not verify";
                ViewBag.Status = false;
            }

            return View();
        }
        #endregion
    }
}