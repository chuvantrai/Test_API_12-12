using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System;
using System.Linq;
using Project.Application.Responses;

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

        [HttpPost]
        public IActionResult ThemTinTuc(string title, string content, IFormFile img)
        {
            // check role
            var newsResponse = new NewsResponse();
            if (!CheckRoleCookie(new String[] { RoleAdmin,RoleUser,RoleUser2 }, false)) // true: and, false: or
            {
                newsResponse.Message = "401 Unauthorized";
                newsResponse.Status = 401;
                return new JsonResult(newsResponse);
            }
            string jsonAcc = Request.Cookies["userAccount"];

            if (String.IsNullOrEmpty(title)||String.IsNullOrEmpty(content) ||title.Length>100 ||content.Length>1500)
            {
                newsResponse.Message = "Invalid request! Missing required field";
                newsResponse.Status = 400;
                return new JsonResult(newsResponse);
            }

            News news = new News();
            string imageName = Logic.ExtensionFile.AddnewImgae(img);
            news.Title = title;
            news.DateUp = DateTime.Now;
            news.Content = content;
            news.ImgAvar = imageName;
            context.News.Add(news);
            context.SaveChanges();
            newsResponse = new NewsResponse()
            {
                Data = news,
                Status = 200,
                Success = true,
                Message = "Successfully!"
            };
            return new JsonResult(newsResponse);
        }

        public IActionResult ChinhSuaTinTuc(int id, string title, DateTime date, string content, IFormFile img)
        {
            User ucheck = CheckRoleSession(new int[] { 1 }, true); // true: and, false: or

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
            User ucheck = CheckRoleSession(new int[] { 1 }, true); // true: and, false: or

            if (id == 0)
            {
                return View("/");
            }

            News news = context.News.FirstOrDefault(x => x.NewsId == id);
            context.News.Remove(news);
            context.SaveChanges();
            string thongbao = "konull!";
            return Redirect("/tintuc?thongbao=" + thongbao);
        }
    }
}