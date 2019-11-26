using System;
using System.Collections.Generic;
using System.Text;
using TextProcessorLibrary.SentenceModel;

namespace TextProcessorLibrary
{
    /// <summary>
    /// Represents one sentence in the text.
    /// </summary>
    public interface ISentence
    {
        /// <summary>
        /// Represents amount of words in sentence.
        /// </summary>
        int WordsCount { get; }
        /// <summary>
        /// Represents type of the sentence.
        /// </summary>
        SentenceType Type { get; }
        /// <summary>
        /// Represents words and symbols at the sentence.
        /// </summary>
        IList<ISentenceItem> Items { get; }
        /// <summary>
        /// Represents punctuation sign of the sentence.
        /// </summary>
        ISymbol PunctuationSign { get; }
    }
}