using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessorLibrary
{
    public class GlobalConfiguration
    {
        private IDictionary<string, string> _configurations;
        public ICollection<string> FileNames { get; set; }

        public GlobalConfiguration()
        {
            _configurations = new Dictionary<string, string>();
        }

        public string this[string index] {
            get {
                return _configurations[index];
            }
            set {
                _configurations[index] = value;
            }
        }

    }
}
