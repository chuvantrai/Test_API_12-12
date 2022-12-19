using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Queries;
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
        public async Task<IActionResult> List(ListProductQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public JsonResult Create(string title, int category, int regional, string content,
            string letterPrice, long noPrice, string linkGgMap, double area, double horizontal, IFormFile img)
        {
            var productResponse = new ProductResponse();
            if (!CheckRoleCookie(new String[] { RoleAdmin }, true)) // true: and, false: or
            {
                productResponse.Message = "401 Unauthorized";
                productResponse.Status = 401;
                return new JsonResult(productResponse);
            }

            var checkCode = "^(?!.*(!|@|#|\\$|%|\\^|&|\\*|\\(|\\)|,|\\.|\\?|\"|:|{|}|\\||<|>)).*$";

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content) ||
                category == 0 || regional == 0 || string.IsNullOrEmpty(letterPrice) ||
                noPrice < 0 || area < 0 || horizontal < 0 || !Regex.IsMatch(letterPrice,checkCode))
            {
                productResponse.Message = "Invalid Request";
                productResponse.Status = 400;
                return new JsonResult(productResponse);
            }

            var proSameTitle = context.Products.FirstOrDefault(x => x.ProductName.Equals(title));
            
            if (proSameTitle is not null)
            {
                productResponse.Message = "Invalid Request! Title already exist";
                productResponse.Status = 400;
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
                productResponse.Message = "An error has occurred, please contact the API Administrator";
                productResponse.Status = 500;
                return new JsonResult(productResponse);
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
                Status = 200,
                Success = true,
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
                productResponse.Message = "401 Unauthorized";
                productResponse.Status = 401;
                return new JsonResult(productResponse);
            }

            if (id == 0)
            {
                productResponse.Message = "Invalid Request";
                productResponse.Status = 400;
                return new JsonResult(productResponse);
            }

            Product p = context.Products.FirstOrDefault(x => x.ProductId == id);
            if (p is null)
            {
                productResponse.Message = "Invalid Request";
                productResponse.Status = 400;
                return new JsonResult(productResponse);
            }

            List<ImageProduct> ipPro = context.ImageProducts.Where(x => x.ProductId == id).ToList();
            context.ImageProducts.RemoveRange(ipPro);
            context.Products.Remove(p);
            context.SaveChanges();
            List<string> listimg = ipPro.Select(x => x.ImgName).ToList();
            bool ch = Logic.ExtensionFile.DeleteListImgae(listimg);
            bool ch2 = Logic.ExtensionFile.DeleteImgae(p.ImgAvar);
            productResponse.Status = 200;
            productResponse.Message = "Successfully!";
            productResponse.Success = true;
            return new JsonResult(productResponse);
        }

        [HttpPut]
        public JsonResult Update(int id, string title, int category, int regional, string content,
            string letterPrice, long noPrice, string linkGgmap, double area, double horizontal, IFormFile img)
        {
            var productResponse = new ProductResponse();
            if (!CheckRoleCookie(new String[] { RoleAdmin }, true)) // true: and, false: or
            {
                productResponse.Message = "401 Unauthorized";
                productResponse.Status = 401;
                return new JsonResult(productResponse);
            }

            var p = context.Products.FirstOrDefault(x => x.ProductId == id);
            
            if (id == 0 || p is null || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content) || category == 0 ||
            regional == 0|| noPrice < 0 || area < 0 || horizontal < 0 || img != null)
            {
                productResponse.Message = "Invalid Request";
                productResponse.Status = 400;
                return new JsonResult(productResponse);
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
                Status = 200,
                Success = true,
                Message = "Successfully!"
            };
            return new JsonResult(productResponse);
        }
    }
}