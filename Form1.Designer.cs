namespace Pendu
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Création des contrôles
            lblTitle = new System.Windows.Forms.Label();
            lblWord = new System.Windows.Forms.Label();
            lblAttempts = new System.Windows.Forms.Label();
            txtLetter = new System.Windows.Forms.TextBox();
            btnGuess = new System.Windows.Forms.Button();
            lblResult = new System.Windows.Forms.Label();
            lblVies = new System.Windows.Forms.Label();
            lblMots = new System.Windows.Forms.Label();
            btnRejouer = new System.Windows.Forms.Button();
            btnQuitter = new System.Windows.Forms.Button();
            picHangman = new System.Windows.Forms.PictureBox();
            btnBack = new System.Windows.Forms.Button();

            // Configuration des contrôles
            ((System.ComponentModel.ISupportInitialize)picHangman).BeginInit();
            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTitle.Location = new System.Drawing.Point(120, 80);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(260, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "WIN OR DIE";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblWord
            lblWord.AutoSize = true;
            lblWord.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblWord.Location = new System.Drawing.Point(120, 280);
            lblWord.Name = "lblWord";
            lblWord.Size = new System.Drawing.Size(260, 32);
            lblWord.TabIndex = 1;
            lblWord.Text = "_ _ _ _ _ _ _";
            lblWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblVies
            lblVies.AutoSize = true;
            lblVies.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblVies.Location = new System.Drawing.Point(360, 50);
            lblVies.Name = "lblVies";
            lblVies.Size = new System.Drawing.Size(100, 22);
            lblVies.TabIndex = 2;
            lblVies.Text = "Vie : 3 ❤❤❤";

            // lblAttempts
            lblAttempts.AutoSize = true;
            lblAttempts.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblAttempts.Location = new System.Drawing.Point(70, 330);
            lblAttempts.Name = "lblAttempts";
            lblAttempts.Size = new System.Drawing.Size(260, 18);
            lblAttempts.TabIndex = 3;
            lblAttempts.Text = "Lettre utilisée : ";

            // txtLetter
            txtLetter.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtLetter.Location = new System.Drawing.Point(120, 370);
            txtLetter.MaxLength = 1;
            txtLetter.Name = "txtLetter";
            txtLetter.Size = new System.Drawing.Size(50, 32);
            txtLetter.TabIndex = 4;
            txtLetter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtLetter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtLetter_KeyPress);

            // btnGuess
            btnGuess.BackColor = System.Drawing.Color.FromArgb(82, 113, 255);
            btnGuess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuess.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnGuess.ForeColor = System.Drawing.Color.White;
            btnGuess.Location = new System.Drawing.Point(190, 370);
            btnGuess.Name = "btnGuess";
            btnGuess.Size = new System.Drawing.Size(120, 40);
            btnGuess.TabIndex = 5;
            btnGuess.Text = "Jouer";
            btnGuess.UseVisualStyleBackColor = false;
            btnGuess.Click += new System.EventHandler(btnGuess_Click);

            // picHangman
            picHangman.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picHangman.Location = new System.Drawing.Point(140, 80);
            picHangman.Name = "picHangman";
            picHangman.Size = new System.Drawing.Size(180, 180);
            picHangman.TabIndex = 6;
            picHangman.TabStop = false;

            // lblResult
            lblResult.AutoSize = true;
            lblResult.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblResult.Location = new System.Drawing.Point(120, 50);
            lblResult.Name = "lblResult";
            lblResult.Size = new System.Drawing.Size(260, 35);
            lblResult.TabIndex = 7;
            lblResult.Text = "Tu as perdu";
            lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblResult.Visible = false;

            // lblMots
            lblMots.AutoSize = true;
            lblMots.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblMots.Location = new System.Drawing.Point(120, 120);
            lblMots.Name = "lblMots";
            lblMots.Size = new System.Drawing.Size(260, 25);
            lblMots.TabIndex = 8;
            lblMots.Text = "Mots : BONJOUR";
            lblMots.Visible = false;

            // btnRejouer
            btnRejouer.BackColor = System.Drawing.Color.FromArgb(82, 113, 255);
            btnRejouer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRejouer.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnRejouer.ForeColor = System.Drawing.Color.White;
            btnRejouer.Location = new System.Drawing.Point(140, 200);
            btnRejouer.Name = "btnRejouer";
            btnRejouer.Size = new System.Drawing.Size(180, 40);
            btnRejouer.TabIndex = 9;
            btnRejouer.Text = "Rejouer";
            btnRejouer.UseVisualStyleBackColor = false;
            btnRejouer.Visible = false;
            btnRejouer.Click += new System.EventHandler(btnRejouer_Click);

            // btnQuitter
            btnQuitter.BackColor = System.Drawing.Color.FromArgb(82, 113, 255);
            btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnQuitter.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnQuitter.ForeColor = System.Drawing.Color.White;
            btnQuitter.Location = new System.Drawing.Point(140, 260);
            btnQuitter.Name = "btnQuitter";
            btnQuitter.Size = new System.Drawing.Size(180, 40);
            btnQuitter.TabIndex = 10;
            btnQuitter.Text = "Quitter";
            btnQuitter.UseVisualStyleBackColor = false;
            btnQuitter.Visible = false;
            btnQuitter.Click += new System.EventHandler(btnQuitter_Click);

            // btnBack
            btnBack.BackColor = System.Drawing.Color.FromArgb(82, 113, 255);
            btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBack.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnBack.ForeColor = System.Drawing.Color.White;
            btnBack.Location = new System.Drawing.Point(20, 20);
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(50, 50);
            btnBack.TabIndex = 11;
            btnBack.Text = "←";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Visible = false;
            btnBack.Click += new System.EventHandler(btnBack_Click);

            // Form1
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(450, 600);
            Controls.Add(btnBack);
            Controls.Add(btnQuitter);
            Controls.Add(btnRejouer);
            Controls.Add(lblMots);
            Controls.Add(lblResult);
            Controls.Add(picHangman);
            Controls.Add(btnGuess);
            Controls.Add(txtLetter);
            Controls.Add(lblAttempts);
            Controls.Add(lblVies);
            Controls.Add(lblWord);
            Controls.Add(lblTitle);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Jeu du Pendu";
            ((System.ComponentModel.ISupportInitialize)picHangman).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.Label lblVies;
        private System.Windows.Forms.Label lblAttempts;
        private System.Windows.Forms.TextBox txtLetter;
        private System.Windows.Forms.Button btnGuess;
        private System.Windows.Forms.PictureBox picHangman;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblMots;
        private System.Windows.Forms.Button btnRejouer;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Button btnBack;
    }
}