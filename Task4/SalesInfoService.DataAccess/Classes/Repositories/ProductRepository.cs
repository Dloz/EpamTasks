using System;
using System.Linq;
using System.Linq.Expressions;
using SalesInfoService.DAL.Classes.Repositories;
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using SalesInfoService.DataAccess.Interfaces.Repositories;
using SalesInfoService.DataAccess.Models;

namespace SalesInfoService.DataAccess.Classes.Repositories
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(SalesInfoContext context) : base(context)
        {

        }

        public void AddUniqueProductToDatabase(Product product)
        {
            Expression<Func<Product, bool>> predicate = x => x.Name == product.Name;

            if (Find(predicate).Any()) return;

            Add(product);
        }

        public int GetId(string productName)
        {
            Expression<Func<Product, bool>> predicate = x => x.Name == productName;

            return Find(predicate).First().Id;
        }

        public bool IsProductExists(Product product)
        {
            Expression<Func<Product, bool>> predicate = x =>
                x.Id == product.Id;
            return Find(predicate).Any();
        }
    }
}
