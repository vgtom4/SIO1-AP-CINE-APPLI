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
            varglob.strconnect = System.IO.File.ReadAllText(Application.StartupPath + "\\connexion.txt") + Interaction.InputBox("Quel est le mot de passe de votre base de donnée ?");

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
                        varglob.strconnect = System.IO.File.ReadAllText(Application.StartupPath + "\\connexion.txt") + Interaction.InputBox("Quel est le mot de passe de votre base de donnée ?");
                    }
                    // Sinon, la boucle s'arrête après avoir mis continu à false
                    else
                    {
                        continu = false;
                    }
                }
            }

            // Arrête de l'application si l'utilisateur n'a pas voulu continué la tentative de connexion
            if (!continu)
                Application.Exit();
            // Sinon, le programme continu et sélectionne le bouton "accueil" dans le menu puis ouvre le formulaire "accueil"
            else
            {
                ActivateButton(btnAccueil);
                OpenChildForm(new FormAccueil());
            }

        }

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

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(32, 32, 32);
                currentBtn.ForeColor = Color.FromArgb(253, 195, 0);
                currentBtn.IconColor = Color.FromArgb(253, 195, 0);
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm == null || currentChildForm.GetType() != childForm.GetType())
            {
                currentChildForm?.Close();

                currentChildForm = (Form)Activator.CreateInstance(childForm.GetType());
                currentChildForm.TopLevel = false;
                currentChildForm.FormBorderStyle = FormBorderStyle.None;
                currentChildForm.Dock = DockStyle.Fill;
                panelDesktop.Controls.Clear();
                panelDesktop.Controls.Add(currentChildForm);
                currentChildForm.BringToFront();
                currentChildForm.Show();
            }
        }

        private void btnGenre_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormGenre());
        }

        private void btnSalle_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormSalle());
        }

        private void btnFilm_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormFilm());
        }

        private void btnProjection_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormProjection());
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormPDF());
        }

        private void btnAccueil_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormAccueil());
        }

        //Déplacement de la fenêtre
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}