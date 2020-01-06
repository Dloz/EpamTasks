using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;
using SalesInfoService.DataAccess.Models;
using SalesInfoService.DataAccess.Classes.SalesDbContext;

namespace SalesInfoService.DAL.Classes.Repositories
{
    public class ClientRepository: GenericRepository<Client>
    {
        public ClientRepository(SalesInfoContext context): base(context)
        {

        }

        public int? GetId(string customerFirstName, string customerLastName)
        {
            //Func<Client, bool> predicate = x =>
            //    x.FirstName == customerFirstName && x.LastName == customerLastName;

            //return _dbSet.Find(predicate).First().Id;
            return 0;
        }
    }
}
