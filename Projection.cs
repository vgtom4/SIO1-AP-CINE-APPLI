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

namespace AP_CINE_APPLI
{
    public partial class Projection : Form
    {
        List<string[]> lstFilms = new List<string[]>();
        public Projection()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        
        private void Projection_Load(object sender, EventArgs e)
        {

            lblMsg.Visible= false;
            lblDonMan.Visible= false;
            cboFilm.FlatStyle = FlatStyle.Flat;

            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Gold;

            txtInfo.BorderStyle = BorderStyle.None;
            btnDeleteProj.FlatStyle = FlatStyle.Flat;
            btnDeleteProj.FlatAppearance.BorderColor = System.Drawing.Color.Gold;

            timeProj.Format = DateTimePickerFormat.Custom;
            timeProj.CustomFormat = "HH:mm";
            timeProj.ShowUpDown = true;

            timeProj.Text = "00:00";
            dateProj.Value = DateTime.Now;

            // Initialisation de la connexion à la base de données en passant par ODBC
            OdbcConnection cnn = new OdbcConnection();
            OdbcCommand cmdproj = new OdbcCommand(); OdbcDataReader drrproj; Boolean existenproj;

            cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + password.pwdDb + "";
            cnn.Open();

            cmdproj.CommandText = "select * from projection natural join film";
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


            OdbcCommand cmdfilm = new OdbcCommand(); OdbcDataReader drrfilm; Boolean existenfilm;
            cmdfilm.CommandText = "select titre, nofilm from film";
            cmdfilm.Connection = cnn;
            drrfilm = cmdfilm.ExecuteReader();
            existenfilm = drrfilm.Read();

            cboFilm.Items.Clear();

            while (existenfilm == true)
            {
                lstFilms.Add(new string[] { drrfilm["titre"].ToString(), drrfilm["nofilm"].ToString() });
                cboFilm.Items.Add(drrfilm["titre"]);

                existenfilm = drrfilm.Read();
            }
            drrfilm.Close();


            OdbcCommand cmdsalle = new OdbcCommand(); OdbcDataReader drrsalle; Boolean existensalle;
            cmdsalle.CommandText = "select * from salle";
            cmdsalle.Connection = cnn;
            drrsalle = cmdsalle.ExecuteReader();
            existensalle = drrsalle.Read();

            cboSalle.Items.Clear();

            while (existensalle == true)
            {
                cboSalle.Items.Add(drrsalle["nosalle"]);

                existensalle = drrsalle.Read();
            }
            drrsalle.Close();

            cnn.Close();
        }

        private void removeError()
        {
            errorProviderDate.SetError(dateProj, "");
            errorProviderFilm.SetError(cboFilm, "");
            errorProviderSalle.SetError(cboSalle, "");
        }

        private void checkData()
        {
            removeError();
            if (cboFilm.SelectedIndex == -1)
            {
                errorProviderFilm.SetError(cboFilm, "Veuillez remplir ce champ");
            }

            if (cboSalle.SelectedIndex == -1)
            {
                errorProviderSalle.SetError(cboSalle, "Veuillez remplir ce champ");
            }

            if (dateProj.Value.Date < DateTime.Now.Date)
            {
                errorProviderDate.SetError(dateProj, "Veuillez remplir ce champ");
            }
        }

        private void refresh(object sender, EventArgs e)
        {
            OdbcConnection cnn = new OdbcConnection();
            OdbcCommand cmdproj = new OdbcCommand(); OdbcDataReader drrproj; Boolean existenproj;

            cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + password.pwdDb + "";
            cnn.Open();

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            checkData();
            if (dateProj.Value.Date >= DateTime.Now.Date && cboFilm.SelectedIndex > -1 && cboSalle.SelectedIndex > -1)
            {
                lblMsg.Visible = true;
                lblDonMan.Visible = false;
                OdbcConnection cnn = new OdbcConnection();
                OdbcCommand cmd = new OdbcCommand();

                cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + password.pwdDb + "";
                cnn.Open();

                cmd.CommandText = "insert into projection values (null, '" + dateProj.Value.ToString("yyyy-MM-dd") + "' , '" + timeProj.Text + "' , '" + txtInfo.Text.ToString() + "' , " + lstFilms[cboFilm.SelectedIndex][1] + " , '" + cboSalle.SelectedItem.ToString() + "')";
                cmd.Connection = cnn;
                cmd.ExecuteReader();
                cnn.Close();
                string message = ("Projection suivante enregistrée :" +
                                "\n Film : " + cboFilm.SelectedItem.ToString() +
                                "\nSalle : " + cboSalle.SelectedItem.ToString() +
                                "\nDate : " + dateProj.Value.ToString("d") +
                                "\nHoraire : " + timeProj.Value.ToString("t"));
                lblMsg.Text = message;
                refresh(sender, e);
            }
            else
            {
                lblMsg.Visible = true;
                lblDonMan.Visible = true;

                string message = "Données invalides :\n";
                message += dateProj.Value.Date >= DateTime.Now.Date ? "" : "Date de projection\n";
                message += cboFilm.SelectedIndex > -1 ? "" : "Film\n";
                message += cboSalle.SelectedIndex > -1 ? "" : "Salle";

                lblMsg.Text=message;
            }
        }


        private void btnDeleteProj_Click(object sender, EventArgs e)
        {
            removeError();
            if (grdProjection.RowCount > 0 && MessageBox.Show("Êtes-vous sûr de vouloir supprimer la projection ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                OdbcConnection cnn = new OdbcConnection();
                OdbcCommand cmd = new OdbcCommand();

                cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + password.pwdDb + "";
                cnn.Open();

                cmd.CommandText = "delete from projection where noproj =" + grdProjection[0, grdProjection.CurrentRow.Index].Value + ";";
                cmd.Connection = cnn;
                cmd.ExecuteReader();
                cnn.Close();
                lblMsg.Text = "Projection supprimée";
                refresh(sender, e);
            }
        }
    }
}
