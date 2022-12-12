using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Models
{
    public partial class ImageProduct
    {
        public int ImgId { get; set; }
        public int ProductId { get; set; }
        public string ImgName { get; set; }

        public virtual Product Product { get; set; }
    }
}
