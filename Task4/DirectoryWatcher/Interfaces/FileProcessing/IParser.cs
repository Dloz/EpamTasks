using DirectoryWatcher.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryWatcher.Interfaces.FileProcessing
{
    interface IParser
    {
        IEnumerable<FileContentModel> ParseFile(string filePath);

        IList<string> ParseLine(string fileName, char separator);
    }
}
