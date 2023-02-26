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
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AP_CINE_APPLI
{
    public partial class Salle : Form
    {
        public Salle()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            lblMsg.Text = "";
        }

        private void Salle_Load(object sender, EventArgs e)
        {
            lblMsg.BackColor = Color.White;

            grdSalle.AllowUserToAddRows = false;
            grdSalle.ReadOnly = true;

            grdSalle.Columns[0].Width = 30;
            grdSalle.Columns[1].Width = 100;


            OdbcConnection cnn = new OdbcConnection();
            OdbcCommand cmd = new OdbcCommand();
            OdbcDataReader drr;
            Boolean existenreg;

            grdSalle.Rows.Clear();

            cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + password.pwdDb + "";
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
            lblMsg.ForeColor = Color.Black;
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
                    lblMsg.ForeColor = Color.Red;
                }
                else
                {
                    i++;
                }
            }
            return existensalle;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            checkData();

            if (!string.IsNullOrEmpty(txtNum.Text) && numCapac.Value > 0)
            {
                
                if (!checkExistSalle(txtNum.Text.ToString()))
                {
                    OdbcConnection cnn = new OdbcConnection();
                    OdbcCommand cmd = new OdbcCommand();

                    cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + password.pwdDb + "";
                    cnn.Open();

                    cmd.CommandText = "insert into salle values ('" + txtNum.Text + "', '" + numCapac.Value + "')";
                    cmd.Connection = cnn;
                    cmd.ExecuteReader();
                    cnn.Close();
                    lblMsg.Text = "La salle " + txtNum.Text + " a été ajoutée \navec une capacité de " + numCapac.Value + " places";
                    lblMsg.ForeColor = Color.Blue;
                    Salle_Load(sender, e);
                }
            }
            else
            {
                lblMsg.Text = "Donnée(s) manquante(s)";
                lblMsg.ForeColor = Color.Red;
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            checkData();

            if (!string.IsNullOrEmpty(txtNum.Text) && numCapac.Value > 0)
            {
                bool unlikeNumSalle = txtNum.Text.ToString() != grdSalle[0, grdSalle.CurrentRow.Index].Value.ToString();
                bool unlikeCapac = numCapac.Value.ToString() != grdSalle[1, grdSalle.CurrentRow.Index].Value.ToString();

                OdbcConnection cnn = new OdbcConnection();

                cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + password.pwdDb + "";
                cnn.Open();

                if (unlikeCapac)
                {
                    OdbcCommand cmdSalleCapac = new OdbcCommand();
                    cmdSalleCapac.CommandText = "update salle set nbplaces = '" + numCapac.Value.ToString() + "' where nosalle ='" + grdSalle[0, grdSalle.CurrentRow.Index].Value + "'";
                    cmdSalleCapac.Connection = cnn;
                    cmdSalleCapac.ExecuteReader();
                }


                if (unlikeNumSalle && !checkExistSalle(txtNum.Text))
                {
                    OdbcCommand cmdSalleNum = new OdbcCommand();
                    cmdSalleNum.CommandText += unlikeNumSalle ? "update salle set nosalle = '" + txtNum.Text.ToString() + "' where nosalle ='" + grdSalle[0, grdSalle.CurrentRow.Index].Value + "';" : "";
                    cmdSalleNum.Connection = cnn;
                    cmdSalleNum.ExecuteReader();
                }

                cnn.Close();

                if ((unlikeNumSalle && !checkExistSalle(txtNum.Text)) || unlikeCapac)
                {
                    string message = "Salle " + grdSalle[0, grdSalle.CurrentRow.Index].Value.ToString() + " :";
                    message += unlikeNumSalle ? "\nmodifiée en salle " + txtNum.Text.ToString() : "";
                    message += unlikeCapac ? "\nnouvelle capacité : " + numCapac.Value : "";
                    lblMsg.Text = message;

                    Salle_Load(sender, e);
                }
                
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            removeError();
            if (grdSalle.RowCount > 0 && MessageBox.Show("Êtes-vous sûr de vouloir supprimer la salle " + grdSalle[0, grdSalle.CurrentRow.Index].Value + " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                OdbcConnection cnn = new OdbcConnection();

                cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + password.pwdDb + "";
                cnn.Open();

                OdbcCommand cmdsalle = new OdbcCommand();

                cmdsalle.CommandText = "delete from salle where nosalle ='" + grdSalle[0, grdSalle.CurrentRow.Index].Value + "'";
                cmdsalle.Connection = cnn;
                cmdsalle.ExecuteReader();
                cnn.Close();

                lblMsg.Text = "La salle " + grdSalle[0, grdSalle.CurrentRow.Index].Value + " a été supprimée";
                lblMsg.ForeColor = Color.Red;

                Salle_Load(sender, e);
            }
        }

        private void grdSalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNum.Text = grdSalle[0, grdSalle.CurrentCell.RowIndex].Value.ToString();
            numCapac.Text = grdSalle[1, grdSalle.CurrentCell.RowIndex].Value.ToString();
        }
    }
}
