using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextProcessorLibrary
{
    /// <summary>
    /// Represents set of operations to read from the stream.
    /// </summary>
    public class TextModelReader
    {
        private StreamReader _streamReader;
        public TextModelReader(StreamReader reader)
        {
            _streamReader = reader;
        }

        /// <summary>
        /// Read whole text block by block.
        /// </summary>
        /// <returns>Iterator of text blocks.</returns>
        public string ReadAllText()
        {
            using (_streamReader)
            {
                return _streamReader.ReadToEnd();
            }

        }
    }
}