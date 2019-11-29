using System;
using System.Collections.Generic;
using System.Text;
using TextProcessorLibrary.SentenceModel;

namespace TextProcessorLibrary
{
    public interface IWord: ISentenceItem
    {
        /// <summary>
        /// Returns bool value whether word started with consonant letter or not.
        /// </summary>
        bool IsStartedWithConsonant { get; }
    }
}