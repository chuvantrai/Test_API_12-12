using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project.Controllers
{
    public class TinTucController : Controller
    {
        Bds_CShapContext context;
        public TinTucController()
        {
            context = new Bds_CShapContext();
        }
        public IActionResult Index(int id, string thongbao)
        {
            if(id != 0 && id != null)
            {
                News news = context.News.FirstOrDefault(x => x.NewsId == id);
                ViewBag.News = news;
                List<News> list = context.News.Where(x=>x.NewsId!=id).Skip(0).Take(3).ToList();
                ViewBag.ListNews = list;
                return View("/Views/News/News.cshtml");
            }
            else
            {
                List<News> NewsList = new List<News>();
                NewsList = context.News.ToList();
                int Pagesize = 5;
                int Pageindex = 1;
                List<News> NewsListPage = Logic.ExtensionPage.PagingNews(NewsList, Pageindex, Pagesize);
                ViewBag.NewsList = NewsListPage;
                ViewBag.PageIndex = Pageindex;
                ViewBag.PageEnd = Logic.ExtensionPage.PageEnd(NewsList, Pagesize);
                if (!string.IsNullOrEmpty(thongbao))
                {
                    ViewBag.thongbao = "Đã xóa thành công";
                }
                return View("/Views/News/NewsList.cshtml");
            }
        }
        public IActionResult Danhsach(int Pageindex,string search,string sort)
        {
            if (Pageindex == 0 || Pageindex == null) { Pageindex = 1; }
            List<News> NewsList = context.News.ToList();
            if (!string.IsNullOrEmpty(search)) { NewsList = NewsList.Where(x => x.Title.ToUpper().Contains(search.ToUpper())).ToList(); }
            if (!string.IsNullOrEmpty(sort)) {
                if (sort.Equals("des")) { NewsList = NewsList.OrderByDescending(x => x.DateUp).ToList(); } 
                else { NewsList = NewsList.OrderBy(x => x.DateUp).ToList(); }
            }
            int Pagesize = 5;
            List<News> NewsListPage = Logic.ExtensionPage.PagingNews(NewsList, Pageindex, Pagesize);
            ViewBag.NewsList = NewsListPage;
            ViewBag.PageEnd = Logic.ExtensionPage.PageEnd(NewsList, Pagesize);
            ViewBag.PageIndex = Pageindex;
            ViewBag.sort = sort;
            ViewBag.search = search;
            return View("/Views/News/NewsList.cshtml");
        }
    }
}
