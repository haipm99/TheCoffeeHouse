using System;
using System.Collections.Generic;

namespace TheCoffeehouse.Data.Models
{
    public partial class AppUsers
    {
        public AppUsers()
        {
            Invoice = new HashSet<Invoice>();
            Posts = new HashSet<Posts>();
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string Salt { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
