using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheCoffeehouse.Data.Models.Repositories;
using TheCoffeehouse.Data.Models.Uow;

namespace TheCoffeehouse.Data.Models.Domains
{
    public class PostsDomains : BaseDomains
    {
        public PostsDomains(IUnitOfWork uow) : base(uow)
        {

        }

        public IList<Posts> GetAll()
        {
            return uow.GetService<IPostsRepository>().GetAll().ToList();
        }
        public Posts Create(Posts post)
        {
            return uow.GetService<IPostsRepository>().Create(post);
        }
        public Posts Delete(Posts posts)
        {
            return uow.GetService<IPostsRepository>().Delete(posts);
        } 
        public Posts Update(Posts posts)
        {
            return uow.GetService<IPostsRepository>().Update(posts);
        }
        public Posts GetPostById(string id)
        {
            return uow.GetService<IPostsRepository>().GetById(id);
        }
    }
}
