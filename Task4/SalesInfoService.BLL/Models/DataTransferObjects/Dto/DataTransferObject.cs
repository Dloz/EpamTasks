using System;
using System.Collections.Generic;
using System.Text;

namespace SalesInfoService.BLL.Classes.DataTransferObjects
{
    public abstract class DataTransferObject
    {
        public int? Id { get; set; } = null;
    }
}
