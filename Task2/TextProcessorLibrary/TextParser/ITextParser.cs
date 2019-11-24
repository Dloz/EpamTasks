using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextProcessorLibrary
{
    public interface ITextParser
    {
        IText Parse(string str);
        ISentence ParseSentence(string str);
    }
}