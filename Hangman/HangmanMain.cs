using System;

namespace Hangman
{
    class HangmanMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman!");
            Hangman hangman = new Hangman();
            HangmanValidator validator = new HangmanValidator();
            string guess;
            string continueToPlayInput;
            bool continueToPlay = false;
            do
            {
                // Continue to guess while the word has not been guessed or the user still has lives
                do
                {
                    Console.WriteLine("Word: {0} \n", hangman.GetHiddenWord());
                    // Ask user to guess a letter
                    do
                    {
                        Console.WriteLine("Guess a letter");
                        guess = Console.ReadLine();
                    } while (!validator.CheckInput(guess));
                    // Check if the letter has been guessed
                    if (!hangman.LetterAlreadyGuessed(guess[0]))
                    {
                        hangman.Guess(guess[0]);
                        Console.WriteLine(hangman.GetLettersGuessed());
                        Console.WriteLine("Lives remaining: {0}", hangman.GetLivesRemaining());
                    }
                    hangman.CheckIfLetterIsGuessed();
                } while (hangman.CanContinueToGuess() && !hangman.Guessed);
                Console.WriteLine("Word: {0} \n", hangman.GetHiddenWord());
                if (hangman.Guessed)
                {
                    Console.WriteLine("You guessed it!");
                }
                else
                {
                    Console.WriteLine("No more lives");
                }
                // Ask user if they want to continue playing
                do
                {
                    Console.WriteLine("Do you want to continue to play? [y/n]");
                    continueToPlayInput = Console.ReadLine();
                } while (!hangman.ValidateContinueToPlayInput(continueToPlayInput[0]));
                continueToPlay = hangman.DecideContinueToPlay(continueToPlayInput[0]);
                if (continueToPlay)
                {
                    hangman.ResetGame();
                    Console.WriteLine("");
                }
            } while (continueToPlay);
        }
    }
}
