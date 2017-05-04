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
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pickupButton = new System.Windows.Forms.Button();
            this.meldButton = new System.Windows.Forms.Button();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // startGame
            // 
            this.startGame.Location = new System.Drawing.Point(1103, 776);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(75, 23);
            this.startGame.TabIndex = 0;
            this.startGame.Text = "Start Game";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // numPlayers
            // 
            this.numPlayers.Location = new System.Drawing.Point(1021, 779);
            this.numPlayers.Name = "numPlayers";
            this.numPlayers.Size = new System.Drawing.Size(54, 20);
            this.numPlayers.TabIndex = 1;
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
            this.discardList.Location = new System.Drawing.Point(513, 330);
            this.discardList.Name = "discardList";
            this.discardList.Size = new System.Drawing.Size(120, 95);
            this.discardList.TabIndex = 6;
            this.discardList.DoubleClick += new System.EventHandler(this.doubleClickDiscardList);
            // 
            // playerHand1
            // 
            this.playerHand1.FormattingEnabled = true;
            this.playerHand1.Location = new System.Drawing.Point(946, 330);
            this.playerHand1.Name = "playerHand1";
            this.playerHand1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.playerHand1.Size = new System.Drawing.Size(120, 95);
            this.playerHand1.TabIndex = 7;
            this.playerHand1.SelectedIndexChanged += new System.EventHandler(this.playerHand1_SelectedIndexChanged);
            this.playerHand1.DoubleClick += new System.EventHandler(this.doubleClickList);
            // 
            // playerHand2
            // 
            this.playerHand2.FormattingEnabled = true;
            this.playerHand2.Location = new System.Drawing.Point(704, 558);
            this.playerHand2.Name = "playerHand2";
            this.playerHand2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.playerHand2.Size = new System.Drawing.Size(120, 95);
            this.playerHand2.TabIndex = 8;
            this.playerHand2.DoubleClick += new System.EventHandler(this.doubleClickList);
            // 
            // playerHand3
            // 
            this.playerHand3.FormattingEnabled = true;
            this.playerHand3.Location = new System.Drawing.Point(292, 558);
            this.playerHand3.Name = "playerHand3";
            this.playerHand3.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.playerHand3.Size = new System.Drawing.Size(120, 95);
            this.playerHand3.TabIndex = 9;
            this.playerHand3.DoubleClick += new System.EventHandler(this.doubleClickList);
            // 
            // playerHand4
            // 
            this.playerHand4.FormattingEnabled = true;
            this.playerHand4.Location = new System.Drawing.Point(45, 330);
            this.playerHand4.Name = "playerHand4";
            this.playerHand4.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.playerHand4.Size = new System.Drawing.Size(120, 95);
            this.playerHand4.TabIndex = 10;
            this.playerHand4.DoubleClick += new System.EventHandler(this.doubleClickList);
            // 
            // meldList
            // 
            this.meldList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20});
            this.meldList.Location = new System.Drawing.Point(12, 94);
            this.meldList.Name = "meldList";
            this.meldList.Size = new System.Drawing.Size(1166, 184);
            this.meldList.TabIndex = 15;
            this.meldList.UseCompatibleStateImageBehavior = false;
            this.meldList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Meld";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Card 1";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Card 2";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Card 3";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Card 4";
            // 
            // pickupButton
            // 
            this.pickupButton.Location = new System.Drawing.Point(515, 446);
            this.pickupButton.Name = "pickupButton";
            this.pickupButton.Size = new System.Drawing.Size(118, 29);
            this.pickupButton.TabIndex = 16;
            this.pickupButton.Text = "Pick Up";
            this.pickupButton.UseVisualStyleBackColor = true;
            this.pickupButton.Click += new System.EventHandler(this.pickupButton_Click);
            // 
            // meldButton
            // 
            this.meldButton.Location = new System.Drawing.Point(515, 481);
            this.meldButton.Name = "meldButton";
            this.meldButton.Size = new System.Drawing.Size(118, 29);
            this.meldButton.TabIndex = 17;
            this.meldButton.Text = "Meld";
            this.meldButton.UseVisualStyleBackColor = true;
            this.meldButton.Click += new System.EventHandler(this.meldButton_Click);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Card 5";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Card 6";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Card 7";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Card 8";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Card 9";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Card 10";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Card 11";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Card 12";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Card 13";
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Card 14";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Card 15";
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Card 16";
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Card 17";
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Card 18";
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Card 19";
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 811);
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
        private System.Windows.Forms.PictureBox card1;
        private System.Windows.Forms.ListBox discardList;
        private System.Windows.Forms.ListBox playerHand1;
        private System.Windows.Forms.ListBox playerHand2;
        private System.Windows.Forms.ListBox playerHand3;
        private System.Windows.Forms.ListBox playerHand4;
        private System.Windows.Forms.ListView meldList;
        private System.Windows.Forms.Button pickupButton;
        private System.Windows.Forms.Button meldButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
    }
}

