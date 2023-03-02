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
    public partial class Genre : Form
    {
        public Genre()
        {
            InitializeComponent();
            lblMsg.Text = "";
        }

        private void Genre_Load(object sender, EventArgs e)
        {
            grdGenre.AllowUserToAddRows = false;
            grdGenre.ReadOnly = true;

            grdGenre.Columns[0].Width = 30;
            grdGenre.Columns[1].Width = 100;

            grdGenre.Rows.Clear();

            
            try
            {   
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                OdbcCommand cmd = new OdbcCommand(); OdbcDataReader drr; Boolean existenreg;
                cmd.CommandText = "select nogenre, libgenre from genre";
                cmd.Connection = cnn;
                drr = cmd.ExecuteReader();
                existenreg = drr.Read();

                while (existenreg == true)
                {
                    grdGenre.Rows.Add(drr["nogenre"], drr["libgenre"]);
                    existenreg = drr.Read();
                }
                drr.Close();
                cnn.Close();   
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")){writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n");}
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
            

            grdGenre.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grdGenre.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void removeError()
        {
            errorProviderGenre.SetError(txtGenre, "");
        }

        private void checkData()
        {
            removeError();
            if (string.IsNullOrEmpty(txtGenre.Text))
            {
                errorProviderGenre.SetError(txtGenre, "Veuillez remplir ce champ");
                lblMsg.Text = "Libellé de genre invalide";
            }
            if (txtGenre.Text.Length > 30)
            {
                errorProviderGenre.SetError(txtGenre, "Libellé trop long");
                lblMsg.Text = "Libellé de genre invalide";
            }
        }

        private bool checkExistGenre(string libgenre)
        {
            lblMsg.Text = "";
            errorProviderGenre.SetError(txtGenre, "");
            bool existengenre = false;
            int i = 0;
            while (!existengenre && i < grdGenre.Rows.Count)
            {
                if (grdGenre[1, i].Value.ToString() == libgenre)
                {
                    existengenre = true;
                    lblMsg.Text = "Ce genre existe déjà";
                    errorProviderGenre.SetError(txtGenre, "Genre déjà existant");
                }
                else
                {
                    i++;
                }
            }
            return existengenre;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            checkData();

            if (!string.IsNullOrEmpty(txtGenre.Text) && txtGenre.Text.Length <= 30)
            { 
                if (!checkExistGenre(txtGenre.Text.ToString()))
                {
                    try 
                    {   
                        OdbcConnection cnn = new OdbcConnection();
                        cnn.ConnectionString = varglob.strconnect;
                        cnn.Open();

                        OdbcCommand cmd = new OdbcCommand();
                        cmd.CommandText = "insert into genre values (null, '" + txtGenre.Text.ToString().Replace("\'", "\\'") + "')";
                        cmd.Connection = cnn;
                        cmd.ExecuteReader();

                        cnn.Close();

                        lblMsg.Text = "Le genre \"" + txtGenre.Text.ToString() + "\" a été ajouté";
                    }
                    catch (Exception ex)
                    {
                        // En cas d'erreur, création du fichier log
                        using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                        MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
                    }
                    
                    Genre_Load(sender, e);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grdGenre.RowCount >= 0)
            {
                if (txtGenre.Text.ToString() != "")
                {
                    if (!checkExistGenre(txtGenre.Text.ToString()))
                    {
                        try
                        {
                            OdbcConnection cnn = new OdbcConnection();
                            cnn.ConnectionString = varglob.strconnect;
                            cnn.Open();

                            OdbcCommand cmdfilm = new OdbcCommand(); OdbcDataReader drrfilm;
                            cmdfilm.CommandText = "update genre set libgenre = '" + txtGenre.Text.ToString().Replace("\'", "\\'") + "' where nogenre =" + grdGenre[0, grdGenre.CurrentRow.Index].Value + "";
                            cmdfilm.Connection = cnn;
                            drrfilm = cmdfilm.ExecuteReader();

                            drrfilm.Close();
                            cnn.Close();

                            lblMsg.Text = "Le genre \"" + grdGenre[1, grdGenre.CurrentRow.Index].Value + "\" a été modifié en \"" + txtGenre.Text.ToString() + "\"";
                        }
                        catch (Exception ex)
                        {
                            // En cas d'erreur, création du fichier log
                            using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                            MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
                        }
                        
                        Genre_Load(sender, e);
                    }
                }
                else
                {
                    lblMsg.Text = "Libellé de genre invalide";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            removeError();
            if (grdGenre.RowCount > 0 && MessageBox.Show("Êtes-vous sûr de vouloir supprimer le genre suivant :\n" + grdGenre[1, grdGenre.CurrentRow.Index].Value, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    OdbcConnection cnn = new OdbcConnection();
                    cnn.ConnectionString = varglob.strconnect;
                    cnn.Open();

                    OdbcCommand cmdconcerner = new OdbcCommand(); OdbcDataReader drrconcerner;
                    cmdconcerner.CommandText = "delete from concerner where nogenre =" + grdGenre[0, grdGenre.CurrentRow.Index].Value + "";
                    cmdconcerner.Connection = cnn;
                    drrconcerner = cmdconcerner.ExecuteReader();
                    drrconcerner.Close();

                    OdbcCommand cmdfilm = new OdbcCommand(); OdbcDataReader drrfilm;
                    cmdfilm.CommandText = "delete from genre where nogenre =" + grdGenre[0, grdGenre.CurrentRow.Index].Value + "";
                    cmdfilm.Connection = cnn;
                    drrfilm = cmdfilm.ExecuteReader();

                    drrfilm.Close();
                    cnn.Close();
                    
                    lblMsg.Text = "Le genre \"" + grdGenre[1, grdGenre.CurrentRow.Index].Value + "\" a été supprimé";
                }
                catch (Exception ex)
                {
                    // En cas d'erreur, création du fichier log
                    using (StreamWriter writer = File.AppendText(@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                    MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
                }
                
                Genre_Load(sender, e);
            }
        }

        private void grdGenre_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtGenre.Text = grdGenre[1, grdGenre.CurrentCell.RowIndex].Value.ToString();
        }
    }
}
