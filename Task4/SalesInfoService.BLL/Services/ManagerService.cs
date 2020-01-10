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
    internal class ManagerService: IManagerService
    {
        private readonly IManagerRepository _managerRepository;

        public ManagerService()
        {
            _managerRepository = new ManagerRepository(new SalesInfoContext());
        }
        public bool IsManagerValid(ManagerDto managerDto)
        {
            return true;
            var managers = _managerRepository.Find(m => m.LastName == managerDto.LastName);
            return managers.Count() != 0;
        }
    }
}
