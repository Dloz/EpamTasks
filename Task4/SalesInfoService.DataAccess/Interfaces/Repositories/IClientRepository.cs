using SalesInfoService.DAL.Interfaces.Repositories;
using SalesInfoService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesInfoService.DataAccess.Interfaces.Repositories
{
    public interface IClientRepository: IGenericRepository<Client>
    {
        bool IsClientExists(Client client);

        void AddUniqueClientToDatabase(Client client);

        int GetId(string clientFirstName, string clientLastName);
    }
}
