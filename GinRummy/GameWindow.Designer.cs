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
            this.SuspendLayout();
            // 
            // startGame
            // 
            this.startGame.Location = new System.Drawing.Point(631, 466);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(75, 23);
            this.startGame.TabIndex = 0;
            this.startGame.Text = "Start Game";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // numPlayers
            // 
            this.numPlayers.Location = new System.Drawing.Point(549, 469);
            this.numPlayers.Name = "numPlayers";
            this.numPlayers.Size = new System.Drawing.Size(54, 20);
            this.numPlayers.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(447, 472);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of Players:";
            // 
            // welcomeText
            // 
            this.welcomeText.AutoSize = true;
            this.welcomeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeText.Location = new System.Drawing.Point(78, 136);
            this.welcomeText.Name = "welcomeText";
            this.welcomeText.Size = new System.Drawing.Size(556, 55);
            this.welcomeText.TabIndex = 3;
            this.welcomeText.Text = "Welcome to Gin Rummy!";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(154, 243);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(96, 13);
            this.infoLabel.TabIndex = 4;
            this.infoLabel.Text = "Game Information: ";
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 503);
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
    }
}

