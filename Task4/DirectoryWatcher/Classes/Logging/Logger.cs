using DirectoryWatcher.Interfaces.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace DirectoryWatcher.Classes.Logging
{
    internal class Logger : ILogger
    {
        private static string _logFilesPath; // TODO add global config.

        private const string DefaultFilePath = @"..\..\..\log.txt";

        public void WriteLine(string message)
        {
            if (string.IsNullOrEmpty(message)) return;

            try
            {
                using (var streamWriter = new StreamWriter(_logFilesPath, true))
                {
                    streamWriter.WriteLine(
                        $"{DateTime.Now.ToString(CultureInfo.InvariantCulture) + ":",-21} {message}");
                }
            }
            catch (ArgumentNullException)
            {
                _logFilesPath = DefaultFilePath;

                WriteLine(message);
            }
            catch (Exception)
            {
                // Notify User Without Stopping Work
            }
        }
    }
}
