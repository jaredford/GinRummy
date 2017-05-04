using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GinRummy
{
    public partial class GameWindow : Form
    {
        Game g;
        bool newGame = true;
        DiscardPile discardPile = new DiscardPile();
        List<ListBox> playerHands = new List<ListBox>();
        public GameWindow()
        {
            InitializeComponent();
        }
        // Start the game with a specified number of players
        private void startGame_Click(object sender, EventArgs e)
        {
            try
            {
                if (newGame)
                {
                    int players = int.Parse(numPlayers.Text);
                    if (players > 4)
                    {
                        infoLabel.Text = "Can't have more than 4 players";
                        return;
                    }
                    else if (players < 2)
                    {
                        infoLabel.Text = "Can't have less than 2 players";
                        return;
                    }
                    g = new Game(players);
                }
                else
                {
                    g.newRound();
                }
                int i = 1;
                foreach (var player in g.players)
                {
                    ListBox l = (ListBox)Controls.Find("playerHand" + i, true)[0];
                    playerHands.Add(l);
                    l.DataSource = player.getHand();
                    i++;
                }
                for (int j = 0; j < g.players.Count(); j++)
                {
                    playerHands[j].DataSource = null;
                }
                playerHands[g.getTurn() - 1].DataSource = g.players[g.getTurn() - 1].getHand();
                startGame.Enabled = false;
                pickupButton.Enabled = true;
                playerHand1.Enabled = true;
                playerHand2.Enabled = true;
                playerHand3.Enabled = true;
                playerHand4.Enabled = true;
                discardList.Enabled = true;
            }
            catch (Exception ex)
            {
                startGame.Enabled = true;
                infoLabel.Text = ex.Message;
            }
        }
        public void setInfoLabel(String text)
        {
            infoLabel.Text += text;
        }

        private void selectedIndexChanged(object sender, EventArgs e)
        {
            // Gets called whenever a player's list of selected cards changes
            infoLabel.ResetText();
            ListBox l = sender as ListBox;
            List<Card> cards = new List<Card>();
            foreach (var card in l.SelectedItems)
            {
                cards.Add(card as Card);
            }
            if (cards.Count == 0)
                return;
            Card c = cards.Last();
            cards.RemoveAt(cards.Count - 1);
            if (l == (ListBox)Controls.Find("playerHand" + g.getTurn(), true)[0])
            {
                if (g.isMeld(cards, c, true))
                {
                    meldButton.Enabled = true;
                }
                else
                {
                    bool layoffPossible = false;
                    foreach (var meld in g.melds)
                    {
                        if (g.isMeld(meld, c))
                        {
                            layoffPossible = true;
                        }
                    }
                    layoffButton.Enabled = layoffPossible;
                    meldButton.Enabled = false;
                }
            }
            foreach (var player in g.players)
            {
                if (player.getHand().Count() == 0)
                {
                    roundOver();
                }
            }
        }

        private void addToMeldList(List<Card> cards)
        {
            ListView listOfMelds = (ListView)Controls.Find("meldList", true)[0];
            listOfMelds.Clear();
            listOfMelds.Refresh();
            listOfMelds.View = View.Details;
            if (cards != null)
                g.addMeld(cards);
            int longestMeld = 0;
            foreach (var meld in g.melds)
            {
                longestMeld = meld.Count() > longestMeld ? meld.Count : longestMeld;
            }
            listOfMelds.Columns.Add("Meld");
            for (int i = 1; i <= longestMeld; i++)
            {
                listOfMelds.Columns.Add("Card " + i);
            }
            g.sortMelds();
            int meldCounter = 1;
            foreach (var meld in g.melds)
            {
                ListViewItem item = new ListViewItem("Meld " + meldCounter);
                foreach (var card in meld)
                {
                    item.SubItems.Add(card.ToShortString());
                    g.pickedUpCard = card == g.pickedUpCard ? null : g.pickedUpCard;
                }
                listOfMelds.Items.Add(item);
                infoLabel.ResetText();
                meldCounter++;
            }
        }

        private void doubleClickList(object sender, EventArgs e)
        {
            // Make sure the player didn't just pick up from the discard pile
            if (g.pickedUpCard != null)
            {
                infoLabel.Text = "You must make a meld with the " + g.pickedUpCard;
                return;
            }
            // Make sure the player has picked up before discarding
            if (g.didPickUp())
            {
                ListBox l = sender as ListBox;
                int turn = g.getTurn();
                if (l == (ListBox)Controls.Find("playerHand" + turn, true)[0])
                {
                    discardPile.discard(l.SelectedItem as Card);
                    g.players[turn - 1].discard(l.SelectedItem as Card);
                    playerHands[turn - 1].DataSource = null;
                    playerHands[turn - 1].DataSource = g.players[turn - 1].getHand();
                    discardList.DataSource = null;
                    discardList.DataSource = discardPile.getCards();
                    discardList.Refresh();                    
                    g.nextTurn();
                    playerHands[turn - 1].DataSource = g.players[turn - 1].getHand();
                    infoLabel.Text = "It's Player " + g.getTurn() + "'s Turn";
                    for (int i = 0; i < g.players.Count(); i++)
                    {
                        playerHands[i].DataSource = null;
                        playerHands[i].DataSource = new List<string>();
                    }
                    pickupButton.Enabled = true;
                }
            }
            foreach (var player in g.players)
            {
                if (player.getHand().Count() == 0)
                {
                    roundOver();
                }
            }
        }

        private void doubleClickDiscardList(object sender, EventArgs e)
        {
            // Make sure the player hasn't picked up yet
            if (!g.didPickUp())
            {
                ListBox l = sender as ListBox;
                Card selectedCard = l.SelectedItem as Card;
                int turn = g.getTurn();
                List<Card> temp = new List<Card>();
                temp.AddRange(g.players[turn - 1].getHand());
                if (l.SelectedIndex != 0)
                {
                    for (int i = l.SelectedIndex; i >= 0; i--)
                    {
                        temp.Add(discardPile.getCards()[i]);
                    }
                }
                List<Card> c = discardPile.pickUp(g.isMeld(temp, selectedCard), selectedCard);
                if (c != null)
                {
                    if (c.Count() > 1)
                        g.pickedUpCard = selectedCard;
                    g.players[turn - 1].pickUp(c);
                    playerHands[turn - 1].DataSource = null;
                    playerHands[turn - 1].DataSource = g.players[turn - 1].getHand();
                    discardList.DataSource = null;
                    discardList.DataSource = discardPile.getCards();
                    discardList.Refresh();
                    g.setPickedUp();
                    pickupButton.Enabled = false;
                }
                else
                {
                    foreach (var meld in g.melds)
                    {
                        List<Card> cards = discardPile.pickUp(g.isMeld(meld, selectedCard), selectedCard);
                        if(cards != null)
                        {
                            g.pickedUpCard = selectedCard;
                            g.players[turn - 1].pickUp(cards);
                            playerHands[turn - 1].DataSource = null;
                            playerHands[turn - 1].DataSource = g.players[turn - 1].getHand();
                            discardList.DataSource = null;
                            discardList.DataSource = discardPile.getCards();
                            discardList.Refresh();
                            g.setPickedUp();
                            pickupButton.Enabled = false;
                            return;
                        }
                    }
                    
                    infoLabel.Text = "Illegal Draw!";
                }
                foreach (var player in g.players)
                {
                    if (player.getHand().Count() == 0)
                    {
                        roundOver();
                    }
                }
            }
        }

        private void pickupButton_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            // Make sure the player only draws one card
            if (!g.didPickUp())
            {
                int turn = g.getTurn();
                g.setPickedUp();
                ListBox l = (ListBox)Controls.Find("playerHand" + turn, true)[0]; // get the current player's hand
                List<Card> c = new List<Card>();
                c.Add(g.deck.draw());
                g.players[turn - 1].pickUp(c);
                l.DataSource = null;
                l.DataSource = g.players[turn - 1].getHand();
            }
            b.Enabled = false;
        }
        private void meldButton_Click(object sender, EventArgs e)
        {
            int turn = g.getTurn();
            ListBox l = (ListBox)Controls.Find("playerHand" + turn, true)[0]; // get the current player's hand
            List<Card> cards = new List<Card>();
            foreach (Card card in l.SelectedItems)
            {
                cards.Add(card as Card);
                g.players[turn - 1].addPoints(card.getPointValue());

            }
            foreach (var card in cards)
            {
                g.players[turn - 1].getHand().Remove(card);
            }
            Label playerPoints = (Label)Controls.Find("playerPoints" + turn, true)[0]; // update player points
            playerPoints.Text = g.players[turn - 1].getPoints().ToString();

            l.DataSource = null;
            l.DataSource = g.players[turn - 1].getHand();
            addToMeldList(cards);
            foreach (var player in g.players)
            {
                if (player.getHand().Count() == 0)
                {
                    roundOver();
                }
            }
        }

        private void layoffButton_Click(object sender, EventArgs e)
        {
            int turn = g.getTurn();
            ListBox l = (ListBox)Controls.Find("playerHand" + turn, true)[0]; // get the current player's hand

            Card cardToLayoff = l.SelectedItem as Card;
            g.players[turn - 1].getHand().Remove(cardToLayoff);
            g.players[turn - 1].addPoints(cardToLayoff.getPointValue());


            Label playerPoints = (Label)Controls.Find("playerPoints" + turn, true)[0]; // update player points
            playerPoints.Text = g.players[turn - 1].getPoints().ToString();
            g.players[turn - 1].discard(cardToLayoff);

            l.DataSource = null;
            l.DataSource = g.players[turn - 1].getHand();
            layoffCard(cardToLayoff);
        }

        private void layoffCard(Card card)
        {
            int i = -1;
            foreach (var meld in g.melds)
            {
                i++;
                if (g.isMeld(meld, card))
                    break;
            }
            g.melds[i].Add(card);
            infoLabel.ResetText();
            addToMeldList(null);
            foreach (var player in g.players)
            {
                if (player.getHand().Count() == 0)
                {
                    roundOver();
                }
            }
        }
        private void roundOver()
        {
            int i = 1;
            foreach (var player in g.players)
            {
                foreach (var card in player.getHand())
                {
                    player.addPoints(-card.getPointValue());
                }
                if(player.getPoints() >= 500)
                {
                    newGame = true;
                    infoLabel.Text = "Player " + i + " Wins!";
                }
                i++;
            }
            discardList.DataSource = null;
            meldList.Clear();
            meldList.Refresh();
            pickupButton.Enabled = false;
            layoffButton.Enabled = false;
            meldButton.Enabled = false;
            startGame.Enabled = true;
            playerHand1.Enabled = false;
            playerHand2.Enabled = false;
            playerHand3.Enabled = false;
            playerHand4.Enabled = false;
            discardList.Enabled = false;
        }
    }
}