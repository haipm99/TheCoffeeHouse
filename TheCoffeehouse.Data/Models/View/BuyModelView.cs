using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoffeehouse.Data.Models.View
{
    public class BuyModelView
    {

    }

    public class BuyModel
    {
        public string UserId { get; set; }

        public List<InvoiceDetails> Details { get; set; }
    }

    public class DetailModel
    {
        public string IdPro { get; set; }
        public string IdInvoide { get; set; }
        public int Quantity { get; set; }

        public float Total { get; set; }

    }
    public class InvoiceModel
    {
        public string UserId { get; set; }
    }

    public class UpdateDescriptionView
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }
}
