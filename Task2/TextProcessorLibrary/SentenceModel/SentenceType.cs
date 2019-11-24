using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessorLibrary
{
    /// <summary>
    /// Represents type of the sentence.
    /// </summary>
    public enum SentenceType
    {
        Simple, // with a '.' symbol at the end.
        Question, // with a '?' symbol at the end.
        Exclamatory, // with a '!' symbol at the end.

        None

    }
}