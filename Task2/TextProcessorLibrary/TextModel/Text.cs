using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessorLibrary.TextModel
{
    /// <summary>
    /// Represents whole text.
    /// </summary>
    public class Text : IText
    {
        /// <summary>
        /// Represents sentences in the text.
        /// </summary>
        public IList<ISentence> Sentences { get; internal set; }

        public Text()
        {
            Sentences = new List<ISentence>();
        }
    }
}
