using System;
using System.IO;
using TextProcessorLibrary;
using TextProcessorLibrary.TextModel;
using TextProcessorLibrary.TextExtensions;
using TextProcessorLibrary.Concordance;
using TextProcessorLibrary.Concordance.Parser;
using TextProcessorLibrary.Parser;
using Newtonsoft.Json;
using System.Collections.Generic;
using TextProcessorLibrary.TextSerializer;
using TextProcessorLibrary.TextModelIO;

namespace TextProcessorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IText text = new Text();
                IConcordance concordance = new Concordance();
                ConcordanceParser concordanceParser = new ConcordanceParser();
                var configuration = new GlobalConfiguration();

                if (args.Length != 0)
                {
                    configuration.FileNames = args;
                }
                else
                {
                    using (var reader = new StreamReader("../../../config.json"))
                    {

                        string json = reader.ReadToEnd();
                        configuration = JsonConvert.DeserializeObject<GlobalConfiguration>(json);
                    }
                }


                foreach (var fileName in configuration.FileNames)
                {
                    using (var stream = new StreamReader(new FileStream(fileName, FileMode.Open)))
                    {
                        var textParser = new TextParser();
                        var textReader = new TextModelReader(stream);
                        text = textParser.ParseText(textReader.ReadAllText());
                    }
                }

                foreach (var fileName in configuration.FileNames)
                {
                    using (var stream = new StreamReader(new FileStream(fileName, FileMode.Open)))
                    {
                        var textParser = new TextParser();
                        var textReader = new TextModelReader(stream);
                        concordance = concordanceParser.ParseText(textReader.ReadAllText());
                    }
                }

                var jsonText = JsonTextSerializer.Serialize(text);
                var jsonConc = JsonTextSerializer.Serialize(concordance);

                using (StreamWriter writer = new StreamWriter("../../../text.json"))
                {
                    var textModelWriter = new TextModelWriter(writer);
                    textModelWriter.Write(jsonText);
                }

                using (StreamWriter writer = new StreamWriter("../../../concordance.json"))
                {
                    var textModelWriter = new TextModelWriter(writer);
                    textModelWriter.Write(jsonConc);
                }
                Console.WriteLine();
                Console.WriteLine("----Select words from question sentences with length 10------------------------");
                Console.WriteLine();
                foreach (var word in text.GetWordsFromQuestionSentences(10))
                {
                    Console.WriteLine(word);
                }
                Console.WriteLine();
                Console.WriteLine("----Order sentences by words count-------------------------");
                Console.WriteLine();
                foreach (var sentence in text.OrderSentencesByWordsCount())
                {
                    Console.Write(sentence);
                    Console.Write(" --- ");
                    Console.Write($"{sentence.WordsCount} words");
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine("-----Deleting words with length 10--------------");
                Console.WriteLine();
                text.DeleteWords(10);
                foreach (var sentence in text.Sentences)
                {
                    Console.WriteLine(sentence);
                }
                Console.WriteLine();
                Console.WriteLine("-----Replacing words: \"In\" replace by \"In word replaced\"----------------");
                Console.WriteLine();
                text.ReplaceWord("In", "In word replaced");
                foreach (var sentence in text.Sentences)
                {
                    Console.WriteLine(sentence);
                }

                Console.WriteLine("------------------------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
