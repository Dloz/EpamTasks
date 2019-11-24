using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessorLibrary
{
    public interface IWord
    {
        string Value { get; }
        int Length { get; }
    }
}