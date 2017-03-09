using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GinRummy
{
    class Card
    {
        int faceValue;
        int suit;

        public Card(int faceValue, int suit)
        {
            this.faceValue = faceValue;
            this.suit = suit;
        }

        public int getFaceValue()
        {
            return faceValue;
        }

        public int getSuit()
        {
            return suit;
        }
    }
    enum FaceValues
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
    enum Suits
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }
}
