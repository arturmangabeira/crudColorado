using persistence.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace persistence
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected AppDbContext _context;
        protected DbSet<TEntity> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }        

        public TEntity GetById(params object[] ids)
        {
            return _dbSet.Find(ids);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
        
        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }        

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();   
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}