using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessorLibrary.Parser
{
    /// <summary>
    /// Represents common interface for parsers of the text.
    /// </summary>
    public interface IParser<out T> where T: class
    {
        T ParseText(string str);
    }
}
