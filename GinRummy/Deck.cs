using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GinRummy
{
    class Deck
    {
        public List<Card> cards = new List<Card>();
        public List<Card> deal(int numberOfPlayers)
        {
            List<Card> cardsToDeal = new List<Card>(cards.GetRange(0, numberOfPlayers * 7));
            cards.RemoveRange(0, numberOfPlayers * 7);
            return cardsToDeal;
        }
        public void populateDeck()
        {
            Random _random = new Random();
            for (int suit = 0; suit < 4; suit++)
            {
                for (int face = 0; face < 13; face++)
                {
                    cards.Add(new Card(face, suit));
                }
            }
            int n = 52;
            for (int i = 0; i < n; i++)
            {
                // NextDouble returns a random number between 0 and 1.
                // ... It is equivalent to Math.random() in Java.
                int r = i + (int)(_random.NextDouble() * (n - i));
                Card c = cards[r];
                cards[r] = cards[i];
                cards[i] = c;
            }
        }
    }
}
