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
            StreamReader stream = new StreamReader(new FileStream("", FileMode.Open));
            IText text = new Text();

            using (var textParser = new TextParser())
            {
                using (var textModelReader = new TextModelReader(stream))
                {
                    text = textParser.Parse(textModelReader.ReadBlock());
                }
            }
            
        }
    }
}
