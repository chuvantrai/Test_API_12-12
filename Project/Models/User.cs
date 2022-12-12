using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Models
{
    public partial class User
    {
        public User()
        {
            UserRequests = new HashSet<UserRequest>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        public int RoleId { get; set; }
        public string ImgAvar { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<UserRequest> UserRequests { get; set; }
    }
}
