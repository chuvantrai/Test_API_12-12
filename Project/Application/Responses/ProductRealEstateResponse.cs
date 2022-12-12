using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Application.Responses
{
    public class ProductResponse
    {
        public Product Data { get; set; } = default!;
        public string Status { get; set; } = "failed";
        public string Message { get; set; } = "none";
    }
    
    public class ListProductResponse
    {
        public List<Product> Data { get; set; } = default!;
        public string Status { get; set; } = "failed";
        public string Message { get; set; } = "none";
    }
}