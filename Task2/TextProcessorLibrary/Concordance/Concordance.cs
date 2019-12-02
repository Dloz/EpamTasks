using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessorLibrary.Concordance
{
    public class Concordance : IConcordance
    {
        private const string EmptyStringExceptionMessage = "String passed through is null or empty";
        public SortedDictionary<string, ConcordanceWord> Words { get; set; }

        public Concordance()
        {
            Words = new SortedDictionary<string, ConcordanceWord>();
        }

        public void Add(string key, ConcordanceWord value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException(EmptyStringExceptionMessage);
            }

            if (!Words.ContainsKey(key))
            {
                Words[key] = value;
            }
            Words[key].Count++;
        }

        public void Add(KeyValuePair<string, ConcordanceWord> keyValue)
        {
            Add(keyValue.Key, keyValue.Value);
        }

        public void Add(string word, int lineNumber)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException(EmptyStringExceptionMessage);
            }
            // Capitalize first letters of words.
            var sb = new StringBuilder(word) {[0] = char.ToUpper(word[0])};
            word = sb.ToString();

            if (Words.ContainsKey(word))
            {
                if (!Words[word].Lines.Contains(lineNumber))
                {
                    Words[word].Lines.Add(lineNumber);
                }
                Words[word].Count++;
                return;
            }
            Words.Add(word, new ConcordanceWord(lineNumber));
        }
    }
}
