using System;
using System.Collections.Generic;

namespace TheCoffeehouse.Data.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }

        public string Id { get; set; }
        public string UserId { get; set; }
        public double Total { get; set; }
        public string Description { get; set; }
        public DateTime BuyDate { get; set; }

        public virtual AppUsers User { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
