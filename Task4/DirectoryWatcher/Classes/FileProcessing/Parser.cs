using DirectoryWatcher.Interfaces.FileProcessing;
using DirectoryWatcher.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryWatcher.Classes.FileProcessing
{
    internal class Parser : IParser
    {
        public IEnumerable<FileContentModel> ParseFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public IList<string> ParseLine(string fileName, char separator)
        {
            throw new NotImplementedException();
        }
    }
}
