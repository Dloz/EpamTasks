using SalesInfoService.DAL.Interfaces.Repositories;
using SalesInfoService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesInfoService.DataAccess.Interfaces.Repositories
{
    interface IManagerRepository: IGenericRepository<Manager>
    {
        bool IsManagerExists(Manager manager);

        void AddUniqueManagerToDatabase(Manager manager);

        int GetId(string managerLastName);
    }
}
