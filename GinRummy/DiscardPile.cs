using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GinRummy
{
    class DiscardPile
    {
        List<Card> cards = new List<Card>();
        public List<Card> pickUp(bool isMeld, Card targetCard)
        {
            int targetCardIndex = cards.IndexOf(targetCard);
            if (isMeld || targetCardIndex == 0)
            {
                List<Card> pickup = cards.GetRange(0, targetCardIndex + 1);
                cards.RemoveRange(0, targetCardIndex + 1);
                return pickup;
            }
            return null;
        }
        public void discard(Card c)
        {
            cards.Insert(0, c);
        }
        public List<Card> getCards()
        {
            return cards;
        }
    }
}
