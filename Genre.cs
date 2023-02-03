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
using Microsoft.VisualBasic;

namespace AP_CINE_APPLI
{
    public partial class Genre : Form
    {
        string pwdDb = "root";
        

        public Genre()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            lblMsg.Text = "";
        }

        private void Genre_Load(object sender, EventArgs e)
        {
            lblMsg.BackColor = Color.White;

            grdGenre.AllowUserToAddRows = false;
            grdGenre.ReadOnly = true;
            grdGenre.RowHeadersVisible = false;
            grdGenre.RowHeadersVisible = true;

            grdGenre.Columns[0].Width = 30;
            grdGenre.Columns[1].Width = 100;

            OdbcConnection cnn = new OdbcConnection();
            OdbcCommand cmd = new OdbcCommand();
            OdbcDataReader drr;
            Boolean existenreg;

            grdGenre.Rows.Clear();

            cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + pwdDb + "";
            cnn.Open();

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

            grdGenre.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grdGenre.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private bool checkExistGenre(string libgenre)
        {
            lblMsg.Text = "";
            lblMsg.ForeColor = Color.Black;
            bool existengenre = false;
            for (int i = 0; i < grdGenre.Rows.Count; i++)
            {
                if (grdGenre[1, i].Value.ToString() == libgenre)
                {
                    existengenre = true;
                    lblMsg.Text = "Ce genre existe déjà";
                    lblMsg.ForeColor = Color.Red;
                    break;
                }
            }
            return existengenre;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtGenre.Text.ToString() != "")
            { 
                if (!checkExistGenre(txtGenre.Text.ToString()))
                {
                    OdbcConnection cnn = new OdbcConnection();
                    OdbcCommand cmd = new OdbcCommand();

                    cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + pwdDb + "";
                    cnn.Open();

                    cmd.CommandText = "insert into genre values (null, '" + txtGenre.Text.ToString() + "')";
                    cmd.Connection = cnn;
                    cmd.ExecuteReader();

                    cnn.Close();

                    lblMsg.Text = "Le genre \"" + txtGenre.Text.ToString() + "\" a été ajouté";
                    lblMsg.ForeColor = Color.Blue;

                    Genre_Load(sender, e);
                }
            }
            else
            {
                lblMsg.Text = "Libellé de genre invalide";
                lblMsg.ForeColor = Color.Red;
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
                        OdbcConnection cnn = new OdbcConnection();

                        cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + pwdDb + "";
                        cnn.Open();

                        OdbcCommand cmdfilm = new OdbcCommand(); OdbcDataReader drrfilm;
                        cmdfilm.CommandText = "update genre set libgenre = '" + txtGenre.Text.ToString() + "' where nogenre =" + grdGenre[0, grdGenre.CurrentRow.Index].Value + "";
                        cmdfilm.Connection = cnn;
                        drrfilm = cmdfilm.ExecuteReader();

                        drrfilm.Close();

                        lblMsg.Text = "Le genre \"" + grdGenre[1, grdGenre.CurrentRow.Index].Value + "\" a été modifié en \"" + txtGenre.Text.ToString() + "\"";
                        lblMsg.ForeColor = Color.Blue;

                        Genre_Load(sender, e);
                    }
                }
                else
                {
                    lblMsg.Text = "Libellé de genre invalide";
                    lblMsg.ForeColor = Color.Red;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grdGenre.RowCount > 0 && MessageBox.Show("Êtes-vous sûr de vouloir supprimer le genre suivant :\n" + grdGenre[1, grdGenre.CurrentRow.Index].Value, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                OdbcConnection cnn = new OdbcConnection();

                cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + pwdDb + "";
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
                lblMsg.Text = "Le genre \"" + grdGenre[1, grdGenre.CurrentRow.Index].Value + "\" a été supprimé";
                lblMsg.ForeColor = Color.Red;

                Genre_Load(sender, e);
            }
        }

        private void grdGenre_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtGenre.Text = grdGenre[1, grdGenre.CurrentCell.RowIndex].Value.ToString();
        }
    }
}
