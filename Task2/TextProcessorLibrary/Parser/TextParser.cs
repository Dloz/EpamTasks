using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TextProcessorLibrary.SentenceModel;
using TextProcessorLibrary.SymbolModel;
using TextProcessorLibrary.TextModel;
using TextProcessorLibrary.WordModel;

namespace TextProcessorLibrary.Parser
{
    /// <summary>
    /// Represents parser which converts from string type to IText type.
    /// </summary>
    public class TextParser : ITextParser
    {
        private const char DotSign = '.';
        private const char QuestionSign = '?';
        private const char ExclamatorySign = '!';

        private const string EmptyStringExceptionMessage = "String passed through is null or empty";
        private readonly IDictionary<char, Action> _actions;
        private IText _text;
        private ISentence _currentSentence;
        private string _sentencePending = "";
        private string _sentenceToParse = "";

        // Positions of sentence parser.
        private int _currentPosition = 0;
        private int _previousPosition = 0;

        public TextParser()
        {
            _text = new TextModel.Text();
            _currentSentence = new Sentence();

            _actions = new Dictionary<char, Action>
            {
                {'.', endOfSentenceAction },
                {'!', endOfSentenceAction },
                {'?', endOfSentenceAction },
                  
                {' ', spaceAction },
                {',', endOfWordAction },
                {':', endOfWordAction },
                  
                {'-', dashAction },
                 
                {'\"', quoteAction }

            };
        }

        private void updatePositions()
        {
            _previousPosition = _currentPosition + 1;
            //currentPosition++;
        }

        private void spaceAction()
        {
            // if space at the beginning of the sentence.
            if (_currentPosition == 0)
            {
                updatePositions();
                return;
            }
            // If there are symbol before current position, then avoid redundant word parsing.
            if (Regex.IsMatch(_sentenceToParse[_currentPosition - 1].ToString(), @"\W"))
            {
                _currentSentence.Items.Add(new Symbol(_sentenceToParse[_currentPosition].ToString()));
                updatePositions();
                return;
            }
            var word = _sentenceToParse.Substring(_previousPosition, _currentPosition - _previousPosition);
            _currentSentence.Items.Add(parseWord(word));
            _currentSentence.Items.Add(new Symbol(_sentenceToParse[_currentPosition].ToString()));

            updatePositions();
        }

        private void quoteAction()
        {
            if (_sentenceToParse[_currentPosition - 1] == ' ')
            {
                _currentSentence.Items.Add(new Symbol(_sentenceToParse[_currentPosition].ToString()));
                updatePositions();
            }

            if (_sentenceToParse[_currentPosition + 1] != ' ') return;
            var word = _sentenceToParse.Substring(_previousPosition, _currentPosition - _previousPosition);
            _currentSentence.Items.Add(parseWord(word));
            _currentSentence.Items.Add(new Symbol(_sentenceToParse[_currentPosition].ToString()));

            updatePositions();
        }

        private void dashAction()
        {
            if (_sentenceToParse[_currentPosition - 1] != ' ' || _sentenceToParse[_currentPosition + 1] != ' ') return;
            _currentSentence.Items.Add(new Symbol(_sentenceToParse[_currentPosition].ToString()));
            updatePositions();
        }

        private void endOfWordAction()
        {
            // If there are symbol before current position, then avoid redundant word parsing.
            if (Regex.IsMatch(_sentenceToParse[_currentPosition - 1].ToString(), @"\W"))
            {
                _currentSentence.Items.Add(new Symbol(_sentenceToParse[_currentPosition].ToString()));
                updatePositions();
                return;
            }

            if (_sentenceToParse[_currentPosition + 1] != ' ') return;
            var word = _sentenceToParse.Substring(_previousPosition, _currentPosition - _previousPosition);
            _currentSentence.Items.Add(parseWord(word));
            _currentSentence.Items.Add(new Symbol(_sentenceToParse[_currentPosition].ToString()));
            _currentSentence.Items.Add(new Symbol(_sentenceToParse[_currentPosition + 1].ToString()));

            _currentPosition++;
            updatePositions();
        }

        private void endOfSentenceAction()
        {
            // If there are symbol before current position, then avoid redundant word parsing.
            if (Regex.IsMatch(_sentenceToParse[_currentPosition - 1].ToString(), @"\W"))
            {
                _currentSentence.Items.Add(new Symbol(_sentenceToParse[_currentPosition].ToString()));
                updatePositions();
                return;
            }
            var word = _sentenceToParse.Substring(_previousPosition, _currentPosition - _previousPosition);
            _currentSentence.Items.Add(parseWord(word));
            _currentSentence.Items.Add(new Symbol(_sentenceToParse[_currentPosition].ToString()));
        }

        private IWord parseWord(string word)
        {
            return new Word(word);
        }

        private string removeSpaces(string str)
        {
            var output = "";

            //Replace extra spaces and tabs.
            output = Regex.Replace(str, @"\s+", " ");
            output = Regex.Replace(output, @"\t+", " ");

            return output;
        }

        public IText ParseText(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException(EmptyStringExceptionMessage);
            }

            _text = new TextModel.Text();

            var endOdSentenceRegex = new Regex(@"(?<=[\.!\?])\s+");
            var sentences = endOdSentenceRegex.Split(str);
            var completeSentences = new List<string>();

            // if sentence from previous block ready to split, split them.
            // If previuos sentence is not ended, merge 2 sentences.
            if (!string.IsNullOrEmpty(_sentencePending))
            {
                sentences[0] = _sentencePending + sentences.First();
                _sentencePending = string.Empty;
            }
            
            // if last sentence is not complete.
            // then delete last sentence from array and add it to temporary variable.
            if (!sentences.Last().EndsWith(DotSign) 
                && !sentences.Last().EndsWith(ExclamatorySign) 
                && !sentences.Last().EndsWith(QuestionSign))
            {
                //int lastIndex = Array.IndexOf(sentences, sentences.Last());
                _sentencePending = sentences.Last();
                completeSentences = sentences.Take(sentences.Length - 1).ToList(); // delete last sentence from array.
            }

            // Parse sentnces from array and add them to the text.
            foreach (var sentence in completeSentences)
            {
                _text.Sentences.Add(ParseSentence(sentence));
            }
            return _text;
        }
        public ISentence ParseSentence(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException(EmptyStringExceptionMessage);
            }

            //Make the string to be seen anywhere from the class.
            _sentenceToParse = str;

            // Remove extra spaces and tabs.
            _sentenceToParse = removeSpaces(_sentenceToParse);

            // Create object of sentence to return
            _currentSentence = new Sentence();

            // Refresh posistions of the parser.
            _currentPosition = 0;
            _previousPosition = 0;

            // Iterate through sentence symbol-wise and invoke actions.
            for (_currentPosition = 0; _currentPosition < _sentenceToParse.Length; _currentPosition++)
            {
                if (!Regex.IsMatch(_sentenceToParse[_currentPosition].ToString(), @"\w"))
                { 
                    // When parser meets some symbol, action which mapped to the symbol would be invoked.
                    _actions[_sentenceToParse[_currentPosition]](); 
                }
            }
            return _currentSentence;
        }
    }
}