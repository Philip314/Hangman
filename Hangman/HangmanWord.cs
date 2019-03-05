using System.Text;

namespace Hangman
{
    class HangmanWord
    {
        public string ToGuess { get; set; }
        public StringBuilder HiddenWord { get; set; }

        public HangmanWord(string word)
        {
            AssignWord(word);
        }

        // Assign a word and generate the hidden word
        public void AssignWord(string word)
        {
            ToGuess = word;
            HiddenWord = GenerateHiddenWord(word);
        }

        // Generate the hidden word
        private StringBuilder GenerateHiddenWord(string guess)
        {
            StringBuilder toReturn = new StringBuilder();
            foreach (char c in guess)
            {
                toReturn.Append("_");
            }
            return toReturn;
        }

        // Returns the hidden word with spaces in between the characters for visibility
        public string GetHiddenWord()
        {
            StringBuilder toReturn = new StringBuilder();
            for (int i = 0; i < HiddenWord.Length; i++)
            {
                toReturn.Append(HiddenWord[i]);
                if (i != HiddenWord.Length - 1)
                {
                    toReturn.Append(" ");
                }
            }
            return toReturn.ToString();
        }
        
    }
}
