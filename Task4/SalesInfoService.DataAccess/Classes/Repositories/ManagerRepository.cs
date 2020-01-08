
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using SalesInfoService.DataAccess.Interfaces.Repositories;
using SalesInfoService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SalesInfoService.DAL.Classes.Repositories
{
    class ManagerRepository: GenericRepository<Manager>, IManagerRepository
    {
        public ManagerRepository(SalesInfoContext context) : base(context)
        {

        }

        public void AddUniqueManagerToDatabase(Manager manager)
        {
            Expression<Func<Manager, bool>> predicate = x => x.LastName == manager.LastName;

            if (Find(predicate).Any()) return;

            Add(manager);
        }

        public int GetId(string managerLastName)
        {
            Expression<Func<Manager, bool>> predicate = x => x.LastName == managerLastName;

            return Find(predicate).First().Id;
        }

        public bool IsManagerExists(Manager manager)
        {
            Expression<Func<Manager, bool>> predicate = x =>
                x.Id == manager.Id;
            return Find(predicate).Any();
        }
    }
}
