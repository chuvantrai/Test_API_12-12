using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Application.Responses
{
    public class ProductResponse : APIResponse
    {
        public Product Data { get; set; } = default!;
    }
    
    public class APIResponse
    {
        public int Status { get; set; } = 400;
        public bool Success { get; set; } = false;
        public string Message { get; set; } = default!;
    }
    
    public class ListProductsResponse : APIResponse
    {
        public List<Product> Data { get; set; } = null;
    }
}