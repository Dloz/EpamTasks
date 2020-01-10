using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesInfoService.BLL.Interfaces;
using SalesInfoService.BLL.Models.DataTransferObjects;
using SalesInfoService.DataAccess.Classes.Repositories;
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using SalesInfoService.DataAccess.Interfaces.Repositories;

namespace SalesInfoService.BLL.Services
{
    internal class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository(new SalesInfoContext());
        }
        
        public bool IsProductValid(ProductDto productDto)
        {
            return true;
            var products = _productRepository.Find(p => p.Name == productDto.Name);
            return products.Count() != 0;
        }
    }
}
