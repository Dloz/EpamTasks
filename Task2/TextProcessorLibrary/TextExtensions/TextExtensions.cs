using System;
using System.Collections.Generic;
using System.Linq;
using TextProcessorLibrary;
using System.Text;

namespace TextProcessorLibrary.TextExtensions
{
    public static class TextExtensions
    {
        public static void ReplaceWord(this IText text, string word, string sequenceToReplace)
        {
            var textParser = new TextParser();
            foreach (var sentence in text.Sentences)
            {
                var sen = text.Sentences.ToList().Find(s => s == sentence);
                sen = textParser.ParseSentence(sentence.ToString().Replace(word, sequenceToReplace));
            }
        }

        public static IEnumerable<IWord> GetWordsFromQuestionSentences(this IText text, int length)
        {
            var output = new List<IWord>();
            foreach (var sentence in text.Sentences)
            {
                if (sentence.Type == SentenceType.Question)
                {
                    foreach (var item in sentence.Items)
                    {
                        if (!output.Contains(item) && item.Length == length && item.Type == SentenceModel.SentenceItemType.Word)
                        {
                            output.Add(item as IWord);
                        }
                    }
                }
            }
            return output.AsEnumerable();
        }

        public static void DeleteWords(this IText text, int length)
        {
            foreach (var sentence in text.Sentences)
            {
                foreach (var word in sentence.Items)
                {
                    if (word.Type == SentenceModel.SentenceItemType.Word && word.Length == length)
                    {
                        sentence.Items.Remove(word);
                    }
                }
            }
        }

        public static IEnumerable<ISentence> OrderSentencesByWordsCount(this IText text)
        {
            return text.Sentences.OrderBy(s => s.WordsCount);
        }
    }
}
