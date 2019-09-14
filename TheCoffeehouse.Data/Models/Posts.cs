using System;
using System.Collections.Generic;

namespace TheCoffeehouse.Data.Models
{
    public partial class Posts
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public string Img { get; set; }
        public string UserId { get; set; }

        public virtual AppUsers User { get; set; }
    }
}
