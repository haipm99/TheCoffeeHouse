using System;
using System.Collections.Generic;
using System.Text;
using TheCoffeehouse.Data.Models.Repositories;
using TheCoffeehouse.Data.Models.Uow;

namespace TheCoffeehouse.Data.Models.Domains
{
    public class InvoiceDomains : BaseDomains
    {
        public InvoiceDomains(IUnitOfWork uow) : base(uow)
        {

        }

        public Invoice Create(Invoice invoice)
        {
            return uow.GetService<IInvoicesRepository>().Create(invoice);
        }

        public Invoice UpdateTotal(string id, float total)
        {
            var invoice = uow.GetService<IInvoicesRepository>().UpdateTotal(id,total);
            uow.SaveChanges();
            return invoice;
        }

    }
}
