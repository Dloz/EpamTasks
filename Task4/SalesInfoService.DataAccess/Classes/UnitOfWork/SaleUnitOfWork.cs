using AutoMapper;
using SalesInfoService.DAL.Classes.Repositories;
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using SalesInfoService.DataAccess.Interfaces.Repositories;
using SalesInfoService.DataAccess.Interfaces.UnitOfWork;
using SalesInfoService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using SalesInfoService.DataAccess.Classes.Repositories;

namespace SalesInfoService.DataAccess.Classes.UnitOfWork
{
    public class SaleUnitOfWork: ISaleUnitOfWork
    {

        private SalesInfoContext _context;
        private ReaderWriterLockSlim _locker;

        private IClientRepository _clients;
        private IManagerRepository _managers;
        private IProductRepository _products;
        private ISaleRepository _sales;


        public SaleUnitOfWork(SalesInfoContext context, ReaderWriterLockSlim locker)
        {
            _context = context;
            _locker = locker;
            
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
                    //sale.Client.Id = _clients.GetId(sale.Client.FirstName, sale.Client.LastName);
                    sale.ClientId = _clients.GetId(sale.Client.FirstName, sale.Client.LastName);
                    sale.Client = null;
                    
                    //sale.Manager.Id = _managers.GetId(sale.Manager.LastName);
                    sale.ManagerId = _managers.GetId(sale.Manager.LastName);
                    sale.Manager = null;
                    
                    //sale.Product.Id = _products.GetId(sale.Product.Name);
                    sale.ProductId = _products.GetId(sale.Product.Name);
                    sale.Product = null;
                    
//                    _context.Entry(sale.Client).State = EntityState.Unchanged;
//                    _context.Entry(sale.Manager).State = EntityState.Unchanged;
//                    _context.Entry(sale.Product).State = EntityState.Unchanged;

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
