using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessorLibrary
{
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
        /// Represents actual sentence.
        /// </summary>
        ICollection<IWord> Words { get; }
    }
}