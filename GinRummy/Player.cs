using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GinRummy
{
    class Player
    {
        private List<Card> hand = new List<Card>();
        private List<Card> playedCards = new List<Card>();
        private int points;
        void RearrangeHand()
        {
            hand.Sort((a,b) => b.GetFaceValue().CompareTo(a.GetFaceValue()));
            hand.Sort((a, b) => a.GetSuit().CompareTo(b.GetSuit()));
        }
        public int GetPoints()
        {
            return points;
        }
        public void SetHand(List<Card> c)
        {
            hand = c;
        }
        public void Discard(Card c)
        {
            hand.Remove(c);
        }
        public List<Card> GetHand()
        {
            RearrangeHand();
            return hand;
        }

        public void PickUp(List<Card> c)
        {
            hand.AddRange(c);
        }
        public void AddPoints(int points)
        {
            this.points += points;
        }
    }
}
