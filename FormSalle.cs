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
using System.Windows.Controls;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AP_CINE_APPLI
{
    public partial class FormSalle : Form
    {
        public FormSalle()
        {
            InitializeComponent();
        }

        private void Salle_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialisation du datagridview "grdSalle"
                grdSalle.Rows.Clear();

                //Connexion à la base de données
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                #region Affichage des salles dans "grdSalle"
                // Recherche de toutes les salles dans la base de données.
                OdbcCommand cmd = new OdbcCommand(); OdbcDataReader drr; Boolean existenreg;
                cmd.CommandText = "select * from salle";
                cmd.Connection = cnn;
                drr = cmd.ExecuteReader();
                existenreg = drr.Read();

                // Boucle permettant de remplir les lignes de "grdSalle" avec le numéro de salle "nosalle" et sa capacité "nbplaces".
                while (existenreg == true)
                {
                    grdSalle.Rows.Add(drr["nosalle"], drr["nbplaces"]);
                    existenreg = drr.Read();
                }
                drr.Close();
                cnn.Close();
                #endregion
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        /// <summary>
        /// Permet de supprimer les erreurs causées par des entrées invalides et de vider "lblMsg"
        /// </summary>
        private void RemoveError()
        {
            lblMsg.Text = "";
            errorProviderNumSalle.SetError(txtNum, "");
            errorProviderCapac.SetError(numCapac, "");
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

                // Vérifie si txtNum est null ou vide
                if (string.IsNullOrEmpty(txtNum.Text))
                {
                    errorProviderNumSalle.SetError(txtNum, "Veuillez remplir ce champ");
                    lblMsg.Text += "Libellé invalide";
                    dataAreValid = false;
                }

                // Vérifie si numCapac est égale à zéro
                if (numCapac.Value == 0)
                {
                    errorProviderCapac.SetError(numCapac, "Veuillez remplir ce champ");
                    lblMsg.Text += "\nCapacité invalide";
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
        /// Permet de vérifier si un libellé de salle existe déjà dans le datagridview "grdSalle".
        /// </summary>
        /// <returns> true si le paramètre numsalle existe dans "grdSalle"; sinon false.</returns>
        private bool CheckExistSalle(string numsalle)
        {
            try
            {
                RemoveError();

                bool existensalle = false;
                int i = 0;

                // Recherche de "numsalle" dans "grdSalle"
                while (!existensalle && i < grdSalle.Rows.Count)
                {
                    if (grdSalle[0, i].Value.ToString() == numsalle)
                    {
                        existensalle = true;
                        lblMsg.Text = "Ce numéro de salle existe déjà";
                        errorProviderNumSalle.SetError(txtNum, "Numéro de salle déjà existant");
                    }
                    else
                        i++;
                }
                return existensalle;
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
                return true;
            }
        }

        /// <summary>
        /// Permet de vérifier si une salle est liée à une projection.
        /// </summary>
        /// <returns>true si la salle "nosalle" est liée à une projection; sinon false</returns>
        private bool SalleHasProjection(string nosalle)
        {
            try
            {
                //Connexion à la base de données
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                // Vérifie dans la base de données si il existe une liaison entre la salle "nosalle" et les projections
                // Retourne : 1 si c'est le cas; sinon 0
                OdbcCommand cmd = new OdbcCommand(); OdbcDataReader drr;
                cmd.CommandText = "select exists(select nosalle as nbproj from projection where nosalle ='" + nosalle + "') as salleLinkToProjection";
                cmd.Connection = cnn;
                drr = cmd.ExecuteReader();
                drr.Read();

                // Conversion de la réponse de la requête précédente en boolean (1 = true / 0 = false)
                Boolean salleIsLinkToProjection = Convert.ToBoolean(drr["salleLinkToProjection"]);
                
                drr.Close();
                cnn.Close();
                
                return salleIsLinkToProjection;
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
        /// Permet de savoir si la salle "nosalle" peut être supprimer.
        /// </summary>
        /// <returns>true si la salle peut être supprimer; sinon false</returns>
        private bool AllowDeleteSalle(string nosalle)
        {
            try
            {
                Boolean CanDelete = true;

                // Si une salle est liée à une projection, une confirmation de suppression est demandée à l'utilisateur
                if (SalleHasProjection(nosalle))
                {
                    CanDelete = false;
                    if (MessageBox.Show("Attention, la salle que vous allez supprimer possède une projection.\nÊtes-vous sûr de vouloir la supprimer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        CanDelete = true;
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

        // Permet d'ajouter une salle dans la base de données
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveError();
                // Vérifie si les entrées sont valides et si la salle existe déjà
                if (CheckData() && !CheckExistSalle(txtNum.Text))
                {
                    // Connexion à la base de données
                    OdbcConnection cnn = new OdbcConnection();
                    cnn.ConnectionString = varglob.strconnect;
                    cnn.Open();

                    // Insertion d'une salle dans la base de données à partir d'un numéro de salle et d'une capacité
                    OdbcCommand cmd = new OdbcCommand();
                    cmd.CommandText = "insert into salle values ('" + txtNum.Text + "', '" + numCapac.Value + "')";
                    cmd.Connection = cnn;
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                    // Message pour informer l'utilisateur de l'ajout de la salle "txtNum" avec une capacité de "numCapac"
                    lblMsg.Text = "La salle " + txtNum.Text + " a été ajoutée \navec une capacité de " + numCapac.Value + " places";

                    // Actualisation de "grdSalle"
                    Salle_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        // Permet de modifier le numéro et/ou la capacité de la salle sélectionnée dans "grdSalle" dans la base de données
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveError();

                if (CheckData())
                {
                    string message = "";

                    // Vérifie si le nouveau numéro de salle souhaité est différent de l'ancien
                    // Retrouve : true c'est le cas; sinon false
                    bool unlikeNumSalle = txtNum.Text.ToString() != grdSalle[0, grdSalle.CurrentRow.Index].Value.ToString();

                    // Vérifie si la nouvelle capacité de salle souhaitée est différente de l'ancienne
                    // Retrouve : true c'est le cas; sinon false
                    bool unlikeCapac = numCapac.Value.ToString() != grdSalle[1, grdSalle.CurrentRow.Index].Value.ToString();

                    if (!unlikeNumSalle)
                        errorProviderNumSalle.SetError(txtNum, "");

                    //Connexion à la base de données
                    OdbcConnection cnn = new OdbcConnection();
                    cnn.ConnectionString = varglob.strconnect;
                    cnn.Open();

                    // Vérifie si le nouveau numéro de salle est à la fois différent de l'ancien et si il n'existe pas dans "grdSalle"
                    if (unlikeNumSalle && !CheckExistSalle(txtNum.Text))
                    {
                        // Vérifie si la salle sélectionnée est liée à une projection
                        // Si ce n'est pas le cas, son numéro est modifié dans la base de données; sinon l'utilisateur est informé qu'il ne peut pas le modifier
                        if (!SalleHasProjection(grdSalle[0, grdSalle.CurrentRow.Index].Value.ToString()))
                        {
                            // Modification, du numéro de la salle sélectionnée dans "grdSalle", par "txtNum", dans la base de données
                            OdbcCommand cmdSalleNum = new OdbcCommand();
                            cmdSalleNum.CommandText = "update salle set nosalle = '" + txtNum.Text.ToString() + "' where nosalle ='" + grdSalle[0, grdSalle.CurrentRow.Index].Value + "'";
                            cmdSalleNum.Connection = cnn;
                            cmdSalleNum.ExecuteNonQuery();

                            message += "\nmodifiée en salle " + txtNum.Text.ToString();
                        }
                        else
                        {
                            message += "\nLa salle est déjà enregistrer\nsur une projection.\nImpossible de modifier son numéro";
                        }
                    }

                    // Vérifie si la nouvelle capacité de salle est différente est différente de celle initiale, afin de la modifier dans la base de données
                    if (unlikeCapac)
                    {
                        // Modification, de la capacité de la salle sélectionnée dans "grdSalle", par "numCapac", dans la base de données
                        OdbcCommand cmdSalleCapac = new OdbcCommand();
                        cmdSalleCapac.CommandText = "update salle set nbplaces = '" + numCapac.Value.ToString() + "' where nosalle ='" + grdSalle[0, grdSalle.CurrentRow.Index].Value + "'";
                        cmdSalleCapac.Connection = cnn;
                        cmdSalleCapac.ExecuteNonQuery();

                        message += "\nnouvelle capacité : " + numCapac.Value.ToString();
                    }
                    cnn.Close();

                    // Affichage des modifications réalisées dans "lblMsg"
                    if ((unlikeNumSalle && !CheckExistSalle(txtNum.Text)) || unlikeCapac)
                    {
                        lblMsg.Text = "Salle " + grdSalle[0, grdSalle.CurrentRow.Index].Value.ToString() + " :" + message;

                        // Actualisation de "grdSalle"
                        Salle_Load(sender, e);
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

        // Permet de supprimer la salle sélectionné dans "grdSalle" de la base de données
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveError();

                // Vérifie si "grdSalle" n'est pas vide, si la salle sélectionnée dans "grdSalle" peut-être supprimer et demande une confirmation de suppression à l'utilisateur
                if (grdSalle.RowCount > 0 && AllowDeleteSalle(grdSalle[0, grdSalle.CurrentRow.Index].Value.ToString()) && MessageBox.Show("Êtes-vous sûr de vouloir supprimer la salle " + grdSalle[0, grdSalle.CurrentRow.Index].Value + " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //Connexion à la base de données
                    OdbcConnection cnn = new OdbcConnection();
                    cnn.ConnectionString = varglob.strconnect;
                    cnn.Open();

                    // Suppression, dans la table "projection" de la base de données, de toutes les correspondances avec la salle sélectionnée dans "grdSalle" 
                    OdbcCommand cmdprojection = new OdbcCommand();
                    cmdprojection.CommandText = "delete from projection where nosalle ='" + grdSalle[0, grdSalle.CurrentRow.Index].Value + "'";
                    cmdprojection.Connection = cnn;
                    cmdprojection.ExecuteNonQuery();

                    // Suppression, dans la table "salle" de la base de données, de la salle sélectionnée dans "grdSalle
                    OdbcCommand cmdsalle = new OdbcCommand();
                    cmdsalle.CommandText = "delete from salle where nosalle ='" + grdSalle[0, grdSalle.CurrentRow.Index].Value + "'";
                    cmdsalle.Connection = cnn;
                    cmdsalle.ExecuteNonQuery();

                    cnn.Close();

                    // Message de confirmation de suppression de la salle
                    lblMsg.Text = "La salle " + grdSalle[0, grdSalle.CurrentRow.Index].Value + " a été supprimée";

                    // Actualisation de "grdSalle"
                    Salle_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        // Permet d'affiche le numéro et la capacité de la salle sélectionnée de "grdGenre" dans "txtNum" et "numCapac"
        private void grdSalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNum.Text = grdSalle[0, grdSalle.CurrentCell.RowIndex].Value.ToString();
            numCapac.Text = grdSalle[1, grdSalle.CurrentCell.RowIndex].Value.ToString();
        }

        // Permet d'autoriser seulement les lettres de l'alphabet en majuscule dans "txtNum"
        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Vérifie si la touche enfoncée est une lettre de l'alphabet
            if (char.IsLetter(e.KeyChar))
            {
                // Si la lettre est en minuscule, la bascule en majuscule
                if (char.IsLower(e.KeyChar))
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
            }
            // Autorise la touche Entrée, la touche de suppression (backspace) et la touche de tabulation
            else if (e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Tab)
            {
                // Empêche toutes les autres touches non autorisées
                e.Handled = true;
            }
        }
    }
}