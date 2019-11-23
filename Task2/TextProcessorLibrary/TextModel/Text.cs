using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessorLibrary.TextModel
{
    class Text : IText
    {
        public ICollection<ISentence> Sentences { get; internal set; }
    }
}
