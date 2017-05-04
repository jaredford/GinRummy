using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace GinRummy
{
    public partial class GameWindow : Form
    {
        Game g;
        int meld = 0;
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
                int players = int.Parse(numPlayers.Text);
                g = new Game(players);
                int i = 1;
                foreach (var player in g.players)
                {
                    ListBox l = (ListBox)Controls.Find("playerHand" + i, true)[0];
                    playerHands.Add(l);
                    l.DataSource = player.getHand();
                    i++;
                }
            }
            catch (Exception ex)
            {
                infoLabel.Text = ex.Message;
            }
        }
        public void setInfoLabel(String text)
        {
            infoLabel.Text += text;
        }

        private void playerHand1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Gets called whenever a player's list of selected cards changes
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
            if (g.isMeld(cards, c))
            {
                infoLabel.Text = "meld";
                meldButton.Enabled = true;
            }
            else
            {
                infoLabel.Text = "not meld";
                meldButton.Enabled = false;
            }
        }

        private void addToMeldList(List<Card> cards)
        {
            // Function to create melds
            meld++;
            ListView melds = (ListView)Controls.Find("meldList", true)[0];
            ListViewItem item = new ListViewItem("Meld " + meld);
            foreach (var card in cards)
            {
                item.SubItems.Add(card.ToShortString());
            }
            melds.Items.Add(item);
            g.addMeld(cards);
        }

        private void doubleClickList(object sender, EventArgs e)
        {
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
                    pickupButton.Enabled = true;
                }
            }
        }

        private void doubleClickDiscardList(object sender, EventArgs e)
        {
            // Make sure the player hasn't picked up yet
            if (!g.didPickUp())
            {
                ListBox l = sender as ListBox;
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
                List<Card> c = discardPile.pickUp(g.isMeld(temp, l.SelectedItem as Card), l.SelectedItem as Card);
                if (c != null)
                {
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
                    infoLabel.Text = "Illegal Draw!";
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
                ListBox l = (ListBox)Controls.Find("playerHand" + turn, true)[0];// get the current player's hand
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
            foreach (var card in l.SelectedItems)
            {
                cards.Add(card as Card);
            }
            foreach (var card in cards)
            {
                g.players[turn - 1].getHand().Remove(card);
            }
            l.DataSource = null;
            l.DataSource = g.players[turn - 1].getHand();
            addToMeldList(cards);
        }
    }
}