using CsvHelper;
using DirectoryWatcher.Interfaces.FileProcessing;
using DirectoryWatcher.Interfaces.Logging;
using DirectoryWatcher.Classes.Config;
using DirectoryWatcher.Models;
using SalesInfoService.DataAccess.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DirectoryWatcher.Classes.EventArgs;
using SalesInfoService.DataAccess.Models;
using IParser = DirectoryWatcher.Interfaces.FileProcessing.IParser;

namespace DirectoryWatcher.Classes.FileProcessing
{
    internal class FileProcessor : IFileProcessor
    {
        private ReaderWriterLockSlim _locker;

        private ISaleUnitOfWork _saleUnitOfWork;
        private IParser _parser;
        private ILogger _logger;
        private DirectoryWatcherConfig _config;
        
        public event EventHandler<FileProcessedEventArgs> FileProcessedEvent;

        public FileProcessor(ISaleUnitOfWork saleUnitOfWork, IParser parser, ILogger logger, ReaderWriterLockSlim locker, DirectoryWatcherConfig config)
        {
            _saleUnitOfWork = saleUnitOfWork;
            _parser = parser;
            _logger = logger;
            _locker = locker;
            _config = config;
        }


        public void ProcessFile(object source, FileSystemEventArgs e)
        {
            
            _logger.WriteLine($"{e.Name} Has Been Added to Directory.");
            var fileNameSplitter = char.Parse(_config["fileNameSplitter"]);

            Task.Run(() =>
            {
                try
                {
                    WriteToDatabase(
                        _parser.ParseFile(e.FullPath),
                        _parser.ParseLine(e.Name, fileNameSplitter).First());

                    Log($"{e.Name} Was Successfully Added to Database");
                }
                catch (HeaderValidationException)
                {
                    Log($"{e.Name} First Line Must Match Template =>" +
                        " Date | Client | Product | Sum");
                }
                catch (FormatException exception)
                {
                    Log($"{e.Name} {exception.Message}");
                }
                catch (ArgumentNullException)
                {
                    Log("Config Must Contain Format of Date Entry" +
                        " and Separator of First and Last Client Name");
                }
                catch (Exception)
                {
                    Log($"{e.Name} AN ERROR HAS OCCURRED, Information is not Added to Database");
                }
            });
        }

        private void Log(string message)
        {
            _locker.EnterWriteLock();
            try
            {
                _logger.WriteLine(message);

            }
            finally
            {
                _locker.ExitWriteLock();
            }
        }

        private void WriteToDatabase(IEnumerable<FileContentModel> sales, string managerLastName)
        {
            var models = CreateModels(sales, managerLastName).ToArray();
            FileProcessedEvent?.Invoke(this, new FileProcessedEventArgs(models));
            // BL reacts and validates
            // BL adds through unitOfWork
            //_saleUnitOfWork.Add(models);
        }

        private IEnumerable<Sale> CreateModels(IEnumerable<FileContentModel> fileContents,
            string managerLastName)
        {
            try
            {
                var dateFormat = _config["dateFormat"];
                var clientNameSplitter = char.Parse(_config["customerNameSplitter"]);

                return (from fileContent in fileContents
                        let date = DateTime.ParseExact(fileContent.Date, dateFormat, null)
                        let clientName = _parser.ParseLine(fileContent.Client, clientNameSplitter)
                        let client = new Client {FirstName =  clientName[0], LastName = clientName[1]}
                        let product = new Product {Name = fileContent.Product}
                        let sum = decimal.Parse(fileContent.Sum)
                        let manager = new Manager {LastName = managerLastName}
                        select new Sale
                        {
                            Date = date, 
                            Client = client, 
                            Product = product,
                            Cost = sum, 
                            Manager = manager
                        })
                    .ToList();
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new FormatException("Customer Field Must Contain First and Last Name");
            }
        }
    }
}
