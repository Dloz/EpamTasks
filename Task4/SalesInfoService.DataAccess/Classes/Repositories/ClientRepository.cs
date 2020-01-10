using System;
using System.Linq;
using System.Linq.Expressions;
using SalesInfoService.DAL.Classes.Repositories;
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using SalesInfoService.DataAccess.Interfaces.Repositories;
using SalesInfoService.DataAccess.Models;

namespace SalesInfoService.DataAccess.Classes.Repositories
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

        public int GetId(string clientFirstName, string clientLastName)
        {
            Expression<Func<Client, bool>> predicate = x =>
                x.FirstName == clientFirstName && x.LastName == clientLastName;

            return Find(predicate).First().Id;
        }

        public bool IsClientExists(Client client)
        {
            Expression<Func<Client, bool>> predicate = x =>
                x.Id == client.Id;
            var clients = Find(predicate);
            return clients.Count() != 0;
        }
    }
}
