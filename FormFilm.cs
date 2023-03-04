using Microsoft.VisualBasic;
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
    public partial class FormFilm : Form
    {
        string namePicture = null;
        Boolean lancement = true;
        List<int> idPublics = new List<int>();
        List<int> idGenres = new List<int>();
        List<int> idFilms = new List<int>();

        public FormFilm()
        {
            InitializeComponent();
        }

        private void Film_Load(object sender, EventArgs e)
        {
            try
            {
                //Initialisation des éléments cboTitre, lblMsg et timeFilm
                cboTitre.Text = "Sélectionner un titre";
                cboTitre.DropDownHeight = 500;
                lblMsg.Text = "";

                timeFilm.Format = DateTimePickerFormat.Time;
                timeFilm.ShowUpDown = true;
                timeFilm.Value = DateTime.Parse("00:00:00");

                //Connexion à la base de données
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                // Affichage des genres dans lstGenre
                // 
                OdbcCommand cmdlstgenre = new OdbcCommand(); OdbcDataReader drrlstgenre; Boolean existenlstgenre;
                // Recherche de tous les genres dans la base de données
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
                refreshCboFilm("select distinct nofilm, titre from film natural join public order by titre");

                pictureBox1.Image = Properties.Resources.noimg;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                lancement = false;
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        public void refreshCboFilm(string requestFilm)
        {
            try
            {
                Boolean existe = true;
            
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                OdbcCommand cmdfilm = new OdbcCommand(); OdbcDataReader drrfilm; Boolean existenfilm;
                cmdfilm.CommandText = requestFilm;
                cmdfilm.Connection = cnn;
                drrfilm = cmdfilm.ExecuteReader();
                existenfilm = drrfilm.Read();
                
                if (!existenfilm) { existe = false; }
                idFilms.Clear();
                cboTitre.Items.Clear();

                while (existenfilm == true)

                {
                    idFilms.Add(Convert.ToInt32(drrfilm["nofilm"]));
                    cboTitre.Items.Add(drrfilm["titre"].ToString());
                    existenfilm = drrfilm.Read();
                }

                drrfilm.Close();
                cnn.Close();

                if (existe && cboTitre.SelectedIndex == -1)
                {
                    
                }

                if (existe)
                {
                    cboTitre.SelectedIndex = 0;
                    cboTitre.Enabled = true;
                    cboTitre_SelectedIndexChanged(this, EventArgs.Empty);
                }
                else
                {
                    cboTitre.Enabled = false;
                    cboTitre.Text = "Aucun film ne correspond à la recherche";
                    ResetInfoFilm();
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        private void ResetInfoFilm()
        {
            lblSynopsis.Text = "Synopsis :";
            lblDirector.Text = "Réalisateur(s) : ";
            lblActor.Text = "Acteur(s) : ";
            lblDuree.Text = "Durée : ";
            lblPublic.Text = "Type de public : ";
            pbAffFilm.Image = null;
            lblGenre.Text = "Genre(s) :";
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
            try
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
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        private bool CheckExistFilm(string titre)
        {   try
            {
                lblMsg.Text = "";
                errorProviderGenre.SetError(txtTitle, "");

                Boolean existenfilm = true;

                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                OdbcCommand cmd = new OdbcCommand(); OdbcDataReader drr;
                cmd.CommandText = "select exists(select nofilm from film where titre ='" + titre + "') as filmExist";
                cmd.Connection = cnn;
                drr = cmd.ExecuteReader();
                drr.Read();

                existenfilm = Convert.ToBoolean(drr["filmExist"]);

                drr.Close();
                cnn.Close();

                if (existenfilm)
                {
                    lblMsg.Text = "Ce film existe déjà";
                    errorProviderGenre.SetError(txtTitle, "Film déjà existant");
                }
            
                return existenfilm;
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
                return true;
            }
        }

        private bool FilmHasProjection(string nofilm)
        {
            try
            {
                Boolean CanDelete = false;

                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                OdbcCommand cmd = new OdbcCommand(); OdbcDataReader drr; Boolean existenProjection;
                cmd.CommandText = "select count(nofilm) as nbproj from projection where nofilm =" + nofilm;
                cmd.Connection = cnn;
                drr = cmd.ExecuteReader();
                existenProjection = drr.Read();

                if (Convert.ToInt16(drr["nbproj"]) > 0)
                {
                    CanDelete = false;
                    if (MessageBox.Show("Attention, le film que vous allez supprimer possède une projection.\nÊtes-vous sûr de vouloir le supprimer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        CanDelete = true;
                    }
                }
                else
                {
                    CanDelete = true;
                }

                drr.Close();
                cnn.Close();
                
                return CanDelete;
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
                return false;
            }
        }

        private void btnAddFilm_Click(object sender, EventArgs e)
        {   try
            {
                if (!CheckExistFilm(txtTitle.Text))
                {
                    checkData();

                    if (lstGenre.SelectedItems.Count > 0 && timeFilm.Text.ToString() != "00:00:00" && txtTitle.Text != "" && txtDirector.Text.ToString() != "" && txtActor.Text.ToString() != "" && txtSynopsis.Text.ToString() != "" && cboPublic.SelectedIndex > -1)
                    {
                    
                        OdbcConnection cnn = new OdbcConnection();
                        cnn.ConnectionString = varglob.strconnect;
                        cnn.Open();

                        OdbcCommand cmdfilm = new OdbcCommand();
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
                        cmdfilm.ExecuteNonQuery();

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

                        refreshCboFilm("select distinct nofilm, titre from film natural join public order by titre");
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
                    }
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        private void btnDeleteFilm_Click(object sender, EventArgs e)
        {   
            try
            {
                removeError();

                if (cboTitre.Items.Count > 0 && MessageBox.Show("Êtes-vous sûr de vouloir supprimer le film suivant :\n" + cboTitre.SelectedItem, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (FilmHasProjection(idFilms[cboTitre.SelectedIndex].ToString()))
                    {
                    
                        OdbcConnection cnn = new OdbcConnection();
                        cnn.ConnectionString = varglob.strconnect;
                        cnn.Open();

                        OdbcCommand cmdprojection = new OdbcCommand();
                        cmdprojection.CommandText = "delete from projection where nofilm =" + idFilms[cboTitre.SelectedIndex] + "";
                        cmdprojection.Connection = cnn;
                        cmdprojection.ExecuteNonQuery();

                        OdbcCommand cmdconcerner = new OdbcCommand();
                        cmdconcerner.CommandText = "delete from concerner where nofilm =" + idFilms[cboTitre.SelectedIndex] + "";
                        cmdconcerner.Connection = cnn;
                        cmdconcerner.ExecuteNonQuery();

                        OdbcCommand cmdfilm = new OdbcCommand();
                        cmdfilm.CommandText = "delete from film where nofilm =" + idFilms[cboTitre.SelectedIndex] + "";
                        cmdfilm.Connection = cnn;
                        cmdfilm.ExecuteNonQuery();

                        cnn.Close();

                        lblMsg.Text = "Le film \"" + cboTitre.SelectedItem + "\" a été supprimé";

                        refreshCboFilm("select distinct nofilm, titre from film natural join public order by titre");
                    }
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }

        }

        private void btnResearch_Click(object sender, EventArgs e)
        {   
            try 
            {
                removeError();

                string dureeFilm = "";
                if (timeFilm.Text.ToString() != "00:00:00")
                {
                    dureeFilm = timeFilm.Text.ToString();
                }

                OdbcCommand cmdfilm = new OdbcCommand();
                cmdfilm.CommandText = "select distinct titre, nofilm from film natural join concerner natural join genre natural join public " +
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
                cmdfilm.CommandText += "order by titre";

                refreshCboFilm(cmdfilm.CommandText);
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }

        }

        private void btnImportPicture_Click(object sender, EventArgs e)
        {
            try
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

                    pictureBox1.Image = Image.FromFile(@Application.StartupPath + "\\affiches\\" + Path.GetFileName(namePicture));
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
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
                    refreshCboFilm("select distinct nofilm, titre from film natural join public order by titre");
                }
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        private void cboTitre_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                OdbcCommand cmdfilm = new OdbcCommand(); OdbcDataReader drrfilm;
                cmdfilm.CommandText = "select * from film natural join public where nofilm =" + idFilms[cboTitre.SelectedIndex];
                cmdfilm.Connection = cnn;
                drrfilm = cmdfilm.ExecuteReader();
                drrfilm.Read();

                string synopsis;
                synopsis = drrfilm["synopsis"].ToString() + "...";
                if (synopsis.Length > 300)
                {
                    synopsis = synopsis.Remove(synopsis.Length - 3).Substring(0, 150) + "...";
                }
                lblSynopsis.Text = "Synopsis :";
                lblSynopsis.Text += "\n" + synopsis;

                lblDirector.Text = "Réalisateur(s) : " + drrfilm["realisateurs"].ToString();
                lblActor.Text = "Acteur(s) : " + drrfilm["acteurs"].ToString();

                DateTime duree = DateTime.Parse(drrfilm["duree"].ToString());
                lblDuree.Text = "Durée : " + duree.ToString("HH") + "h " + duree.ToString("mm") + "min";

                lblPublic.Text = "Type de public : " + drrfilm["libpublic"].ToString();

                string imgPath = Path.Combine(Application.StartupPath + "\\affiches\\" + drrfilm["imgaffiche"].ToString());
                if (File.Exists(imgPath))
                {
                    pbAffFilm.Image = Image.FromFile(imgPath);
                }
                else
                {
                    pbAffFilm.Image = Properties.Resources.noimg;
                }
                pbAffFilm.SizeMode = PictureBoxSizeMode.Zoom;


                lblGenre.Text = "Genre(s) :";
                //affichage des genres
                OdbcCommand cmdgenre = new OdbcCommand(); OdbcDataReader drrgenre; Boolean existengenre;
                cmdgenre.CommandText = "SELECT libgenre FROM genre natural join concerner where nofilm = " + drrfilm["nofilm"] + "";

                cmdgenre.Connection = cnn;
                drrgenre = cmdgenre.ExecuteReader();
                existengenre = drrgenre.Read();

                while (existengenre == true)
                {
                    lblGenre.Text += " " + drrgenre["libgenre"].ToString() + ",";
                    existengenre = drrgenre.Read();
                }
                string genres = lblGenre.Text.ToString();

                if (lblGenre.Text.ToString() != "")
                {
                    lblGenre.Text = genres.Remove(genres.Length - 1);
                }

                drrgenre.Close();
                drrfilm.Close();
                cnn.Close();
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        private void cboTitre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboTitre.SelectedIndex == -1 || cboTitre.Items.Count == 0)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                }
            }
        }

        private void cboTitre_TextChanged(object sender, EventArgs e)
        {
                Cursor = Cursors.Default;
        }
    }
}