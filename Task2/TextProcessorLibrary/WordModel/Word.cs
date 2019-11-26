using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessorLibrary.WordModel
{
    class Word : IWord
    {
        public int Length { get; set; }

        public string Value { get; set; }

        public Word()
        {
            Value = "";
        }

        public Word(string word): this()
        {
            Value = word;
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
