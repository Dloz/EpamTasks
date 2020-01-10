using SalesInfoService.BLL.Classes.DataTransferObjects;

namespace SalesInfoService.BLL.Models.DataTransferObjects
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
