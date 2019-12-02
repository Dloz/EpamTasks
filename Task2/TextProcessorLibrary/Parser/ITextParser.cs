using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextProcessorLibrary.Parser
{
    public interface ITextParser: IParser<IText>
    {
        ISentence ParseSentence(string str);
    }
}