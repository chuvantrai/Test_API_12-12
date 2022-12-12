using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;
using System;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class YeuCauController : AbstractController
    {
        Bds_CShapContext context;
        public YeuCauController()
        {
            context = new Bds_CShapContext();
        }
        public IActionResult Index()
        {
            return View("/");
        }
        public IActionResult GuiYeuCau(string content)
        {
            User ucheck = CheckRoleSession(new int[] { 1 }, true);// true: and, false: or

            string jsonStr = HttpContext.Session.GetString("useraccount");
            User user;
            if (jsonStr is null) user = new User();
            else user = JsonConvert.DeserializeObject<User>(jsonStr);
            UserRequest r = new UserRequest() {UseId=user.UserId, Content=content,DateRequest=DateTime.Now,Status=true };
            context.UserRequests.Add(r);
            context.SaveChanges();
            string gender = "Nữ";
            if(user.Gender == true){ gender = "Nam"; }
            string ndEmail = "<span style='color: #3266A4;'>Khách hàng:  </span>" + user.FullName
                + " | <span style='color: #4B9AF6;'>Ngày sinh: </span>" + user.Dob.Day+"/"+ user.Dob.Month + "/" + user.Dob.Year 
                + " | <span style='color: #BACCE0;'>Giới tính:  </span>" + gender 
                + "<br><span style='color: #C34B4D;'>Sđt:  </span>" + user.Phone 
                + " | <span style='color: #D78788;'>Email Khách hàng:  </span>" + user.Email
                + "<br> <span style='color: #87D788;'>Nội dung yêu cầu:  </span>" + content ;
            Task<string> te = Logic.SendGmail
               .SendMailGoogleSmtp("traicvhe153014@fpt.edu.vn", "traicvhe153014@fpt.edu.vn", "Yêu cầu tư vấn từ khách hàng "+user.FullName, 
               ndEmail, "traicvhe153014@fpt.edu.vn", "0362351671");
            string thongbao = "1";
            return Redirect("/trangchu?tb="+thongbao);
        }
    }
}
