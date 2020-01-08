using CsvHelper;
using DirectoryWatcher.Interfaces.FileProcessing;
using DirectoryWatcher.Interfaces.Logging;
using DirectoryWatcher.Models;
using SalesInfoService.BLL.Classes.DataTransferObjects;
using SalesInfoService.DataAccess.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IParser = DirectoryWatcher.Interfaces.FileProcessing.IParser;

namespace DirectoryWatcher.Classes.FileProcessing
{
    internal class FileProcessor : IFileProcessor
    {
        private ReaderWriterLockSlim Locker { get; }

        private ISaleUnitOfWork SaleUnitOfWork { get; }
        private IParser Parser { get; }
        private ILogger Logger { get; }

        public FileProcessor(ISaleUnitOfWork saleUnitOfWork, IParser parser, ILogger logger, ReaderWriterLockSlim locker)
        {
            SaleUnitOfWork = saleUnitOfWork;
            Parser = parser;
            Logger = logger;
            Locker = locker;
        }

        public void ProcessFile(object source, FileSystemEventArgs e)
        {
            
            Logger.WriteLine($"{e.Name} Has Been Added to Directory.");
            var fileNameSplitter = char.Parse(ConfigurationManager.AppSettings["fileNameSplitter"]);

            Task.Run(() =>
            {
                try
                {
                    WriteToDatabase(
                        Parser.ParseFile(e.FullPath),
                        Parser.ParseLine(e.Name, fileNameSplitter).First());

                    Log($"{e.Name} Was Successfully Added to Database");
                }
                catch (HeaderValidationException)
                {
                    Log($"{e.Name} First Line Must Match Template =>" +
                        " Date | Customer | Product | Sum");
                }
                catch (FormatException exception)
                {
                    Log($"{e.Name} {exception.Message}");
                }
                catch (ArgumentNullException)
                {
                    Log("AppConfig Must Contain Format of Date Entry" +
                        " and Separator of First and Last Customer Name");
                }
                catch (Exception)
                {
                    Log($"{e.Name} AN ERROR OCCURRED, Information is not Added to Database");
                }
            });
        }

        private void Log(string message)
        {
            Locker.EnterWriteLock();
            try
            {
                Logger.WriteLine(message);

            }
            finally
            {
                Locker.ExitWriteLock();
            }
        }

        private void WriteToDatabase(IEnumerable<FileContentModel> sales, string managerLastName)
        {
            var dtos = CreateDataTransferObjects(sales, managerLastName).ToArray();
            SaleUnitOfWork.Add();
        }

        private IEnumerable<SaleDto> CreateDataTransferObjects(IEnumerable<FileContentModel> fileContents,
            string managerLastName)
        {
            try
            {
                var dateFormat = ConfigurationManager.AppSettings["dateFormat"];
                var customerNameSplitter = char.Parse(ConfigurationManager.AppSettings["customerNameSplitter"]);

                return (from fileContent in fileContents
                        let date = DateTime.ParseExact(fileContent.Date, dateFormat, null)
                        let customerName = Parser.ParseLine(fileContent.Customer, customerNameSplitter)
                        let customerDto = new ClientDto(customerName[0], customerName[1])
                        let productDto = new ProductDto(fileContent.Product)
                        let sum = decimal.Parse(fileContent.Sum)
                        let managerDto = new ManagerDto(managerLastName)
                        select new SaleDto(date, customerDto, productDto, sum, managerDto))
                    .ToList();
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new FormatException("Customer Field Must Contain First and Last Name");
            }
        }
    }
}
