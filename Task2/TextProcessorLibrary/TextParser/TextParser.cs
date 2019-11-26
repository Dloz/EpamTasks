using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TextProcessorLibrary.SentenceModel;
using TextProcessorLibrary.SymbolModel;
using TextProcessorLibrary.WordModel;

namespace TextProcessorLibrary
{
    /// <summary>
    /// Represents parser which converts from string type to IText type.
    /// </summary>
    public class TextParser : ITextParser, IDisposable
    {
        private IDictionary<char, Action> _actions;
        private IText _text;
        private ISentence _currentSentence;
        private string _sentencePending = "";
        private string _sentenceToParse = "";

        // Positions of sentence parser.
        private int currentPosition = 0;
        private int previousPosition = 0;

        public TextParser()
        {
            _text = new TextModel.Text();
            _currentSentence = new SentenceModel.Sentence();

            _actions = new Dictionary<char, Action>
            {
                {'.', EndOfSentence },
                {'!', EndOfSentence },
                {'?', EndOfSentence },
                  
                {' ', SpaceAction },
                {',', EndOfWordAction },
                {':', EndOfWordAction },
                  
                {'-', DashAction },
                 
                {'\"', QuoteAction }

            };
        }

        private void SpaceAction()
        {
            string word = _sentenceToParse.Substring(previousPosition, currentPosition - previousPosition);
            _currentSentence.Items.Add(parseWord(word));
            _currentSentence.Items.Add(new Symbol(_sentenceToParse[currentPosition].ToString()));

            previousPosition = currentPosition + 1;
        }

        private void QuoteAction()
        {
            //int endPos = 0;
            //for (int i = currentPosition; i < _sentenceToParse.Length; i++)
            //{
            //    if (_sentenceToParse[i] == ' ')
            //    {
            //        string word = _sentenceToParse.Substring(currentPosition, i - currentPosition);
            //        _currentSentence.Items.Add(parseWord(word));
            //        _currentSentence.Items.Add(new Symbol(_sentenceToParse[i].ToString()));
            //        continue;
            //    }

            //    if (_sentenceToParse[i] == '\"')
            //    {
            //        return;
            //    }
            //}

            if (_sentenceToParse[currentPosition - 1] == ' ')
            {
                _currentSentence.Items.Add(new Symbol(_sentenceToParse[currentPosition].ToString()));
            }
            if (_sentenceToParse[currentPosition + 1] == ' ')
            {
                string word = _sentenceToParse.Substring(previousPosition, currentPosition - previousPosition);
                _currentSentence.Items.Add(parseWord(word));
                _currentSentence.Items.Add(new Symbol(_sentenceToParse[currentPosition].ToString()));

                updatePositions();
            }
        }

        private void updatePositions()
        {
            previousPosition = currentPosition + 1;
            currentPosition++;
        }

        private void DashAction()
        {
            if (_sentenceToParse[currentPosition-1] == ' ' && _sentenceToParse[currentPosition + 1] == ' ')
            {
                _currentSentence.Items.Add(new Symbol(_sentenceToParse[currentPosition].ToString()));
                _currentSentence.Items.Add(new Symbol(_sentenceToParse[currentPosition-1].ToString()));
                _currentSentence.Items.Add(new Symbol(_sentenceToParse[currentPosition+1].ToString()));
            }
        }

        private void EndOfWordAction()
        {
            if (_sentenceToParse[currentPosition + 1] == ' ')
            {
                string word = _sentenceToParse.Substring(previousPosition, currentPosition - previousPosition);
                _currentSentence.Items.Add(parseWord(word));
                _currentSentence.Items.Add(new Symbol(_sentenceToParse[currentPosition].ToString()));
                _currentSentence.Items.Add(new Symbol(_sentenceToParse[currentPosition + 1].ToString()));

                currentPosition++;
                updatePositions();
            }
        }

        private void EndOfSentence()
        {
            string word = _sentenceToParse.Substring(previousPosition, currentPosition - previousPosition);
            _currentSentence.Items.Add(parseWord(word));
            _currentSentence.Items.Add(new Symbol(_sentenceToParse[currentPosition].ToString()));
        }

        public IText Parse(string str)
        {
            _text = new TextModel.Text();

            Regex endOdSentenceRegex = new Regex(@"(?<=[\.!\?])\s+");
            var sentences = endOdSentenceRegex.Split(str);

            // if sentence from previous block ready to split, split them.
            // If previuos sentence is not ended, merge 2 sentences.
            if (_sentencePending != "")
            {
                sentences[0] = _sentencePending + sentences.First();
                _sentencePending = "";
            }
            
            // if last sentence is not complete.
            // then delete last sentence from array and add it to temporary variable.
            if (!sentences.Last().EndsWith('.') && !sentences.Last().EndsWith("!") && !sentences.Last().EndsWith("?"))
            {
                int lastIndex = Array.IndexOf(sentences, sentences.Last());
                _sentencePending = sentences.Last();
                sentences = sentences.Where((val, idx) => idx != lastIndex).ToArray(); // delete last sentence from array.
            }
            foreach (var sentence in sentences)
            {
                _text.Sentences.Add(ParseSentence(sentence));
            }
            return _text;
        }
        public ISentence ParseSentence(string str)
        {
            //Make the string to be seen anywhere from the class.
            _sentenceToParse = str;
            //Replace extra spaces and tabs.
            _sentenceToParse = Regex.Replace(_sentenceToParse, @"\s+", " ");
            _sentenceToParse = Regex.Replace(_sentenceToParse, @"\t+", " ");

            // Create object of sentence to return
            _currentSentence = new SentenceModel.Sentence();

            // Refresh posistions of the parser.
            currentPosition = 0;
            previousPosition = 0;

            for (currentPosition = 0; currentPosition < _sentenceToParse.Length; currentPosition++)
            {
                // \"([a-zA-Z\s\,]+)\" - Regex to parse quote.
                if (!Regex.IsMatch(_sentenceToParse[currentPosition].ToString(), @"\w"))
                {
                    _actions[_sentenceToParse[currentPosition]]();
                }
            }
            return _currentSentence;
        }

        private IWord parseWord(string word)
        {
            return new Word(word);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~TextParser()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}