namespace GinRummy
{
    partial class GameWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startGame = new System.Windows.Forms.Button();
            this.numPlayers = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.welcomeText = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.discardList = new System.Windows.Forms.ListBox();
            this.playerHand1 = new System.Windows.Forms.ListBox();
            this.playerHand2 = new System.Windows.Forms.ListBox();
            this.playerHand3 = new System.Windows.Forms.ListBox();
            this.playerHand4 = new System.Windows.Forms.ListBox();
            this.meldList = new System.Windows.Forms.ListView();
            this.pickupButton = new System.Windows.Forms.Button();
            this.meldButton = new System.Windows.Forms.Button();
            this.playerPoints4 = new System.Windows.Forms.Label();
            this.playerPoints3 = new System.Windows.Forms.Label();
            this.playerPoints2 = new System.Windows.Forms.Label();
            this.playerPoints1 = new System.Windows.Forms.Label();
            this.layoffButton = new System.Windows.Forms.Button();
            this.showHand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startGame
            // 
            this.startGame.Location = new System.Drawing.Point(1103, 776);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(75, 23);
            this.startGame.TabIndex = 1;
            this.startGame.Text = "Start Game";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // numPlayers
            // 
            this.numPlayers.Location = new System.Drawing.Point(1021, 779);
            this.numPlayers.Name = "numPlayers";
            this.numPlayers.Size = new System.Drawing.Size(54, 20);
            this.numPlayers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(919, 782);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of Players:";
            // 
            // welcomeText
            // 
            this.welcomeText.AutoSize = true;
            this.welcomeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeText.Location = new System.Drawing.Point(282, 9);
            this.welcomeText.Name = "welcomeText";
            this.welcomeText.Size = new System.Drawing.Size(556, 55);
            this.welcomeText.TabIndex = 3;
            this.welcomeText.Text = "Welcome to Gin Rummy!";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(289, 64);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(96, 13);
            this.infoLabel.TabIndex = 4;
            this.infoLabel.Text = "Game Information: ";
            // 
            // discardList
            // 
            this.discardList.FormattingEnabled = true;
            this.discardList.Location = new System.Drawing.Point(546, 330);
            this.discardList.Name = "discardList";
            this.discardList.Size = new System.Drawing.Size(120, 95);
            this.discardList.TabIndex = 6;
            this.discardList.DoubleClick += new System.EventHandler(this.DoubleClickDiscardList);
            // 
            // playerHand1
            // 
            this.playerHand1.FormattingEnabled = true;
            this.playerHand1.Location = new System.Drawing.Point(979, 330);
            this.playerHand1.Name = "playerHand1";
            this.playerHand1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.playerHand1.Size = new System.Drawing.Size(120, 251);
            this.playerHand1.TabIndex = 7;
            this.playerHand1.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            this.playerHand1.DoubleClick += new System.EventHandler(this.DoubleClickList);
            // 
            // playerHand2
            // 
            this.playerHand2.FormattingEnabled = true;
            this.playerHand2.Location = new System.Drawing.Point(751, 428);
            this.playerHand2.Name = "playerHand2";
            this.playerHand2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.playerHand2.Size = new System.Drawing.Size(120, 251);
            this.playerHand2.TabIndex = 8;
            this.playerHand2.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            this.playerHand2.DoubleClick += new System.EventHandler(this.DoubleClickList);
            // 
            // playerHand3
            // 
            this.playerHand3.FormattingEnabled = true;
            this.playerHand3.Location = new System.Drawing.Point(325, 428);
            this.playerHand3.Name = "playerHand3";
            this.playerHand3.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.playerHand3.Size = new System.Drawing.Size(120, 251);
            this.playerHand3.TabIndex = 9;
            this.playerHand3.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            this.playerHand3.DoubleClick += new System.EventHandler(this.DoubleClickList);
            // 
            // playerHand4
            // 
            this.playerHand4.FormattingEnabled = true;
            this.playerHand4.Location = new System.Drawing.Point(76, 330);
            this.playerHand4.Name = "playerHand4";
            this.playerHand4.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.playerHand4.Size = new System.Drawing.Size(120, 251);
            this.playerHand4.TabIndex = 10;
            this.playerHand4.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            this.playerHand4.DoubleClick += new System.EventHandler(this.DoubleClickList);
            // 
            // meldList
            // 
            this.meldList.Location = new System.Drawing.Point(12, 94);
            this.meldList.Name = "meldList";
            this.meldList.Size = new System.Drawing.Size(1166, 184);
            this.meldList.TabIndex = 15;
            this.meldList.UseCompatibleStateImageBehavior = false;
            this.meldList.View = System.Windows.Forms.View.Details;
            // 
            // pickupButton
            // 
            this.pickupButton.Enabled = false;
            this.pickupButton.Location = new System.Drawing.Point(548, 446);
            this.pickupButton.Name = "pickupButton";
            this.pickupButton.Size = new System.Drawing.Size(118, 29);
            this.pickupButton.TabIndex = 16;
            this.pickupButton.Text = "Pick Up";
            this.pickupButton.UseVisualStyleBackColor = true;
            this.pickupButton.Click += new System.EventHandler(this.pickupButton_Click);
            // 
            // meldButton
            // 
            this.meldButton.Enabled = false;
            this.meldButton.Location = new System.Drawing.Point(548, 481);
            this.meldButton.Name = "meldButton";
            this.meldButton.Size = new System.Drawing.Size(118, 29);
            this.meldButton.TabIndex = 17;
            this.meldButton.Text = "Meld";
            this.meldButton.UseVisualStyleBackColor = true;
            this.meldButton.Click += new System.EventHandler(this.meldButton_Click);
            // 
            // playerPoints4
            // 
            this.playerPoints4.AutoSize = true;
            this.playerPoints4.Location = new System.Drawing.Point(123, 588);
            this.playerPoints4.Name = "playerPoints4";
            this.playerPoints4.Size = new System.Drawing.Size(13, 13);
            this.playerPoints4.TabIndex = 18;
            this.playerPoints4.Text = "0";
            this.playerPoints4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerPoints3
            // 
            this.playerPoints3.AutoSize = true;
            this.playerPoints3.Location = new System.Drawing.Point(374, 682);
            this.playerPoints3.Name = "playerPoints3";
            this.playerPoints3.Size = new System.Drawing.Size(13, 13);
            this.playerPoints3.TabIndex = 19;
            this.playerPoints3.Text = "0";
            this.playerPoints3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerPoints2
            // 
            this.playerPoints2.AutoSize = true;
            this.playerPoints2.Location = new System.Drawing.Point(804, 682);
            this.playerPoints2.Name = "playerPoints2";
            this.playerPoints2.Size = new System.Drawing.Size(13, 13);
            this.playerPoints2.TabIndex = 20;
            this.playerPoints2.Text = "0";
            this.playerPoints2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerPoints1
            // 
            this.playerPoints1.AutoSize = true;
            this.playerPoints1.Location = new System.Drawing.Point(1035, 588);
            this.playerPoints1.Name = "playerPoints1";
            this.playerPoints1.Size = new System.Drawing.Size(13, 13);
            this.playerPoints1.TabIndex = 21;
            this.playerPoints1.Text = "0";
            this.playerPoints1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layoffButton
            // 
            this.layoffButton.Enabled = false;
            this.layoffButton.Location = new System.Drawing.Point(548, 516);
            this.layoffButton.Name = "layoffButton";
            this.layoffButton.Size = new System.Drawing.Size(118, 29);
            this.layoffButton.TabIndex = 22;
            this.layoffButton.Text = "Lay Off";
            this.layoffButton.UseVisualStyleBackColor = true;
            this.layoffButton.Click += new System.EventHandler(this.layoffButton_Click);
            // 
            // showHand
            // 
            this.showHand.Enabled = false;
            this.showHand.Location = new System.Drawing.Point(546, 551);
            this.showHand.Name = "showHand";
            this.showHand.Size = new System.Drawing.Size(118, 29);
            this.showHand.TabIndex = 23;
            this.showHand.Text = "Show Hand";
            this.showHand.UseVisualStyleBackColor = true;
            this.showHand.Click += new System.EventHandler(this.showHand_Click);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 811);
            this.Controls.Add(this.showHand);
            this.Controls.Add(this.layoffButton);
            this.Controls.Add(this.playerPoints1);
            this.Controls.Add(this.playerPoints2);
            this.Controls.Add(this.playerPoints3);
            this.Controls.Add(this.playerPoints4);
            this.Controls.Add(this.meldButton);
            this.Controls.Add(this.pickupButton);
            this.Controls.Add(this.meldList);
            this.Controls.Add(this.playerHand4);
            this.Controls.Add(this.playerHand3);
            this.Controls.Add(this.playerHand2);
            this.Controls.Add(this.playerHand1);
            this.Controls.Add(this.discardList);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.welcomeText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numPlayers);
            this.Controls.Add(this.startGame);
            this.Name = "GameWindow";
            this.Text = "Gin Rummy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startGame;
        private System.Windows.Forms.TextBox numPlayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label welcomeText;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.ListBox discardList;
        private System.Windows.Forms.ListBox playerHand1;
        private System.Windows.Forms.ListBox playerHand2;
        private System.Windows.Forms.ListBox playerHand3;
        private System.Windows.Forms.ListBox playerHand4;
        private System.Windows.Forms.ListView meldList;
        private System.Windows.Forms.Button pickupButton;
        private System.Windows.Forms.Button meldButton;
        private System.Windows.Forms.Label playerPoints4;
        private System.Windows.Forms.Label playerPoints3;
        private System.Windows.Forms.Label playerPoints2;
        private System.Windows.Forms.Label playerPoints1;
        private System.Windows.Forms.Button layoffButton;
        private System.Windows.Forms.Button showHand;
    }
}

