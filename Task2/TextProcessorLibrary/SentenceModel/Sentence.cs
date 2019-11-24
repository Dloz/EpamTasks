using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessorLibrary.SentenceModel
{
    class Sentence : ISentence
    {
        public int WordsCount => Words.Count;

        public SentenceType Type => detectSentenceType();

        public ICollection<IWord> Words { get; set; }

        public ISymbol Symbol { get; set; }

        public Sentence()
        {

        }

        public Sentence(ICollection<IWord> words)
        {
            Words = words;
        }

        private SentenceType detectSentenceType()
        {
            switch (Symbol.Value[0].ToString())
            {
                case ".":
                    return SentenceType.Simple;
                case "!":
                    return SentenceType.Exclamatory;
                case "?":
                    return SentenceType.Question;
                default:
                    return SentenceType.None;
            }
        }
    }
}
