using DirectoryWatcher.Interfaces.FileProcessing;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryWatcher.Interfaces.DirectoryWatchers
{
    interface IDirectoryWatcher
    {
        void Run(IFileProcessor fileHandler);

        void Stop(IFileProcessor fileHandler);
    }
}
