using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;
using SalesInfoService.DataAccess.Models;
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using SalesInfoService.DataAccess.Interfaces.Repositories;

namespace SalesInfoService.DAL.Classes.Repositories
{
    public class ClientRepository: GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(SalesInfoContext context): base(context)
        {

        }

        public void AddUniqueClientToDatabase(Client client)
        {
            Expression<Func<Client, bool>> predicate = x =>
                x.LastName == client.LastName && x.FirstName == client.FirstName;

            if (Find(predicate).Any()) return;

            Add(client);
        }

        public int? GetId(string clientFirstName, string clientLastName)
        {
            Expression<Func<Client, bool>> predicate = x =>
                x.FirstName == clientFirstName && x.LastName == clientLastName;

            return Find(predicate).First().Id;
        }
    }
}
