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
            errorProviderInfo.SetError(cboSalle, "");
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

                if (cboFilm.SelectedIndex == -1)
                {
                    errorProviderFilm.SetError(cboFilm, "Veuillez remplir ce champ");
                    dataAreValid = false;
                }

                if (cboSalle.SelectedIndex == -1)
                {
                    errorProviderSalle.SetError(cboSalle, "Veuillez remplir ce champ");
                    dataAreValid = false;
                }

                if (dateProj.Value.Date < DateTime.Now.Date)
                {
                    errorProviderDate.SetError(dateProj, "Veuillez remplir ce champ");
                    dataAreValid = false;
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

                // Recherche
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

                Boolean filmEnCours = Convert.ToBoolean(drr["filmBlocked"]);
                drr.Close();
                cnn.Close();

                if (filmEnCours)
                {
                    lblMsg.Text += "Impossible de créer la projection.\nUn film est en cours\nde diffusion à cette instant";
                    errorProviderInfo.SetError(lblMsg, "Projection déjà programmé");
                }

                bool existenproj = false;
                int i = 0;
                while (!existenproj && i < grdProjection.Rows.Count)
                {
                    if (grdProjection[1, i].Value.ToString() == DateTime.Parse(date).ToString("d") && grdProjection[2, i].Value.ToString().Replace("h", ":") + ":00" == time && grdProjection[5, i].Value.ToString() == salle)
                    {
                        grdProjection.Rows[i].Selected = true;
                        existenproj = true;
                        lblMsg.Text += "\nUne projection existe déjà à ce moment";
                        errorProviderInfo.SetError(lblMsg, "Projection déjà programmé");
                    }
                    else
                    {
                        i++;
                    }
                }

                return !filmEnCours && !existenproj;
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
                return false;
            }
        }

        private void refresh()
        {
            try 
            {
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                OdbcCommand cmdproj = new OdbcCommand(); OdbcDataReader drrproj; Boolean existenproj;
                cmdproj.CommandText = "select * from projection natural join film order by dateproj, heureproj, nosalle";
                cmdproj.Connection = cnn;
                drrproj = cmdproj.ExecuteReader();
                existenproj = drrproj.Read();

                grdProjection.Rows.Clear();

                while (existenproj == true)
                {
                    grdProjection.Rows.Add(drrproj["noproj"], DateTime.Parse(drrproj["dateproj"].ToString()).ToString("d"), DateTime.Parse(drrproj["heureproj"].ToString()).ToString("HH") + "h" + DateTime.Parse(drrproj["heureproj"].ToString()).ToString("mm"), drrproj["infoproj"], drrproj["titre"], drrproj["nosalle"]);

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CheckData();

                if (dateProj.Value.Date >= DateTime.Now.Date && cboFilm.SelectedIndex > -1 && cboSalle.SelectedIndex > -1)
                {
                    if (CanCreateProjection(dateProj.Value.ToString("yyyy-MM-dd"), timeProj.Value.ToString("T"), cboSalle.SelectedItem.ToString(), lstIdFilms[cboFilm.SelectedIndex].ToString()))
                    {
                    
                        OdbcConnection cnn = new OdbcConnection();
                        cnn.ConnectionString = varglob.strconnect;
                        cnn.Open();

                        OdbcCommand cmd = new OdbcCommand();
                        cmd.CommandText = "insert into projection values (null, '" + dateProj.Value.ToString("yyyy-MM-dd") + "' , '" + timeProj.Value.ToString("T") + "' , '" + txtInfo.Text.ToString().Replace("\'", "\\'") + "' , " + lstIdFilms[cboFilm.SelectedIndex] + " , '" + cboSalle.SelectedItem.ToString() + "')";
                        cmd.Connection = cnn;
                        cmd.ExecuteReader();
                        cnn.Close();
                        string message = ("Projection suivante enregistrée :" +
                                        "\n Film : " + cboFilm.SelectedItem.ToString() +
                                        "\nSalle : " + cboSalle.SelectedItem.ToString() +
                                        "\nDate : " + dateProj.Value.ToString("d") +
                                        "\nHoraire : " + timeProj.Value.ToString("t"));
                        lblMsg.Text = message;
                    }

                    refresh();
                }
                else
                {
                    string message = "Données invalides :\n";
                    message += dateProj.Value.Date >= DateTime.Now.Date ? "" : "Date de projection\n";
                    message += cboFilm.SelectedIndex > -1 ? "" : "Film\n";
                    message += cboSalle.SelectedIndex > -1 ? "" : "Salle";

                    lblMsg.Text = message;
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveError();

                if (grdProjection.RowCount > 0 && MessageBox.Show("Êtes-vous sûr de vouloir supprimer la projection ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();
                
                OdbcCommand cmd = new OdbcCommand();
                cmd.CommandText = "delete from projection where noproj =" + grdProjection[0, grdProjection.CurrentRow.Index].Value + ";";
                cmd.Connection = cnn;
                cmd.ExecuteReader();
                cnn.Close();
                lblMsg.Text = "Projection supprimée";

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