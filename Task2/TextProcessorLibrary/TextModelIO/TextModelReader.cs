using System.IO;

namespace TextProcessorLibrary.TextModelIO
{
    /// <summary>
    /// Represents set of operations to read from the stream.
    /// </summary>
    public class TextModelReader
    {
        private readonly StreamReader _streamReader;
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