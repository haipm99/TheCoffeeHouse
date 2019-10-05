using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheCoffeehouse.Data.Models.Repositories
{
    public interface IInvoicesRepository : IBaseRepository<Invoice,string>
    {
        List<Invoice> GetInvoiceOfUser(string id);

        Invoice UpdateTotal(string id, float total);

        List<Invoice> GetAllInvoice();

        Invoice UpdateDescription(string id, string desc);
    }

    public class InvoiceRepository : BaseRepository<Invoice, string>, IInvoicesRepository
    {
        public InvoiceRepository(DbContext context) : base(context)
        {

        }

        public List<Invoice> GetAllInvoice()
        {
            return _dbSet.ToList();
        }

        public override Invoice GetById(string id)
        {
            return _dbSet.FirstOrDefault(i => i.Id == id);
        }

        public List<Invoice> GetInvoiceOfUser(string id)
        {
            return _dbSet.Where(i => i.UserId == id).ToList();
        }

        public Invoice UpdateDescription(string id, string desc)
        {
            Invoice invoice = this.GetById(id);
            invoice.Description = desc;
            return invoice;
        }

        public Invoice UpdateTotal(string id, float total)
        {
            var invoice = _dbSet.FirstOrDefault(i => i.Id == id);

            invoice.Total = total;

            return invoice;
        }
    }
}
