using System;
using System.Collections.Generic;
using System.Text;

namespace SalesInfoService.BLL.Classes.DataTransferObjects
{
    class SaleDto : DataTransferObject
    {
        public ManagerDto Manager { get; set; }
        public ProductDto Product { get; set; }
        public ClientDto Client { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
    }
}
