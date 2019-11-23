using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextProcessorLibrary
{
    public class TextModelReader: IDisposable
    {
        TextReader _textReader;
        // buffer
        public TextModelReader(TextReader reader)
        {
            _textReader = reader;
        }

        public string ReadBlock()
        {
            StringBuilder output;
            using (_textReader)
            {
                output = new StringBuilder();
                for (int i = 0; i < 4; i++)
                {
                    output.Append(_textReader.ReadLine());
                }
            }
            return output.ToString();
        }

        public IEnumerable<string> ReadAllText()
        {
            yield return ReadBlock();
        }

        public void Dispose()
        {
            ((IDisposable)_textReader).Dispose();
        }
    }
}