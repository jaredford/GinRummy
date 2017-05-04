using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GinRummy
{
    class Deck
    {
        private List<Card> cards = new List<Card>();
        public List<Card> Deal(int numberOfPlayers)
        {
            var numCards = numberOfPlayers > 2 ? 7 : 13;
            var cardsToDeal = new List<Card>(cards.GetRange(0, numberOfPlayers * numCards));
            cards.RemoveRange(0, numberOfPlayers * numCards);
            return cardsToDeal;
        }
        public Card Draw()
        {
            Card c = cards[0];
            cards.Remove(c);
            return c;
        }
        public void PopulateDeck()
        {
            Random random = new Random();
            for (int suit = 0; suit < 4; suit++)
            {
                for (int face = 0; face < 13; face++)
                {
                    cards.Add(new Card(face, suit));
                }
            }
            const int n = 52;
            for (var i = 0; i < n; i++)
            {
                // NextDouble returns a random number between 0 and 1.
                // ... It is equivalent to Math.random() in Java.
                var r = i + (int)(random.NextDouble() * (n - i));
                var c = cards[r];
                cards[r] = cards[i];
                cards[i] = c;
            }
        }
    }
}
