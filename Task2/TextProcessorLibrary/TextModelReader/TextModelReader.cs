using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextProcessorLibrary
{
    /// <summary>
    /// Represents set of operations to read from the stream.
    /// </summary>
    public class TextModelReader: IDisposable
    {
        private StreamReader _streamReader;
        public TextModelReader(StreamReader reader)
        {
            _streamReader = reader;
        }

        /// <summary>
        /// Reads block of data.
        /// </summary>
        /// <returns>String value of the data.</returns>
        public string ReadBlock()
        {
            StringBuilder output;
            output = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                output.Append(_streamReader.ReadLine());
            }
            return output.ToString();
        }

        /// <summary>
        /// Read whole text block by block.
        /// </summary>
        /// <returns>Iterator of text blocks.</returns>
        public string ReadAllText()
        {
            // exception handling.
            StringBuilder output;
            using (_streamReader)
            {
                output = new StringBuilder();
                while (!_streamReader.EndOfStream)
                {
                    output.Append(ReadBlock());
                }
            }

            return output.ToString();
        }

        public void Dispose()
        {
            ((IDisposable)_streamReader).Dispose();
        }
    }
}