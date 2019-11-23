using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessorLibrary
{
    public interface IText
    {
        ICollection<ISentence> Sentences { get; }
    }
}