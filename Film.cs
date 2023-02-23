using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP_CINE_APPLI
{
    public partial class Film : Form
    {
        string namePicture = null;
        List<int> idPublics = new List<int>();
        List<int> idGenres = new List<int>();

        public Film()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Film_Load(object sender, EventArgs e)
        {
            // Initialisation du DataGridView et des différents éléments graphiques.
            lblMsg.BackColor = Color.White;
            lblMsg.Text = "";

            grdFilm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grdFilm.AllowUserToAddRows = false;
            grdFilm.ReadOnly = true;
            grdFilm.RowHeadersVisible = false;
            grdFilm.ColumnCount = 10;
            grdFilm.RowHeadersVisible = true;

            grdFilm.Columns[0].Width = 30;
            grdFilm.Columns[1].Width = 100;
            grdFilm.Columns[2].Width = 100;
            grdFilm.Columns[3].Width = 100;
            grdFilm.Columns[4].Width = 100;
            grdFilm.Columns[5].Width = 50;
            grdFilm.Columns[6].Width = 127;
            grdFilm.Columns[7].Width = 100;
            grdFilm.Columns[8].Width = 100;
            grdFilm.Columns[9].Width = 100;

            grdFilm.Columns[0].HeaderText = "N°";
            grdFilm.Columns[1].HeaderText = "Titre";
            grdFilm.Columns[2].HeaderText = "Affiche";
            grdFilm.Columns[3].HeaderText = "Réalisateur(s)";
            grdFilm.Columns[4].HeaderText = "Acteur(s)";
            grdFilm.Columns[5].HeaderText = "Durée";
            grdFilm.Columns[6].HeaderText = "Synopsis";
            grdFilm.Columns[7].HeaderText = "Genre(s)";
            grdFilm.Columns[8].HeaderText = "Type de public";
            grdFilm.Columns[9].HeaderText = "Informations du film";

            for (int j = 1; j <= grdFilm.ColumnCount - 1; j++)
            {
                grdFilm.Columns[j].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            timeFilm.Format = DateTimePickerFormat.Time;
            timeFilm.ShowUpDown = true;
            timeFilm.Value = DateTime.Parse("00:00:00");

            //Initialisation de la connexion à la base de données
            OdbcConnection cnn = new OdbcConnection();

            cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + password.pwdDb + "";
            cnn.Open();

            //affichage des genres dans lstGenre

            OdbcCommand cmdlstgenre = new OdbcCommand(); OdbcDataReader drrlstgenre; Boolean existenlstgenre;
            cmdlstgenre.CommandText = "select * from genre";
            cmdlstgenre.Connection = cnn;
            drrlstgenre = cmdlstgenre.ExecuteReader();
            existenlstgenre = drrlstgenre.Read();

            lstGenre.Items.Clear();
            lstGenre.MultiColumn= true;
            lstGenre.SelectionMode = SelectionMode.MultiSimple;

            while (existenlstgenre == true)
            {
                lstGenre.Items.Add(drrlstgenre["libgenre"]);
                idGenres.Add(Convert.ToInt16(drrlstgenre["nogenre"]));

                existenlstgenre = drrlstgenre.Read();
            }
            drrlstgenre.Close();

            // Remplissage du ComboBox pour les différents publics ciblés possibles (-12, -16...)

            OdbcCommand cmdpublic = new OdbcCommand(); OdbcDataReader drrpublic; Boolean existenpublic;
            cmdpublic.CommandText = "select * from public";
            cmdpublic.Connection = cnn;
            drrpublic = cmdpublic.ExecuteReader();
            existenpublic = drrpublic.Read();

            cboPublic.Items.Clear();

            while (existenpublic == true)
            {
                cboPublic.Items.Add(drrpublic["libpublic"]);
                idPublics.Add(Convert.ToInt16(drrpublic["nopublic"]));

                existenpublic = drrpublic.Read();
            }
            drrpublic.Close();

            cnn.Close();

            
            // Affichage des films en appelant la méthode affichageFilm avec la requête qui importe tous les films et publics
            affichageFilm("select * from film natural join public");


            pictureBox1.Image = Properties.Resources.noimg;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }

        // Création d'une méthode affichage film qui appelle un paramètre "requestfilm" pour afficher ensuite dans le combobox
        public void affichageFilm(string requestFilm)
        {
            grdFilm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            OdbcConnection cnn = new OdbcConnection();
            OdbcCommand cmdfilm = new OdbcCommand(); OdbcDataReader drrfilm; Boolean existenfilm;

            cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + password.pwdDb + "";
            cnn.Open();

            cmdfilm.CommandText = requestFilm;
            cmdfilm.Connection = cnn;
            drrfilm = cmdfilm.ExecuteReader();
            existenfilm = drrfilm.Read();

            grdFilm.Rows.Clear();

            while (existenfilm == true)
            {
                string synopsis;
                synopsis = Convert.ToString(drrfilm["synopsis"]);
                if (synopsis.Length > 100)
                {
                    synopsis = synopsis.Substring(0, 100) + "...";
                }

                grdFilm.Rows.Add(drrfilm["nofilm"], drrfilm["titre"], null, drrfilm["realisateurs"], drrfilm["acteurs"], drrfilm["duree"], synopsis, "", drrfilm["libpublic"], drrfilm["infofilm"]);

                grdFilm[2, grdFilm.RowCount - 1] = new DataGridViewImageCell();

                string imgPath = Path.Combine(Application.StartupPath + "\\affiches\\" + drrfilm["imgaffiche"].ToString());
                if (File.Exists(imgPath))
                {
                    Image img = Image.FromFile(imgPath);
                    grdFilm[2, grdFilm.RowCount - 1].Value = new Bitmap(img, grdFilm.Columns[2].Width, img.Height * grdFilm.Columns[2].Width / img.Width);
                }
                else
                {

                    Image img = Properties.Resources.noimg;
                    grdFilm[2, grdFilm.RowCount - 1].Value = new Bitmap(img, grdFilm.Columns[2].Width, img.Height * grdFilm.Columns[2].Width / img.Width);
                }


                //affichage des genres dans grdFilm
                OdbcCommand cmdgenre = new OdbcCommand(); OdbcDataReader drrgenre; Boolean existengenre;
                cmdgenre.CommandText = "SELECT libgenre FROM genre natural join concerner where nofilm = " + drrfilm["nofilm"] + "";

                cmdgenre.Connection = cnn;
                drrgenre = cmdgenre.ExecuteReader();
                existengenre = drrgenre.Read();

                while (existengenre == true)
                {
                    grdFilm[7, grdFilm.RowCount - 1].Value += drrgenre["libgenre"].ToString() + ",\n";
                    existengenre = drrgenre.Read();
                }
                string genres = grdFilm[7, grdFilm.RowCount - 1].Value.ToString();

                grdFilm[7, grdFilm.RowCount - 1].Value = genres.Remove(genres.Length - 2);
                drrgenre.Close();

                existenfilm = drrfilm.Read();
            }

            drrfilm.Close();

            cnn.Close();

            grdFilm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void removeError()
        {
            errorProviderTitle.SetError(txtTitle, "");
            errorProviderDirector.SetError(txtDirector, "");
            errorProviderActor.SetError(txtActor, "");
            errorProviderSynopsis.SetError(txtSynopsis, "");
            errorProviderDuree.SetError(timeFilm, "");
            errorProviderPublic.SetError(cboPublic, "");
            errorProviderGenre.SetError(lstGenre, "");
            lblMsg.Text = "";
        }

        private void checkData()
        {
            removeError();

            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                errorProviderTitle.SetError(txtTitle, "Veuillez remplir ce champ");
            }

            if (string.IsNullOrEmpty(txtDirector.Text))
            {
                errorProviderDirector.SetError(txtDirector, "Veuillez remplir ce champ");
            }

            if (string.IsNullOrEmpty(txtActor.Text))
            {
                errorProviderActor.SetError(txtActor, "Veuillez remplir ce champ");
            }

            if (string.IsNullOrEmpty(txtSynopsis.Text))
            {
                errorProviderSynopsis.SetError(txtSynopsis, "Veuillez remplir ce champ");
            }

            if (timeFilm.Value.ToString("T") == "00:00:00")
            {
                errorProviderDuree.SetError(timeFilm, "Veuillez remplir ce champ");
            }

            if (cboPublic.SelectedIndex < 0)
            {
                errorProviderPublic.SetError(cboPublic, "Veuillez remplir ce champ");
            }

            if (lstGenre.SelectedItems.Count == 0)
            {
                errorProviderGenre.SetError(lstGenre, "Veuillez remplir ce champ");
            }
        }

        private void btnAddFilm_Click(object sender, EventArgs e)
        {
            checkData();

            if (lstGenre.SelectedItems.Count > 0 && timeFilm.Text.ToString() != "00:00:00" && txtTitle.Text != "" && txtDirector.Text.ToString() != "" && txtActor.Text.ToString() != "" && txtSynopsis.Text.ToString() != "" && cboPublic.SelectedIndex > -1)
            {
                OdbcConnection cnn = new OdbcConnection();
                OdbcCommand cmdfilm = new OdbcCommand();

                cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + password.pwdDb + "";
                cnn.Open();

                cmdfilm.CommandText = "insert into film values (null, " +
                                                            "'" + txtTitle.Text.Replace("\'", "\\'") + "', " +
                                                            "'" + txtDirector.Text.Replace("\'", "\\'") + "', " +
                                                            "'" + txtActor.Text.ToString().Replace("\'", "\\'") + "', " +
                                                            "'" + timeFilm.Text + "', " +
                                                            "'" + txtSynopsis.Text.ToString().Replace("\'", "\\'") + "', " +
                                                            "'" + txtInfo.Text.ToString().Replace("\'", "\\'") + "', " +
                                                            "'" + namePicture + "', " +
                                                            "'" + idPublics[cboPublic.SelectedIndex] + "')";
                cmdfilm.Connection = cnn;
                cmdfilm.ExecuteReader();

                OdbcCommand cmdnofilm = new OdbcCommand(); OdbcDataReader drrnofilm; bool existennofilm;
                cmdnofilm.CommandText = "SELECT nofilm FROM film ORDER BY nofilm DESC LIMIT 1";
                cmdnofilm.Connection = cnn;
                drrnofilm = cmdnofilm.ExecuteReader();
                existennofilm = drrnofilm.Read();

                OdbcCommand cmdconcerner = new OdbcCommand();
                for (int i = 0; i < lstGenre.Items.Count; i++)
                {
                    if (lstGenre.GetSelected(i) == true)
                    {
                        cmdconcerner.CommandText = "insert into concerner values (" + drrnofilm["nofilm"] + ", " + idGenres[i] + ")";
                        cmdconcerner.Connection = cnn;
                        cmdconcerner.ExecuteNonQuery();
                    }
                }
                drrnofilm.Close();
                cnn.Close();

                lblMsg.Text = "Le film \"" + txtTitle.Text + "\" a été ajouté";
                lblMsg.ForeColor = Color.Blue;

                affichageFilm("select * from film natural join public");
            }
            else
            {
                string message = "Données manquantes :\n";
                message += txtTitle.Text != "" ? "" : "Titre\n";
                message += txtDirector.Text.ToString() != "" ? "" : "Réalisateur(s)\n";
                message += txtActor.Text.ToString() != "" ? "" : "Acteur(s)\n";
                message += txtSynopsis.Text.ToString() != "" ? "" : "Synopsis\n";
                message += timeFilm.Text.ToString() != "00:00:00" ? "" : "Durée\n";
                message += cboPublic.SelectedIndex > 0 ? "" : "Type de public\n";
                message += lstGenre.SelectedItems.Count != 0 ? "" : "Genre(s)\n";

                lblMsg.Text = message;
                lblMsg.ForeColor = Color.Red;
            }
        }

        private void btnDeleteFilm_Click(object sender, EventArgs e)
        {
            removeError();
            if (grdFilm.RowCount > 0 && MessageBox.Show("Êtes-vous sûr de vouloir supprimer le film suivant :\n" + grdFilm[1, grdFilm.CurrentRow.Index].Value, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                OdbcConnection cnn = new OdbcConnection();
                
                cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + password.pwdDb + "";
                cnn.Open();

                OdbcCommand cmdconcerner = new OdbcCommand(); OdbcDataReader drrconcerner;

                cmdconcerner.CommandText = "delete from concerner where nofilm =" + grdFilm[0, grdFilm.CurrentRow.Index].Value + "";
                cmdconcerner.Connection = cnn;
                drrconcerner = cmdconcerner.ExecuteReader();

                drrconcerner.Close();


                OdbcCommand cmdprojection = new OdbcCommand();

                cmdprojection.CommandText = "delete from projection where nofilm =" + grdFilm[0, grdFilm.CurrentRow.Index].Value + "";
                cmdprojection.Connection = cnn;
                cmdprojection.ExecuteReader();


                OdbcCommand cmdfilm = new OdbcCommand(); OdbcDataReader drrfilm;
                cmdfilm.CommandText = "delete from film where nofilm =" + grdFilm[0, grdFilm.CurrentRow.Index].Value + "";
                cmdfilm.Connection = cnn;
                drrfilm = cmdfilm.ExecuteReader();

                drrfilm.Close();
                lblMsg.Text = "Le film \"" + grdFilm[1, grdFilm.CurrentRow.Index].Value + "\" a été supprimé";
                lblMsg.ForeColor = Color.Red;

                affichageFilm("select * from film natural join public");
            }

        }

        private void btnResearch_Click(object sender, EventArgs e)
        {
            removeError();
            grdFilm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            string dureeFilm = "";
            if (timeFilm.Text.ToString() != "00:00:00")
            {
                dureeFilm = timeFilm.Text.ToString();
            }

            OdbcConnection cnn = new OdbcConnection(); OdbcCommand cmdfilm = new OdbcCommand();
            
            cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + password.pwdDb + "";
            cnn.Open();

            cmdfilm.CommandText = "select film.*, libgenre, libpublic from film natural join concerner natural join genre natural join public " +
                                           "where titre like '%" + txtTitle.Text.ToString().Replace("\'", "\\'") + "%' " +
                                           "and realisateurs like '%" + txtDirector.Text.ToString().Replace("\'", "\\'") + "%' " +
                                           "and acteurs like '%" + txtActor.Text.ToString().Replace("\'", "\\'") + "%' " +
                                           "and duree like '%" + dureeFilm + "%' " +
                                           "and synopsis like '%" + txtSynopsis.Text.ToString().Replace("\'", "\\'") + "%' " +
                                           "and infofilm like '%" + txtInfo.Text.ToString().Replace("\'", "\\'") + "%' ";
            if (cboPublic.SelectedIndex > -1)
            {
                cmdfilm.CommandText += "and nopublic = " + idPublics[cboPublic.SelectedIndex] + " ";
            }

            if (lstGenre.SelectedItems.Count > 0)
            {
                cmdfilm.CommandText += "and nogenre IN (";

                for (int i = 0; i < lstGenre.Items.Count; i++)
                {
                    if (lstGenre.GetSelected(i) == true)
                    {
                        cmdfilm.CommandText += "" + idGenres[i] + ",";
                    }
                }
                cmdfilm.CommandText = cmdfilm.CommandText.Remove(cmdfilm.CommandText.Length - 1);
                cmdfilm.CommandText += ") ";
            }

            cmdfilm.CommandText += "group by nofilm";

            affichageFilm(cmdfilm.CommandText);

            cnn.Close();

            grdFilm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void btnImportPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images (*.BMP;*.JPG;*.PNG;*.JPEG)|*.BMP;*.JPG;*.PNG;*.JPEG|" + "All files (*.*)|*.*";
            openFileDialog.InitialDirectory = @Application.StartupPath + "\\affiches\\";
            openFileDialog.Title = "Sélectionner une image";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                string destinationPath = @Application.StartupPath + "\\affiches\\" + Path.GetFileName(filePath);
                namePicture = Path.GetFileName(filePath);
                if (String.Compare(filePath, destinationPath)!=0)
                {
                    File.Copy(filePath, destinationPath, true);
                }
                lblMsg.Text = "L'image a été enregistrée";
                lblMsg.ForeColor = Color.Blue;

                pictureBox1.Image = Image.FromFile(@Application.StartupPath + "\\affiches\\" + Path.GetFileName(namePicture));
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            removeError();
            if (txtTitle.Text == "test")
            {
                txtTitle.Text = "test";
                txtDirector.Text = "test";
                txtActor.Text = "test";
                timeFilm.Text = "01:00:00";
                txtSynopsis.Text = "test";
                txtInfo.Text = "test";
                namePicture = "noimg.png";
                cboPublic.SelectedIndex = 1;
                lstGenre.SelectedIndex = 0;
                lstGenre.SelectedIndex = 3;
            }
            else
            {
                txtTitle.Text = "";
                txtDirector.Text = "";
                txtActor.Text = "";
                timeFilm.Text = "00:00:00";
                txtSynopsis.Text = "";
                txtInfo.Text = "";
                namePicture = null;
                cboPublic.SelectedIndex = -1;
                lstGenre.SelectedIndex = -1;
                affichageFilm("select * from film natural join public");
            }
            lblMsg.Text = "";
        }
    }
}
