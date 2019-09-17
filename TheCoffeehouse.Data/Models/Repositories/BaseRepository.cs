using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheCoffeehouse.Data.Models.Repositories
{
    public interface IBaseRepository<E,K> where E : class
    {
        IQueryable<E> GetAll();
        E Create(E entity);
        E Delete(E entity);
        E Update(E entity);
        E GetById(K id);

    }

    public abstract class BaseRepository<E, K> : IBaseRepository<E, K> where E : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<E> _dbSet;
        public BaseRepository(DbContext context)
        {
            _context = context;

            _dbSet = _context.Set<E>();
        }

        public E Create(E entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public E Delete(E entity)
        {
            _dbSet.Remove(entity);
            return entity;
        }

        public IQueryable<E> GetAll()
        {
            return _dbSet;
        }

        public abstract E GetById(K id);


        public E Update(E entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }

}
