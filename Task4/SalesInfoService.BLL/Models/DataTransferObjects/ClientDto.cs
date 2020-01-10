using SalesInfoService.BLL.Classes.DataTransferObjects;

namespace SalesInfoService.BLL.Models.DataTransferObjects
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
