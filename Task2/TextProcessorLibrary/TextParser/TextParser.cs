using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TextProcessorLibrary
{
    public class TextParser : ITextParser, IDisposable
    {
        private IDictionary<string, Action> _actions;
        private IText _text;
        private ISentence _currentSentence;

        private int currentPosition = 0;

        public TextParser()
        {
            _text = new TextModel.Text();
            _currentSentence = new SentenceModel.Sentence();

            _actions = new Dictionary<string, Action>
            {
                {".", EndOfSentence },
                {"!", EndOfSentence },
                {"?", EndOfSentence },
                {"!?", EndOfSentence },
                {"?!", EndOfSentence },
                {"...", EndOfSentence },

                {" ", EndOfWord },
                {",", EndOfWord },
                {":", EndOfWord },

                { "-", Dash },

                {"-\n", WordWrap },

            };
        }

        private void Dash()
        {
            throw new NotImplementedException();
        }

        private void WordWrap() // перенос слова.
        {
            throw new NotImplementedException();
        }

        private void EndOfWord()
        {
            throw new NotImplementedException();
        }

        private void EndOfSentence()
        {
            throw new NotImplementedException();
        }

        public IText Parse(string str)
        {
            // If previuos sentence is not ended, merge 2 sentences.
            Regex endOdSentenceRegex = new Regex(@"(?<=[\.!\?])\s+");
            var sentences = endOdSentenceRegex.Split(str);
            foreach (var sentence in sentences)
            {
                _text.Sentences.Add(ParseSentence(sentence));
            }
            return _text;
        }
        public ISentence ParseSentence(string str)
        {

            return _currentSentence;
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