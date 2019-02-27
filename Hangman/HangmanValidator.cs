using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class HangmanValidator
    {
        // Checks whether the argument is a single letter
        public Boolean CheckGuess(String input)
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
    }
}
