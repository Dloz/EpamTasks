﻿using AutoMapper;
using SalesInfoService.BLL.Classes.DataTransferObjects;
using SalesInfoService.BLL.Models.DataTransferObjects;
using SalesInfoService.DataAccess.Models;

namespace SalesInfoService.BLL.Classes.AutoMapper
{
    internal static class AutoMapper
    {
        internal static MapperConfiguration CreateConfiguration()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Client, ClientDto>();
                config.CreateMap<ClientDto, Client>();

                config.CreateMap<Product, ProductDto>();
                config.CreateMap<ProductDto, Product>();

                config.CreateMap<Manager, ManagerDto>();
                config.CreateMap<ManagerDto, Manager>();

                config.CreateMap<Sale, SaleDto>();
                config.CreateMap<SaleDto, Sale>();
            });
        }
    }
}
