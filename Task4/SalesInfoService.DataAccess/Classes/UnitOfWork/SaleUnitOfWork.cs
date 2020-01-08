using SalesInfoService.BLL.Classes.DataTransferObjects;
using SalesInfoService.DAL.Classes.Repositories;
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using SalesInfoService.DataAccess.Interfaces.Repositories;
using SalesInfoService.DataAccess.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SalesInfoService.DataAccess.Classes.UnitOfWork
{
    class SaleUnitOfWork: ISaleUnitOfWork
    {
        
        private SalesInfoContext Context { get; }
        private ReaderWriterLockSlim Locker { get; }

        private IClientRepository Clients { get; }
        private IManagerRepository Managers { get; }
        private IProductRepository Products { get; }
        private ISaleRepository Sales { get; }

        public SaleUnitOfWork(SalesInfoContext context, ReaderWriterLockSlim locker)
        {
            Context = context;
            Locker = locker;

            var mapper = AutoMapper.CreateConfiguration().CreateMapper();
            Clients = new ClientRepository(Context, mapper);
            Managers = new ManagerRepository(Context, mapper);
            Products = new ProductRepository(Context, mapper);
            Sales = new SaleRepository(Context, mapper);
        }

        public void Add(params SaleDto[] sales)
        {
            Locker.EnterWriteLock();
            try
            {
                foreach (var sale in sales)
                {
                    Clients.AddUniqueCustomerToDatabase(sale.Customer);
                    Clients.Save();
                    sale.Customer.Id = Clients.GetId(sale.Customer.FirstName, sale.Customer.LastName);

                    Managers.AddUniqueManagerToDatabase(sale.Manager);
                    Managers.Save();
                    sale.Manager.Id = Managers.GetId(sale.Manager.LastName);

                    Products.AddUniqueProductToDatabase(sale.Product);
                    Products.Save();
                    sale.Product.Id = Products.GetId(sale.Product.Name);

                    Sales.Add(sale);
                    Sales.Save();
                }
            }
            finally
            {
                Locker.ExitWriteLock();
            }
        }

        public IEnumerable<SaleDto> GetAll()
        {
            return Sales.GetAll();
        }
    }
}
