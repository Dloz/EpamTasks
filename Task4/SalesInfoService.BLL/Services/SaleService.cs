using System;
using System.Collections.Generic;
using System.Text;
using SalesInfoService.BLL.Interfaces;
using SalesInfoService.BLL.Models.DataTransferObjects;
using SalesInfoService.DataAccess.Classes.Repositories;
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using SalesInfoService.DataAccess.Interfaces.Repositories;

namespace SalesInfoService.BLL.Services
{
    internal class SaleService: ISaleService
    {
        private ISaleRepository _saleRepository;
        private readonly IClientService _clientService;
        private readonly IManagerService _managerService;
        private readonly IProductService _productService;

        public SaleService()
        {
            _saleRepository = new SaleRepository(new SalesInfoContext());
            _clientService  = new ClientService();
            _managerService = new ManagerService();
            _productService = new ProductService();
        }
        public bool IsSaleValid(SaleDto saleDto)
        {
            return _clientService.IsClientValid(saleDto.Client) &&
                   _managerService.IsManagerValid(saleDto.Manager) && 
                    _productService.IsProductValid(saleDto.Product);
        }
    }
}
