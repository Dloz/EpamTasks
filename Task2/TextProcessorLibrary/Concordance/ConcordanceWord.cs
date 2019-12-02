using System;
using System.Collections.Generic;
using System.Text;
using TextProcessorLibrary.WordModel;

namespace TextProcessorLibrary.Concordance
{
    public class ConcordanceWord
    {
        public ICollection<int> Lines { get; } 
        public int Count { get; set; }

        public ConcordanceWord(ICollection<int> lines): this()
        {
            Lines = lines;
        }
        /// <summary>
        /// Initializes first word.
        /// </summary>
        /// <param name="lineNumber"></param>
        public ConcordanceWord(int lineNumber): this()
        {
            Lines.Add(lineNumber);
        }

        public ConcordanceWord()
        {
            Count = 1;
            Lines = new List<int>();
        }

        public void AddLineNumber(int lineNumber)
        {
            Lines.Add(lineNumber);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var line in Lines)
            {
                sb.Append($" {line}");
            }
            return $"{Count}:{sb.ToString()}";
        }
    }
}
