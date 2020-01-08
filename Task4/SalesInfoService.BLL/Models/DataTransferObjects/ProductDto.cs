using System;
using System.Collections.Generic;
using System.Text;

namespace SalesInfoService.BLL.Classes.DataTransferObjects
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
