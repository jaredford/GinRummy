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
        public List<List<Card>> melds = new List<List<Card>>();
        public Deck deck = new Deck();
        public DiscardPile discardPile = new DiscardPile();
        bool pickedUp = false;
        public Card pickedUpCard = null;
        int turn, numberOfPlayers;
        void InitializePlayers(int numberOfPlayers)
        {
            for (int i = 0; i < numberOfPlayers; i++)
                players.Add(new Player());
        }
        public Game(int numberOfPlayers)
        {
            turn = 1;
            this.numberOfPlayers = numberOfPlayers;
            deck.populateDeck();
            InitializePlayers(numberOfPlayers);
            List<Card> deal = deck.deal(numberOfPlayers);
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players[i].setHand(deal.GetRange(0, 7));
                deal.RemoveRange(0, 7);
            }
        }
        public int getTurn()
        {
            return turn;
        }

        public void addMeld(List<Card> cards)
        {
            melds.Add(cards);
        }

        public bool isMeld(List<Card> cards, Card newCard)
        {
            if (cards.Contains(newCard))
                cards.Remove(newCard);
            int sameFace = 0;
            int suit = newCard.getSuit();
            int faceValue = newCard.getFaceValue();
            bool meld = false;
            List<int> targetOffset = new List<int>();
            foreach (var card in cards)
            {
                sameFace = card.getFaceValue() == faceValue ? sameFace + 1 : sameFace;
                if(card.getSuit() == suit)
                {
                    if(card.getFaceValue() == (int)FaceValues.Ace) // Aces can also be played as the highest card
                    {
                        switch ((int)FaceValues.King + 1 - faceValue)
                        {
                            case -2:
                                meld = targetOffset.Contains(-2) ? true : meld;
                                targetOffset.Add(-1);
                                break;
                            case -1:
                                targetOffset.Add(1);
                                targetOffset.Add(-2);
                                meld = targetOffset.Contains(-1) ? true : meld;
                                break;
                            case 1:
                                targetOffset.Add(-1);
                                targetOffset.Add(2);
                                meld = targetOffset.Contains(1) ? true : meld;
                                break;
                            case 2:
                                targetOffset.Add(1);
                                meld = targetOffset.Contains(2) ? true : meld;
                                break;
                        }
                    }
                    switch (card.getFaceValue() - faceValue)
                    {
                        case -2:
                            meld = targetOffset.Contains(-2) ? true : meld;
                            targetOffset.Add(-1);
                            break;
                        case -1:
                            targetOffset.Add(1);
                            targetOffset.Add(-2);
                            meld = targetOffset.Contains(-1) ? true : meld;
                            break;
                        case 1:
                            targetOffset.Add(-1);
                            targetOffset.Add(2);
                            meld = targetOffset.Contains(1) ? true : meld;
                            break;
                        case 2:
                            targetOffset.Add(1);
                            meld = targetOffset.Contains(2) ? true : meld;
                            break;                        
                    }
                }

            }
            if(sameFace >= 2)
            {
                meld = true;
            }
            return meld;
        }
        public void setPickedUp()
        {
            pickedUp = true;
        }

        public bool didPickUp()
        {
            return pickedUp;
        }

        public void nextTurn()
        {
            pickedUp = false;
            turn = turn == numberOfPlayers ? 1 : turn + 1;
        }
    }
}