using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System;
using System.Linq;

namespace Project.Controllers
{
    public class TinTucAdminController : AbstractController
    {
        Bds_CShapContext context;
        public TinTucAdminController()
        {
            context = new Bds_CShapContext();
        }
        public IActionResult Index()
        {
            return View("/");
        }
        
        public IActionResult ThemTinTuc(string title,DateTime date,string content, IFormFile img)
        {
            // check role
            User ucheck = CheckRoleSession(new int[] {1} , true);// true: and, false: or

            if (title == null|| string.IsNullOrEmpty(content)) { ViewBag.url = "themtintuc"; return View("/Views/News/NewsDetail.cshtml"); }
            if (date == null) { date = DateTime.Now; }
            News news = new News();
            string imageName = Logic.ExtensionFile.AddnewImgae(img);
            news.Title = title;
            news.DateUp = date;
            news.Content = content;
            news.ImgAvar = imageName;
            context.News.Add(news);
            context.SaveChanges();
            ViewBag.thongbao = "Đã thêm thành công!";
            ViewBag.url = "themtintuc";
            return View("/Views/News/NewsDetail.cshtml");
        }

        public IActionResult ChinhSuaTinTuc(int id, string title, DateTime date, string content, IFormFile img)
        {
            User ucheck = CheckRoleSession(new int[] { 1 }, true);// true: and, false: or

            if (id == 0)
            {
                ViewBag.url = "themtintuc";
                return View("/Views/News/NewsDetail.cshtml");
            }
            else
            {
                News news = context.News.FirstOrDefault(x => x.NewsId == id);
                if (string.IsNullOrEmpty(title))
				{
                    ViewBag.News = news;
                    ViewBag.url = "ChinhSuaTinTuc";
                    return View("/Views/News/NewsDetail.cshtml");
				}
				else
				{
                    ViewBag.url = "ChinhSuaTinTuc";
                    if (img != null)
                    {
                        string imageName = Logic.ExtensionFile.AddandUploadImgaeNews(img, news);
                        news.ImgAvar = imageName;
                    }
                    news.Title = title;
                    news.DateUp = date;
                    news.Content = content;
                    context.News.Update(news);
                    context.SaveChanges();
                    ViewBag.thongbao = "Đã chỉnh sửa thành công!";
                    return View("/Views/News/NewsDetail.cshtml");
                }
            }
            
        }

        public IActionResult XoaTinTuc(int id)
        {
            User ucheck = CheckRoleSession(new int[] { 1 }, true);// true: and, false: or

            if (id == 0)
			{
                return View("/");
			}
            News news = context.News.FirstOrDefault(x => x.NewsId == id);
            context.News.Remove(news);
            context.SaveChanges();
            string thongbao = "konull!";
            return Redirect("/tintuc?thongbao="+ thongbao);
        }
    }
}
