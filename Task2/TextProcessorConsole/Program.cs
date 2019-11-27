using System;
using System.IO;
using TextProcessorLibrary;
using TextProcessorLibrary.TextModel;

namespace TextProcessorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new GlobalConfiguration();
            configuration["fileName"] = "../../../text.txt";

            var stream = new StreamReader(new FileStream(configuration["fileName"], FileMode.Open));
            IText text = new Text();
            //string test = "Some, sen-tence, \"some - quote\" and: asadf!";

            using (var textParser = new TextParser())
            {
                using (var textReader = new TextModelReader(stream))
                {
                    text = textParser.ParseText(textReader.ReadAllText());
                }
            }
            
        }
    }
}
