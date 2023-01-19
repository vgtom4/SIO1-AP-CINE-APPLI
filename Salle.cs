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

namespace AP_CINE_APPLI
{
    public partial class Salle : Form
    {
        string pwdDb = "root";
        public Salle()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Salle_Load(object sender, EventArgs e)
        {
            grdSalle.AllowUserToAddRows = false;
            grdSalle.ReadOnly = true;
            grdSalle.RowHeadersVisible = false;
            grdSalle.RowHeadersVisible = true;

            grdSalle.Columns[0].Width = 30;
            grdSalle.Columns[1].Width = 100;


            OdbcConnection cnn = new OdbcConnection();
            OdbcCommand cmd = new OdbcCommand();
            OdbcDataReader drr;
            Boolean existenreg;

            grdSalle.Rows.Clear();

            cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=root";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < grdSalle.Rows.Count ;i++)
            {
                if (grdSalle[0,i].Value.ToString() == txtNum.Text.ToString())
                {
                    existe = true;
                }
            }

            if (existe == false)
            {
                if (txtNum.Text != "" && numCapac.Value > 0)
                {
                    OdbcConnection cnn = new OdbcConnection();
                    OdbcCommand cmd = new OdbcCommand();

                    cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + pwdDb + "";
                    cnn.Open();

                    cmd.CommandText = "insert into salle values ('" + txtNum.Text + "', '" + numCapac.Value + "')";
                    cmd.Connection = cnn;
                    cmd.ExecuteReader();
                    cnn.Close();
                    MessageBox.Show("La salle " + txtNum.Text + " a été ajoutée avec une capacité de " + numCapac.Value);
                    Salle_Load(sender, e);
                }
                else
                {
                    string message = "Données manquantes :\n";
                    message += txtNum.Text != "" ? "" : "Numéro de salle\n";
                    message += numCapac.Value > 0 ? "" : "Capacité insuffisante";

                    MessageBox.Show(message);
                }
            }
            else
            {
                MessageBox.Show("Le numéro de salle existe déjà");
            }

        }

        private void btnEditCapac_Click(object sender, EventArgs e)
        {
            string newCapacite = Interaction.InputBox("Saisissez la nouvelle capacité de la salle " + grdSalle[0, grdSalle.CurrentRow.Index].Value + "\nCapacité actuelle : " + grdSalle[1, grdSalle.CurrentRow.Index].Value);

            if (newCapacite != "")
            {
                MessageBox.Show("La capacité de la salle " + grdSalle[0, grdSalle.CurrentRow.Index].Value + " est désormais de " + newCapacite.ToString());

                OdbcConnection cnn = new OdbcConnection();

                cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + pwdDb + "";
                cnn.Open();

                OdbcCommand cmdsalle = new OdbcCommand();
                cmdsalle.CommandText = "update salle set nbplaces = '" + newCapacite + "' where nosalle ='" + grdSalle[0, grdSalle.CurrentRow.Index].Value + "'";
                cmdsalle.Connection = cnn;
                cmdsalle.ExecuteReader();

                cnn.Close();

                Salle_Load(sender, e);
            }
        }

        private void btnEditNum_Click(object sender, EventArgs e)
        {
            string newNum = Interaction.InputBox("Saisissez le nouveau numéro de la salle " + grdSalle[0, grdSalle.CurrentRow.Index].Value);

            if (newNum != "")
            {
                MessageBox.Show("Le salle " + grdSalle[0, grdSalle.CurrentRow.Index].Value + " a été renommée en salle " + newNum.ToString());

                OdbcConnection cnn = new OdbcConnection();

                cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + pwdDb + "";
                cnn.Open();

                OdbcCommand cmdsalle = new OdbcCommand();
                cmdsalle.CommandText = "update salle set nosalle = '" + newNum + "' where nosalle ='" + grdSalle[0, grdSalle.CurrentRow.Index].Value + "'";
                cmdsalle.Connection = cnn;
                cmdsalle.ExecuteReader();

                Salle_Load(sender, e);
            }
        }

            private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grdSalle.RowCount > 0 && MessageBox.Show("Êtes-vous sûr de vouloir supprimer la salle " + grdSalle[0, grdSalle.CurrentRow.Index].Value + " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                OdbcConnection cnn = new OdbcConnection();

                cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + pwdDb + "";
                cnn.Open();

                OdbcCommand cmdsalle = new OdbcCommand(); OdbcDataReader drrsalle;

                cmdsalle.CommandText = "delete from salle where nosalle ='" + grdSalle[0, grdSalle.CurrentRow.Index].Value + "'";
                cmdsalle.Connection = cnn;
                cmdsalle.ExecuteReader();
                cnn.Close();

                MessageBox.Show("La salle " + grdSalle[0, grdSalle.CurrentRow.Index].Value + " a été supprimée");

                Salle_Load(sender, e);
            }
        }
    }
}
