using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheCoffeehouse.Data.Models.Repositories
{
    interface IProductsRepository : IBaseRepository<Products,string>
    {

    }

    public class ProductsRepository : BaseRepository<Products, string>, IProductsRepository
    {
        public ProductsRepository(DbContext  context) : base(context)
        {
            
        }
        public override Products GetById(string id)
        {
            return _dbSet.FirstOrDefault(p => p.Id == id);
        }

        public override Products Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }

}
