using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GinRummy
{
    public partial class GameWindow : Form
    {
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
                Game g = new Game(players);
                infoLabel.Text = "\nGame created with " + players + " players\n";
                infoLabel.Text += "Cards in deck after deal: " + g.deck.cards.Count();
                infoLabel.Text += "\nTop Card in player 1's hand: " + Enum.GetName(typeof(FaceValues), g.players[0].getHand().First().getFaceValue()) + " of " + Enum.GetName(typeof(Suits), g.players[0].getHand().First().getSuit());
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
    }
}
