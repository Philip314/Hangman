using System;
using System.IO;
using System.Text;

namespace Hangman
{
    class Hangman
    {
        private HangmanWord word;
        private int numberOfGuesses;
        private int currentIndexGuessed;
        private int livesRemaining;
        private char[] lettersGuessed;
        public bool Guessed { get; set; }

        public Hangman()
        {
            word = new HangmanWord(GetWordFromWordList());
            numberOfGuesses = 6 + word.ToGuess.Length;
            currentIndexGuessed = 0;
            livesRemaining = 6;
            lettersGuessed = new char[numberOfGuesses];
            Guessed = false;
        }

        public string GetHiddenWord()
        {
            return word.GetHiddenWord();
        }

        // True if argument matches the word but not the hidden word
        // Adds letter to array of letter guessed
        // Reduces a life if the user guessed wrong
        public bool Guess(char letter)
        {
            bool toReturn = false;
            AddLetterToGuessed(letter);
            for (int i=0; i<word.ToGuess.Length; i++)
            {
                if (word.ToGuess[i] == letter && word.HiddenWord[i] != letter)
                {
                    word.HiddenWord[i] = letter;
                    return true;
                }
                
            }
            Console.WriteLine("False");
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
            foreach (char c in word.HiddenWord.ToString())
            {
                if (c.Equals('_'))
                {
                    Guessed = false;
                }
            }
        }
        
        // Checks whether the argument is a single letter
        public Boolean CheckInput(String input)
        {
            if (input.Equals("") || input.Length > 1 || input.Equals(" ") || !char.IsLetter(input[0]))
            {
                return false;
            } else
            {
                return true;
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

        // Access the word list and get a random word
        private string GetWordFromWordList()
        {
            string[] words = null;
            try
            {
                words = File.ReadAllLines("WordList.txt");
                
            } catch (Exception)
            {
                Console.WriteLine("File not found");
            }
            return words[GenerateRandomNumber(words.Length)];
        }

        // Generate random number
        private int GenerateRandomNumber(int upper)
        {
            Random random = new Random();
            return random.Next(0, upper);
        }

        public void ReduceOneLife()
        {
            livesRemaining--;
        }

        public int GetLivesRemaining()
        {
            return livesRemaining;
        }

        // Validate the input of if user wants to continue to play
        public bool ValidateContinueToPlayInput(char letter)
        {
            if (letter == 'y' || letter == 'n')
            {
                return true;
            } else
            {
                return false;
            }
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
            word.AssignWord(GetWordFromWordList());
            numberOfGuesses = 6;
            currentIndexGuessed = 0;
            livesRemaining = 6;
            lettersGuessed = new char[numberOfGuesses];
            Guessed = false;
        }
    }
}
