using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheCoffeehouse.Data.Models.Repositories
{
    interface IPostsRepository : IBaseRepository<Posts,string>
    {

    }

    public class PostsRepository : BaseRepository<Posts, string>, IPostsRepository
    {

        public PostsRepository(DbContext context) : base(context)
        {

        }

        public override Posts GetById(string id)
        {
            return _dbSet.FirstOrDefault(p => p.Id == id);
        }

       
    }
}
