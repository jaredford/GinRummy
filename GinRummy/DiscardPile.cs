using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GinRummy
{
    class DiscardPile
    {
        private List<Card> _cards = new List<Card>();
        public List<Card> pickUp(bool isMeld, Card targetCard)
        {
            var targetCardIndex = _cards.IndexOf(targetCard);
            if (isMeld || targetCardIndex == 0)
            {
                var pickup = _cards.GetRange(0, targetCardIndex + 1);
                _cards.RemoveRange(0, targetCardIndex + 1);
                return pickup;
            }
            return null;
        }
        public void Discard(Card c)
        {
            _cards.Insert(0, c);
        }
        public List<Card> GetCards()
        {
            return _cards;
        }
    }
}
