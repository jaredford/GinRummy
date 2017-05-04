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
        private int points;
        void rearrangeHand()
        {
            hand.Sort((a,b) => b.getFaceValue().CompareTo(a.getFaceValue()));
            hand.Sort((a, b) => a.getSuit().CompareTo(b.getSuit()));
        }
        public int getPoints()
        {
            return points;
        }
        public void setHand(List<Card> c)
        {
            hand = c;
        }
        public void discard(Card c)
        {
            hand.Remove(c);
        }
        public List<Card> getHand()
        {
            rearrangeHand();
            return hand;
        }

        public void pickUp(List<Card> c)
        {
            hand.AddRange(c);
        }
        public void addPoints(int points)
        {
            this.points += points;
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
                else if(card.getFaceValue() >= (int)FaceValues.Jack)
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
