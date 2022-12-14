using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Project.Application.Queries;
using Project.Application.Responses;
using Project.Models;

namespace Project.Application.Queries
{
    public class ListProductQuery : IRequest<ListProductsResponse>
    {
        public int category {get; set; } = 0;
        public int regional{get; set; }
        public string sort{get; set; }
        public string price{get; set; } 
        public int pageindex{get; set; }
    }

    internal class Handler : IRequestHandler<ListProductQuery, ListProductsResponse>
    {
        private readonly IMediator _mediator;
        private readonly Bds_CShapContext _context;

        public Handler(IMediator mediator)
        {
            _context = new Bds_CShapContext();
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<ListProductsResponse> Handle(ListProductQuery request, CancellationToken cancellationToken)
        {
            int pagesize = 10; // size page
            if (request.pageindex <= 0)
            {
                var productResponse = new ListProductsResponse()
                {
                    Data = null,
                    Status = 400,
                    Message = "Invalid Request"
                };
                return productResponse;
            }
            if (request.category == 0 && request.regional == 0 && string.IsNullOrEmpty(request.sort) && string.IsNullOrEmpty(request.price))
            {
                var pro = _context.Products.OrderByDescending(x => x.DateUp).ToList();
                var listPro = Logic.ExtensionPage.PagingProduct(pro, 1, pagesize);
                var pageEnd = Logic.ExtensionPage.PageEndProduct(pro, 1);
                var productResponse = new ListProductsResponse()
                {
                    Data = listPro,
                };
                return productResponse;
            }
            else
            {
                List<Product> pro = _context.Products.OrderByDescending(x => x.DateUp).ToList();
                if (request.category != 0)
                {
                    pro = pro.Where(x => x.CategoryId == request.category).ToList();
                } // loai

                if (request.regional != 0)
                {
                    pro = pro.Where(x => x.RegionalId == request.regional).ToList();
                } // khu vuc

                if (!string.IsNullOrEmpty(request.sort))
                {
                    pro = Logic.ExtensionProduct.FilterSort(pro, request.sort); // xap sep
                }

                if (!string.IsNullOrEmpty(request.price))
                {
                    List<long> pri = Logic.ExtensionProduct.GetPriceMinMax(request.price);
                    if (pri[1] == 0)
                    {
                        pro = pro.Where(x => x.NoPrice > pri[0]).ToList();
                    } // >20ty

                    pro = pro.Where(x => x.NoPrice > pri[0] && x.NoPrice < pri[1]).ToList(); // khoang gia
                }

                if (request.pageindex == 0)
                {
                    request.pageindex = 1;
                }

                var listPro = Logic.ExtensionPage.PagingProduct(pro, request.pageindex, pagesize);
                var pageEnd = Logic.ExtensionPage.PageEndProduct(pro, pagesize);
                var productResponse = new ListProductsResponse()
                {
                    Data = listPro,
                    Status = 200,
                    Success = true,
                    Message = "Successfully!"
                };
                return productResponse;
            }
        }
    }
}

public class ListProductQueryCommandValidator : AbstractValidator<ListProductQuery>
{
    public ListProductQueryCommandValidator()
    {
        RuleFor(x => x.pageindex==0);
    }
}