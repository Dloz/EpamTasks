using System.Collections.Generic;

namespace TextProcessorLibrary.Configuration
{
    public class GlobalConfiguration
    {
        private readonly IDictionary<string, string> _configurations;
        public ICollection<string> FileNames { get; set; }

        public GlobalConfiguration()
        {
            _configurations = new Dictionary<string, string>();
        }

        public string this[string index] {
            get => _configurations[index];
            set => _configurations[index] = value;
        }

    }
}
