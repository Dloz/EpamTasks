using System;
using System.IO;
using TextProcessorLibrary;

namespace TextProcessorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fileStream = new FileStream("", FileMode.OpenOrCreate);            
            using (var textParser = new TextParser())
            {
                using (var textModelReader = new TextModelReader())
                {

                }
            }
            
        }
    }
}
