using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GinRummy
{
    public partial class GameWindow : Form
    {
        Assembly assembly;
        ResourceManager resourceManager;
        Game g;
        DiscardPile discardPile = new DiscardPile();
        List<ListBox> playerHands = new List<ListBox>();
        public GameWindow()
        {
            InitializeComponent();
            assembly = this.GetType().Assembly;
            resourceManager = new ResourceManager("GinRummy.Properties.Resources", assembly);
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
            ListBox l = sender as ListBox;
            //card1.Image = (Bitmap)resourceManager.GetObject(l.SelectedItem.ToString().ToLower().Replace(" ", "_"));
        }
        private void addToDiscardImages(Card card)
        {
            card1 = new System.Windows.Forms.PictureBox();
            card1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            card1.Location = new System.Drawing.Point(1, 74);//+21
            card1.Name = "card1";
            card1.Size = new System.Drawing.Size(79, 119);
            card1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            card1.TabIndex = 5;
            card1.TabStop = false;
            card1.Image = null;
            card1.Image = (Bitmap)resourceManager.GetObject(card.ToString().ToLower().Replace(" ", "_"));
            this.ResumeLayout(false);
            this.PerformLayout();
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
                    addToDiscardImages(l.SelectedItem as Card);
                    discardPile.discard(l.SelectedItem as Card);
                    g.players[turn - 1].discard(l.SelectedItem as Card);
                    playerHands[turn - 1].DataSource = null;
                    playerHands[turn - 1].DataSource = g.players[turn - 1].getHand();
                    discardList.DataSource = null;
                    discardList.DataSource = discardPile.getCards();
                    discardList.Refresh();
                    g.nextTurn();
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
                List<Card> c = discardPile.pickUp(g.isMeld(g.players[turn - 1].getHand(), l.SelectedItem as Card), l.SelectedItem as Card);
                if(c != null)
                {
                    g.players[turn - 1].pickUp(c);
                    playerHands[turn - 1].DataSource = null;
                    playerHands[turn - 1].DataSource = g.players[turn - 1].getHand();
                    discardList.DataSource = null;
                    discardList.DataSource = discardPile.getCards();
                    discardList.Refresh();
                    g.setPickedUp();
                }
                else
                {
                    infoLabel.Text = "Illegal Draw!";
                }
            }
        }

        private void pickUpClick(object sender, EventArgs e)
        {
            // Make sure the player only draws one card
            if (!g.didPickUp())
            {
                int turn = g.getTurn();
                g.setPickedUp();
                Button b = sender as Button;
                if (b == (Button)Controls.Find("pickUp" + turn, true)[0])
                {
                    ListBox l = (ListBox)Controls.Find("playerHand" + turn, true)[0];
                    List<Card> c = new List<Card>();
                    c.Add(g.deck.draw());
                    g.players[turn - 1].pickUp(c);
                    l.DataSource = null;
                    l.DataSource = g.players[turn - 1].getHand();
                }
            }
        }
    }
}