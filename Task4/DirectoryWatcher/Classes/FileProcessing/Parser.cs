using CsvHelper;
using DirectoryWatcher.Interfaces.FileProcessing;
using DirectoryWatcher.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IParser = DirectoryWatcher.Interfaces.FileProcessing.IParser;

namespace DirectoryWatcher.Classes.FileProcessing
{
    internal class Parser : IParser
    {
        public IEnumerable<FileContentModel> ParseFile(string filePath)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                var csvReader = new CsvReader(streamReader);

                foreach (var record in csvReader.GetRecords<FileContentModel>())
                {
                    yield return record.Product != string.Empty &&
                                 record.Client != string.Empty &&
                                 record.Date != string.Empty &&
                                 record.Sum != string.Empty
                        ? record
                        : throw new FormatException("File Should Not Contain Empty Fields");
                }
            }
        }

        public IList<string> ParseLine(string line, char separator)
        {
            return line.Split(separator);
        }
    }
}
