using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        public int Value { get; set; } // Represents the face of the card with values 1 to 13, with 1, 11, 12, and 13 representing Aces, Jacks, Queens, and Kings respectively.

        public int Suit { get; set; } // Represents the suit of the card with values 1 to 4, representing Spades, Hearts, Clubs, and Diamonds respectively.

        public Card(int value, int suit) // Constructor for the Card class, generates a card based on value and suit passed in.
        {
            Value = value;
            Suit = suit;
        }
    }
}
