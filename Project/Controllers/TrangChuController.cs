using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class TrangChuController : Controller
    {
        Bds_CShapContext context;
        public TrangChuController()
        {
            context = new Bds_CShapContext();
        }
        public IActionResult Index(string tb)
        {
            // lay Acc user
            string jsonStr = HttpContext.Session.GetString("useraccount");
            User user;
            if (jsonStr is null) { user = new User(); }
            else { user = JsonConvert.DeserializeObject<User>(jsonStr); ViewBag.User = user; }

            if (tb!=null&&tb.Equals("1")) { ViewBag.thongbao = "Đã gửi yêu cầu thành công!"; }
            List<News> listnews = context.News.OrderByDescending(x=>x.DateUp).Skip(0).Take(3).ToList();
            ViewBag.listnews= listnews;

            List<Product> listcanho = context.Products.OrderByDescending(x=>x.ProductId)
                .Where(x=>x.Category.CategoryName.Equals("Căn hộ")).Skip(0).Take(3).ToList();
            ViewBag.listcanho = listcanho;
            List<Product> listdatnen = context.Products.OrderByDescending(x => x.ProductId)
                .Where(x => x.Category.CategoryName.Equals("Đất nền")).Skip(0).Take(3).ToList();
            ViewBag.listdatnen = listdatnen;
            List<Product> listnhapho = context.Products.OrderByDescending(x => x.ProductId)
                .Where(x => x.Category.CategoryName.Equals("Nhà Phố")).Skip(0).Take(3).ToList();
            ViewBag.listnhapho = listnhapho;
            List<Product> listbietthu = context.Products.OrderByDescending(x => x.ProductId)
                .Where(x => x.Category.CategoryName.Equals("Biệt Thự")).Skip(0).Take(3).ToList();
            ViewBag.listbietthu = listbietthu;
            ViewBag.listregi = context.Regionals.ToList();
            return View("/Views/User/Home.cshtml");
        }
    }
}
