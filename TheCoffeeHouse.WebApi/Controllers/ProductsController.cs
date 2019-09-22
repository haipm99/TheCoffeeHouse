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
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
       public ProductsController(IUnitOfWork uow) : base(uow)
        {

        }


        //desc : get all product
        [HttpGet("getAll")]
        public IActionResult GetAllProduct()
        {
            var repo = _uow.GetService<ProductsDomains>();
            var list = repo.GetAll();
            List<object> mylist = new List<object>();
            foreach(Products p in list)
            {
                var a = new
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    TypeId = p.TypeId.Split("-")[0],
                    Description = p.Description,
                    Img = p.Img,
                    Type = p.TypeId.Split("-")[1]
                };
                mylist.Add(a);
            }

            return Ok(mylist);
        }

        //desc : get 6 product for main page
        [HttpGet("getMainPageProduct")]
        public IActionResult GetProductForMainPage()
        {
            var repo = _uow.GetService<ProductsDomains>();
            var list = repo.GetAll().Take(6);
            List<object> mylist = new List<object>();
            foreach(Products p in list)
            {
                var a = new
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    TypeId = p.TypeId.Split("-")[0],
                    Description = p.Description,
                    Img = p.Img,
                    Type = p.TypeId.Split("-")[1]
                };
                mylist.Add(a);
            }
            if (mylist.Count > 0)
            {
                return Ok(mylist);
            }
            return BadRequest("Dont have product");
        }
        //desc : create product
        [HttpPost("create")]
        public IActionResult CreateProduct(ProductsModelCreate model)
        {
            var repo = _uow.GetService<ProductsDomains>();

            var newPro = new Products
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Img = model.Img,
                TypeId = model.TypeId
            };
            repo.Create(newPro);
            _uow.SaveChanges();
            return Ok(newPro);
        }

        //desc: Update Product
        [HttpPatch("{id}")]
        public IActionResult UpdateProduct(string id, ProductsModelCreate model)
        {
            var repo = _uow.GetService<ProductsDomains>();
            var newPro = new Products
            {
                Id = id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Img = model.Img,
                TypeId = model.TypeId
            };
            repo.Update(newPro);
            _uow.SaveChanges();
            return Ok(newPro);
        }

        //desc: Delete Product
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(string id)
        {
            var repo = _uow.GetService<ProductsDomains>();

            var product = repo.GetProductById(id);
             if(product != null)
            {
                repo.Delete(product);
                _uow.SaveChanges();
                return Ok(product);
            }
            return BadRequest("Not Found Product.");
            
        }

        //desc : get product by id
        [HttpGet("{id}")]
        public IActionResult GetProduct(string id)
        {
            var repo = _uow.GetService<ProductsDomains>();
            var product = repo.GetProductById(id);
            if(product != null)
            {
                var a = new 
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Img = product.Img,
                    TypeId = product.TypeId
                };
                return Ok(a);
            }
            return BadRequest("Not Found.");
        }

    }
}
