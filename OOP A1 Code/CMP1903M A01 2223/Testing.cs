using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    internal class Testing
    {
        public static void runTest()
        {
            Console.WriteLine("Standard deck.");
            Pack pack = new Pack(); // Creates a new pack.
            displayDeck(pack); // Displays the deck without applying a shuffle.

            Console.WriteLine("Fisher-Yates (shuffle 1) applied.");
            pack = new Pack(); // Resets the pack (although this isn't necessary at this point).
            pack.shuffleCardPack(1); // Applies shuffle 1, the Fisher-Yates shuffle.
            displayDeck(pack); // Displays the Fisher-Yates shuffled deck.

            Console.WriteLine("Riffle / Faro (shuffle 2) applied.");
            pack = new Pack(); // Resets the pack (this time to demonstrate the shuffle properly).
            pack.shuffleCardPack(2); // Applies shuffle 2, the Riffle shuffle.
            displayDeck(pack); // Displays the Riffle shuffled deck.

            Console.WriteLine("No shuffle (shuffle 3) applied.");
            pack = new Pack(); // Resets the pack (this time to demonstrate no shuffle properly).
            pack.shuffleCardPack(3); // Applies shuffle 3, which is none at all.
            displayDeck(pack); // Displays the unshuffled deck.
        }

        private static void displayDeck(Pack deck)
        {
            Card card = deck.deal(); // Deals a single card with the corresponding method.
            Console.WriteLine($"Card #1, dealt singularly:\nSuit: {card.Suit}. Value: {card.Value}.\n\nThe rest of the cards, dealt together:"); // Shows the single dealt card, and prepares for the upcoming outputs.
            List<Card> cards = deck.dealCard(deck.size()); // Deals the rest of the deck with the corresponding method.
            for (int i = 0; i < cards.Count(); i++) // Iterates through the number of cards that there are.
            {
                Console.WriteLine($"Suit: {cards[i].Suit}. Value: {cards[i].Value}."); // Displays each dealt card one by one.
            }
            Console.WriteLine("\n=========================\n"); // A seperator for visibility in outputs.
        }
    }
}
