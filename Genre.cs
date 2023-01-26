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
        }

        private void Genre_Load(object sender, EventArgs e)
        {
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

            cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=root";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string nomGenre = Interaction.InputBox("Saisissez le libellé du nouveau genre :");
            if (nomGenre!="")
            {
                OdbcConnection cnn = new OdbcConnection();
                OdbcCommand cmd = new OdbcCommand();

                cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + pwdDb + "";
                cnn.Open();

                cmd.CommandText = "insert into genre values (null, '" + nomGenre + "')";
                cmd.Connection = cnn;
                cmd.ExecuteReader();

                cnn.Close();
                MessageBox.Show("Le genre \"" + nomGenre + "\" a été ajouté");
                Genre_Load(sender, e);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grdGenre.RowCount > 0 && MessageBox.Show("Êtes-vous sûr de vouloir modifier le libellé du genre suivant :\n" + grdGenre[1, grdGenre.CurrentRow.Index].Value, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string newNameGenre = Interaction.InputBox("Saisissez le nouveau libellé de " + grdGenre[1, grdGenre.CurrentRow.Index].Value);
                
                if (newNameGenre!="")
                {
                    MessageBox.Show("Le libellé du genre \"" + grdGenre[1, grdGenre.CurrentRow.Index].Value + "\" a été modifié en " + newNameGenre);

                    OdbcConnection cnn = new OdbcConnection();

                    cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + pwdDb + "";
                    cnn.Open();

                    OdbcCommand cmdfilm = new OdbcCommand(); OdbcDataReader drrfilm;
                    cmdfilm.CommandText = "update genre set libgenre = '" + newNameGenre + "' where nogenre =" + grdGenre[0, grdGenre.CurrentRow.Index].Value + "";
                    cmdfilm.Connection = cnn;
                    drrfilm = cmdfilm.ExecuteReader();

                    drrfilm.Close();

                    Genre_Load(sender, e);
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
                MessageBox.Show("Le genre \"" + grdGenre[1, grdGenre.CurrentRow.Index].Value + "\" a été supprimé");

                Genre_Load(sender, e);
            }
        }
    }
}
