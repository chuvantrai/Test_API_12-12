using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Models
{
    public partial class UserRequest
    {
        public int RequestId { get; set; }
        public int UseId { get; set; }
        public string Content { get; set; }
        public DateTime DateRequest { get; set; }
        public bool Status { get; set; }

        public virtual User Use { get; set; }
    }
}
