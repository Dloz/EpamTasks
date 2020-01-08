using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryWatcher.Interfaces.Logging
{
    public interface ILogger
    {
        void WriteLine(string message);
    }
}
