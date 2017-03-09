using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GinRummy
{
    class Player
    {
        protected List<Card> hand = new List<Card>();
        protected List<Card> playedCards = new List<Card>();
        protected int points;
        void rearrangeHand()
        {
            hand.Sort(); //TODO: provide different sorting options
        }
        int getPoints()
        {
            return points;
        }
        public void setHand(List<Card> c)
        {
            hand = c;
        }
        public List<Card> getHand()
        {
            return hand;
        }
        void refreshPoints()
        {
            int tempPoints = 0;
            foreach(var card in playedCards)
            {
                if(card.getFaceValue() == (int)FaceValues.Ace)
                {
                    tempPoints += 15;
                }
                else if(card.getFaceValue() >= (int) FaceValues.Jack)
                {
                    tempPoints += 10;
                }
                else
                {
                    tempPoints += 5;
                }
            }
            points = tempPoints;
        }
    }
}
