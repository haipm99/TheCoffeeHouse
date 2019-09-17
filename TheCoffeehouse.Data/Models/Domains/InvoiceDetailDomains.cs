using System;
using System.Collections.Generic;
using System.Text;
using TheCoffeehouse.Data.Models.Repositories;
using TheCoffeehouse.Data.Models.Uow;
using TheCoffeehouse.Data.Models.View;

namespace TheCoffeehouse.Data.Models.Domains
{
    public class InvoiceDetailDomains : BaseDomains
    {
        public InvoiceDetailDomains(IUnitOfWork uow) : base(uow)
        {

        }

        public List<InvoiceDetails> GetDetail(string id)
        {
           return uow.GetService<IInvoiceDetailRepository>().GetDetailOfInvoice(id);
        }

        public InvoiceDetails Create(InvoiceDetails detail)
        {
            return uow.GetService<IInvoiceDetailRepository>().Create(detail);
        }
    }
}
