using System;
using System.Collections.Generic;
using System.Text;

namespace SalesInfoService.BLL.Classes.DataTransferObjects
{
    public class ClientDto : DataTransferObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ClientDto(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }


    }
}
