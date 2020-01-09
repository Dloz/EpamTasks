using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryWatcher.Classes.Config
{
    public class DirectoryWatcherConfig
    {
        private readonly IDictionary<string, string> _configurations;

        public DirectoryWatcherConfig()
        {
            _configurations = new Dictionary<string, string>();
        }

        public DirectoryWatcherConfig(IDictionary<string, string> configurations): base()
        {
            _configurations = configurations;
        }

        public string this[string index] {
            get => _configurations[index];
            set => _configurations[index] = value;
        }

    }
}
