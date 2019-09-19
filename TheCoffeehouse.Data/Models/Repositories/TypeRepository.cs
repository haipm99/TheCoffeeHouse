using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheCoffeehouse.Data.Models.Repositories
{
    public interface ITypeRepository : IBaseRepository<Type,string>
    {

    }

    public class TypeRepository : BaseRepository<Type, string>, ITypeRepository
    {
        public TypeRepository(DbContext context) : base(context)
        {

        }

        public override Type GetById(string id)
        {
            return _dbSet.FirstOrDefault(t => t.Id == id);
        }
    }
}
