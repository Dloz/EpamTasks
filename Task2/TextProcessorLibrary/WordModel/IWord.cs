using TextProcessorLibrary.SentenceModel;

namespace TextProcessorLibrary.WordModel
{
    public interface IWord: ISentenceItem
    {
        /// <summary>
        /// Returns bool value whether word started with consonant letter or not.
        /// </summary>
        bool IsStartedWithConsonant { get; }
    }
}