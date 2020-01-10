using SalesInfoService.DAL.Interfaces.Repositories;
using SalesInfoService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesInfoService.DataAccess.Interfaces.Repositories
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
    }
}
