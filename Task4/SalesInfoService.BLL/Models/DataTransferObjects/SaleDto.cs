﻿using System;
using SalesInfoService.BLL.Classes.DataTransferObjects;

namespace SalesInfoService.BLL.Models.DataTransferObjects
{
    public class SaleDto : DataTransferObject
    {
        public SaleDto(DateTime date, ClientDto client, ProductDto product, decimal cost, ManagerDto manager)
        {
            Date = date;
            Client = client;
            Product = product;
            Cost = cost;
            Manager = manager;
        }

        public ManagerDto Manager { get; set; }
        public ProductDto Product { get; set; }
        public ClientDto Client { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
    }
}
