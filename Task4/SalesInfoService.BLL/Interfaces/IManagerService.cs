using System;
using System.Collections.Generic;
using System.Text;
using SalesInfoService.BLL.Models.DataTransferObjects;
using SalesInfoService.DataAccess.Models;

namespace SalesInfoService.BLL.Interfaces
{
    interface IManagerService
    {
        bool IsManagerValid(ManagerDto managerDto);
    }
}
