using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessorLibrary
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