using AutoMapper;
using SalesInfoService.BLL.Classes.DataTransferObjects;
using SalesInfoService.DAL.Classes.Repositories;
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using SalesInfoService.DataAccess.Interfaces.Repositories;
using SalesInfoService.DataAccess.Interfaces.UnitOfWork;
using SalesInfoService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SalesInfoService.DataAccess.Classes.UnitOfWork
{
    class SaleUnitOfWork: ISaleUnitOfWork
    {

        private SalesInfoContext _context;
        private ReaderWriterLockSlim _locker;

        private IClientRepository _clients;
        private IManagerRepository _managers;
        private IProductRepository _products;
        private ISaleRepository _sales;

        private IMapper _mapper;

        public SaleUnitOfWork(SalesInfoContext context, ReaderWriterLockSlim locker)
        {
            _context = context;
            _locker = locker;
            
            var mapper = AutoMapper.CreateConfiguration().CreateMapper();
            _clients = new ClientRepository(_context);
            _managers = new ManagerRepository(_context);
            _products = new ProductRepository(_context);
            _sales = new SaleRepository(_context);
        }

        public void Add(params Sale[] sales)
        {
            _locker.EnterWriteLock();
            try
            {
                foreach (var sale in sales)
                {
                    
                }
                foreach (var sale in sales)
                {
                    _clients.AddUniqueCustomerToDatabase(sale.Client);
                    _clients.Save();
                    sale.Client.Id = _clients.GetId(sale.Client.FirstName, sale.Client.LastName);

                    _managers.AddUniqueManagerToDatabase(sale.Manager);
                    _managers.Save();
                    sale.Manager.Id = _managers.GetId(sale.Manager.LastName);

                    _products.AddUniqueProductToDatabase(sale.Product);
                    _products.Save();
                    sale.Product.Id = _products.GetId(sale.Product.Name);

                    _sales.Add(sale);
                    _sales.Save();
                }
            }
            finally
            {
                _locker.ExitWriteLock();
            }
        }

        public IEnumerable<Sale> GetAll()
        {
            return _sales.GetAll();
        }
    }
}
