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
            var serviceType = uow.GetService<ITypeRepository>();
            List<Products> mylist = uow.GetService<IProductsRepository>().GetAll().ToList();
            foreach(Products p in mylist)
            {
                var type = serviceType.GetById(p.TypeId).TypeName;
                p.TypeId = type + "-" + p.TypeId;
            }
            return mylist;
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
