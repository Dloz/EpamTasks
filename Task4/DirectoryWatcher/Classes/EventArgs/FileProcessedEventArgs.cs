using System.Collections.Generic;
using SalesInfoService.DataAccess.Models;

namespace DirectoryWatcher.Classes.EventArgs
{
    public class FileProcessedEventArgs: System.EventArgs
    {
        public IEnumerable<Sale> Sales { get; }
        
        public FileProcessedEventArgs(IEnumerable<Sale> sales)
        {
            Sales = sales;
        }
    }
}