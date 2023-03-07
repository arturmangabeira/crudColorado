using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace persistence.interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    void Add(TEntity entity);        

    TEntity GetById(params object[] ids);

    IEnumerable<TEntity> GetAll();

    void Update(TEntity entity);
    
    void Remove(TEntity entity);        

    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    int SaveChanges(); 
}