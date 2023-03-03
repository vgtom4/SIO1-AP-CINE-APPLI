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
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AP_CINE_APPLI
{
    public partial class FormGenre : Form
    {
        public FormGenre()
        {
            InitializeComponent();
        }

        private void Genre_Load(object sender, EventArgs e)
        {
            // Permet de ne pas faire crash le programme si le code qui suit produit une erreur
            try
            {
                // Initialisation du datagridview "grdGenre"
                grdGenre.Rows.Clear();

                //Connexion à la base de données
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                #region Affichage des genres dans "grdGenre".
                // Recherche de tous les genres dans la base de données
                OdbcCommand cmd = new OdbcCommand(); OdbcDataReader drr; Boolean existenreg;
                cmd.CommandText = "select nogenre, libgenre from genre";
                cmd.Connection = cnn;
                drr = cmd.ExecuteReader();
                existenreg = drr.Read();

                // Boucle permettant de remplir les lignes de "grdGenre" avec le numéro de genre "nogenre" et son libellé "libgenre"
                while (existenreg == true)
                {
                    grdGenre.Rows.Add(drr["nogenre"], drr["libgenre"]);
                    existenreg = drr.Read();
                }
                drr.Close();
                cnn.Close();
                #endregion
            }
            // Si la partie après le "try" produit une erreur, le code suivant s'exécute.
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")){writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n");}
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        /// <summary>
        /// Permet de supprimer les erreurs causées par des entrées invalides et de vider "lblMsg"
        /// </summary>
        private void RemoveError()
        {
            lblMsg.Text = "";
            errorProviderGenre.SetError(txtGenre, "");
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

                // Indique si les données sont valides
                Boolean dataAreValid = true;

                // Vérifie si txtGenre est null ou vide
                if (string.IsNullOrEmpty(txtGenre.Text))
                {
                    errorProviderGenre.SetError(txtGenre, "Veuillez remplir ce champ");
                    lblMsg.Text = "Libellé invalide";
                    dataAreValid = false;
                }

                // Vérifie si txtGenre contient plus de 30 caractères
                else if (txtGenre.Text.Length > 30)
                {
                    errorProviderGenre.SetError(txtGenre, "Libellé trop long");
                    lblMsg.Text = "Libellé invalide";
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
        /// Permet de vérifier si un libellé de genre existe déjà dans le datagridview "grdGenre".
        /// </summary>
        /// <returns> true si le paramètre libgenre existe dans "grdGenre"; sinon false.</returns>
        private bool CheckExistGenre(string libgenre)
        {
            try
            {
                RemoveError();

                bool existengenre = false;
                int i = 0;

                // Recherche de "libgenre" dans "grdGenre"
                while (!existengenre && i < grdGenre.Rows.Count)
                {
                    if (grdGenre[1, i].Value.ToString() == libgenre)
                    {
                        existengenre = true;
                        lblMsg.Text = "Ce genre existe déjà";
                        errorProviderGenre.SetError(txtGenre, "Genre déjà existant");
                    }
                    else 
                        i++;
                }
                return existengenre;
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
                return true;
            }
        }

        // Permet d'ajouter un genre dans la base de données
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveError();

                // Vérifie si les entrées sont valides et si le genre existe déjà
                if (CheckData() && !CheckExistGenre(txtGenre.Text))
                {
                    //Connexion à la base de données
                    OdbcConnection cnn = new OdbcConnection();
                    cnn.ConnectionString = varglob.strconnect;
                    cnn.Open();

                    // Insertion d'un genre dans la base de données à partir d'un libellé
                    OdbcCommand cmd = new OdbcCommand();
                    cmd.CommandText = "insert into genre values (null, '" + txtGenre.Text.ToString().Replace("\'", "\\'") + "')";
                    cmd.Connection = cnn;
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                    // Message pour informer l'utilisateur de l'ajout du genre de libellé "txtGenre"
                    lblMsg.Text = "Le genre \"" + txtGenre.Text.ToString() + "\" a été ajouté";
                        
                    // Actualisation de "grdGenre"
                    Genre_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        // Permet de modifier le libellé du genre sélectionné dans "grdGenre" dans la base de données
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveError();

                // Vérifie si les entrées sont valides et si le genre existe déjà
                if (CheckData() && !CheckExistGenre(txtGenre.Text))
                {
                    //Connexion à la base de données
                    OdbcConnection cnn = new OdbcConnection();
                    cnn.ConnectionString = varglob.strconnect;
                    cnn.Open();

                    // Assignation du nouveau libellé de genre
                    OdbcCommand cmdfilm = new OdbcCommand();
                    cmdfilm.CommandText = "update genre set libgenre = '" + txtGenre.Text.ToString().Replace("\'", "\\'") + "' where nogenre =" + grdGenre[0, grdGenre.CurrentRow.Index].Value + "";
                    cmdfilm.Connection = cnn;
                    cmdfilm.ExecuteNonQuery();
                    cnn.Close();

                    lblMsg.Text = "Le genre \"" + grdGenre[1, grdGenre.CurrentRow.Index].Value + "\" a été modifié en \"" + txtGenre.Text.ToString() + "\"";

                    // Actualisation de "grdGenre"
                    Genre_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        // Permet de supprimer le genre sélectionné dans "grdGenre" de la base de données
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveError();

                // Demande confirmation à l'utilisateur pour la suppression du genre sélectionné dans "grdGenre"
                if (grdGenre.RowCount > 0 && MessageBox.Show("Êtes-vous sûr de vouloir supprimer le genre suivant :\n" + grdGenre[1, grdGenre.CurrentRow.Index].Value, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //Connexion à la base de données
                    OdbcConnection cnn = new OdbcConnection();
                    cnn.ConnectionString = varglob.strconnect;
                    cnn.Open();

                    // Suppression, dans la table concerner, de toute correspondance avec le genre sélectionné dans "grdGenre" de la base de données
                    OdbcCommand cmdconcerner = new OdbcCommand();
                    cmdconcerner.CommandText = "delete from concerner where nogenre =" + grdGenre[0, grdGenre.CurrentRow.Index].Value + "";
                    cmdconcerner.Connection = cnn;
                    cmdconcerner.ExecuteNonQuery();

                    // Suppression, dans la table genre, du genre sélectionné dans "grdGenre" de la base de données
                    OdbcCommand cmdfilm = new OdbcCommand();
                    cmdfilm.CommandText = "delete from genre where nogenre =" + grdGenre[0, grdGenre.CurrentRow.Index].Value + "";
                    cmdfilm.Connection = cnn;
                    cmdfilm.ExecuteNonQuery();

                    cnn.Close();
                    
                    lblMsg.Text = "Le genre \"" + grdGenre[1, grdGenre.CurrentRow.Index].Value + "\" a été supprimé";

                    // Actualisation de "grdGenre"
                    Genre_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        // Affiche le libellé du genre sélectionner de "grdGenre" dans "txtGenre"
        private void grdGenre_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtGenre.Text = grdGenre[1, grdGenre.CurrentCell.RowIndex].Value.ToString();
        }
    }
}