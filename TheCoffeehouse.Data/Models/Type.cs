using System;
using System.Collections.Generic;

namespace TheCoffeehouse.Data.Models
{
    public partial class Type
    {
        public Type()
        {
            Products = new HashSet<Products>();
        }

        public string Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
