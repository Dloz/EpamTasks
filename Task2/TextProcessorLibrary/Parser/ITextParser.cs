using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TextProcessorLibrary.SentenceModel;
using TextProcessorLibrary.TextModel;

namespace TextProcessorLibrary.Parser
{
    public interface ITextParser: IParser<IText>
    {
        ISentence ParseSentence(string str);
    }
}