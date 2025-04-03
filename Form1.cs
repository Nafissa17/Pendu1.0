// Form1.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Pendu
{
    public partial class Form1 : Form
    {
        private string wordToGuess;
        private char[] guessedLetters;
        private List<char> usedLetters = new List<char>();
        private int maxGuesses = 6;
        private int incorrectGuesses = 0;
        private int lives = 3;


        private Color primaryColor = Color.FromArgb(82, 113, 255);  // Bleu principal pour les boutons
        private Color backgroundColor = Color.White;                // Fond blanc
        private Color accentColor = Color.FromArgb(231, 76, 60);    // Rouge pour les erreurs
        private Color successColor = Color.FromArgb(46, 204, 113);  // Vert pour les succès

        public Form1()
        {
            InitializeComponent();
            StyleApplication();
            InitializeGame();
        }

        private void StyleApplication()
        {
            
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackColor = backgroundColor;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Style pour les boutons
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.BackColor = primaryColor;
                    button.ForeColor = Color.White;
                    button.Font = new Font("Arial", 12F, FontStyle.Bold);
                    button.Cursor = Cursors.Hand;
                }
            }

            // Style pour l'écran titre
            lblTitle.Font = new Font("Arial", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;

            // Style pour le mot à deviner
            lblWord.Font = new Font("Arial", 20F, FontStyle.Bold);

            // Style pour les champs d'information
            lblVies.Font = new Font("Arial", 14F, FontStyle.Regular);
            lblAttempts.Font = new Font("Arial", 12F, FontStyle.Regular);

            // Style pour les écrans de fin
            lblResult.Font = new Font("Arial", 22F, FontStyle.Bold);
            lblMots.Font = new Font("Arial", 16F, FontStyle.Regular);

            // Style pour la zone de texte
            txtLetter.Font = new Font("Arial", 16F, FontStyle.Bold);
            txtLetter.TextAlign = HorizontalAlignment.Center;
            txtLetter.BorderStyle = BorderStyle.FixedSingle;
        }

        private void InitializeGame()
        {
            // Afficher l'écran de démarrage 
            lblTitle.Visible = true;
            lblTitle.Text = "WIN OR DIE";
            lblTitle.ForeColor = Color.Black;

            btnGuess.Text = "Jouer";
            btnGuess.Visible = true;
            btnGuess.Location = new Point((this.ClientSize.Width - btnGuess.Width) / 2, this.ClientSize.Height - 120);

            // Cacher les éléments de jeu 
            lblWord.Visible = false;
            lblVies.Visible = false;
            lblAttempts.Visible = false;
            txtLetter.Visible = false;
            picHangman.Visible = false;
            btnBack.Visible = false;

            // Cacher l'écran de fin 
            lblResult.Visible = false;
            lblMots.Visible = false;
            btnRejouer.Visible = false;
            btnQuitter.Visible = false;

            // Réinitialiser les variables
            usedLetters.Clear();
            incorrectGuesses = 0;
            lives = 3;
        }

        private void StartNewGame()
        {
            // Cacher l'écran de démarrage
            lblTitle.Visible = false;

            // Afficher l'écran de jeu 
            lblWord.Visible = true;
            lblVies.Visible = true;
            lblAttempts.Visible = true;
            txtLetter.Visible = true;
            picHangman.Visible = true;
            btnBack.Visible = true;

            btnGuess.Location = new Point(txtLetter.Right + 10, txtLetter.Top - 5);
            btnGuess.Text = "Valider";

            // Réinitialiser les variables
            usedLetters.Clear();
            incorrectGuesses = 0;
            UpdateLives();

            // Charger un nouveau mot
            LoadWordAsync();

            // Dessiner le pendu initial
            DrawHangman();
        }

        private async void LoadWordAsync()
        {
            wordToGuess = await GetRandomFrenchWord();
            guessedLetters = new char[wordToGuess.Length];
            for (int i = 0; i < guessedLetters.Length; i++)
            {
                guessedLetters[i] = '\0';
            }
            UpdateDisplay();
        }

        private async Task<string> GetRandomFrenchWord()
        {
            // Liste de mots au cas où l'API échoue
            string[] frenchWords = { "BONJOUR", "MAISON", "VOITURE", "CHIEN", "CHAT", "ARBRE", "ETOILE", "MUSIQUE", "SOLEIL", "ORDINATEUR" };

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer CLE_API");
                    HttpResponseMessage response = await client.GetAsync("https://www.blagues-api.fr/api/random");
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        JObject json = JObject.Parse(responseContent);
                        string joke = json["joke"]?.ToString();
                        string[] words = joke.Split(' ');

                        // Filtrer les mots pour ne garder que ceux d'au moins 4 lettres
                        var validWords = words.Where(w => w.Length >= 4 && !w.Contains("-") && !w.Contains("'")).ToArray();
                        if (validWords.Length > 0)
                        {
                            return validWords[new Random().Next(validWords.Length)].ToUpper();
                        }
                    }
                }
                catch (Exception)
                {
                    // En cas d'erreur, utiliser un mot de secours
                }
                return frenchWords[new Random().Next(frenchWords.Length)];
            }
        }

        private void UpdateDisplay()
        {
            // Afficher le mot avec des tirets pour les lettres non devinées
            lblWord.Text = string.Join(" ", guessedLetters.Select(c => c == '\0' ? '_' : c).ToArray());

            // Afficher les lettres utilisées
            if (usedLetters.Count > 0)
            {
                lblAttempts.Text = $"Lettres utilisées : {string.Join(", ", usedLetters)}";
            }
            else
            {
                lblAttempts.Text = "Lettres utilisées : ";
            }

            // Effacer la lettre dans la zone de texte
            txtLetter.Text = "";
            txtLetter.Focus();
        }

        private void UpdateLives()
        {
            string hearts = new string('❤', lives);
            lblVies.Text = $"Vie : {lives} {hearts}";

            // Mise à jour de la couleur en fonction du nombre de vies
            if (lives == 1)
                lblVies.ForeColor = accentColor;
            else if (lives == 3)
                lblVies.ForeColor = successColor;
            else
                lblVies.ForeColor = Color.Black;
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            // Si on est sur l'écran de démarrage
            if (lblTitle.Visible && lblTitle.Text == "WIN OR DIE")
            {
                StartNewGame();
                return;
            }

            // Vérification de la lettre
            if (!string.IsNullOrWhiteSpace(txtLetter.Text))
            {
                char letter = char.ToUpper(txtLetter.Text[0]);

                // Vérifier si c'est une lettre
                if (!char.IsLetter(letter))
                {
                    MessageBox.Show("Veuillez entrer une lettre!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLetter.Text = "";
                    return;
                }

                // Vérifier si la lettre a déjà été utilisée
                if (usedLetters.Contains(letter))
                {
                    MessageBox.Show("Vous avez déjà utilisé cette lettre!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLetter.Text = "";
                    return;
                }

                // Ajouter la lettre aux lettres utilisées
                usedLetters.Add(letter);

                bool letterFound = false;
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == letter)
                    {
                        guessedLetters[i] = letter;
                        letterFound = true;
                    }
                }

                if (!letterFound)
                {
                    incorrectGuesses++;
                    DrawHangman();

                    if (incorrectGuesses >= maxGuesses)
                    {
                        lives--;
                        UpdateLives();

                        if (lives <= 0)
                        {
                            GameOver(false);
                        }
                        else
                        {
                            // Réinitialiser le jeu pour un nouveau mot mais garder les vies
                            usedLetters.Clear();
                            incorrectGuesses = 0;
                            LoadWordAsync();
                            DrawHangman();
                        }
                    }
                }

                UpdateDisplay();
                CheckGameStatus();
            }
        }

        private void DrawHangman()
        {
            Bitmap bmp = new Bitmap(picHangman.Width, picHangman.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                // Dessiner le pendu en fonction du nombre d'erreurs
                using (Pen pen = new Pen(Color.Black, 3))
                {
                    
                    g.DrawLine(pen, 10, picHangman.Height - 10, picHangman.Width - 10, picHangman.Height - 10); // Base horizontale
                    g.DrawLine(pen, 30, 10, 30, picHangman.Height - 10);   // Poteau vertical
                    g.DrawLine(pen, 30, 10, picHangman.Width - 30, 10);    // Traverse horizontale
                    g.DrawLine(pen, picHangman.Width - 30, 10, picHangman.Width - 30, 30);    // Corde

                    if (incorrectGuesses >= 1)
                    {
                        // Tête
                        g.DrawEllipse(pen, picHangman.Width - 45, 30, 30, 30);
                    }
                    if (incorrectGuesses >= 2)
                    {
                        // Corps
                        g.DrawLine(pen, picHangman.Width - 30, 60, picHangman.Width - 30, 110);
                    }
                    if (incorrectGuesses >= 3)
                    {
                        // Bras gauche
                        g.DrawLine(pen, picHangman.Width - 30, 70, picHangman.Width - 50, 90);
                    }
                    if (incorrectGuesses >= 4)
                    {
                        // Bras droit
                        g.DrawLine(pen, picHangman.Width - 30, 70, picHangman.Width - 10, 90);
                    }
                    if (incorrectGuesses >= 5)
                    {
                        // Jambe gauche
                        g.DrawLine(pen, picHangman.Width - 30, 110, picHangman.Width - 50, 140);
                    }
                    if (incorrectGuesses >= 6)
                    {
                        // Jambe droite
                        g.DrawLine(pen, picHangman.Width - 30, 110, picHangman.Width - 10, 140);

                        // Visage triste
                        g.DrawArc(pen, picHangman.Width - 40, 42, 20, 10, 0, 180);
                    }
                }
            }
            picHangman.Image = bmp;
        }

        private void CheckGameStatus()
        {
            if (!guessedLetters.Contains('\0'))
            {
                GameOver(true);
            }
        }

        private void GameOver(bool won)
        {
            // Cacher l'écran de jeu
            lblWord.Visible = false;
            lblVies.Visible = false;
            lblAttempts.Visible = false;
            txtLetter.Visible = false;
            btnGuess.Visible = false;
            picHangman.Visible = false;
            btnBack.Visible = false;

            // Afficher l'écran de fin 
            lblResult.Visible = true;
            lblMots.Visible = true;
            btnRejouer.Visible = true;
            btnQuitter.Visible = true;

            // Centrer les contrôles
            lblResult.Location = new Point((this.ClientSize.Width - lblResult.Width) / 2, 50);
            lblMots.Location = new Point((this.ClientSize.Width - lblMots.Width) / 2, 120);
            btnRejouer.Location = new Point((this.ClientSize.Width - btnRejouer.Width) / 2, 200);
            btnQuitter.Location = new Point((this.ClientSize.Width - btnQuitter.Width) / 2, 260);

            if (won)
            {
                lblResult.Text = "Bravo !!!";
                lblResult.ForeColor = successColor;
            }
            else
            {
                lblResult.Text = "Tu as perdu";
                lblResult.ForeColor = accentColor;
            }

            lblMots.Text = $"Mots : {wordToGuess}";
        }

        private void btnRejouer_Click(object sender, EventArgs e)
        {
            lives = 3;
            InitializeGame();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Retourner à l'écran d'accueil
            InitializeGame();
        }

        private void txtLetter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permettre de valider avec la touche Entrée
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnGuess_Click(sender, e);
            }
        }
    }
}