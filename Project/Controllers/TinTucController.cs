using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System.Collections.Generic;
using System.Linq;
using Project.Application.Responses;

namespace Project.Controllers
{
    public class TinTucController : Controller
    {
        Bds_CShapContext context;
        public TinTucController()
        {
            context = new Bds_CShapContext();
        }
        [HttpGet]
        public IActionResult Index(int? id)
        {
            var productResponse = new NewsResponse();
            if(id is not null)
            {
                var news = context.News.FirstOrDefault(x => x.NewsId == id);
                if (news is null)
                {
                    productResponse.Message = "Invalid request! Missing required field";
                    productResponse.Status = 400;
                    return new JsonResult(productResponse);
                }
                productResponse = new NewsResponse()
                {
                    Data = news,
                    Status = 200,
                    Success = true,
                    Message = "Successfully!"
                };
                return new JsonResult(productResponse);
            }
            else
            {
                productResponse.Message = "Invalid request! Missing required field";
                productResponse.Status = 400;
                return new JsonResult(productResponse);
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
