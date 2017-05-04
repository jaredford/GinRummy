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

        public int getPointValue()
        {
            if(faceValue >= (int)FaceValues.Two && faceValue < (int)FaceValues.Ten)
            {
                return 5;
            }
            return 10;
        }

        public string ToShortString()
        {
            return Enum.GetName(typeof(FaceValues), this.getFaceValue()) + " " + Enum.GetName(typeof(ShortSuits), this.getSuit());
        }

        public override string ToString()
        {
            return Enum.GetName(typeof(FaceValues), this.getFaceValue()) + " of " + Enum.GetName(typeof(Suits), this.getSuit());
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
    enum ShortSuits
    {
        H,
        D,
        S,
        C
    }
}
