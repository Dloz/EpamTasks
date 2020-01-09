using DirectoryWatcher.Classes.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalesInfoService.BLL
{
    class Facade
    {
        private DirectoryWatcherConfig _config;
        private DirectoryWatcher.Facade _facade;

        public Facade(string configFilePath = "../../config.json")
        {
            string json = string.Empty;
            using (var reader = new StreamReader(configFilePath))
            {
                json = reader.ReadToEnd();
            }
            _config = new DirectoryWatcherConfig(JsonConvert.DeserializeObject<Dictionary<string, string>>(json));
            _facade = new DirectoryWatcher.Facade(_config["directoryPath"], _config["filesFilter"]);
        }

        public void Run()
        {
            _facade.Run();
        }

        public void Stop()
        {
            _facade.Stop();
        }
    }
}
