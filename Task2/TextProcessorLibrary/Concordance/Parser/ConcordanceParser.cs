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
        private string _emptyStringExceptionMessage = "String passed through is null or empty";

        IConcordance _concordance;
        int _lineNumber = 1;
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
                parseLine(line);
                _lineNumber++;
            }

            return _concordance;
        }

        private void parseLine(string str)
        {
            var words = Regex.Matches(str, @"'(.*?)'|(\w+)");
            foreach (var word in words)
            {
                _concordance.Add(word.ToString(), _lineNumber);
            }
        }
    }
}
