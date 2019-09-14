using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoffeehouse.Data.Models.View
{
    public class ProductsModelView
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public float Price { get; set; }
        public string TypeId { get; set; }
    }
    public class ProductsModelCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public float Price { get; set; }
        public string TypeId { get; set; }
    }
}
