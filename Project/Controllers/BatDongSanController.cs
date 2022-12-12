using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project.Controllers
{
    public class BatDongSanController : Controller
    {
        Bds_CShapContext context;
        public BatDongSanController()
        {
            context = new Bds_CShapContext();
        }
        public IActionResult Index(int category,int regional, string sort, string price, int Pageindex, string thongbao)
        {
            int Pagesize = 6;// size page
            ViewBag.ListCate = context.Categories.ToList();
            ViewBag.ListRegi = context.Regionals.ToList();
            if (category==0&&regional==0&&string.IsNullOrEmpty(sort)&&string.IsNullOrEmpty(price)&& Pageindex==0)
            {
                ViewBag.Cate = 0;
                ViewBag.Regi = 0;
                ViewBag.sort = "";
                ViewBag.price = "";
                ViewBag.PageIndex = 1;
                List<Product> pro = context.Products.OrderByDescending(x=>x.DateUp).ToList();
                ViewBag.ListPro = Logic.ExtensionPage.PagingProduct(pro, 1, Pagesize);
                ViewBag.PageEnd = Logic.ExtensionPage.PageEndProduct(pro, 1);
                if (thongbao != null) { ViewBag.thongbao = "Đã xóa thành công!"; }
                return View("/Views/Product/ProductList.cshtml");
            }
            else
            {
                List<Product> pro = context.Products.OrderByDescending(x => x.DateUp).ToList();
                if (category != 0) { pro = pro.Where(x => x.CategoryId == category).ToList(); }// loai
                if(regional != 0) { pro = pro.Where(x => x.RegionalId == regional).ToList(); }// khu vuc
                if(!string.IsNullOrEmpty(sort)) {
                    pro = Logic.ExtensionProduct.FilterSort(pro,sort);// xap sep
                }
                if(!string.IsNullOrEmpty(price)) { 
                    List<long> pri = Logic.ExtensionProduct.GetPriceMinMax(price);
                    if (pri[1]==0) { pro = pro.Where(x => x.NoPrice>pri[0]).ToList(); }// >20ty
                    pro = pro.Where(x => x.NoPrice > pri[0]&&x.NoPrice<pri[1]).ToList();// khoang gia
                }
                if (Pageindex == 0) { Pageindex = 1; }
                ViewBag.ListPro = Logic.ExtensionPage.PagingProduct(pro, Pageindex, Pagesize);
                ViewBag.PageEnd = Logic.ExtensionPage.PageEndProduct(pro, Pagesize);
                ViewBag.Cate = category;
                ViewBag.Regi = regional;
                ViewBag.sort = sort;
                ViewBag.price = price;
                ViewBag.PageIndex = Pageindex;
                return View("/Views/Product/ProductList.cshtml");
            }
        }
        public IActionResult Chitiet(int id)
        {
            Product pro = context.Products.FirstOrDefault(x=>x.ProductId==id);
            ViewBag.Product= pro;
            ViewBag.ListImg = null;
            if (context.ImageProducts.Where(x => x.ProductId == id).Count() > 0)
            {
                ViewBag.ListImg = context.ImageProducts.Where(x => x.ProductId == id).ToList();
            }
            ViewBag.listregi = context.Regionals.ToList();
            ViewBag.ListPro = context.Products.Where(x=>x.ProductId!=id&&x.RegionalId==pro.RegionalId).Skip(0).Take(3).ToList();
            return View("/Views/Product/Product.cshtml");
        }


    }
}
