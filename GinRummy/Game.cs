using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace GinRummy
{
    class Game
    {
        private List<Player> _players = new List<Player>();
        private List<List<Card>> _melds = new List<List<Card>>();
        private Deck _deck = new Deck();
        private DiscardPile discardPile = new DiscardPile();
        private bool _pickedUp = false;
        private Card _pickedUpCard = null;
        private int _turn, _lastTurn;
        private readonly int numberOfPlayers;
        void InitializePlayers(int numberPlayers)
        {
            for (int i = 0; i < numberPlayers; i++)
                _players.Add(new Player());
        }
        public Game(int numberOfPlayers)
        {
            _turn = 1;
            _lastTurn = 1;
            this.numberOfPlayers = numberOfPlayers;
            _deck.PopulateDeck();
            InitializePlayers(numberOfPlayers);
            var deal = _deck.Deal(numberOfPlayers);
            for (int i = 0; i < numberOfPlayers; i++)
            {
                if (numberOfPlayers > 2)
                {
                    _players[i].SetHand(deal.GetRange(0, 7));
                    deal.RemoveRange(0, 7);
                }
                else
                {
                   _players[i].SetHand(deal.GetRange(0, 13));
                    deal.RemoveRange(0, 13);
                }
            }
        }

        public Deck GetDeck()
        {
            return _deck;
        }
        public Card GetPickedUpCard()
        {
            return _pickedUpCard;
        }

        public void SetPickedUpCard(Card card)
        {
            _pickedUpCard = card;
        }
        public List<Player> GetPlayers()
        {
            return _players;
        }

        public void SetPlayers(List<Player> players)
        {
            _players = players;
        }
        public List<List<Card>> GetMelds()
        {
            return _melds;
        }

        public void SetMelds(List<List<Card>> melds)
        {
            _melds = melds;
        }


        public void NewRound ()
        {
            _turn = _lastTurn == numberOfPlayers ? 1 : _lastTurn + 1;
            _lastTurn = _turn;
            _deck.PopulateDeck();
            List<Card> deal = _deck.Deal(numberOfPlayers);
            for (int i = 0; i < numberOfPlayers; i++)
            {
                if (numberOfPlayers > 2)
                {
                    _players[i].SetHand(deal.GetRange(0, 7));
                    deal.RemoveRange(0, 7);
                }
                else
                {
                    _players[i].SetHand(deal.GetRange(0, 13));
                    deal.RemoveRange(0, 13);
                }
            }
        }
        public int GetTurn()
        {
            return _turn;
        }

        public void AddMeld(List<Card> cards)
        {
            _melds.Add(cards);
        }

        public bool IsMeld(List<Card> cards, Card newCard, bool strict = false)
        {
            if (cards.Contains(newCard))
                cards.Remove(newCard);
            int sameFace = 0;
            int suit = newCard.GetSuit();
            int faceValue = newCard.GetFaceValue();
            bool meld = false;
            List<int> targetOffset = new List<int>();
            foreach (var card in cards)
            {
                sameFace = card.GetFaceValue() == faceValue ? sameFace + 1 : sameFace;
                if (card.GetSuit() == suit)
                {
                    switch (card.GetFaceValue() - faceValue)
                    {
                        case -2:
                            meld = targetOffset.Contains(-2) || meld;
                            targetOffset.Add(-1);
                            break;
                        case -1:
                            targetOffset.Add(1);
                            targetOffset.Add(-2);
                            meld = targetOffset.Contains(-1) || meld;
                            break;
                        case 1:
                            targetOffset.Add(-1);
                            targetOffset.Add(2);
                            meld = targetOffset.Contains(1) || meld;
                            break;
                        case 2:
                            targetOffset.Add(1);
                            meld = targetOffset.Contains(2) || meld;
                            break;
                    }
                }
                if (card.GetFaceValue() == (int)FaceValues.Ace || faceValue == (int)FaceValues.Ace)
                {
                    if (cards.Any(m => m.GetFaceValue() == (int)FaceValues.King && m.GetSuit() == suit))
                        if (cards.Any(m => m.GetFaceValue() == (int)FaceValues.Queen && m.GetSuit() == suit))
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
                        if (card.GetFaceValue() != faceValue)
                            return false;
                    }
                }
            }
            else if (meld && strict)
            {
                cards.Sort((a, b) => a.GetFaceValue().CompareTo(b.GetFaceValue()));
                cards.Sort((a, b) => a.GetSuit().CompareTo(b.GetSuit()));
                int previous = cards[0].GetFaceValue() - 1;
                if (previous == -1 && cards[1].GetFaceValue() > 1)
                {
                    cards.Add(new Card((int)FaceValues.King + 1, cards[0].GetSuit()));
                    cards.RemoveAt(0);
                }
                previous = cards[0].GetFaceValue() - 1;
                foreach (var card in cards)
                {
                    if (card.GetSuit() != suit || card.GetFaceValue() != previous + 1)
                    {
                        return false;
                    }
                    previous += 1;
                }
            }
            return meld;
        }
        public void SortMelds()
        {
            foreach (var meld in _melds)
            {
                meld.Sort((b, a) => b.GetFaceValue().CompareTo(a.GetFaceValue()));
                meld.Sort((a, b) => a.GetSuit().CompareTo(b.GetSuit()));
            }
        }
        public void SetPickedUp()
        {
            _pickedUp = true;
        }

        public bool DidPickUp()
        {
            return _pickedUp;
        }

        public void NextTurn()
        {
            _pickedUp = false;
            _turn = _turn == numberOfPlayers ? 1 : _turn + 1;
        }
    }
}