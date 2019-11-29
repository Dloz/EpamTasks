using System;
using System.IO;
using TextProcessorLibrary;
using TextProcessorLibrary.TextModel;
using TextProcessorLibrary.TextExtensions;

namespace TextProcessorConsole
{
    class Program
    {
        static void Main(string[] args)// file Name from json or command line
        {
            var configuration = new GlobalConfiguration();
            configuration["fileName"] = "../../../text.txt";
            IText text = new Text();

            using (var stream = new StreamReader(new FileStream(configuration["fileName"], FileMode.Open)))
            {
                //string test = "Some, sen-tence, \"some - quote\" and: asadf!";

                var textParser = new TextParser();
                var textReader = new TextModelReader(stream);
                text = textParser.ParseText(textReader.ReadAllText());
            }

            Console.WriteLine("------------------------------------");

            foreach (var word in text.GetWordsFromQuestionSentences(10))
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("------------------------------------");

            foreach (var sentence in text.OrderSentencesByWordsCount())
            {
                Console.WriteLine(sentence);
            }

            Console.WriteLine("------------------------------------");
        }
    }
}
