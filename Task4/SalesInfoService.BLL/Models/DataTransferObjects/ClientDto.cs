using System;
using System.Collections.Generic;
using System.Text;

namespace SalesInfoService.BLL.Classes.DataTransferObjects
{
    class ClientDto : DataTransferObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
