using iTextSharp.text.pdf.qrcode;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AP_CINE_APPLI
{
    public partial class Salle : Form
    {
        public Salle()
        {
            InitializeComponent();
            lblMsg.Text = "";
        }

        private void Salle_Load(object sender, EventArgs e)
        {
            OdbcConnection cnn = new OdbcConnection();
            OdbcCommand cmd = new OdbcCommand();
            OdbcDataReader drr;
            Boolean existenreg;

            grdSalle.Rows.Clear();

            cnn.ConnectionString = varglob.strconnect;
            cnn.Open();

            cmd.CommandText = "select * from salle";
            cmd.Connection = cnn;
            drr = cmd.ExecuteReader();
            existenreg = drr.Read();

            while (existenreg == true)
            {
                grdSalle.Rows.Add(drr["nosalle"], drr["nbplaces"]);
                existenreg = drr.Read();

            }

            drr.Close();
            cnn.Close();

            grdSalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void removeError()
        {
            errorProviderNumSalle.SetError(txtNum, "");
            errorProviderCapac.SetError(numCapac, "");
        }

        private void checkData()
        {
            removeError();
            if (string.IsNullOrEmpty(txtNum.Text))
            {
                errorProviderNumSalle.SetError(txtNum, "Veuillez remplir ce champ");
            }

            if (numCapac.Value == 0)
            {
                errorProviderCapac.SetError(numCapac, "Veuillez remplir ce champ");
            }
        }

        private bool checkExistSalle(string numsalle)
        {
            lblMsg.Text = "";
            errorProviderNumSalle.SetError(txtNum, "");
            bool existensalle = false;
            int i = 0;
            while (!existensalle && i < grdSalle.Rows.Count)
            {
                if (grdSalle[0, i].Value.ToString() == numsalle)
                {
                    existensalle = true;
                    lblMsg.Text = "Ce numéro de salle existe déjà";
                    errorProviderNumSalle.SetError(txtNum, "Numéro de salle déjà existant");
                }
                else
                {
                    i++;
                }
            }
            return existensalle;
        }

        private bool salleHasProjection(string mode, string nosalle)
        {
            Boolean CanDelete = true;

            OdbcConnection cnn = new OdbcConnection();

            cnn.ConnectionString = varglob.strconnect;
            cnn.Open();

            OdbcCommand cmd = new OdbcCommand(); OdbcDataReader drr;
            cmd.CommandText = "select count(nosalle) as nbproj from projection where nosalle ='" + nosalle + "'";
            cmd.Connection = cnn;
            drr = cmd.ExecuteReader();
            drr.Read();

            if (Convert.ToInt16(drr["nbproj"]) > 0)
            {
                CanDelete = false;
                if (mode == "delete" && MessageBox.Show("Attention, la salle que vous allez supprimer possède une projection.\nÊtes-vous sûr de vouloir la supprimer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    CanDelete = true;
                }
            }

            drr.Close();
            cnn.Close();

            return CanDelete;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            checkData();

            if (!string.IsNullOrEmpty(txtNum.Text) && numCapac.Value > 0)
            {
                
                if (!checkExistSalle(txtNum.Text.ToString()))
                {
                    OdbcConnection cnn = new OdbcConnection();
                    cnn.ConnectionString = varglob.strconnect;
                    cnn.Open();

                    OdbcCommand cmd = new OdbcCommand();
                    cmd.CommandText = "insert into salle values ('" + txtNum.Text + "', '" + numCapac.Value + "')";
                    cmd.Connection = cnn;
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                    lblMsg.Text = "La salle " + txtNum.Text + " a été ajoutée \navec une capacité de " + numCapac.Value + " places";

                    Salle_Load(sender, e);
                }
            }
            else
            {
                lblMsg.Text = "/!\\ Donnée(s) manquante(s) /!\\";
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            checkData();
            lblMsg.Text = "";

            if (!string.IsNullOrEmpty(txtNum.Text) && numCapac.Value > 0)
            {
                string message = "";

                bool unlikeNumSalle = txtNum.Text.ToString() != grdSalle[0, grdSalle.CurrentRow.Index].Value.ToString();
                bool unlikeCapac = numCapac.Value.ToString() != grdSalle[1, grdSalle.CurrentRow.Index].Value.ToString();

                if (!unlikeNumSalle)
                {
                    errorProviderNumSalle.SetError(txtNum, "");
                }

                OdbcConnection cnn = new OdbcConnection();

                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                if (unlikeNumSalle && !checkExistSalle(txtNum.Text))
                {
                    if (salleHasProjection("edit", grdSalle[0, grdSalle.CurrentRow.Index].Value.ToString()))
                    {
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

                if (unlikeCapac)
                {
                    OdbcCommand cmdSalleCapac = new OdbcCommand();
                    cmdSalleCapac.CommandText = "update salle set nbplaces = '" + numCapac.Value.ToString() + "' where nosalle ='" + grdSalle[0, grdSalle.CurrentRow.Index].Value + "'";
                    cmdSalleCapac.Connection = cnn;
                    cmdSalleCapac.ExecuteNonQuery();

                    message += "\nnouvelle capacité : " + numCapac.Value.ToString();
                }

                cnn.Close();

                if ((unlikeNumSalle && !checkExistSalle(txtNum.Text)) || unlikeCapac)
                {
                    lblMsg.Text = "Salle " + grdSalle[0, grdSalle.CurrentRow.Index].Value.ToString() + " :" + message;

                    Salle_Load(sender, e);
                }

            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            removeError();
            if (grdSalle.RowCount > 0 && MessageBox.Show("Êtes-vous sûr de vouloir supprimer la salle " + grdSalle[0, grdSalle.CurrentRow.Index].Value + " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes && salleHasProjection("delete", grdSalle[0, grdSalle.CurrentRow.Index].Value.ToString()))
            {
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                OdbcCommand cmdprojection = new OdbcCommand();
                cmdprojection.CommandText = "delete from projection where nosalle ='" + grdSalle[0, grdSalle.CurrentRow.Index].Value + "'";
                cmdprojection.Connection = cnn;
                cmdprojection.ExecuteNonQuery();

                OdbcCommand cmdsalle = new OdbcCommand();
                cmdsalle.CommandText = "delete from salle where nosalle ='" + grdSalle[0, grdSalle.CurrentRow.Index].Value + "'";
                cmdsalle.Connection = cnn;
                cmdsalle.ExecuteNonQuery();

                cnn.Close();

                lblMsg.Text = "La salle " + grdSalle[0, grdSalle.CurrentRow.Index].Value + " a été supprimée";

                Salle_Load(sender, e);
            }
        }

        private void grdSalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNum.Text = grdSalle[0, grdSalle.CurrentCell.RowIndex].Value.ToString();
            numCapac.Text = grdSalle[1, grdSalle.CurrentCell.RowIndex].Value.ToString();
        }

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
