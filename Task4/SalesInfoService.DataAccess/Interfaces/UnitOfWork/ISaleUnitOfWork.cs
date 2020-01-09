
using SalesInfoService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesInfoService.DataAccess.Interfaces.UnitOfWork
{
    public interface ISaleUnitOfWork
    {
        void Add(params Sale[] models);

        IEnumerable<Sale> GetAll();
    }
}
