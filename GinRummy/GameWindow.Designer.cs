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
            this.pickUp1 = new System.Windows.Forms.Button();
            this.pickUp2 = new System.Windows.Forms.Button();
            this.pickUp3 = new System.Windows.Forms.Button();
            this.pickUp4 = new System.Windows.Forms.Button();
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
            this.discardList.Location = new System.Drawing.Point(870, 56);
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
            // pickUp1
            // 
            this.pickUp1.Location = new System.Drawing.Point(968, 446);
            this.pickUp1.Name = "pickUp1";
            this.pickUp1.Size = new System.Drawing.Size(75, 23);
            this.pickUp1.TabIndex = 11;
            this.pickUp1.Text = "Pick Up";
            this.pickUp1.UseVisualStyleBackColor = true;
            this.pickUp1.Click += new System.EventHandler(this.pickUpClick);
            // 
            // pickUp2
            // 
            this.pickUp2.Location = new System.Drawing.Point(720, 676);
            this.pickUp2.Name = "pickUp2";
            this.pickUp2.Size = new System.Drawing.Size(75, 23);
            this.pickUp2.TabIndex = 12;
            this.pickUp2.Text = "Pick Up";
            this.pickUp2.UseVisualStyleBackColor = true;
            this.pickUp2.Click += new System.EventHandler(this.pickUpClick);
            // 
            // pickUp3
            // 
            this.pickUp3.Location = new System.Drawing.Point(309, 676);
            this.pickUp3.Name = "pickUp3";
            this.pickUp3.Size = new System.Drawing.Size(75, 23);
            this.pickUp3.TabIndex = 13;
            this.pickUp3.Text = "Pick Up";
            this.pickUp3.UseVisualStyleBackColor = true;
            this.pickUp3.Click += new System.EventHandler(this.pickUpClick);
            // 
            // pickUp4
            // 
            this.pickUp4.Location = new System.Drawing.Point(63, 446);
            this.pickUp4.Name = "pickUp4";
            this.pickUp4.Size = new System.Drawing.Size(75, 23);
            this.pickUp4.TabIndex = 14;
            this.pickUp4.Text = "Pick Up";
            this.pickUp4.UseVisualStyleBackColor = true;
            this.pickUp4.Click += new System.EventHandler(this.pickUpClick);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 811);
            this.Controls.Add(this.pickUp4);
            this.Controls.Add(this.pickUp3);
            this.Controls.Add(this.pickUp2);
            this.Controls.Add(this.pickUp1);
            this.Controls.Add(this.playerHand4);
            this.Controls.Add(this.playerHand3);
            this.Controls.Add(this.playerHand2);
            this.Controls.Add(this.playerHand1);
            this.Controls.Add(this.discardList);
            this.Controls.Add(this.card1);
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
        private System.Windows.Forms.Button pickUp1;
        private System.Windows.Forms.Button pickUp2;
        private System.Windows.Forms.Button pickUp3;
        private System.Windows.Forms.Button pickUp4;
    }
}

