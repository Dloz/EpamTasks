using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextProcessorLibrary.TextModelIO
{
    public class TextModelWriter
    {
        private StreamWriter _streamWriter;
        public TextModelWriter(StreamWriter writer)
        {
            _streamWriter = writer;
        }
        /// <summary>
        /// Writes a string to the stream.
        /// </summary>
        public void Write(string str) 
        {
            _streamWriter.Write(str);
        }

    }
}
