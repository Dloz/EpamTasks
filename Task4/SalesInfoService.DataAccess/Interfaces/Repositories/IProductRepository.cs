using SalesInfoService.DAL.Interfaces.Repositories;
using SalesInfoService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesInfoService.DataAccess.Interfaces.Repositories
{
    interface IProductRepository : IGenericRepository<Product>
    {
        bool IsProductExists(Product product);

        void AddUniqueProductToDatabase(Product product);

        int GetId(string productName);
    }
}
