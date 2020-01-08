
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using SalesInfoService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SalesInfoService.DAL.Classes.Repositories
{
    class ProductRepository: GenericRepository<Product>
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

        public int? GetId(string productName)
        {
            Expression<Func<Product, bool>> predicate = x => x.Name == productName;

            return Find(predicate).First().Id;
        }
    }
}
