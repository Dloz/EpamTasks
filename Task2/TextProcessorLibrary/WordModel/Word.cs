using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TextProcessorLibrary.SentenceModel;

namespace TextProcessorLibrary.WordModel
{
    class Word : IWord
    {
        /// <summary>
        /// Represents length of the word.
        /// </summary>
        public int Length => Value.Length;
        /// <summary>
        /// Represents string value of the part of the sentence.
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Represents word type of sentence item
        /// </summary>
        public SentenceItemType Type => SentenceItemType.Word;
        /// <summary>
        /// Returns bool value whether word started with consonant letter or not.
        /// </summary>
        public bool IsStartedWithConsonant => !Regex.IsMatch(Value, "^[aeiou]");


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
