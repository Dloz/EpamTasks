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
        /// <summary>
        /// Add word to the concordance.
        /// </summary>
        /// <param name="value">Actual word</param>
        void Add(string value, ConcordanceWord word);
        /// <summary>
        /// Add word to the concordance.
        /// </summary>
        void Add(KeyValuePair<string, ConcordanceWord> keyValue);
        /// <summary>
        /// Add word to the concordance.
        /// </summary>
        void Add(string word, int lineNumber);
    }
}
