using SalesInfoService.DAL.Classes.Repositories;
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using SalesInfoService.DataAccess.Interfaces.Repositories;
using SalesInfoService.DataAccess.Models;

namespace SalesInfoService.DataAccess.Classes.Repositories
{
    public class SaleRepository: GenericRepository<Sale>, ISaleRepository
    {
        public SaleRepository(SalesInfoContext context) : base(context)
        {

        }
    }
}
