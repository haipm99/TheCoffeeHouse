using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheCoffeehouse.Data.Models.Repositories;
using TheCoffeehouse.Data.Models.Uow;

namespace TheCoffeehouse.Data.Models.Domains
{
    public class AppUsersDomains : BaseDomains
    {

        public AppUsersDomains(IUnitOfWork uow) : base(uow)
        {

        }

        public IList<AppUsers> GetAll()
        {
            var list = uow.GetService<IAppUsersRepository>().GetAll().ToList();
            return list;
        }

        public AppUsers GetById(string id)
        {
            var acc = uow.GetService<IAppUsersRepository>().GetById(id);
            return acc;
        }

        public bool CheckExistedUser(string username)
        {
            var acc = uow.GetService<IAppUsersRepository>().GetAll().FirstOrDefault(u => u.Username == username);
            if(acc != null)
            {
                return true;
            }
            return false;
        }

        public AppUsers Create(AppUsers user)
        {
            return uow.GetService<IAppUsersRepository>().Create(user);
        }

        public AppUsers Delete(AppUsers user)
        {
            return uow.GetService<IAppUsersRepository>().Delete(user);
        }

        public AppUsers Update(AppUsers Update)
        {
            return uow.GetService<IAppUsersRepository>().Update(Update);
        }

        public AppUsers Login(string username ,string password)
        {
            return uow.GetService<IAppUsersRepository>().Login(username, password);
        }
    }
}
