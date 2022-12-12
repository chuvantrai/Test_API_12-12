using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Models
{
    public partial class Regional
    {
        public Regional()
        {
            Products = new HashSet<Product>();
        }

        public int RegionalId { get; set; }
        public string RegionalName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
