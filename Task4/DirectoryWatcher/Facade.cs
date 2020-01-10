using System;
using System.Collections.Generic;
using System.Threading;
using DirectoryWatcher.Classes.FileProcessing;
using DirectoryWatcher.Classes.Logging;
using DirectoryWatcher.Interfaces.DirectoryWatchers;
using DirectoryWatcher.Interfaces.FileProcessing;
using DirectoryWatcher.Interfaces.Logging;
using DirectoryWatcher.Classes.Config;
using DirectoryWatcher.Classes.EventArgs;
using SalesInfoService.DataAccess.Classes.SalesDbContext;
using SalesInfoService.DataAccess.Classes.UnitOfWork;
using SalesInfoService.DataAccess.Interfaces.UnitOfWork;
using SalesInfoService.DataAccess.Models;

namespace DirectoryWatcher
{
    public class Facade
    {
        private SalesInfoContext _context;
        private ReaderWriterLockSlim _locker;

        private IDirectoryWatcher _directoryWatcher;
        private ISaleUnitOfWork _saleUnitOfWork;
        private IParser _parser;
        private ILogger _logger;
        private IFileProcessor _fileProcessor;

        public event EventHandler<FileProcessedEventArgs> FileProcessedEvent;

        public Facade(DirectoryWatcherConfig config)
        {
            _context = new SalesInfoContext();

            _locker = new ReaderWriterLockSlim();

            _logger = new Logger();

            _directoryWatcher = new Classes.DirectoryWatchers.DirectoryWatcher(config["directoryPath"],config["filesFilter"], _logger);

            _saleUnitOfWork = new SaleUnitOfWork(_context, _locker);

            _parser = new Parser();

            _fileProcessor = new FileProcessor(_saleUnitOfWork, _parser, _logger, _locker, config);
            _fileProcessor.FileProcessedEvent += OnFileProcessedEvent;
        }

        private void OnFileProcessedEvent(object sender, FileProcessedEventArgs e)
        {
            FileProcessedEvent?.Invoke(sender, e);
        }

        public void Run()
        {
            _directoryWatcher.Run(_fileProcessor);
        }

        public void Stop()
        {
            _directoryWatcher.Stop(_fileProcessor);
        }

        public IEnumerable<Sale> ShowAllSales()
        {
            return _saleUnitOfWork.GetAll();
        }
    }
}
