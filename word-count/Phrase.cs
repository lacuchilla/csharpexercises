using System.Collections.Generic;
using System.Text;

namespace exercism
{
    public class Phrase
    {
        public static Dictionary<string, int> WordCount(string phrase)
        {
            var currentIndex = 0;
            var currentWord = new StringBuilder();
            var wordCountDictionary = new Dictionary<string, int>();

            foreach (var t in phrase)
            {
                AddsLettersOrDigitsToCurrentWord(t, currentWord);

                if (AddsValidApostrophesToCurrentWord(phrase, t, currentIndex, currentWord)) break;

                SavesTheCurrentWordWhenTIsADelimiter(t, currentWord, wordCountDictionary);
                currentIndex += 1;
            }

            var stringedWord = currentWord.ToString().ToLower();

            AddOrUpdateWordCountDictionary(wordCountDictionary, stringedWord);

            currentWord.Clear();

            return wordCountDictionary;
        }

        private static void AddOrUpdateWordCountDictionary(Dictionary<string, int> wordCountDictionary, string stringedWord)
        {
            if (wordCountDictionary.ContainsKey(stringedWord))
            {
                wordCountDictionary[stringedWord] += 1;
            }
            else
            {
                if (stringedWord.Length > 0)
                {
                    wordCountDictionary[stringedWord] = 1;
                }
            }
        }

        private static void SavesTheCurrentWordWhenTIsADelimiter(char t, StringBuilder currentWord,
            Dictionary<string, int> wordCountDictionary)
        {
            if ((t.Equals(' ') || t.Equals(',')) && currentWord.Length > 0)
            {
                var stringedWord = currentWord.ToString().ToLower();
                if (wordCountDictionary.ContainsKey(stringedWord))
                {
                    wordCountDictionary[stringedWord] += 1;
                }
                else
                {
                    wordCountDictionary[stringedWord] = 1;
                }

                currentWord.Clear();
            }
        }

        private static bool AddsValidApostrophesToCurrentWord(string phrase,
            char t, int currentIndex, StringBuilder currentWord)
        {
            if (t.Equals('\''))
            {
                if (currentIndex.Equals(phrase.Length - 1))
                {
                    return true;
                }

                if (InBetweenTwoLetters(phrase, currentIndex))
                {
                    currentWord.Append(t);
                }
            }
            return false;
        }

        private static void AddsLettersOrDigitsToCurrentWord(char t, StringBuilder currentWord)
        {
            if (char.IsLetterOrDigit(t))
            {
                currentWord.Append(t);
            }
        }

        private static bool InBetweenTwoLetters(string parsedString, int currentIndex)
        {
            var letterOrDigitIndexMinus1 = char.IsLetterOrDigit(parsedString[currentIndex - 1]);
            var letterOrDigitIndexPlus1 = char.IsLetterOrDigit(parsedString[currentIndex + 1]);
            var inBetweenTwoLetters = letterOrDigitIndexMinus1 &&
                                      letterOrDigitIndexPlus1;
            return inBetweenTwoLetters;
        }
    }
}