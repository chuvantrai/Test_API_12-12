using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class NguoiDungController : AbstractController
    {
        Bds_CShapContext context;
        public NguoiDungController()
        {
            context = new Bds_CShapContext();
        }
        public IActionResult Index()
        {
            return View("/");
        }
        public IActionResult Eror(){
            return View("/Views/404.cshtml");
        }
        public IActionResult DangNhap()
        {
            return View("/Views/User/Login.cshtml");
        }
        public IActionResult DoDangNhap(string email, string password, bool remember)
        {
            User user = context.Users.FirstOrDefault(x=>x.Email.Equals(email)&&x.Password.Equals(Logic.coding.Encode(password)));
            
            if (user != null)
            {
                if (remember == true)// luu cookie account
                {
                    CookieOptions cookieOptions = new CookieOptions();
                    cookieOptions.Expires = DateTimeOffset.Now.AddSeconds(60*60*24*7);// 1tuan
                    Response.Cookies.Append("email", user.Email, cookieOptions);
                    Response.Cookies.Append("password", user.Password, cookieOptions);
                }
                string jsonStr = JsonConvert.SerializeObject(user);
                HttpContext.Session.SetString("useraccount", jsonStr);
                ViewBag.User = user;
                return Redirect("/trangchu/index");
            }
            else
            {
                string thongbao = "Email hoặc mật khẩu không đúng";
                ViewBag.Thongbao = thongbao;
                return View("/Views/User/Login.cshtml");
            }
        }
        public IActionResult DangXuat()
        {
            User ucheck = CheckRoleSession(new int[] { 1,2 }, false);// true: and, false: or

            HttpContext.Session.Remove("useraccount");
            return Redirect("/trangchu/index");
        }
        public IActionResult CheckMail(string mail)
        {
            List<User> u = context.Users.Where(x => x.Email.Equals(mail)).ToList();
            if(u.Count != 0)
            {
                ViewBag.thongbao2 = "Email đã đăng ký!";
                return View("/Views/User/CheckMail.cshtml");
            }
            ViewBag.thongbao = "Hãy xác nhận trong Mail của bạn!";
            string codeMail = Logic.coding.Encode(mail);
            string ndEmail =
                @"Bấm xác nhận để đăng ký tài khoản: <a href='http://localhost:64224/nguoidung/dangkythongtin?mail=" + codeMail + "' style='color: green;'>Xác Nhận</a>";

            Task<string> te = Logic.SendGmail
               .SendMailGoogleSmtp("traicvhe153014@fpt.edu.vn", mail, "Xác nhận đăng ký", ndEmail, "traicvhe153014@fpt.edu.vn", "0362351671");
            
            return View("/Views/User/CheckMail.cshtml");
        }
        public IActionResult DangKy()
        {
            return View("/Views/User/CheckMail.cshtml");
        }
        public IActionResult Dangkythongtin(string mail)
        {
            ViewBag.email = Logic.coding.Decode(mail);
            return View("/Views/User/Registration.cshtml");
        }
        public IActionResult DoDangKy(string fullname, string email,string password,string re_password, string mobile, DateTime date,bool gender)
        {
            if (context.Users.Where(x=>x.Email.Equals(email)).Count()>0)
            {
                ViewBag.email = email;
                ViewBag.thongbao = "Email đã đăng ký!";
                return View("/Views/User/Registration.cshtml");
            }
            if (!password.Equals(re_password)) { 
                ViewBag.email = email;
                ViewBag.thongbao = "Mật khẩu không khớp";
                return View("/Views/User/Registration.cshtml"); 
            }
            User user = new User { FullName = fullname, Email=email, Password= Logic.coding.Encode(password), Phone=mobile,Dob = date,Gender=gender,RoleId= 2};
            context.Users.Add(user);
            context.SaveChanges();
            ViewBag.Thongbao = "Đăng ký thành công";
            return View("/Views/User/Login.cshtml");
        }
        public IActionResult Laylaimatkhau(string mail)
        {
            return View("/Views/User/ResetPassword.cshtml");
        }
        public IActionResult Randommatkhau(string mail)
        {
            if (context.Users.Where(x=>x.Email.Equals(mail)).Count()==0) {
                ViewBag.thongbao = "Email sai!";
                return View("/Views/User/ResetPassword.cshtml");
            }
            Random rnd = new Random();
            int ran = rnd.Next(111111, 999999);// Random từ 111111 đến 999999
            ViewBag.thongbao = "Đã gửi mật khẩu mới đến email của bạn!";
            string ndEmail =
                @"Mật khẩu mới của bạn là: <br>"+ran.ToString();

            Task<string> te = Logic.SendGmail
               .SendMailGoogleSmtp("traicvhe153014@fpt.edu.vn", mail, "Lấy lại mật khẩu", ndEmail, "traicvhe153014@fpt.edu.vn", "0362351671");
            User user = context.Users.FirstOrDefault(x=>x.Email.Equals(mail));
            user.Password = Logic.coding.Encode(ran.ToString());
            context.Users.Update(user);
            context.SaveChanges();

            return View("/Views/User/Login.cshtml");
        }

        public IActionResult Doimatkhau()
        {
            User ucheck = CheckRoleSession(new int[] { 1, 2 }, false);// true: and, false: or

            return View("/Views/User/ChangePassword.cshtml");
        }
        public IActionResult Dodoimatkhau(string oldpassword,string newpassword1,string newpassword2)
        {
            User ucheck = CheckRoleSession(new int[] { 1, 2 }, false);// true: and, false: or

            string jsonStr = HttpContext.Session.GetString("useraccount");
            User user;
            if (jsonStr is null) user = new User();
            else user = JsonConvert.DeserializeObject<User>(jsonStr);
            if (!user.Password.Equals(Logic.coding.Encode(oldpassword)))
            {
                ViewBag.thongbao = "Mật khẩu cũ không đúng";
                return View("/Views/User/ChangePassword.cshtml");
            }
            if (!newpassword1.Equals(newpassword2))
            {
                ViewBag.thongbao = "Mật khẩu mới không khớp";
                return View("/Views/User/ChangePassword.cshtml");
            }
            if (user.Password.Equals(Logic.coding.Encode(oldpassword)))
            {
                user.Password = Logic.coding.Encode(newpassword1);
                context.Users.Update(user);
                context.SaveChanges();
                HttpContext.Session.Remove("useraccount");
                ViewBag.thongbao = "Đổi mật khẩu thành công";
                
            }
            return View("/Views/User/Login.cshtml");
        }
        public IActionResult Thongtincanhan()
        {
            User ucheck = CheckRoleSession(new int[] { 1, 2 }, false);// true: and, false: or

            return View("/Views/User/Profile.cshtml");
        }
        [HttpPost]
        public IActionResult DoThongtincanhan(IFormFile myfile,string fullname, string phone,DateTime dob,bool gender)
        {
            User ucheck = CheckRoleSession(new int[] { 1, 2 }, false);// true: and, false: or

            string jsonStr = HttpContext.Session.GetString("useraccount");
            User user = null;
            if (jsonStr != null) user = JsonConvert.DeserializeObject<User>(jsonStr);

            string _FileName = Logic.ExtensionFile.AddandUploadImgae(myfile,user);// add image

            if (_FileName != null)
            {
                // lưu name file vao database
                user.ImgAvar = _FileName;
            }
                user.FullName = fullname; user.Phone = phone; user.Dob = dob; user.Gender = gender;
                context.Users.Update(user);
                context.SaveChanges();

                // set session mới
                string jsonStr2 = JsonConvert.SerializeObject(user);
                HttpContext.Session.SetString("useraccount", jsonStr2);
            
            ViewBag.thongbao = "Cập nhật thông tin thành công!";
            return View("/Views/User/Profile.cshtml");
        }
        
    }
}
