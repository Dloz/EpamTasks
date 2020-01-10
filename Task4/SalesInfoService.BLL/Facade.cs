using DirectoryWatcher.Classes.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Threading;
using AutoMapper;
using DirectoryWatcher.Classes.EventArgs;
using SalesInfoService.BLL.Interfaces;
using SalesInfoService.BLL.Models.DataTransferObjects;
using SalesInfoService.BLL.Services;
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using SalesInfoService.DataAccess.Classes.UnitOfWork;
using SalesInfoService.DataAccess.Interfaces.UnitOfWork;
using SalesInfoService.DataAccess.Models;

namespace SalesInfoService.BLL
{
    public class Facade
    {
        private DirectoryWatcherConfig _config;
        private DirectoryWatcher.Facade _facade;
        private ISaleService _saleService;
        private IMapper _mapper;
        private ISaleUnitOfWork _saleUnitOfWork;

        public Facade(string configFilePath = "../../../config.json")
        {
            string json;
            using (var reader = new StreamReader(configFilePath))
            {
                json = reader.ReadToEnd();
            }
            _saleUnitOfWork = new SaleUnitOfWork(new SalesInfoContext(), new ReaderWriterLockSlim());
            _mapper = Classes.AutoMapper.AutoMapper.CreateConfiguration().CreateMapper();
            _saleService = new SaleService();
            _config = new DirectoryWatcherConfig(JsonConvert.DeserializeObject<Dictionary<string, string>>(json));
            _facade = new DirectoryWatcher.Facade(_config);
            _facade.FileProcessedEvent += FileProcessed;
        }

        private void FileProcessed(object sender, FileProcessedEventArgs e)
        {
            var saleDataToSave = new List<Sale>();
            foreach (var sale in e.Sales)
            {
                var saleDto = _mapper.Map<SaleDto>(sale);
                if (_saleService.IsSaleValid(saleDto))
                {
                    saleDataToSave.Add(_mapper.Map<Sale>(saleDto));
                }
                else
                {
                    return;
                }
            }
            
            _saleUnitOfWork.Add(saleDataToSave.ToArray());
            
        }

        public void Run()
        {
            _facade.Run();
        }

        public void Stop()
        {
            _facade.Stop();
        }
    }
}
