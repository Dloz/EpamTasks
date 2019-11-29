using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessorLibrary.Concordance
{
    class Concordance : IConcordance
    {
        public SortedDictionary<string, ConcordanceWord> Words { get; set; }

        public void Add(string key, ConcordanceWord value)
        {
            Words.Add(key, value);
        }

        public void Add(KeyValuePair<string, ConcordanceWord> keyValue)
        {
            Words.Add(keyValue.Key, keyValue.Value);
        }
    }
}
