using System;
using System.Collections.Generic;
using System.Linq;
using TextProcessorLibrary;
using System.Text;
using TextProcessorLibrary.Parser;
using System.Text.RegularExpressions;
using TextProcessorLibrary.SentenceModel;
using TextProcessorLibrary.TextModel;
using TextProcessorLibrary.WordModel;

namespace TextProcessorLibrary.TextExtensions
{
    public static class TextExtensions
    {
        public static void ReplaceWord(this IText text, string word, string sequenceToReplace)
        {
            var textParser = new TextParser();
            foreach (var sentence in text.Sentences.ToList())
            {
                var sen = text.Sentences.ToList().Find(s => s == sentence);
                var index = text.Sentences.ToList().IndexOf(sentence);

                sen = textParser.ParseSentence(sentence.ToString().Replace(word, sequenceToReplace));
                text.Sentences[index] = sen;

            }
        }

        public static IEnumerable<IWord> GetWordsFromQuestionSentences(this IText text, int length)
        {
            var output = new List<IWord>();
            foreach (var sentence in text.Sentences)
            {
                if (sentence.Type != SentenceType.Question) continue;
                foreach (var item in sentence.Items)
                {
                    if (!output.Contains(item) && item.Length == length && item.Type == SentenceModel.SentenceItemType.Word)
                    {
                        output.Add(item as IWord);
                    }
                }
            }
            return output.AsEnumerable();
        }

        public static void DeleteWords(this IText text, int length)
        {
            var textParser = new TextParser();
            foreach (var sentence in text.Sentences.ToList())
            {
                foreach (var word in sentence.Items.ToList().Where(word => word.Type == SentenceModel.SentenceItemType.Word && word.Length == length))
                {
                    sentence.Items.Remove(word);
                }
                var completeSentence = sentence.ToString();
                completeSentence = Regex.Replace(completeSentence, @"[ \t]{2,}", " ");
                completeSentence = Regex.Replace(completeSentence, @"^[ ]", string.Empty);
                var index = text.Sentences.ToList().IndexOf(sentence);
                text.Sentences[index] = textParser.ParseSentence(completeSentence);
            }
        }

        public static IEnumerable<ISentence> OrderSentencesByWordsCount(this IText text)
        {
            return text.Sentences.OrderBy(s => s.WordsCount);
        }
    }
}
