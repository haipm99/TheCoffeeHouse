using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheCoffeehouse.Data.Models.Repositories
{
    public interface IInvoiceDetailRepository : IBaseRepository<InvoiceDetails,string>
    {
        List<InvoiceDetails> GetDetailOfInvoice(string id);
    }

    public class InvoiceDetailRepository : BaseRepository<InvoiceDetails, string>, IInvoiceDetailRepository
    {

        public InvoiceDetailRepository(DbContext context) : base(context)
        {

        }
        public override InvoiceDetails GetById(string id)
        {
            throw new NotImplementedException();
        }

        public List<InvoiceDetails> GetDetailOfInvoice(string id)
        {
            return _dbSet.Where(detail => detail.IdPro == id).ToList();
        }
    }
}
