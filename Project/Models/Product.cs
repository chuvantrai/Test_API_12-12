using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Models
{
    public partial class Product
    {
        public Product()
        {
            ImageProducts = new HashSet<ImageProduct>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int RegionalId { get; set; }
        public string LetterPrice { get; set; }
        public long NoPrice { get; set; }
        public DateTime DateUp { get; set; }
        public string LinkGgmap { get; set; }
        public double? AreaM2 { get; set; }
        public double? HorizontalM { get; set; }
        public bool Status { get; set; }
        public string ImgAvar { get; set; }

        public virtual Category Category { get; set; }
        public virtual Regional Regional { get; set; }
        public virtual ICollection<ImageProduct> ImageProducts { get; set; }
    }
}
