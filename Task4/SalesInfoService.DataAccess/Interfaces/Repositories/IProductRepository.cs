using SalesInfoService.DAL.Interfaces.Repositories;
using SalesInfoService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesInfoService.DataAccess.Interfaces.Repositories
{
    interface IProductRepository : IGenericRepository<Product>
    {
        void AddUniqueProductToDatabase(Product product);

        int? GetId(string productName);
    }
}
