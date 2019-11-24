using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextProcessorLibrary
{
    public class TextModelReader: IDisposable
    {
        StreamReader _streamReader;
        // buffer
        public TextModelReader(StreamReader reader)
        {
            _streamReader = reader;
        }

        public string ReadBlock()
        {
            StringBuilder output;
            using (_streamReader)
            {
                output = new StringBuilder();
                for (int i = 0; i < 4; i++)
                {
                    output.Append(_streamReader.ReadLine());
                }
            }
            return output.ToString();
        }

        public IEnumerable<string> ReadAllText()
        {
            // exception handling.
            yield return ReadBlock();
        }

        public void Dispose()
        {
            ((IDisposable)_streamReader).Dispose();
        }
    }
}