using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextProcessorLibrary.SentenceModel
{
    /// <summary>
    /// Represents one sentence in the text.
    /// </summary>
    internal class Sentence : ISentence
    {
        /// <summary>
        /// Represents words and symbols at the sentence.
        /// </summary>
        public IList<ISentenceItem> Items { get; set; }
        /// <summary>
        /// Represents punctuation sign of the sentence.
        /// </summary>
        public ISymbol PunctuationSign { get; set; }
        /// <summary>
        /// Represents amount of words in sentence.
        /// </summary>
        public int WordsCount => Items.Where(i => i is IWord).Count();
        /// <summary>
        /// Represents type of the sentence.
        /// </summary>
        public SentenceType Type => detectSentenceType();

        public Sentence()
        {
            Items = new List<ISentenceItem>();
        }

        public Sentence(IList<ISentenceItem> items)
        {
            Items = items;
        }

        private SentenceType detectSentenceType()
        {
            switch (PunctuationSign.Value[0].ToString())
            {
                case ".":
                    return SentenceType.Simple;
                case "!":
                    return SentenceType.Exclamatory;
                case "?":
                    return SentenceType.Question;
                default:
                    return SentenceType.None;
            }
        }
    }
}
