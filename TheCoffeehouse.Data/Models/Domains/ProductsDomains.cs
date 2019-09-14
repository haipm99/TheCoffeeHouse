using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheCoffeehouse.Data.Models.Repositories;
using TheCoffeehouse.Data.Models.Uow;

namespace TheCoffeehouse.Data.Models.Domains
{
    public class ProductsDomains : BaseDomains
    {
        public ProductsDomains(IUnitOfWork uow) : base(uow)
        {

        }

        public IList<Products> GetAll()
        {
            return uow.GetService<IProductsRepository>().GetAll().ToList();
        }
        public Products Create(Products products)
        {
            return uow.GetService<IProductsRepository>().Create(products);
        }
        public Products Delete(Products products)
        {
            return uow.GetService<IProductsRepository>().Delete(products);
        }
        public Products Update(Products product)
        {
            return uow.GetService<IProductsRepository>().Update(product);
        }
        public Products GetProductById(string id)
        {
            return uow.GetService<IProductsRepository>().GetById(id);
        }
    }
}
