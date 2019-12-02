using System.Collections.Generic;
using TextProcessorLibrary.SentenceModel;

namespace TextProcessorLibrary.TextModel
{
    /// <summary>
    /// Represents whole text.
    /// </summary>
    public interface IText
    {
        /// <summary>
        /// Represents sentences in the text.
        /// </summary>
        IList<ISentence> Sentences { get; set; }
    }
}