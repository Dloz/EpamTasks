using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessorLibrary.SymbolModel
{
    class Symbol : ISymbol
    {
        public string Value { get; set; }

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
