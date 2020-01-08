using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SalesInfoService.DAL.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(params TEntity[] models);

        void Update(params TEntity[] entities);

        void Remove(params TEntity[] entities);

        TEntity Get(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Save();
    }
}
