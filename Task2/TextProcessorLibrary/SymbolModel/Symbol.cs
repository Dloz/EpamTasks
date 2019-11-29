using System;
using System.Collections.Generic;
using System.Text;
using TextProcessorLibrary.SentenceModel;

namespace TextProcessorLibrary.SymbolModel
{
    class Symbol : ISymbol
    {
        /// <summary>
        /// Represents string value of the part of the sentence.
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Represents symbol type of sentence item
        /// </summary>
        public SentenceItemType Type => SentenceItemType.Symbol;
        /// <summary>
        /// Represents length of the symbol.
        /// </summary>
        public int Length => Value.Length;

        public Symbol(string value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
