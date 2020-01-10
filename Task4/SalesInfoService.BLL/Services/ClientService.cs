using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesInfoService.BLL.Interfaces;
using SalesInfoService.BLL.Models.DataTransferObjects;
using SalesInfoService.DataAccess.Classes.Repositories;
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using SalesInfoService.DataAccess.Interfaces.Repositories;

namespace SalesInfoService.BLL.Services
{
    internal class ClientService: IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService()
        {
            _clientRepository = new ClientRepository(new SalesInfoContext());
        }
        public bool IsClientValid(ClientDto clientDto)
        {
            return true;
            var clients = _clientRepository.Find(c => c.FirstName == clientDto.FirstName && c.LastName == clientDto.LastName);
            return clients.Count() != 0;
        }
    }
}
