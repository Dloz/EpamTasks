
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using SalesInfoService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesInfoService.DAL.Classes.Repositories
{
    class SaleRepository: GenericRepository<Sale>
    {
        public SaleRepository(SalesInfoContext context) : base(context)
        {

        }
    }
}
