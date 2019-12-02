using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TextProcessorLibrary.SentenceModel;

namespace TextProcessorLibrary.WordModel
{
    public class Word : IWord
    {
        private const string EmptyStringExceptionMessage = "String passed through is null or empty";

        /// <summary>
        /// Represents length of the word.
        /// </summary>
        public int Length => Value.Length;
        /// <summary>
        /// Represents string value of the part of the sentence.
        /// </summary>
        public string Value { get; }
        /// <summary>
        /// Represents word type of sentence item
        /// </summary>
        public SentenceItemType Type => SentenceItemType.Word;
        /// <summary>
        /// Returns bool value whether word started with consonant letter or not.
        /// </summary>
        public bool IsStartedWithConsonant => !Regex.IsMatch(Value.ToLower(), "^[aeiou]");


        public Word()
        {
            Value = "";
        }

        public Word(string word): this()
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException(EmptyStringExceptionMessage);
            }
            Value = word;
        }

        public override string ToString()
        {
            return $"{Value}";
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Word word)
            {
                return Value.Equals(word.Value);
            }
            return base.Equals(obj);
        }
    }
}
