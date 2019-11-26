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
            //StreamReader stream = new StreamReader(new FileStream("", FileMode.Open));
            IText text = new Text();
            string test = "Some, sentence, \"some quote\" and: asadf!";

            using (var textParser = new TextParser())
            {
                text = textParser.Parse(test);
            }
            
        }
    }
}
