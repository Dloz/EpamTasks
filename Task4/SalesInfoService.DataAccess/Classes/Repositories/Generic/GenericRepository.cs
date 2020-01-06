using Microsoft.EntityFrameworkCore;
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesInfoService.DAL.Classes.Repositories
{
    public class GenericRepository<TEntity> where TEntity: class
    {
        protected readonly SalesInfoContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(SalesInfoContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
    }
}
