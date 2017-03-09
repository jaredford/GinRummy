using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GinRummy
{
    class Game
    {
        GameWindow g = new GameWindow();
        public Dictionary<Player, int> playerPoints = new Dictionary<Player, int>();
        public List<Player> players = new List<Player>();
        public Deck deck = new Deck();
        public DiscardPile discardPile = new DiscardPile();
        int turn = 0;
        void InitializePlayers(int numberOfPlayers)
        {
            for (int i = 0; i < numberOfPlayers; i++)
                players.Add(new Player());
        }
        public Game(int numberOfPlayers)
        {
            deck.populateDeck();
            InitializePlayers(numberOfPlayers);
            List<Card> deal = deck.deal(numberOfPlayers);
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players[i].setHand(deal.GetRange(0, 7));
                deal.RemoveRange(0, 7);
            }
        }
    }
}