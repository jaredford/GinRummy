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
        List<Card> pickUp()
        {
            return cards;
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
