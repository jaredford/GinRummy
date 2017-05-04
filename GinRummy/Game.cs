using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GinRummy
{
    class Game
    {
        public Dictionary<Player, int> playerPoints = new Dictionary<Player, int>();
        public List<Player> players = new List<Player>();
        public List<List<Card>> melds = new List<List<Card>>();
        public Deck deck = new Deck();
        public DiscardPile discardPile = new DiscardPile();
        bool pickedUp = false;
        public Card pickedUpCard = null;
        int turn, lastTurn, numberOfPlayers;
        void InitializePlayers(int numberOfPlayers)
        {
            for (int i = 0; i < numberOfPlayers; i++)
                players.Add(new Player());
        }
        public Game(int numberOfPlayers)
        {
            turn = 1;
            lastTurn = 1;
            this.numberOfPlayers = numberOfPlayers;
            deck.populateDeck();
            InitializePlayers(numberOfPlayers);
            List<Card> deal = deck.deal(numberOfPlayers);
            for (int i = 0; i < numberOfPlayers; i++)
            {
                if (numberOfPlayers > 2)
                {
                    players[i].setHand(deal.GetRange(0, 7));
                    deal.RemoveRange(0, 7);
                }
                else
                {
                    players[i].setHand(deal.GetRange(0, 13));
                    deal.RemoveRange(0, 13);
                }
            }
        }
        public void newRound ()
        {
            turn = lastTurn == numberOfPlayers ? 1 : lastTurn + 1;
            deck.populateDeck();
            List<Card> deal = deck.deal(numberOfPlayers);
            for (int i = 0; i < numberOfPlayers; i++)
            {
                if (numberOfPlayers > 2)
                {
                    players[i].setHand(deal.GetRange(0, 7));
                    deal.RemoveRange(0, 7);
                }
                else
                {
                    players[i].setHand(deal.GetRange(0, 13));
                    deal.RemoveRange(0, 13);
                }
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

        public bool isMeld(List<Card> cards, Card newCard, bool strict = false)
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
                if (card.getSuit() == suit)
                {
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
                if (card.getFaceValue() == (int)FaceValues.Ace || faceValue == (int)FaceValues.Ace)
                {
                    if (cards.Any(m => m.getFaceValue() == (int)FaceValues.King && m.getSuit() == suit))
                        if (cards.Any(m => m.getFaceValue() == (int)FaceValues.Queen && m.getSuit() == suit))
                            meld = true;
                }
            }
            if (sameFace >= 2)
            {
                meld = true;
                if (strict)
                {
                    foreach (var card in cards)
                    {
                        if (card.getFaceValue() != faceValue)
                            return false;
                    }
                }
            }
            else if (meld && strict)
            {
                cards.Sort((a, b) => a.getFaceValue().CompareTo(b.getFaceValue()));
                cards.Sort((a, b) => a.getSuit().CompareTo(b.getSuit()));
                int previous = cards[0].getFaceValue() - 1;
                if (previous == -1 && cards[1].getFaceValue() > 1)
                {
                    cards.Add(new Card((int)FaceValues.King + 1, cards[0].getSuit()));
                    cards.RemoveAt(0);
                }
                previous = cards[0].getFaceValue() - 1;
                foreach (var card in cards)
                {
                    if (card.getSuit() != suit || card.getFaceValue() != previous + 1)
                    {
                        return false;
                    }
                    previous += 1;
                }
            }
            return meld;
        }
        public void sortMelds()
        {
            foreach (var meld in melds)
            {
                meld.Sort((b, a) => b.getFaceValue().CompareTo(a.getFaceValue()));
                meld.Sort((a, b) => a.getSuit().CompareTo(b.getSuit()));
            }
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