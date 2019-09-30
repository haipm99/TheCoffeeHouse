using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheCoffeehouse.Data.Models;
using TheCoffeehouse.Data.Models.Domains;
using TheCoffeehouse.Data.Models.Uow;
using TheCoffeehouse.Data.Models.View;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheCoffeeHouse.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyingController : BaseController
    {
       public BuyingController(IUnitOfWork uow) : base(uow)
        {

        }

        //desc : create Invoice
        [HttpPost("createInvoice/{id}")]
        public IActionResult CreateInvoice(string id)
        {
            var repo = _uow.GetService<InvoiceDomains>();
            var invoice = new Invoice
            {
                Id = Guid.NewGuid().ToString(),
                UserId = id,
                BuyDate = DateTime.Now,
                Description = "",
                Total = 0
            };

            repo.Create(invoice);
            _uow.SaveChanges();
            return Ok(invoice);
        }

        //desc : create InvoiceDetail
        [HttpPost("createDetail")]
        public IActionResult CreateDetail(DetailModel model)
        {
            var repo = _uow.GetService<InvoiceDetailDomains>();
            var newDetail = new InvoiceDetails
            {
                IdPro = model.IdPro,
                IdInvoice = model.IdInvoide,
                Quantity = model.Quantity,
                Total = model.Total,
            };
            repo.Create(newDetail);
            _uow.SaveChanges();
            return Ok();
        }

        //desc : update total of invoice

        [HttpPost("UpdateTotal/{id}")]
        public IActionResult UpdateTotal(string id ,float total)
        {
            var repo = _uow.GetService<InvoiceDomains>();

            repo.UpdateTotal(id, total);
            
            return Ok("Update Success");
        }
    }
}
