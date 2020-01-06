
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using SalesInfoService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesInfoService.DAL.Classes.Repositories
{
    class ProductRepository: GenericRepository<Product>
    {
        public ProductRepository(SalesInfoContext context) : base(context)
        {

        }
    }
}
