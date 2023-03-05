using iTextSharp.text.pdf;
using iTextSharp.text;
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
using iTextSharp.text.pdf.qrcode;
using System.Globalization;

namespace AP_CINE_APPLI
{
    public partial class FormProjection : Form
    {
        List<int> lstIdFilms = new List<int>();

        public FormProjection()
        {
            InitializeComponent();
        }
        
        private void Projection_Load(object sender, EventArgs e)
        {
            try
            {
                //Initialisations des éléments
                cboFilm.FlatStyle = FlatStyle.Flat;

                btnAdd.FlatStyle = FlatStyle.Flat;
                btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Gold;

                txtInfo.BorderStyle = BorderStyle.None;
                btnDelete.FlatStyle = FlatStyle.Flat;
                btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Gold;

                timeProj.Format = DateTimePickerFormat.Custom;
                timeProj.CustomFormat = "HH:mm";
                timeProj.ShowUpDown = true;

                timeProj.Text = "00:00";
                dateProj.Value = DateTime.Now;

                //Connexion à la base de données
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                #region Insertion des titres de film dans "cboFilm" et de leur ID dans la liste "lstIdFilms"
                // Recherche des titres et de leur ID dans la base de données
                OdbcCommand cmdfilm = new OdbcCommand(); OdbcDataReader drrfilm; Boolean existenfilm;
                cmdfilm.CommandText = "select titre, nofilm from film";
                cmdfilm.Connection = cnn;
                drrfilm = cmdfilm.ExecuteReader();
                existenfilm = drrfilm.Read();

                cboFilm.Items.Clear();

                // Remplissage du ComboBox "cboFilm" avec les titres de film "titre" et de la liste "lstIdFilms" avec leur ID
                while (existenfilm == true)
                {
                    lstIdFilms.Add(Convert.ToInt32(drrfilm["nofilm"]));
                    cboFilm.Items.Add(drrfilm["titre"]);
                    existenfilm = drrfilm.Read();
                }
                drrfilm.Close();
                #endregion

                #region Insertion des numéros de salle dans "cboSalle"
                // Recherche des numéros de salle dans la base de données
                OdbcCommand cmdsalle = new OdbcCommand(); OdbcDataReader drrsalle; Boolean existensalle;
                cmdsalle.CommandText = "select * from salle";
                cmdsalle.Connection = cnn;
                drrsalle = cmdsalle.ExecuteReader();
                existensalle = drrsalle.Read();

                cboSalle.Items.Clear();

                // Remplissage du ComboBox "cboSalle" avec les numéros de salle "nosalle"
                while (existensalle == true)
                {
                    cboSalle.Items.Add(drrsalle["nosalle"]);
                    existensalle = drrsalle.Read();
                }
                drrsalle.Close();
                #endregion
                
                cnn.Close();

                // Affichage des projections dans "grdProjection"
                refresh();
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        /// <summary>
        /// Permet de supprimer les erreurs causées par des entrées invalides et de vider "lblMsg".
        /// </summary>
        private void RemoveError()
        {
            errorProviderDate.SetError(dateProj, "");
            errorProviderFilm.SetError(cboFilm, "");
            errorProviderSalle.SetError(cboSalle, "");
            errorProviderInfo.SetError(lblMsg, "");
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
                string message = "";

                if (cboFilm.SelectedIndex == -1)
                {
                    errorProviderFilm.SetError(cboFilm, "Veuillez remplir ce champ");
                    message += "Film invalide\n";
                    dataAreValid = false;
                }

                if (cboSalle.SelectedIndex == -1)
                {
                    errorProviderSalle.SetError(cboSalle, "Veuillez remplir ce champ");
                    message += "Salle invalide\n";
                    dataAreValid = false;
                }

                if (dateProj.Value.Date < DateTime.Now.Date)
                {
                    errorProviderDate.SetError(dateProj, "Veuillez remplir ce champ");
                    message += "Date passée\n";
                    dataAreValid = false;
                }

                if (!dataAreValid)
                {
                    lblMsg.Text = "Données invalides :\n" + message;
                }

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
        /// Permet de savoir si une projection peut-être créée avec les informations de projection saisies par l'utilisateur pour éviter qu'une projection se superpose sur une autre.
        /// </summary>
        /// <returns>true si la projection peut être créée (pas de superposition sur une autre projection); sinon false</returns>
        private bool CanCreateProjection(string date, string time, string salle, string nofilm)
        {   
            try
            {
                // Connexion à la base de données
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                // Recherche dans la base de données si la nouvelle projection chevauche une autre.
                // (heure saisie par l'utilisateur - durée du film de la dernière scéance avant l'heure saisie)
                // (heure saisie par l'utilisateur + durée du film saisi)
                // Un intervalle de 5 min est ajouté pour vider la salle et la nettoyer
                OdbcCommand cmd = new OdbcCommand(); OdbcDataReader drr;
                cmd.CommandText = "SELECT EXISTS(" +
                                  "SELECT noproj FROM projection " +
                                  "WHERE dateproj = '" + date + "' " +
                                  "AND nosalle = '" + salle + "' " +
                                  "AND CAST(heureproj as time) " +
                                  "BETWEEN TIMEDIFF(" +
                                        "'" + time + "', " +
                                        "ADDTIME(" +
                                            "'00:05:00'," +
                                            "(SELECT duree FROM film natural join projection " +
                                            "WHERE dateproj = '" + date + "' " +
                                            "AND nosalle = '" + salle + "' " +
                                            "AND heureproj = (" +
                                                "SELECT MAX(heureproj) FROM projection " +
                                                "WHERE dateproj = '" + date + "' " +
                                                "AND nosalle = '" + salle + "' " +
                                                "AND heureproj <= '" + time + "')))) " +
                                  "AND ADDTIME('" + time + "', " +
                                        "ADDTIME('00:05:00'," +
                                            "(SELECT duree FROM film WHERE nofilm = " + nofilm + ")))) AS filmBlocked";
            
                cmd.Connection = cnn;
                drr = cmd.ExecuteReader();
                drr.Read();

                // Conversion de la réponse de la requête précédente en boolean (1 = true / 0 = false)
                Boolean filmEnCours = Convert.ToBoolean(drr["filmBlocked"]);
                drr.Close();
                cnn.Close();

                // Si filmEnCours est vrai, c'est que la nouvelle projection se superpose sur une autre. L'utilisateur en est alors averti.
                if (filmEnCours)
                {
                    lblMsg.Text += "Impossible de créer la projection.\nUn film est en cours\nde diffusion à cet instant.";
                    errorProviderInfo.SetError(lblMsg, "Projection déjà programmé");
                }

                // Vérifie si la nouvelle projection saisie par l'utilisateur n'est pas déjà programmée
                bool existProj = false;
                int i = 0;
                while (!existProj && i < grdProjection.Rows.Count)
                {
                    // Si la projection existe déjà, la ligne de celle-ci est surlignée dans "grdProjection"
                    if (grdProjection[1, i].Value.ToString() == DateTime.Parse(date).ToString("d") && grdProjection[2, i].Value.ToString().Replace("h", ":").Remove(5) + ":00" == time && cboFilm.SelectedItem.ToString() == grdProjection[4, i].Value.ToString() && grdProjection[5, i].Value.ToString() == salle)
                    {
                        grdProjection.Rows[i].Selected = true;
                        existProj = true;
                        lblMsg.Text += "\nCette scéance existe déjà";
                        errorProviderInfo.SetError(lblMsg, "Projection déjà programmée");
                    }
                    else i++;
                }

                return !filmEnCours;
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
        /// Permet d'actualiser "grdProjection"
        /// </summary>
        private void refresh()
        {
            try 
            {
                // Connexion à la base de données
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                // Recherche de toutes les projections triées dans l'ordre suivant : date de projection, jeure de projection et numéro de la salle
                OdbcCommand cmdproj = new OdbcCommand(); OdbcDataReader drrproj; Boolean existenproj;
                cmdproj.CommandText = "select * from projection natural join film order by dateproj, heureproj, nosalle";
                cmdproj.Connection = cnn;
                drrproj = cmdproj.ExecuteReader();
                existenproj = drrproj.Read();

                grdProjection.Rows.Clear();

                // Insertion des informations des projections dans "grdProjection"
                while (existenproj == true)
                {
                    // Pour l'affiche des horaires de projections sous la forme "heure_de_début - heure_de_fin"
                    DateTime debutProj = DateTime.ParseExact(DateTime.Parse(drrproj["heureproj"].ToString()).ToString("t"), "HH:mm", CultureInfo.InvariantCulture);
                    DateTime dureeFilm = DateTime.ParseExact(DateTime.Parse(drrproj["duree"].ToString()).ToString("t"), "HH:mm", CultureInfo.InvariantCulture);
                    DateTime finProj = DateTime.MinValue.Add(debutProj.TimeOfDay.Add(dureeFilm.TimeOfDay));
                    String horaireProj = debutProj.ToString("t").Replace(":", "h") + " - " + finProj.ToString("t").Replace(":", "h");

                    grdProjection.Rows.Add(drrproj["noproj"], DateTime.Parse(drrproj["dateproj"].ToString()).ToString("d"), horaireProj, drrproj["infoproj"], drrproj["titre"], drrproj["nosalle"]);
                    existenproj = drrproj.Read();
                }
                
                drrproj.Close();
                cnn.Close();
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        // Permet de créer une projection avec les saisies utilisateurs
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifie si les saisies utilisateur sont valides et si la projection peut-être créée
                if (CheckData() && CanCreateProjection(dateProj.Value.ToString("yyyy-MM-dd"), timeProj.Value.ToString("T"), cboSalle.SelectedItem.ToString(), lstIdFilms[cboFilm.SelectedIndex].ToString()))
                {
                    // Connexion à la base de données
                    OdbcConnection cnn = new OdbcConnection();
                    cnn.ConnectionString = varglob.strconnect;
                    cnn.Open();

                    // Insertion dans la base de données de la nouvelle projection saisie par l'utilisateur
                    OdbcCommand cmd = new OdbcCommand();
                    cmd.CommandText = "insert into projection values (null, '" + dateProj.Value.ToString("yyyy-MM-dd") + "' , '" + timeProj.Value.ToString("T") + "' , '" + txtInfo.Text.ToString().Replace("\'", "\\'") + "' , " + lstIdFilms[cboFilm.SelectedIndex] + " , '" + cboSalle.SelectedItem.ToString() + "')";
                    cmd.Connection = cnn;
                    cmd.ExecuteReader();
                    cnn.Close();

                    // Message pour signaler à l'utilisateur de l'ajout de la projection
                    lblMsg.Text = "Projection suivante enregistrée :" +
                                    "\nFilm : " + cboFilm.SelectedItem.ToString() +
                                    "\nSalle : " + cboSalle.SelectedItem.ToString() +
                                    "\nDate : " + dateProj.Value.ToString("d") +
                                    "\nHoraire : " + timeProj.Value.ToString("t");
                }

                // Actualisation de "grdProjection"
                refresh();
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        // Permet de supprimer la projection sélectionnée dans "grdProjection" par l'utilisateur
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Suppression des messages d'erreur
                RemoveError();

                // Demande de confirmation de suppression à l'utilisateur
                if (grdProjection.RowCount > 0 && MessageBox.Show("Êtes-vous sûr de vouloir supprimer la projection ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // Connexion à la base de données
                    OdbcConnection cnn = new OdbcConnection();
                    cnn.ConnectionString = varglob.strconnect;
                    cnn.Open();
                    
                    // Suppresion de la projection sélectionnée dans "grdProjection" par l'utilisateur de la base de données
                    OdbcCommand cmd = new OdbcCommand();
                    cmd.CommandText = "delete from projection where noproj =" + grdProjection[0, grdProjection.CurrentRow.Index].Value + ";";
                    cmd.Connection = cnn;
                    cmd.ExecuteReader();
                    cnn.Close();

                    lblMsg.Text = "Projection supprimée";

                    // Actualisation de la base de données
                    refresh();
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }
    }
}