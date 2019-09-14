using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoffeehouse.Data.Models.Uow
{
    public partial interface IUnitOfWork
    {

        T GetService<T>();
        int SaveChanges();

    }

    public partial class UnitOfWork : IUnitOfWork
    {
        protected readonly IServiceProvider scope;
        protected readonly DbContext context;
        public UnitOfWork(IServiceProvider scope , DbContext context)
        {
            this.scope = scope;
            this.context = context;
        }

        public T GetService<T>()
        {
            return scope.GetService<T>();
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
