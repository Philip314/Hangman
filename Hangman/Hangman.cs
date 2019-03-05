using System;
using System.Text;

namespace Hangman
{
    class Hangman
    {
        private HangmanWord hangmanWord;
        private HangmanFile hangmanFile;
        private int numberOfGuesses;
        private int currentIndexGuessed;
        private int livesRemaining;
        private char[] lettersGuessed;
        public bool Guessed { get; set; }

        public Hangman()
        {
            hangmanFile = new HangmanFile();
            hangmanWord = new HangmanWord(hangmanFile.GetWordFromWordList());
            numberOfGuesses = 6 + hangmanWord.ToGuess.Length;
            currentIndexGuessed = 0;
            livesRemaining = 6;
            lettersGuessed = new char[numberOfGuesses];
            Guessed = false;
        }

        public string GetHiddenWord()
        {
            return hangmanWord.GetHiddenWord();
        }

        // True if argument matches the word but not the hidden word
        // Adds letter to array of letter guessed
        // Reduces a life if the user guessed wrong
        public bool Guess(char letter)
        {
            AddLetterToGuessed(letter);
            for (int i=0; i< hangmanWord.ToGuess.Length; i++)
            {
                if (hangmanWord.ToGuess[i] == letter && hangmanWord.HiddenWord[i] != letter)
                {
                    hangmanWord.HiddenWord[i] = letter;
                    return true;
                }
                
            }
            ReduceOneLife();
            return false;
        }

        // Checks if letter is present in array of letter guessed
        public Boolean LetterAlreadyGuessed(char letter)
        {
            foreach (char c in lettersGuessed)
            {
                if (c == letter)
                {
                    return true;
                }
            }
            return false;
        }

        // Print out a list of all the letters that have been guessed
        public string GetLettersGuessed()
        {
            StringBuilder toReturn = new StringBuilder();
            toReturn.Append("Letters guessed: [");
            if (lettersGuessed.Length > 1)
            {
                for (int i=0; i<lettersGuessed.Length; i++)
                {
                    if (char.IsLetter(lettersGuessed[i]))
                    {
                        toReturn.Append(lettersGuessed[i]);
                        // Separate each elements with comma
                        try
                        {
                            if (char.IsLetter(lettersGuessed[i + 1]))
                            {
                                toReturn.Append(", ");
                            }
                        }
                        catch(IndexOutOfRangeException)
                        {

                        }
                    }
                }
            }
            toReturn.Append("]");
            return toReturn.ToString();
        }

        // Checks whether the letter is guessed
        public void CheckIfLetterIsGuessed()
        {
            Guessed = true;
            foreach (char c in hangmanWord.HiddenWord.ToString())
            {
                if (c.Equals('_'))
                {
                    Guessed = false;
                }
            }
        }        

        // Checks if array is full via index and if there is no more lives
        public bool CanContinueToGuess()
        {
            if (numberOfGuesses == currentIndexGuessed || livesRemaining == 0)
            {
                return false;
            } else
            {
                return true;
            }
        }

        // Adds the letter to array of letters guessed
        private bool AddLetterToGuessed(char letter)
        {
            if (currentIndexGuessed != numberOfGuesses)
            {
                lettersGuessed[currentIndexGuessed] = letter;
                currentIndexGuessed++;
                return true;
            }
            return false;
        }

        public void ReduceOneLife()
        {
            livesRemaining--;
        }

        public int GetLivesRemaining()
        {
            return livesRemaining;
        }

        // Process user input on whether they want to continue to play
        public bool DecideContinueToPlay(char letter)
        {
            if (letter == 'y')
            {
                return true;
            } else
            {
                return false;
            }
        }

        // Reset the game
        public void ResetGame()
        {
            hangmanWord.AssignWord(hangmanFile.GetWordFromWordList());
            numberOfGuesses = 6 + hangmanWord.ToGuess.Length;
            currentIndexGuessed = 0;
            livesRemaining = 6;
            lettersGuessed = new char[numberOfGuesses];
            Guessed = false;
        }
    }
}
