using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static Pack mainDeck = new Pack();
        static void Main(string[] args)
        {
            while (MainMenu()) ; // Runs the main menu until false is returned - indicating the program should end.
        }

        static bool MainMenu()
        {
            Console.WriteLine("Welcome to the shuffling program! Please enter one of the following options:" +
                "\n1 - Generate a fresh, unshuffled deck." +
                "\n2 - Perform a shuffle on your deck." +
                "\n3 - Deal a single card from your deck." +
                "\n4 - Deal a number of cards from your deck." +
                "\n5 - Run the program testing." +
                "\n6 - Exit the program.");
            int choice = GetInteger(1, 6);
            Console.WriteLine("\n=========================\n"); // A seperator for visibility in outputs.
            if (choice == 1)
            {
                mainDeck = new Pack(); // Replaces the main deck with a fresh, unshuffled pack - refreshing it.
                Console.WriteLine("A new deck has been generated!");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter the type of shuffle you'd like to perform:" +
                    "\n1 - Fisher-Yates Shuffle." +
                    "\n2 - Riffle / Faro Shuffle." +
                    "\n3 - No Shuffle / Cancel.");
                int shuffleChoice = GetInteger(1, 3);
                Console.WriteLine("\n=========================\n"); // A seperator for visibility in outputs.
                mainDeck.shuffleCardPack(shuffleChoice); // Applies the chosen shuffle to the main deck.
                Console.WriteLine($"Shuffle {shuffleChoice} applied!");
            }
            else if (choice == 3)
            {
                Card dealtCard = mainDeck.deal(); // Deals a singular card.
                DisplayCard(dealtCard); // Displays the dealt card.
            }
            else if (choice == 4)
            {
                Console.WriteLine("Enter the number of cards you'd like to deal:");
                int dealChoice = GetInteger(1, mainDeck.size()); // Gets the number of cards to deal.
                Console.WriteLine("\n=========================\n"); // A seperator for visibility in outputs.
                List<Card> dealtCards = mainDeck.dealCard(dealChoice); // Deals the given number of cards.
                for (int i = 0; i < dealtCards.Count(); i++) // Iterates through the number of cards that have been dealt.
                {
                    DisplayCard(dealtCards[i]); // Displays the card at index i in the dealt cards.
                }
            }
            else if (choice == 5)
            {
                Testing.runTest(); // Runs the testing class' method - this quickly demonstrates the program's funcitonality.
            }
            else if (choice == 6)
            {
                return false; // Returns false to the main loop, ending the loop and thus the program.
            }
            else // There shouldn't be any other possible inputs, but just in case this else exists.
            {
                Console.WriteLine("That is not a valid option on the menu - please try again."); // An error message for invalid inputs.
            }
            Console.WriteLine("\n=========================\n"); // A seperator for visibility in outputs.
            return true; // If the user does not choose to exit, the main loop remains true and persists.
        }

        static void DisplayCard(Card card) // Displays the card in a more human-readable way.
        {
            List<string> cardValues = new List<string> { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" }; // A list of corresponding value names.
            List<string> cardSuits = new List<string> { "Spades", "Hearts", "Clubs", "Diamonds" }; // A list of corresponding suit names.
            Console.WriteLine($"{cardValues[card.Value-1]} of {cardSuits[card.Suit-1]}"); // Outputs the card as according to the corresponding value and suit names.
        }

        static int GetInteger(int min, int max) // Gets an integer input within a specified min and max range.
        {
            int userInteger = 0;
            bool isValidating = true;
            while (isValidating)
            {
                string userInput = Console.ReadLine(); // Gets a user input to convert into an integer.
                try // Try-Catch is used for Error Handling, as well as a Range Check.
                {
                    userInteger = Convert.ToInt32(userInput); // Attempts to convert user's input to an integer. IF this fails, the exception will be caught.
                    if (userInteger < min || userInteger > max) // Compares the user's integer against the min and max parameters.
                    {
                        Console.WriteLine($"That is not a valid option - please enter a whole number between {min} and {max} (inclusive)."); // An error message for invalid inputs.
                    }
                    else
                    {
                        isValidating = false; // If no errors are thrown and it is within range, validation can end - the input is valid.
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"That is not a valid option - please enter a whole number between {min} and {max} (inclusive)."); // An error message for invalid inputs.
                }
            }
            return userInteger; // Returns the validated integer.
        }
    }
}
