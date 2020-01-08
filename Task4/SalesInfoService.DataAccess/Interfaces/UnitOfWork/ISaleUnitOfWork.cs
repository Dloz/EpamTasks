using SalesInfoService.BLL.Classes.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesInfoService.DataAccess.Interfaces.UnitOfWork
{
    interface ISaleUnitOfWork
    {
        void Add(params SaleDto[] models);

        IEnumerable<SaleDto> GetAll();
    }
}
