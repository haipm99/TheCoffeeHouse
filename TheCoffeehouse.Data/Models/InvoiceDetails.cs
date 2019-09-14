using System;
using System.Collections.Generic;

namespace TheCoffeehouse.Data.Models
{
    public partial class InvoiceDetails
    {
        public string IdPro { get; set; }
        public string IdInvoice { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }

        public virtual Invoice IdInvoiceNavigation { get; set; }
        public virtual Products IdProNavigation { get; set; }
    }
}
