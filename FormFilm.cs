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
        // Déclaration et initialisation de variables
        string namePicture = null;

        // Déclaration des listes pour les ID
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
                //Initialisations des éléments
                cboTitre.DropDownHeight = 500;

                timeFilm.Format = DateTimePickerFormat.Time;
                timeFilm.ShowUpDown = true;
                timeFilm.Value = DateTime.Parse("00:00:00");

                pictureBox1.Image = Properties.Resources.noimg;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                lblMsg.Text = "";

                //Connexion à la base de données
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                #region Insertion du libellé des genres dans "lstGenre" et de leur ID dans la liste "idGenres"
                OdbcCommand cmdlstgenre = new OdbcCommand(); OdbcDataReader drrlstgenre; Boolean existenlstgenre;
                // Recherche de tous les genres dans la base de données
                cmdlstgenre.CommandText = "select * from genre order by libgenre";
                cmdlstgenre.Connection = cnn;
                drrlstgenre = cmdlstgenre.ExecuteReader();
                existenlstgenre = drrlstgenre.Read();

                // Paramétrage de "lstGenre"
                lstGenre.Items.Clear();
                lstGenre.MultiColumn= true;
                lstGenre.SelectionMode = SelectionMode.MultiSimple;

                // Remplissage du ListBox "lstGenre" avec le libellé de genre "libgenre" et de la liste "idGenres" avec l'ID de genre.
                while (existenlstgenre == true)
                {
                    lstGenre.Items.Add(drrlstgenre["libgenre"]);
                    idGenres.Add(Convert.ToInt16(drrlstgenre["nogenre"]));
                    existenlstgenre = drrlstgenre.Read();
                }
                drrlstgenre.Close();
                #endregion

                #region Insertion du libellé des publics dans "cboPublic" et de leur ID dans la liste "idPublics"
                // Recherche de tous les publics dans la base de données
                OdbcCommand cmdpublic = new OdbcCommand(); OdbcDataReader drrpublic; Boolean existenpublic;
                cmdpublic.CommandText = "select * from public";
                cmdpublic.Connection = cnn;
                drrpublic = cmdpublic.ExecuteReader();
                existenpublic = drrpublic.Read();

                cboPublic.Items.Clear();

                // Remplissage du ComboBox "cboPublic" avec le libellé de public "libpublic" et de la liste "idPublics" avec l'ID de public.
                while (existenpublic == true)
                {
                    cboPublic.Items.Add(drrpublic["libpublic"]);
                    idPublics.Add(Convert.ToInt16(drrpublic["nopublic"]));
                    existenpublic = drrpublic.Read();
                }
                drrpublic.Close();
                cnn.Close();
                #endregion

                // Appel de la méthode refreshCboFilm avec la requête qui importe tous les films et publics pour insérer les titres de films dans "cboTitre"
                RefreshCboFilm("select distinct nofilm, titre from film natural join public order by titre");
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        /// <summary>
        /// Permet d'insérer dans "cboTitre" les titres des films et leur ID recherchés par la requête SQL "requestFilm"
        /// </summary>
        /// <param name="requestFilm">Requête SQL pour rechercher les titres de films et leur ID</param>
        public void RefreshCboFilm(string requestFilm)
        {
            try
            {
                Boolean existe = true;

                // Connexion à la base de données
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                // Recherche des titres et de leur ID avec la requête "requestFilm"
                OdbcCommand cmdfilm = new OdbcCommand(); OdbcDataReader drrfilm; Boolean existenfilm;
                cmdfilm.CommandText = requestFilm;
                cmdfilm.Connection = cnn;
                drrfilm = cmdfilm.ExecuteReader();
                existenfilm = drrfilm.Read();
                
                // Vérifie si le résultat de la requête retourne des films
                // Si ce n'est pas le cas, "existe" bascule sur false
                if (!existenfilm) existe = false;
                
                idFilms.Clear();
                cboTitre.Items.Clear();

                // Remplissage de "cboTitre" avec les titres de film "titre" et de la liste "idFilms" avec l'ID de film.
                while (existenfilm == true)
                {
                    idFilms.Add(Convert.ToInt32(drrfilm["nofilm"]));
                    cboTitre.Items.Add(drrfilm["titre"].ToString());
                    existenfilm = drrfilm.Read();
                }
                drrfilm.Close();
                cnn.Close();

                // Vérifie si la requête renvoie des films grâce à la variable "existe"
                // Si c'est le cas, les informations du premier film sont affichées via la méthode "cboTitre_SelectedIndexChanged"
                if (existe)
                {
                    cboTitre.SelectedIndex = 0;
                    cboTitre.Enabled = true;
                    cboTitre_SelectedIndexChanged(this, EventArgs.Empty);
                }
                // Sinon, tous les champs sont vidés, "cboTitre" devient non cliquable et un message est affiché
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

        /// <summary>
        /// Permet de vider tous les labels informatifs de film.
        /// </summary>
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

        /// <summary>
        /// Permet de supprimer les erreurs causées par des entrées invalides et de vider "lblMsg".
        /// </summary>
        private void RemoveError()
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

        /// <summary>
        /// Permet de vérifier si toutes les entrées sont valides.
        /// </summary>
        /// <returns>true si toutes les entrées sont valides; sinon false</returns>
        private bool CheckData()
        {
            try
            {
                RemoveError();

                // Initialisation de la variable boolean qui permet d'indique si les données sont valides
                Boolean dataAreValid = true;

                // Vérifie si "txtTitle" est null ou vide
                if (string.IsNullOrEmpty(txtTitle.Text))
                {
                    errorProviderTitle.SetError(txtTitle, "Veuillez remplir ce champ");
                     
                }

                // Vérifie si "txtDirector" est null ou vide
                if (string.IsNullOrEmpty(txtDirector.Text))
                {
                    errorProviderDirector.SetError(txtDirector, "Veuillez remplir ce champ");
                    dataAreValid = false;
                }

                // Vérifie si "txtActor" est null ou vide
                if (string.IsNullOrEmpty(txtActor.Text))
                {
                    errorProviderActor.SetError(txtActor, "Veuillez remplir ce champ");
                    dataAreValid = false;
                }

                // Vérifie si "txtSynopsis" est null ou vide
                if (string.IsNullOrEmpty(txtSynopsis.Text))
                {
                    errorProviderSynopsis.SetError(txtSynopsis, "Veuillez remplir ce champ");
                    dataAreValid = false;
                }

                // Vérifie si "timeFilm" est égale à "00:00:00" ("timeFilm" permet d'obtenir une durée pour un film. "00:00:00" signifie que le film à une durée de 0s)
                if (timeFilm.Value.ToString("T") == "00:00:00")
                {
                    errorProviderDuree.SetError(timeFilm, "Veuillez remplir ce champ");
                    dataAreValid = false;
                }

                // Vérifie si "cboPublic" n'a aucun élément de sélectionné
                if (cboPublic.SelectedIndex == -1)
                {
                    errorProviderPublic.SetError(cboPublic, "Veuillez remplir ce champ");
                    dataAreValid = false;
                }

                // Vérifie si aucun genre n'est sélectionné
                if (lstGenre.SelectedItems.Count == 0)
                {
                    errorProviderGenre.SetError(lstGenre, "Veuillez remplir ce champ");
                    dataAreValid = false;
                }
                
                if (!dataAreValid) lblMsg.Text = "Donnée(s) manquante(s) ou invalide(s)";
                
                return dataAreValid;
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
                return false;
            }
        }

        /// <summary> 
        /// Permet de vérifier si un titre de film existe déjà dans la base de données.
        /// </summary>
        /// <returns> true si le film existe; sinon false.</returns>
        private bool CheckExistFilm(string titre)
        {   try
            {
                RemoveError();

                // Connexion à la base de données
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                // Recherche pour vérifier dans la base de données si le même titre existe déjà
                // Retourne : 1 si c'est le cas; sinon 0
                OdbcCommand cmd = new OdbcCommand(); OdbcDataReader drr;
                cmd.CommandText = "select exists(select nofilm from film where titre ='" + titre.Replace("\'", "\\'") + "') as filmExist";
                cmd.Connection = cnn;
                drr = cmd.ExecuteReader();
                drr.Read();

                // Conversion de la réponse de la requête précédente en boolean (1 = true / 0 = false)
                Boolean filmExist = Convert.ToBoolean(drr["filmExist"]);

                drr.Close();
                cnn.Close();

                // Affiche un message si il existe déjà le film "titre"
                if (filmExist)
                {
                    lblMsg.Text = "Ce film existe déjà";
                    errorProviderGenre.SetError(txtTitle, "Film déjà existant");
                }
            
                return filmExist;
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - Méthode CheckExistFilm - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
                return true;
            }
        }

        /// <summary>
        /// Permet de vérifier si un film est lié à une projection.
        /// </summary>
        /// <returns>true si le film d'ID "nofilm" est lié à une projection; sinon false</returns>
        private bool FilmHasProjection(string nofilm, ref string msgError)
        {
            try
            {
                //Connexion à la base de données
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                // Vérifie dans la base de données s'il existe une liaison entre le film "nofilm" et les projections
                // Retourne : 1 si c'est le cas; sinon 0
                OdbcCommand cmd = new OdbcCommand(); OdbcDataReader drr;
                cmd.CommandText = "select exists(select nofilm from projection where nofilm ='" + nofilm + "') as filmLinkToProjection";
                cmd.Connection = cnn;
                drr = cmd.ExecuteReader();
                drr.Read();

                // Conversion de la réponse de la requête précédente en boolean (1 = true / 0 = false)
                Boolean filmIsLinkToProjection = Convert.ToBoolean(drr["filmLinkToProjection"]);

                drr.Close();
                cnn.Close();

                return filmIsLinkToProjection;
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - error originating from SalleHasProjection - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
                msgError = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Permet de savoir si le film "nofilm" peut être supprimer.
        /// </summary>
        /// <returns>true si le film peut être supprimer; sinon false</returns>
        private bool AllowDeleteFilm(string nofilm)
        {
            try
            {
                Boolean CanDelete = true;
                string msgError = "";

                // Si le film est lié à une projection, une confirmation de suppression est demandée à l'utilisateur
                if (FilmHasProjection(nofilm, ref msgError))
                {
                    CanDelete = false;
                    if (MessageBox.Show("Attention, le film que vous allez supprimer possède une projection.\nÊtes-vous sûr de vouloir le supprimer ?\n(Cela supprimera toutes les projections avec ce film)", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        CanDelete = true;
                    }
                }
                else
                {
                    // L'utilisateur nous pourra pas supprimer le film "nofilm" si une erreur se produit dans "FilmHasProjection"
                    if (msgError != "")
                    {
                        return false;
                    }
                }
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

        // Permet d'ajouter un film dans la base de données
        private void btnAddFilm_Click(object sender, EventArgs e)
        {   try
            {
                // Vérifie si les entrées sont valides et si le nouveau film n'existe pas déjà
                if (CheckData() && !CheckExistFilm(txtTitle.Text))
                {
                    // Connexion à la base de données
                    OdbcConnection cnn = new OdbcConnection();
                    cnn.ConnectionString = varglob.strconnect;
                    cnn.Open();

                    // Insertion d'un film dans la base de données à partir des saisies de l'utilisateur
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

                    // Récupération de l'ID du nouveau film créé
                    OdbcCommand cmdnofilm = new OdbcCommand(); OdbcDataReader drrnofilm; bool existennofilm;
                    cmdnofilm.CommandText = "SELECT MAX(nofilm) as lastFilm FROM film";
                    cmdnofilm.Connection = cnn;
                    drrnofilm = cmdnofilm.ExecuteReader();
                    existennofilm = drrnofilm.Read();

                    // Ajout des liaisons entre le nouveau film et ses genres dans la table concerner de la base de données
                    OdbcCommand cmdconcerner = new OdbcCommand();
                    for (int i = 0; i < lstGenre.Items.Count; i++)
                    {
                        // Si l'item i de "lstGenre" est sélectionné, on ajoute une liaison entre le film et le genre
                        if (lstGenre.GetSelected(i) == true)
                        {
                            cmdconcerner.CommandText = "insert into concerner values (" + drrnofilm["lastFilm"] + ", " + idGenres[i] + ")";
                            cmdconcerner.Connection = cnn;
                            cmdconcerner.ExecuteNonQuery();
                        }
                    }
                    drrnofilm.Close();
                    cnn.Close();

                    // Message pour informer l'utilisateur de l'ajout du film
                    lblMsg.Text = "Le film \"" + txtTitle.Text + "\" a été ajouté";

                    // Actualisation de "cboTitre"
                    RefreshCboFilm("select distinct nofilm, titre from film natural join public order by titre");
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        // Permet de supprimer le film sélectionné dans "cboTitre" de la base de données
        private void btnDeleteFilm_Click(object sender, EventArgs e)
        {   
            try
            {
                RemoveError();

                // Demande à l'utilisateur une confirmation du film sélectionné dans "cboTitre". Si le film possède une projection, une confirmation de supression des projections liées sera demandée.
                if (cboTitre.Items.Count > 0 && MessageBox.Show("Êtes-vous sûr de vouloir supprimer le film suivant :\n" + cboTitre.SelectedItem, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes && AllowDeleteFilm(idFilms[cboTitre.SelectedIndex].ToString()))
                {
                    // Connexion à la base de données
                    OdbcConnection cnn = new OdbcConnection();
                    cnn.ConnectionString = varglob.strconnect;
                    cnn.Open();

                    // Suppression, dans la table "projection" de la base de données, de toutes les correspondances avec le film sélectionné dans "cboTitre"
                    OdbcCommand cmdprojection = new OdbcCommand();
                    cmdprojection.CommandText = "delete from projection where nofilm =" + idFilms[cboTitre.SelectedIndex] + "";
                    cmdprojection.Connection = cnn;
                    cmdprojection.ExecuteNonQuery();

                    // Suppression, dans la table "concerner" de la base de données, de toutes les correspondances avec le film sélectionné dans "cboTitre"
                    OdbcCommand cmdconcerner = new OdbcCommand();
                    cmdconcerner.CommandText = "delete from concerner where nofilm =" + idFilms[cboTitre.SelectedIndex] + "";
                    cmdconcerner.Connection = cnn;
                    cmdconcerner.ExecuteNonQuery();

                    // Suppression, dans la table "film" de la base de données, du film sélectionné dans "cboTitre"
                    OdbcCommand cmdfilm = new OdbcCommand();
                    cmdfilm.CommandText = "delete from film where nofilm =" + idFilms[cboTitre.SelectedIndex] + "";
                    cmdfilm.Connection = cnn;
                    cmdfilm.ExecuteNonQuery();

                    cnn.Close();

                    // Message de confirmation de la suppression du film
                    lblMsg.Text = "Le film \"" + cboTitre.SelectedItem + "\" a été supprimé";

                    // Actualisation de "cboTitre"
                    RefreshCboFilm("select distinct nofilm, titre from film natural join public order by titre");
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }

        }

        // Permet de rechercher un film dans base de données à partir des saisies utilisateurs
        private void btnResearch_Click(object sender, EventArgs e)
        {   
            try 
            {
                RemoveError();

                string dureeFilm = "";
                if (timeFilm.Text.ToString() != "00:00:00") dureeFilm = timeFilm.Text.ToString();

                // Création de la requête avec les paramètres de recherche (saisies utilisateurs)
                OdbcCommand cmdfilm = new OdbcCommand();
                cmdfilm.CommandText = "select distinct titre, nofilm from film natural join concerner natural join genre natural join public " +
                                                "where titre like '%" + txtTitle.Text.ToString().Replace("\'", "\\'") + "%' " +
                                                "and realisateurs like '%" + txtDirector.Text.ToString().Replace("\'", "\\'") + "%' " +
                                                "and acteurs like '%" + txtActor.Text.ToString().Replace("\'", "\\'") + "%' " +
                                                "and duree like '%" + dureeFilm + "%' " +
                                                "and synopsis like '%" + txtSynopsis.Text.ToString().Replace("\'", "\\'") + "%' " +
                                                "and infofilm like '%" + txtInfo.Text.ToString().Replace("\'", "\\'") + "%' ";

                // Récupération de la sélection utilisateur pour le type de public dans "cboPublic"
                if (cboPublic.SelectedIndex > -1)
                {
                    cmdfilm.CommandText += "and nopublic = " + idPublics[cboPublic.SelectedIndex] + " ";
                }

                // Récupération de la sélection utilisateur pour les dans "lstGenre"
                if (lstGenre.SelectedItems.Count > 0)
                {
                    cmdfilm.CommandText += "and nogenre IN (";

                    // Ajout à la requête de tous les genres sélectionnés par l'utilisateur
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

                // Actualisation de "cboTitre"
                RefreshCboFilm(cmdfilm.CommandText);
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }

        }

        // Permet à l'utilisateur d'importer une image pour un film qu'il veut créer
        private void btnImportPicture_Click(object sender, EventArgs e)
        {
            try
            {
                // Ouverture d'une fenêtre pour choisir l'image à importer
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Images (*.BMP;*.JPG;*.PNG;*.JPEG)|*.BMP;*.JPG;*.PNG;*.JPEG|" + "All files (*.*)|*.*";
                openFileDialog.InitialDirectory = @Application.StartupPath + "\\affiches\\";
                openFileDialog.Title = "Sélectionner une image";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Récupération du chemin d'origine de l'image
                    string destinationPath = @Application.StartupPath + "\\affiches\\" + Path.GetFileName(filePath);
                    namePicture = Path.GetFileName(filePath);
                    
                    // Vérifie si l'image n'existe pas déjà dans le dossier affiches" de l'application
                    if (String.Compare(filePath, destinationPath)!=0)
                    {
                        File.Copy(filePath, destinationPath, true);
                    }
                    lblMsg.Text = "L'image a été enregistrée";

                    // Affichage d'un aperçu de l'image importée
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

        // Permet de vider les zones de saisies utilisateurs
        // Si le bouton est cliqué alors que l'utilisateur à saisi "test" dans txtTitle alors des valeurs de test sont insérées dans les zones de saisies utilisateurs
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveError();
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
                    RefreshCboFilm("select distinct nofilm, titre from film natural join public order by titre");
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

        // Permet d'afficher les informations d'un film sélectionné dans "cboTitre"
        private void cboTitre_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Connexion à la base de données
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                // Recherche des toutes les informations du film sélectionné dans "cboTitre" dans la base de données
                OdbcCommand cmdfilm = new OdbcCommand(); OdbcDataReader drrfilm;
                cmdfilm.CommandText = "select * from film natural join public where nofilm =" + idFilms[cboTitre.SelectedIndex];
                cmdfilm.Connection = cnn;
                drrfilm = cmdfilm.ExecuteReader();
                drrfilm.Read();

                #region Affichage des informations récupérées dans leur label respectif
                
                lblDirector.Text = "Réalisateur(s) : " + drrfilm["realisateurs"].ToString();
                lblActor.Text = "Acteur(s) : " + drrfilm["acteurs"].ToString();
                lblPublic.Text = "Type de public : " + drrfilm["libpublic"].ToString();

                // Si le synopsis récupéré par la requête dépasse 150 caractères, celui-ci est raccourci et affiché dans lblSynopsis
                string synopsis;
                synopsis = drrfilm["synopsis"].ToString() + "...";
                if (synopsis.Length > 150)
                {
                    synopsis = synopsis.Remove(synopsis.Length - 3).Substring(0, 150) + "...";
                }
                lblSynopsis.Text = "Synopsis :";
                lblSynopsis.Text += "\n" + synopsis;

                // Affichage de la durée du film sous la forme : __h__min
                DateTime duree = DateTime.Parse(drrfilm["duree"].ToString());
                lblDuree.Text = "Durée : " + duree.ToString("HH") + "h " + duree.ToString("mm") + "min";

                // Affiche de l'affiche du film
                // Si l'image n'arrive pas à être chargée, une autre par défaut sera affichée
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

                // Affichage des genres dans "lblGenre"
                lblGenre.Text = "Genre(s) :";
                
                // Recherche des genres liés au film
                OdbcCommand cmdgenre = new OdbcCommand(); OdbcDataReader drrgenre; Boolean existengenre;
                cmdgenre.CommandText = "SELECT libgenre FROM genre natural join concerner where nofilm = " + drrfilm["nofilm"] + "";
                cmdgenre.Connection = cnn;
                drrgenre = cmdgenre.ExecuteReader();
                existengenre = drrgenre.Read();

                // Chaques genres liés sont ajoutés à "lblGenre"
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
                #endregion

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

        // Permet d'éviter un crash lorsque l'utilisateur saisi dans "cboTitre" un titre qui n'existe pas dans la base de données
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

        // Change l'esthétisme du curseur lors de la sélection dans "cboTitre"
        private void cboTitre_TextChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}