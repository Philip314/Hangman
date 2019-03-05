using System;
using System.IO;

namespace Hangman
{
    class HangmanFile
    {

        private const string filePath = "../../../WordList.txt";
        private string[] wordList;

        public HangmanFile()
        {
            SetWordList();
        }

        // Get a random word from the array
        public string GetWordFromWordList()
        {
            return wordList[GenerateRandomNumber(wordList.Length)];
        }

        // Get all the words from the file and put it into array
        public void SetWordList()
        {
            this.wordList = GetWordArray();
        }

        // Get all words as array
        private string[] GetWordArray()
        {
            string[] words = null;
            try
            {
                words = File.ReadAllLines(filePath);

            }
            catch (Exception)
            {
                Console.WriteLine("File not found");
            }
            return words;
        }

        // Generate random number
        private int GenerateRandomNumber(int upper)
        {
            Random random = new Random();
            return random.Next(0, upper);
        }
    }
}
