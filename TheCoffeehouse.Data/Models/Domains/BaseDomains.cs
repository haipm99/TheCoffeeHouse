using System;
using System.Collections.Generic;
using System.Text;
using TheCoffeehouse.Data.Models.Uow;

namespace TheCoffeehouse.Data.Models.Domains
{
    public abstract class BaseDomains
    {
        protected readonly IUnitOfWork uow;

        public BaseDomains(IUnitOfWork uow)
        {
            this.uow = uow;
        }
    }
}
