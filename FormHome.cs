using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace AP_CINE_APPLI
{

    public partial class FormHome : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        Color originalBackColor, originalForeColor;

        public FormHome()
        {
            // Initialisation des éléments
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(149, 222);
            panelMenu.Controls.Add(leftBorderBtn);

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void home_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

            Boolean goodPWD = false;
            Boolean continu = true;

            // Demande du mot de passe de la base de données
            varglob.strconnect = System.IO.File.ReadAllText(Application.StartupPath + "\\connexion.txt") + Interaction.InputBox("Saisissez le mot de passe de la base de données");

            // La boucle permet de vérifier si le mot de passe saisi au-dessus est le bon.
            while (!goodPWD && continu)
            {
                //Tentative de connexion à la base de données
                try
                {
                    //Connexion à la base de données
                    OdbcConnection cnn = new OdbcConnection();
                    cnn.ConnectionString = varglob.strconnect;
                    cnn.Open();
                    goodPWD = true;
                    cnn.Close();
                }
                //Si la tentation échoue (mot de passe invalide), le code qui suit s'exécute
                catch (Exception)
                {
                    // Demande à l'utilisateur si il souhaite continuer sa tentative de connexion à la base de données.
                    // Si oui, le mot de passe est redemandé
                    if (MessageBox.Show("Erreur de mot de passe. Voulez-vous réessayer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        varglob.strconnect = System.IO.File.ReadAllText(Application.StartupPath + "\\connexion.txt") + Interaction.InputBox("Saisissez le mot de passe de la base de données");
                    }
                    // Sinon, la boucle s'arrête après avoir mis continu à false
                    else
                    {
                        continu = false;
                    }
                }
            }

            // Si l'utilisateur n'a pas voulu continuer la tentative de connexion, arrête de l'application
            if (!continu)
                Application.Exit();
            // Sinon, le programme continu et sélectionne le bouton "accueil" dans le menu puis ouvre le formulaire "FormAccueil"
            else
            {
                originalBackColor = btnAccueil.BackColor;
                originalForeColor = btnAccueil.ForeColor;
                ActivateButton(btnAccueil);
                OpenChildForm(new FormAccueil());
            }

        }

        /// <summary> Permet de changer la couleur du bouton cliqué. </summary>
        /// <param name="senderBtn">Bouton cliqué</param>
        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(253, 195, 0);
                currentBtn.ForeColor = Color.FromArgb(32, 32, 32);
                currentBtn.IconColor = Color.FromArgb(32, 32, 32);
            }
        }

        /// <summary> Permet de restaurer la couleur initial de tous les boutons. </summary>
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = originalBackColor;
                currentBtn.ForeColor = originalForeColor;
                currentBtn.IconColor = originalForeColor;
            }
        }

        /// <summary> Permet d'afficher un formulaire enfant dans la zone de travail "panelDesktop". </summary>
        /// <param name="childForm">Nouveau formulaire à afficher</param>
        private void OpenChildForm(Form childForm)
        {
            // Vérifie si le formulaire actuel est différent du formulaire à ouvrir
            if (currentChildForm == null || currentChildForm.GetType() != childForm.GetType())
            {
                // Ferme le formulaire actuel s'il existe
                currentChildForm?.Close();

                // Crée une nouvelle instance du formulaire à ouvrir
                currentChildForm = (Form)Activator.CreateInstance(childForm.GetType());

                // Configure les propriétés du formulaire
                currentChildForm.TopLevel = false;
                currentChildForm.FormBorderStyle = FormBorderStyle.None;
                currentChildForm.Dock = DockStyle.Fill;

                // Ajoute le formulaire à la zone de travail "panelDesktop"
                panelDesktop.Controls.Clear();
                panelDesktop.Controls.Add(currentChildForm);
                currentChildForm.BringToFront();
                currentChildForm.Show();
            }
        }

        // Lorsque le bouton est cliqué, celui-ci change d'apparence et ouvre le formulaire "FormGenre"
        private void btnGenre_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormGenre());
        }

        // Lorsque le bouton est cliqué, celui-ci change d'apparence et ouvre le formulaire "FormSalle"
        private void btnSalle_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormSalle());
        }

        // Lorsque le bouton est cliqué, celui-ci change d'apparence et ouvre le formulaire "FormFilm"
        private void btnFilm_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormFilm());
        }

        // Lorsque le bouton est cliqué, celui-ci change d'apparence et ouvre le formulaire "FormProjection"
        private void btnProjection_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormProjection());
        }

        // Lorsque le bouton est cliqué, celui-ci change d'apparence et ouvre le formulaire "FormPDF"
        private void btnPDF_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormPDF());
        }

        // Lorsque le bouton est cliqué, celui-ci change d'apparence et ouvre le formulaire "FormAccueil"
        private void btnAccueil_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormAccueil());
        }

        // Déplacement de la fenêtre
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Permet de déplacer la fenêtre avec la souris
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Permet de fermer l'application
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Permet d'agrandir l'application sur toute l'écran
        private void btnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
                WindowState = FormWindowState.Normal;
        }

        // Permet de minimiser l'application dans la barre de tâche
        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}