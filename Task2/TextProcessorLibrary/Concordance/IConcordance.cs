using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessorLibrary.Concordance
{
    /// <summary>
    /// Represents public parts of Concordance class.
    /// </summary>
    public interface IConcordance
    {
        /// <summary>
        /// Represents dictionary of words in concordance.
        /// </summary>
        SortedDictionary<string, ConcordanceWord> Words { get; }
        void Add(string value, ConcordanceWord word);
        void Add(KeyValuePair<string, ConcordanceWord> keyValue);
        void Add(string word, int lineNumber);
    }
}
