using DirectoryWatcher.Interfaces.FileProcessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DirectoryWatcher.DirectoryWatchers
{
    public class DirectoryWatcher
    {
        private FileSystemWatcher _fileSystemWatcher;

        private ILogger _logger;

        public DirectoryWatcher(string directoryPath, string filesFilter, ILogger logger)
        {
            try
            {
                _logger = logger;

                _fileSystemWatcher = new FileSystemWatcher
                {
                    Path = directoryPath,
                    Filter = filesFilter,

                    NotifyFilter = NotifyFilters.LastAccess
                                   | NotifyFilters.LastWrite
                                   | NotifyFilters.FileName
                                   | NotifyFilters.DirectoryName
                };
            }
            catch (ArgumentException)
            {
                _logger.WriteLine("Check out Path to Directory to Track in AppConfig file.");
            }
        }

        public void Run(IFileProcessor fileProcessor)
        {
            try
            {
                _fileSystemWatcher.Created += fileProcessor.ProcessFile;

                _fileSystemWatcher.EnableRaisingEvents = true;
            }
            catch (ArgumentNullException)
            {
                _logger.WriteLine("Set Path to Directory to Track in AppConfig file.");
            }
            catch (Exception)
            {
                _logger.WriteLine("AN ERROR HAS OCCURRED! Check AppConfig file.");
            }
        }

        public void Stop(IFileProcessor fileProcessor)
        {
            _fileSystemWatcher.Created -= fileProcessor.ProcessFile;

            _fileSystemWatcher.EnableRaisingEvents = false;
        }

    }
}

