using Microsoft.EntityFrameworkCore;
using SalesInfoService.DAL.Interfaces.Repositories;
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SalesInfoService.DAL.Classes.Repositories
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity: class
    {
        protected readonly SalesInfoContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(SalesInfoContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
               

        public void Add(params TEntity[] models)
        {
            foreach (var item in models)
            {
                _dbSet.Add(item);
                _context.SaveChanges();
            }
        }

        public void Update(params TEntity[] entities)
        {
            foreach (var item in entities)
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Remove(params TEntity[] entities)
        {
            foreach (var item in entities)
            {
                _dbSet.Remove(item);
                _context.SaveChanges();
            }
        }

        public TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
