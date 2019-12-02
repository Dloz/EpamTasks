using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using TextProcessorLibrary.Parser;

namespace TextProcessorLibrary.Concordance.Parser
{
    public class ConcordanceParser: IParser<IConcordance>
    {
        private readonly string _emptyStringExceptionMessage = "String passed through is null or empty";

        private readonly IConcordance _concordance;
        private int _lineNumber = 1;
        public ConcordanceParser()
        {
            _concordance = new Concordance();
        }
        public IConcordance ParseText(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException(_emptyStringExceptionMessage);
            }

            _lineNumber = 1;
            var lines = str.Split("\n");

            foreach (var line in lines)
            {
                ParseLine(line);
                _lineNumber++;
            }

            return _concordance;
        }

        private void ParseLine(string str)
        {
            var words = Regex.Matches(str, @"'(.*?)'|(\w+)");
            foreach (var word in words)
            {
                _concordance.Add(word.ToString(), _lineNumber);
            }
        }
    }
}
