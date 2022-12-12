using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Models
{
    public partial class News
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateUp { get; set; }
        public string ImgAvar { get; set; }
    }
}
