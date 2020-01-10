using SalesInfoService.BLL.Classes.DataTransferObjects;

namespace SalesInfoService.BLL.Models.DataTransferObjects
{
    public class ProductDto : DataTransferObject
    {
        public string Name { get; set; }

        public ProductDto(string name)
        {
            Name = name;
        }

    }
}
