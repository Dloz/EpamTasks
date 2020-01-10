using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DirectoryWatcher.Classes.EventArgs;

namespace DirectoryWatcher.Interfaces.FileProcessing
{
    public interface IFileProcessor
    {
        event EventHandler<FileProcessedEventArgs> FileProcessedEvent;
        void ProcessFile(object source, FileSystemEventArgs e);
    }
}
