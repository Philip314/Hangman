using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class HangmanValidator
    {
        // Checks whether the argument is a single letter
        public Boolean ValidateGuess(String input)
        {
            if (input.Equals("") || input.Length > 1 || input.Equals(" ") || !char.IsLetter(input[0]))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Validate the input of if user wants to continue to play
        public bool ValidateContinueToPlayInput(char letter)
        {
            if (letter == 'y' || letter == 'n')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
