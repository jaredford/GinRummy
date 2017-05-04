using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GinRummy
{
    class Card
    {
        readonly int faceValue;
        readonly int suit;

        public Card(int faceValue, int suit)
        {
            this.faceValue = faceValue;
            this.suit = suit;
        }

        public int GetFaceValue()
        {
            return faceValue;
        }

        public int GetSuit()
        {
            return suit;
        }

        public int GetPointValue()
        {
            if(faceValue >= (int)FaceValues.Two && faceValue < (int)FaceValues.Ten)
            {
                return 5;
            }
            return 10;
        }

        public string ToShortString()
        {
            return Enum.GetName(typeof(FaceValues), this.GetFaceValue()) + " " + Enum.GetName(typeof(ShortSuits), this.GetSuit());
        }

        public override string ToString()
        {
            return Enum.GetName(typeof(FaceValues), this.GetFaceValue()) + " of " + Enum.GetName(typeof(Suits), this.GetSuit());
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
