using System;
using System.Collections.Generic;
using System.Text;

namespace SalesInfoService.BLL.Classes.DataTransferObjects
{
    public class ManagerDto : DataTransferObject
    {
        public string LastName { get; set; }

        public ManagerDto(string lastName)
        {
            LastName = lastName;
        }

    }
}
