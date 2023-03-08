using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        List<Card> pack; // Represents the deck of cards.

        public Pack() // Constructor for the pack class, generates a deck of cards.
        {
            pack = new List<Card>();
            for (int i = 1; i <= 4; i++) // Fills the deck with 4 suits.
            {
                for (int j = 1; j <= 13; j++) // Fills each suit with 13 face cards.
                {
                    pack.Add(new Card(j, i)); // Adds the card generated based on the iterators to the pack.
                }
            }
        }

        public bool shuffleCardPack(int typeOfShuffle) // Static method which shuffles the deck as specified - returning true if shuffled and false if not.
        {
            int packSize = pack.Count(); // Creates an integer storing the current size of the deck - the shuffles assume deck size is unknown.
            if (typeOfShuffle == 1) // Shuffle type 1 is a Fisher-Yates shuffle.
            {
                Random random = new Random(); // Creates a random object for random number generation.
                for (int i = packSize - 1; i >= 1; i--) // Performs the modern Fisher-Yates algorithm introduced by Richard Durstenfeld in 1964. I think.
                {
                    int j = random.Next(0, i + 1); // Generates a random number between 0 and the iterator.
                    (pack[i], pack[j]) = (pack[j], pack[i]); // Swaps the cards at indexes i and j.
                }
                return true; // Shuffle is complete, true is returned.
            }

            else if (typeOfShuffle == 2) // Shuffle type 1 is a Riffle / Faro shuffle.
            {
                int midPoint = packSize / 2; // Used to split the deck into two. Encapsulated as it isn't needed elsewhere, as are topHalf and botHalf
                List<Card> topHalf = pack.GetRange(0, midPoint); // Holds the top half of the deck, the mid point rounded down.
                List<Card> botHalf = pack.GetRange(midPoint, packSize - midPoint); // Holds the rest of the deck. With odd numbers, it holds one more card than the top half.
                pack = new List<Card>(); // Empties the pack to be re-filled by the Riffle shuffle.
                for (int i = 0; i < topHalf.Count(); i++) // Performs a Riffle shuffle algorithm developed based on my own knowledge of the shuffle.
                {
                    pack.Add(botHalf[i]); // Adds a card from the bottom half of the deck back to the pack.
                    pack.Add(topHalf[i]); // Adds a card from the top half of the deck back to the pack - interleaving the two halves.
                }
                if (topHalf.Count() < botHalf.Count()) // Checks if there is a card left in the bottom half of the deck.
                {
                    pack.Add(botHalf[botHalf.Count()-1]); // Adds the final card in the bottom half of the deck, if so.
                }
                return true; // Shuffle is complete, true is returned.
            }

            else
            {
                return false; // No shuffle performed, false is returned.
            }
        }

        public Card deal() // This methods deals a single card from the deck.
        {
            Card card = pack[0]; // Deals a card from the 'bottom' of the pack - this could be switched to the 'top' by changing 0 to pack.Count()-1.
            //pack.RemoveAt(0); // Removes the card that has been dealt from the pack. Commented out as it is not needed.
            return card;
        }

        public List<Card> dealCard(int amount) // This method deals an amount of cards from the deck.
        {
            List<Card> cards = pack.GetRange(0, amount); // Deals an amount of cards from the 'bottom' of the pack. Would have to be implemented differently for top of deck.
            //pack.RemoveRange(0, amount); // Removes the cards that have been dealt from the pack. Commented out as it is not needed.
            return cards;
        }

        public int size() // This method returns the current size of the pack for validation purposes - as the deck itself is private.
        {
            return pack.Count();
        }
    }
}
