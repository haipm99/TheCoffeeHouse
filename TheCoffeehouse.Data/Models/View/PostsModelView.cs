using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoffeehouse.Data.Models.View
{
    public class PostsModelView
    {
    }

    public class PostsModelCreate
    {
        public string title { get; set; }
        public string content { get; set; }
        public string img { get; set; }
        public string userId { get; set; }
    }

    public class PostsModelUpdate
    {
        public string title { get; set; }
        public string content { get; set; }
        public string img { get; set; }
        public string userId { get; set; }


    }

}
