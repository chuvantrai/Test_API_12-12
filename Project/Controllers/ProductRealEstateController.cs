using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Responses;
using Project.Models;

namespace Project.Controllers
{
    /// test API
    public class ProductRealEstateController : AbstractController
    {
        private readonly IMediator _mediator;
        Bds_CShapContext context;

        public ProductRealEstateController(IMediator mediator)
        {
            context = new Bds_CShapContext();
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public JsonResult List(int category, int regional, string sort, string price, int pageindex)
        {
            int pagesize = 10; // size page
            if (category == 0 && regional == 0 && string.IsNullOrEmpty(sort) && string.IsNullOrEmpty(price) &&
                pageindex == 0)
            {
                var pro = context.Products.OrderByDescending(x => x.DateUp).ToList();
                var listPro = Logic.ExtensionPage.PagingProduct(pro, 1, pagesize);
                var pageEnd = Logic.ExtensionPage.PageEndProduct(pro, 1);
                return new JsonResult(listPro);
            }
            else
            {
                List<Product> pro = context.Products.OrderByDescending(x => x.DateUp).ToList();
                if (category != 0)
                {
                    pro = pro.Where(x => x.CategoryId == category).ToList();
                } // loai

                if (regional != 0)
                {
                    pro = pro.Where(x => x.RegionalId == regional).ToList();
                } // khu vuc

                if (!string.IsNullOrEmpty(sort))
                {
                    pro = Logic.ExtensionProduct.FilterSort(pro, sort); // xap sep
                }

                if (!string.IsNullOrEmpty(price))
                {
                    List<long> pri = Logic.ExtensionProduct.GetPriceMinMax(price);
                    if (pri[1] == 0)
                    {
                        pro = pro.Where(x => x.NoPrice > pri[0]).ToList();
                    } // >20ty

                    pro = pro.Where(x => x.NoPrice > pri[0] && x.NoPrice < pri[1]).ToList(); // khoang gia
                }

                if (pageindex == 0)
                {
                    pageindex = 1;
                }

                var listPro = Logic.ExtensionPage.PagingProduct(pro, pageindex, pagesize);
                var pageEnd = Logic.ExtensionPage.PageEndProduct(pro, pagesize);
                var productResponse = new ListProductResponse()
                {
                    Data = listPro,
                    Status = "Success",
                    Message = "Successfully!"
                };
                return new JsonResult(productResponse);
            }
        }

        [HttpPost]
        public JsonResult Create(string title, int category, int regional, string content,
            string letterPrice, long noPrice, string linkGgMap, double area, double horizontal, IFormFile img)
        {
            var productResponse = new ProductResponse();
            if (!CheckRoleCookie(new String[] { RoleAdmin }, true)) // true: and, false: or
            {
                return new JsonResult("No authorization required");
            }

            if (string.IsNullOrEmpty(title))
            {
                productResponse.Message = "title can't null";
                return new JsonResult(productResponse);
            }

            if (string.IsNullOrEmpty(content))
            {
                productResponse.Message = "content can't null";
                return new JsonResult(productResponse);
            }

            if (category == 0)
            {
                productResponse.Message = "category can't null";
                return new JsonResult(productResponse);
            }

            if (regional == 0)
            {
                productResponse.Message = "regional can't null";
                return new JsonResult(productResponse);
            }

            if (string.IsNullOrEmpty(letterPrice))
            {
                productResponse.Message = "letter price can't null";
                return new JsonResult(productResponse);
            }

            if (noPrice == 0)
            {
                productResponse.Message = "noPrice can't null";
                return new JsonResult(productResponse);
            }

            if (area == 0)
            {
                productResponse.Message = "area can't null";
                return new JsonResult(productResponse);
            }

            if (horizontal == 0)
            {
                productResponse.Message = "horizontal can't null";
                return new JsonResult(productResponse);
            }

            Product p = new Product()
            {
                ProductName = title,
                CategoryId = category,
                RegionalId = regional,
                Description = content,
                LetterPrice = letterPrice,
                NoPrice = noPrice,
                LinkGgmap = linkGgMap,
                AreaM2 = area,
                HorizontalM = horizontal
            };

            var filename = Logic.ExtensionFile.AddnewImgae(img);
            if (string.IsNullOrEmpty(filename))
            {
                throw new NullReferenceException("Upload file error!");
            }

            p.ImgAvar = filename;
            p.DateUp = DateTime.Now;
            p.Status = true;
            context.Products.Add(p);
            context.SaveChanges();
            var product = context.Products.OrderByDescending(x => x.ProductId)
                .FirstOrDefault(pro => pro.ProductId != 0);
            productResponse = new ProductResponse()
            {
                Data = product,
                Status = "Success",
                Message = "Successfully!"
            };
            return new JsonResult(productResponse);
        }

        [HttpDelete]
        public JsonResult Remove(int id)
        {
            var productResponse = new ProductResponse();
            if (!CheckRoleCookie(new String[] { RoleAdmin }, true)) // true: and, false: or
            {
                productResponse.Message = "No authorization required";
                return new JsonResult(productResponse);
            }

            if (id == 0)
            {
                productResponse.Message = "No id";
                return new JsonResult(productResponse);
            }

            Product p = context.Products.FirstOrDefault(x => x.ProductId == id);
            if (p is null)
            {
                productResponse.Message = "Product does not exist";
                return new JsonResult(productResponse);
            }
            List<ImageProduct> ipPro = context.ImageProducts.Where(x => x.ProductId == id).ToList();
            context.ImageProducts.RemoveRange(ipPro);
            context.Products.Remove(p);
            context.SaveChanges();
            List<string> listimg = ipPro.Select(x => x.ImgName).ToList();
            bool ch = Logic.ExtensionFile.DeleteListImgae(listimg);
            bool ch2 = Logic.ExtensionFile.DeleteImgae(p.ImgAvar);
            productResponse.Status = "Success";
            productResponse.Message = "Successfully!";
            return new JsonResult(productResponse);
        }

        [HttpPut]
        public JsonResult Update(int id, string title, int category, int regional, string content,
            string letterPrice, long noPrice, string linkGgmap, double area, double horizontal, IFormFile img)
        {
            var productResponse = new ProductResponse();
            if (!CheckRoleCookie(new String[] { RoleAdmin }, true)) // true: and, false: or
            {
                productResponse.Message = "No authorization required";
                return new JsonResult(productResponse);
            }

            if (id == 0)
            {
                productResponse.Message = "id can't null";
                return new JsonResult(productResponse);
            }

            var p = context.Products.FirstOrDefault(x => x.ProductId == id);
            if (p is null)
            {
                productResponse.Message = "Product does not exist";
                return new JsonResult(productResponse);
            }

            if (string.IsNullOrEmpty(title))
            {
                productResponse.Message = "title can't null";
                return new JsonResult(productResponse);
            }

            if (string.IsNullOrEmpty(content))
            {
                productResponse.Message = "content can't null";
                return new JsonResult(productResponse);
            }

            if (category == 0)
            {
                productResponse.Message = "category can't null";
                return new JsonResult(productResponse);
            }

            if (regional == 0)
            {
                productResponse.Message = "regional can't null";
                return new JsonResult(productResponse);
            }

            if (string.IsNullOrEmpty(letterPrice))
            {
                productResponse.Message = "letter price can't null";
                return new JsonResult(productResponse);
            }

            if (noPrice == 0)
            {
                productResponse.Message = "noPrice can't null";
                return new JsonResult(productResponse);
            }

            if (area == 0)
            {
                productResponse.Message = "area can't null";
                return new JsonResult(productResponse);
            }

            if (horizontal == 0)
            {
                productResponse.Message = "horizontal can't null";
                return new JsonResult(productResponse);
            }

            if (img != null)
            {
                string imageName = Logic.ExtensionFile.AddandUploadImgaeP(img, p.ImgAvar);
                p.ImgAvar = imageName;
            }

            p.ProductName = title;
            p.CategoryId = category;
            p.RegionalId = regional;
            p.Description = content;
            p.LetterPrice = letterPrice;
            p.NoPrice = noPrice;
            p.LinkGgmap = linkGgmap;
            p.AreaM2 = area;
            p.HorizontalM = horizontal;
            context.Products.Update(p);
            context.SaveChanges();
            productResponse = new ProductResponse()
            {
                Data = context.Products.FirstOrDefault(x => x.ProductId == id),
                Status = "Success",
                Message = "Successfully!"
            };
            return new JsonResult(productResponse);
        }
    }
}