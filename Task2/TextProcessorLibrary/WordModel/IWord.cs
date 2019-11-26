using System;
using System.Collections.Generic;
using System.Text;
using TextProcessorLibrary.SentenceModel;

namespace TextProcessorLibrary
{
    public interface IWord: ISentenceItem
    {
        int Length { get; }
    }
}