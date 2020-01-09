using DirectoryWatcher.Interfaces.FileProcessing;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryWatcher.Interfaces.DirectoryWatchers
{
    interface IDirectoryWatcher
    {
        void Run(IFileProcessor fileProcessor);

        void Stop(IFileProcessor fileProcessor);
    }
}
