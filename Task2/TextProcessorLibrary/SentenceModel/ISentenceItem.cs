using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessorLibrary.SentenceModel
{
    /// <summary>
    /// Represents part of the sentence.
    /// </summary>
    public interface ISentenceItem
    {
        /// <summary>
        /// Represents string value of the part of the sentence.
        /// </summary>
        string Value { get; }
    }
}
