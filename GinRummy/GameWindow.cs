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
                    g.NewRound();
                }
                var i = 1;
                foreach (var player in g.GetPlayers())
                {
                    ListBox l = (ListBox)Controls.Find("playerHand" + i, true)[0];
                    playerHands.Add(l);
                    l.DataSource = player.GetHand();
                    i++;
                }
                for (var j = 0; j < g.GetPlayers().Count(); j++)
                {
                    playerHands[j].DataSource = null;
                }
                playerHands[g.GetTurn() - 1].DataSource = g.GetPlayers()[g.GetTurn() - 1].GetHand();
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
        public void SetInfoLabel(String text)
        {
            infoLabel.Text += text;
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
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
            if (l == (ListBox)Controls.Find("playerHand" + g.GetTurn(), true)[0])
            {
                if (g.IsMeld(cards, c, true))
                {
                    meldButton.Enabled = true;
                }
                else
                {
                    bool layoffPossible = false;
                    foreach (var meld in g.GetMelds())
                    {
                        if (g.IsMeld(meld, c))
                        {
                            layoffPossible = true;
                        }
                    }
                    layoffButton.Enabled = layoffPossible;
                    meldButton.Enabled = false;
                }
            }
            if(g.GetPlayers().Any(p => p.GetHand().Count == 0))
                RoundOver();
        }

        private void AddToMeldList(List<Card> cards)
        {
            ListView listOfMelds = (ListView)Controls.Find("meldList", true)[0];
            listOfMelds.Clear();
            listOfMelds.Refresh();
            listOfMelds.View = View.Details;
            if (cards != null)
                g.AddMeld(cards);
            int longestMeld = 0;
            foreach (var meld in g.GetMelds())
            {
                longestMeld = meld.Count() > longestMeld ? meld.Count : longestMeld;
            }
            listOfMelds.Columns.Add("Meld");
            for (int i = 1; i <= longestMeld; i++)
            {
                listOfMelds.Columns.Add("Card " + i);
            }
            g.SortMelds();
            int meldCounter = 1;
            foreach (var meld in g.GetMelds())
            {
                ListViewItem item = new ListViewItem("Meld " + meldCounter);
                foreach (var card in meld)
                {
                    item.SubItems.Add(card.ToShortString());
                    g.SetPickedUpCard(card == g.GetPickedUpCard() ? null : g.GetPickedUpCard());
                }
                listOfMelds.Items.Add(item);
                infoLabel.ResetText();
                meldCounter++;
            }
        }

        private void DoubleClickList(object sender, EventArgs e)
        {
            // Make sure the player didn't just pick up from the discard pile
            if (g.GetPickedUpCard() != null)
            {
                infoLabel.Text = "You must make a meld with the " + g.GetPickedUpCard();
                return;
            }
            // Make sure the player has picked up before discarding
            if (g.DidPickUp())
            {
                ListBox l = sender as ListBox;
                int turn = g.GetTurn();
                if (l == (ListBox)Controls.Find("playerHand" + turn, true)[0])
                {
                    discardPile.Discard(l.SelectedItem as Card);
                    g.GetPlayers()[turn - 1].Discard(l.SelectedItem as Card);
                    playerHands[turn - 1].DataSource = null;
                    playerHands[turn - 1].DataSource = g.GetPlayers()[turn - 1].GetHand();
                    discardList.DataSource = null;
                    discardList.DataSource = discardPile.GetCards();
                    discardList.Refresh();                    
                    g.NextTurn();
                    playerHands[turn - 1].DataSource = g.GetPlayers()[turn - 1].GetHand();
                    infoLabel.Text = "It's Player " + g.GetTurn() + "'s Turn";
                    for (var i = 0; i < g.GetPlayers().Count(); i++)
                    {
                        playerHands[i].DataSource = null;
                        playerHands[i].DataSource = new List<string>();
                    }
                    pickupButton.Enabled = true;
                }
                showHand.Enabled = true;
            }
            foreach (var player in g.GetPlayers())
            {
                if (player.GetHand().Count == 0)
                {
                    RoundOver();
                }
            }
        }

        private void DoubleClickDiscardList(object sender, EventArgs e)
        {
            // Make sure the player hasn't picked up yet
            if (!g.DidPickUp())
            {
                ListBox l = sender as ListBox;
                Card selectedCard = l.SelectedItem as Card;
                int turn = g.GetTurn();
                List<Card> temp = new List<Card>();
                temp.AddRange(g.GetPlayers()[turn - 1].GetHand());
                if (l.SelectedIndex != 0)
                {
                    for (int i = l.SelectedIndex; i >= 0; i--)
                    {
                        temp.Add(discardPile.GetCards()[i]);
                    }
                }
                List<Card> c = discardPile.pickUp(g.IsMeld(temp, selectedCard), selectedCard);
                if (c != null)
                {
                    if (c.Count > 1)
                        g.SetPickedUpCard(selectedCard);
                    g.GetPlayers()[turn - 1].PickUp(c);
                    playerHands[turn - 1].DataSource = null;
                    playerHands[turn - 1].DataSource = g.GetPlayers()[turn - 1].GetHand();
                    discardList.DataSource = null;
                    discardList.DataSource = discardPile.GetCards();
                    discardList.Refresh();
                    g.SetPickedUp();
                    pickupButton.Enabled = false;
                }
                else
                {
                    foreach (var meld in g.GetMelds())
                    {
                        List<Card> cards = discardPile.pickUp(g.IsMeld(meld, selectedCard), selectedCard);
                        if(cards != null)
                        {
                            g.SetPickedUpCard(selectedCard);
                            g.GetPlayers()[turn - 1].PickUp(cards);
                            playerHands[turn - 1].DataSource = null;
                            playerHands[turn - 1].DataSource = g.GetPlayers()[turn - 1].GetHand();
                            discardList.DataSource = null;
                            discardList.DataSource = discardPile.GetCards();
                            discardList.Refresh();
                            g.SetPickedUp();
                            pickupButton.Enabled = false;
                            return;
                        }
                    }
                    
                    infoLabel.Text = "Illegal Draw!";
                }
                foreach (var player in g.GetPlayers())
                {
                    if (player.GetHand().Count == 0)
                    {
                        RoundOver();
                    }
                }
            }
        }

        private void pickupButton_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            // Make sure the player only draws one card
            if (!g.DidPickUp())
            {
                int turn = g.GetTurn();
                g.SetPickedUp();
                ListBox l = (ListBox)Controls.Find("playerHand" + turn, true)[0]; // get the current player's hand
                List<Card> c = new List<Card>();
                c.Add(g.GetDeck().Draw());
                g.GetPlayers()[turn - 1].PickUp(c);
                l.DataSource = null;
                l.DataSource = g.GetPlayers()[turn - 1].GetHand();
            }
            b.Enabled = false;
        }
        private void meldButton_Click(object sender, EventArgs e)
        {
            int turn = g.GetTurn();
            ListBox l = (ListBox)Controls.Find("playerHand" + turn, true)[0]; // get the current player's hand
            List<Card> cards = new List<Card>();
            foreach (Card card in l.SelectedItems)
            {
                cards.Add(card as Card);
                g.GetPlayers()[turn - 1].AddPoints(card.GetPointValue());

            }
            foreach (var card in cards)
            {
                g.GetPlayers()[turn - 1].GetHand().Remove(card);
            }
            Label playerPoints = (Label)Controls.Find("playerPoints" + turn, true)[0]; // update player points
            playerPoints.Text = g.GetPlayers()[turn - 1].GetPoints().ToString();

            l.DataSource = null;
            l.DataSource = g.GetPlayers()[turn - 1].GetHand();
            AddToMeldList(cards);
            foreach (var player in g.GetPlayers())
            {
                if (player.GetHand().Count == 0)
                {
                    RoundOver();
                }
            }
        }

        private void layoffButton_Click(object sender, EventArgs e)
        {
            int turn = g.GetTurn();
            ListBox l = (ListBox)Controls.Find("playerHand" + turn, true)[0]; // get the current player's hand

            Card cardToLayoff = l.SelectedItem as Card;
            g.GetPlayers()[turn - 1].GetHand().Remove(cardToLayoff);
            g.GetPlayers()[turn - 1].AddPoints(cardToLayoff.GetPointValue());


            Label playerPoints = (Label)Controls.Find("playerPoints" + turn, true)[0]; // update player points
            playerPoints.Text = g.GetPlayers()[turn - 1].GetPoints().ToString();
            g.GetPlayers()[turn - 1].Discard(cardToLayoff);

            l.DataSource = null;
            l.DataSource = g.GetPlayers()[turn - 1].GetHand();
            LayoffCard(cardToLayoff);
        }

        private void LayoffCard(Card card)
        {
            int i = -1;
            foreach (var meld in g.GetMelds())
            {
                i++;
                if (g.IsMeld(meld, card))
                    break;
            }
            g.GetMelds()[i].Add(card);
            infoLabel.ResetText();
            AddToMeldList(null);
            foreach (var player in g.GetPlayers())
            {
                if (player.GetHand().Count == 0)
                {
                    RoundOver();
                }
            }
        }
        private void RoundOver()
        {
            int i = 1;
            foreach (var player in g.GetPlayers())
            {
                foreach (var card in player.GetHand())
                {
                    player.AddPoints(-card.GetPointValue());
                }
                if(player.GetPoints() >= 500)
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

        private void showHand_Click(object sender, EventArgs e)
        {
            showHand.Enabled = false;
            var turn = g.GetTurn();
            playerHands[turn - 1].DataSource = null;
            playerHands[turn - 1].DataSource = g.GetPlayers()[turn - 1].GetHand();
        }
    }
}