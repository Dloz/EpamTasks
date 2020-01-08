using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DirectoryWatcher.Interfaces.FileProcessing
{
    interface IFileProcessor
    {
        void ProcessFile(object source, FileSystemEventArgs e);
    }
}
