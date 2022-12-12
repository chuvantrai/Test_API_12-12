using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Controllers
{
    public class BatDongSanAdminController : AbstractController
    {
        Bds_CShapContext context;
        public BatDongSanAdminController()
        {
            context = new Bds_CShapContext();
        }
        public IActionResult Index()
        {
            User ucheck = CheckRoleSession(new int[] { 1 }, true);// true: and, false: or

            return View("/Views/Product/ProductDetail.cshtml");
        }
        public IActionResult ThemBatDongSan(string title,int category,int regional, string content, 
            string letterprice, long noprice, string linkggmap, double area, double horizontal, IFormFile img)
        {
            User ucheck = CheckRoleSession(new int[] { 1 }, true);// true: and, false: or

            if (string.IsNullOrEmpty(title)|| string.IsNullOrEmpty(content))
            {
                ViewBag.ListCategory = context.Categories.ToList();
                ViewBag.ListRegional = context.Regionals.ToList();
                ViewBag.url = "Thembatdongsan";
                return View("/Views/Product/ProductDetail.cshtml");
            }
            else
            {
                Product p = new Product() {ProductName=title,CategoryId=category,RegionalId= regional,
                    Description=content, LetterPrice=letterprice, NoPrice=noprice, LinkGgmap=linkggmap, 
                    AreaM2=area, HorizontalM=horizontal};

                string filename = Logic.ExtensionFile.AddnewImgae(img);
                p.ImgAvar = filename;
                p.DateUp = DateTime.Now;
                p.Status = true;
                context.Products.Add(p);
                context.SaveChanges();
                ViewBag.ListCategory = context.Categories.ToList();
                ViewBag.ListRegional = context.Regionals.ToList();
                ViewBag.thongbao = "Đã thêm BĐS thành công!";
                ViewBag.url = "Thembatdongsan";
                return View("/Views/Product/ProductDetail.cshtml");
            }
        }
        public IActionResult ThemImgBDS(int id, IFormFile img)
        {
            User ucheck = CheckRoleSession(new int[] { 1 }, true);// true: and, false: or

            ImageProduct p = new ImageProduct();
            p.ImgName = Logic.ExtensionFile.AddnewImgae(img);
            p.ProductId = id;
            context.ImageProducts.Add(p);
            context.SaveChanges();
            return Redirect("~/batdongsan/chitiet?id="+id);
        }
        public IActionResult XoaBDS(int id)
        {
            User ucheck = CheckRoleSession(new int[] { 1 }, true);// true: and, false: or

            if (id == 0) { return View("/"); }
            Product p = context.Products.FirstOrDefault(x=>x.ProductId==id);
            List<ImageProduct> ip = context.ImageProducts.Where(x=>x.ProductId==id).ToList();
            context.ImageProducts.RemoveRange(ip);
            context.Products.Remove(p);
            context.SaveChanges();
            List<string> listimg = ip.Select(x => x.ImgName).ToList();
            bool ch = Logic.ExtensionFile.DeleteListImgae(listimg);
            bool ch2 = Logic.ExtensionFile.DeleteImgae(p.ImgAvar);
            return Redirect("/batdongsan?thongbao=konull");
        }
        public IActionResult ChinhSuaBDS(int id,string thongbao, string title, int category, int regional, string content,
            string letterprice, long noprice, string linkggmap, double area, double horizontal, IFormFile img)
        {
            User ucheck = CheckRoleSession(new int[] { 1 }, true);// true: and, false: or

            Product p = context.Products.FirstOrDefault(x => x.ProductId == id);
            ViewBag.ListCategory = context.Categories.ToList();
            ViewBag.ListRegional = context.Regionals.ToList();
            ViewBag.url = "chinhsuabds";
            if (string.IsNullOrEmpty(title))
            {
                ViewBag.pro = p;
                if (!string.IsNullOrEmpty(thongbao)) { ViewBag.thongbao = "Đã chỉnh sửa thành công!"; }
                return View("/Views/Product/ProductDetail.cshtml");
            }
            else
            {
                if (img != null){
                    string imageName = Logic.ExtensionFile.AddandUploadImgaeP(img, p.ImgAvar);
                    p.ImgAvar = imageName;
                }
                p.ProductName= title;p.CategoryId= category;p.RegionalId= regional;
                p.Description= content; p.LetterPrice= letterprice;p.NoPrice= noprice;
                p.LinkGgmap= linkggmap;p.AreaM2= area; p.HorizontalM= horizontal;
                context.Products.Update(p);
                context.SaveChanges();
                string t2 = "konull";
                return Redirect("/batdongsanadmin/chinhsuabds?id="+id+"&thongbao="+t2);
            }
            
        }
        public IActionResult XoaImg(int id)
        {
            User ucheck = CheckRoleSession(new int[] { 1 }, true);// true: and, false: or

            ImageProduct p = context.ImageProducts.FirstOrDefault(x => x.ImgId == id);
            context.ImageProducts.Remove(p);
            context.SaveChanges();
            bool ch2 = Logic.ExtensionFile.DeleteImgae(p.ImgName);
            return Redirect("/batdongsan/chitiet?id="+p.ProductId);
        }
    }
}
