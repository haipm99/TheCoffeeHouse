using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheCoffeehouse.Data.Models.Repositories
{
    public interface IAppUsersRepository : IBaseRepository<AppUsers,string>
    {
    }

    public class AppUsersRepository : BaseRepository<AppUsers, string>, IAppUsersRepository
    {
        public AppUsersRepository(DbContext context) : base(context)
        {

        }
        public override AppUsers GetById(string id)
        {
            return _dbSet.FirstOrDefault(user => user.Id == id);
        }

        public override AppUsers Login(string username, string password)
        {
            return _dbSet.FirstOrDefault(user => user.Username == username && user.Password == password);
        }
    }
}
