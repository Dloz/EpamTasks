using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextProcessorLibrary.SymbolModel;

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
        public IList<ISentenceItem> Items { get; }
        /// <summary>
        /// Represents punctuation sign of the sentence.
        /// </summary>
        private ISymbol PunctuationSign => Items.Last() as ISymbol; // private
        /// <summary>
        /// Represents amount of words in sentence.
        /// </summary>
        public int WordsCount => Items.Count(i => i.Type == SentenceItemType.Word);
        /// <summary>
        /// Represents type of the sentence.
        /// </summary>
        public SentenceType Type { get; }

        public Sentence()
        {
            Items = new List<ISentenceItem>();
        }

        public Sentence(IList<ISentenceItem> items)
        {
            Items = items ?? throw new ArgumentException("Sentence items is null.");
            Type = detectSentenceType();
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            foreach (var item in Items)
            {
                output.Append(item);
            }
            return output.ToString();
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
