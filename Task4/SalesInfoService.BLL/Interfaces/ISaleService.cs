﻿using System;
using System.Collections.Generic;
using System.Text;
using SalesInfoService.BLL.Models.DataTransferObjects;

namespace SalesInfoService.BLL.Interfaces
{
    interface ISaleService
    {
        bool IsSaleValid(SaleDto saleDto);
    }
}
