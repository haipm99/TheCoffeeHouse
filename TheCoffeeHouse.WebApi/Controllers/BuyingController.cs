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
            try
            {
                var repo = _uow.GetService<InvoiceDomains>();
                var invoice = new Invoice
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = id,
                    BuyDate = DateTime.UtcNow.Date,
                    Description = "",
                    Total = 0
                };
                repo.Create(invoice);
                _uow.SaveChanges();
                return Ok(invoice);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResult()
                {
                    Code = 400,
                    Detail = ex.Message
                });
            }
        }

        //desc : create InvoiceDetail
        [HttpPost("createDetail")]
        public IActionResult CreateDetail(DetailModel model)
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(new ApiResult()
                {
                    Code = 400,
                    Detail = ex.Message
                });
            }
        }

        //desc : update total of invoice

        [HttpPost("UpdateTotal/{id}")]
        public IActionResult UpdateTotal(string id, float total)
        {
            try
            {
                var repo = _uow.GetService<InvoiceDomains>();

                repo.UpdateTotal(id, total);

                return Ok("Update Success");
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResult()
                {
                    Code = 400,
                    Detail = ex.Message
                });
            }
        }
        //desc : get all invoice
        [HttpGet("GetAllInvoice")]
        public IActionResult GetAllInvoice()
        {
            try
            {
                var repo = _uow.GetService<InvoiceDomains>();
                var mylist = repo.GetAllInvoice();
                if (mylist.Count < 0)
                {
                    return BadRequest("Cant get invoice list.");
                }
                List<object> returnList = new List<object>();
                foreach (Invoice invoice in mylist)
                {
                    var a = new
                    {
                        id = invoice.Id,
                        userId = invoice.UserId,
                        total = invoice.Total,
                        description = invoice.Description,
                        date = invoice.BuyDate.ToString("d")
                    };
                    returnList.Add(a);
                }
                return Ok(returnList);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResult()
                {
                    Code = 400,
                    Detail = ex.Message
                });
            }
        }

        //desc : update Description of invoice
        [HttpPost("UpdateDescription")]

        public IActionResult UpdateDescription(UpdateDescriptionView model)
        {
            try
            {
                var repo = _uow.GetService<InvoiceDomains>();
                Invoice inv = repo.UpdateDescription(model.Id, model.Description);
                if(inv != null)
                {
                    var a = new
                    {
                        id = inv.Id,
                        userId = inv.UserId,
                        description = inv.Description,
                        total = inv.Total,
                        data = inv.BuyDate
                    };
                    return Ok(a);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResult()
                {
                    Code = 400,
                    Detail = ex.Message
                });
            }
        }
    }
}
