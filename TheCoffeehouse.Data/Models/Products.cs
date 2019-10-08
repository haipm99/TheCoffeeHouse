using System;
using System.Collections.Generic;

namespace TheCoffeehouse.Data.Models
{
    public partial class Products
    {
        public Products()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string TypeId { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public bool? Status { get; set; }

        public virtual Type Type { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
