﻿using System;
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
    public partial class Film : Form
    {
        string namePicture = null;
        string pwdDb = "root";

        public Film()
        {
            InitializeComponent();
        }

        private void Film_Load(object sender, EventArgs e)
        {
            namePicture = null;
            

            grdFilm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grdFilm.AllowUserToAddRows = false;
            grdFilm.ReadOnly = true;
            grdFilm.RowHeadersVisible = false;
            grdFilm.ColumnCount = 10;
            grdFilm.RowHeadersVisible = true;

            grdFilm.Columns[0].Width = 25;
            grdFilm.Columns[2].Width = 100;
            grdFilm.Columns[5].Width = 50;

            grdFilm.Columns[0].HeaderText = "N°";
            grdFilm.Columns[1].HeaderText = "Titres";
            grdFilm.Columns[2].HeaderText = "Affiche";
            grdFilm.Columns[3].HeaderText = "Réalisateurs";
            grdFilm.Columns[4].HeaderText = "Acteurs";
            grdFilm.Columns[5].HeaderText = "Durée";
            grdFilm.Columns[6].HeaderText = "Synopsis";
            grdFilm.Columns[7].HeaderText = "Genre";
            grdFilm.Columns[8].HeaderText = "Public";
            grdFilm.Columns[9].HeaderText = "Informations du film";

            for (int j = 1; j <= grdFilm.ColumnCount - 1; j++)
            {
                grdFilm.Columns[j].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            timeFilm.Format = DateTimePickerFormat.Time;
            timeFilm.ShowUpDown = true;
            timeFilm.Value = DateTime.Parse("00:00:00");


            OdbcConnection cnn = new OdbcConnection();
            OdbcCommand cmdfilm = new OdbcCommand(); OdbcDataReader drrfilm; Boolean existenfilm;

            cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + pwdDb + "";
            cnn.Open();

            cmdfilm.CommandText = "select * from film natural join public";
            cmdfilm.Connection = cnn;
            drrfilm = cmdfilm.ExecuteReader();
            existenfilm = drrfilm.Read();

            grdFilm.Rows.Clear();

            while (existenfilm == true)
            {
                string synopsis;
                synopsis = Convert.ToString(drrfilm["synopsis"]);
                if (synopsis.Length > 100)
                {
                    synopsis = synopsis.Substring(0, 100) + "...";
                }

                grdFilm.Rows.Add(drrfilm["nofilm"], drrfilm["titre"], null, drrfilm["realisateurs"], drrfilm["acteurs"], drrfilm["duree"], synopsis,  null, drrfilm["libpublic"] , drrfilm["infofilm"]);

                grdFilm[2, grdFilm.RowCount - 1] = new DataGridViewImageCell();
                
                string imgPath = Path.Combine(Application.StartupPath + "\\affiches\\" + drrfilm["imgaffiche"].ToString());
                if (File.Exists(imgPath))
                {
                    Image img = Image.FromFile(imgPath);
                    grdFilm[2, grdFilm.RowCount - 1].Value = new Bitmap(img, grdFilm.Columns[2].Width, img.Height * grdFilm.Columns[2].Width / img.Width);
                }
                else
                {
                    
                    Image img = Properties.Resources.noimg;
                    grdFilm[2, grdFilm.RowCount - 1].Value = new Bitmap(img, grdFilm.Columns[2].Width, img.Height * grdFilm.Columns[2].Width / img.Width);
                }

                existenfilm = drrfilm.Read();
            }

            drrfilm.Close();


            OdbcCommand cmdgenre = new OdbcCommand(); OdbcDataReader drrgenre; Boolean existengenre;
            cmdgenre.CommandText = "select * from genre";
            cmdgenre.Connection = cnn;
            drrgenre = cmdgenre.ExecuteReader();
            existengenre = drrgenre.Read();

            lstGenre.Items.Clear();
            lstGenre.MultiColumn= true;
            lstGenre.SelectionMode = SelectionMode.MultiSimple;

            while (existengenre == true)
            {
                lstGenre.Items.Add(drrgenre["libgenre"]);

                existengenre = drrgenre.Read();
            }
            drrgenre.Close();

            OdbcCommand cmdpublic = new OdbcCommand(); OdbcDataReader drrpublic; Boolean existenpublic;
            cmdpublic.CommandText = "select * from public";
            cmdpublic.Connection = cnn;
            drrpublic = cmdpublic.ExecuteReader();
            existenpublic = drrpublic.Read();

            cboPublic.Items.Clear();
            cboPublic.Items.Add("");

            while (existenpublic == true)
            {
                cboPublic.Items.Add(drrpublic["libpublic"]);

                existenpublic = drrpublic.Read();
            }
            drrpublic.Close();

            cnn.Close();
            cboPublic.SelectedValue = "";

            grdFilm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //grdFilm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //grdFilm.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;

            Boolean test = true;

            if (test == true)
            {
                txtTitle.Text = "test";
                txtDirector.Text = "test";
                txtActor.Text = "test";
                timeFilm.Text = "01:00:00";
                txtSynopsis.Text = "test";
                txtInfo.Text = "test";
                namePicture = "noimg.png";
                cboPublic.SelectedIndex = 1;
            }

            pictureBox1.Image = Image.FromFile(@Application.StartupPath + "\\affiches\\" + namePicture);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }

        private void btnAddFilm_Click(object sender, EventArgs e)
        {
            if (cboPublic.Text.ToString() != "" && timeFilm.Text.ToString() != "00:00:00") {
                if (txtTitle.Text != "" && txtDirector.Text.ToString() != "" && txtActor.Text.ToString() != "" && timeFilm.Text.ToString() != "" && txtSynopsis.Text.ToString() != "" && txtInfo.Text.ToString() != "" && namePicture != "" && cboPublic.SelectedIndex != -1)
                {
                    OdbcConnection cnn = new OdbcConnection();
                    OdbcCommand cmdfilm = new OdbcCommand(); OdbcDataReader drrfilm;

                    cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + pwdDb + "";
                    cnn.Open();

                    cmdfilm.CommandText = "insert into film values (null, " +
                                                              "'" + txtTitle.Text.ToString() + "', " +
                                                              "'" + txtDirector.Text.ToString() + "', " +
                                                              "'" + txtActor.Text.ToString() + "', " +
                                                              "'" + timeFilm.Text + "', " +
                                                              "'" + txtSynopsis.Text.ToString() + "', " +
                                                              "'" + txtInfo.Text.ToString() + "', " +
                                                              "'" + namePicture + "', " +
                                                              "(select nopublic from public " +
                                                              "where libpublic = '" + cboPublic.SelectedItem + "'))";
                    cmdfilm.Connection = cnn;
                    drrfilm = cmdfilm.ExecuteReader();

                    drrfilm.Close();
                    MessageBox.Show("Le film \"" + txtTitle.Text + "\" a été ajouté");
                    namePicture = null;
                    Film_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Données manquantes");
                }
            }
            else
            {
                if (cboPublic.Text.ToString() == "")
                {
                    MessageBox.Show("Veuillez saisir le type de public");
                }
                if (timeFilm.Text.ToString() == "00:00:00")
                {
                    MessageBox.Show("Veuillez saisir la durée du film");
                }
            }
        }

        private void btnDeleteFilm_Click(object sender, EventArgs e)
        {
            if (grdFilm.RowCount > 0 && MessageBox.Show("Êtes-vous sûr de vouloir supprimer le film suivant :\n" + grdFilm[1, grdFilm.CurrentRow.Index].Value, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                OdbcConnection cnn = new OdbcConnection();
                OdbcCommand cmdfilm = new OdbcCommand(); OdbcDataReader drrfilm;

                cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + pwdDb + "";
                cnn.Open();

                cmdfilm.CommandText = "delete from film where nofilm =" + grdFilm[0, grdFilm.CurrentRow.Index].Value + "";
                cmdfilm.Connection = cnn;
                drrfilm = cmdfilm.ExecuteReader();

                drrfilm.Close();
                MessageBox.Show("Le film \"" + grdFilm[1, grdFilm.CurrentRow.Index].Value + "\" a été supprimé");

                Film_Load(sender, e);
            }

        }

        private void btnResearch_Click(object sender, EventArgs e)
        {
            grdFilm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            string dureeFilm, typePublic;
            if (cboPublic.Text.ToString() == "")
            {
                typePublic = "";
                
            }
            else
            {
                typePublic = cboPublic.SelectedItem.ToString();
            }

            if (timeFilm.Text.ToString() == "00:00:00")
            {
                dureeFilm = "";
            }
            else
            {
                dureeFilm = timeFilm.Text.ToString();
            }

OdbcConnection cnn = new OdbcConnection();
            OdbcCommand cmdfilm = new OdbcCommand(); OdbcDataReader drrfilm; Boolean existenfilm;

            cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=" + pwdDb + "";
            cnn.Open();

            cmdfilm.CommandText = "select * from film natural join public " +
                                           "where titre like '%" + txtTitle.Text.ToString() + "%' " +
                                           "and realisateurs like '%" + txtDirector.Text.ToString() + "%'" +
                                           "and acteurs like '%" + txtActor.Text.ToString() + "%' " +
                                           "and duree like '%" + dureeFilm + "%' " +
                                           "and synopsis like '%" + txtSynopsis.Text.ToString() + "%' " +
                                           "and infofilm like '%" + txtInfo.Text.ToString() + "%' ";
            if (typePublic != "")
            {
                cmdfilm.CommandText += "and nopublic like (select nopublic from public where libpublic = '" + typePublic + "') ";
            }
            

            cmdfilm.Connection = cnn;
            drrfilm = cmdfilm.ExecuteReader();
            existenfilm = drrfilm.Read();

            grdFilm.Rows.Clear();

            while (existenfilm == true)
            {
                string synopsis;
                synopsis = Convert.ToString(drrfilm["synopsis"]);
                if (synopsis.Length > 100)
                {
                    synopsis = synopsis.Substring(0, 100) + "...";
                }

                grdFilm.Rows.Add(drrfilm["nofilm"], drrfilm["titre"], null, drrfilm["realisateurs"], drrfilm["acteurs"], drrfilm["duree"], synopsis, null, drrfilm["libpublic"], drrfilm["infofilm"]);

                grdFilm[2, grdFilm.RowCount - 1] = new DataGridViewImageCell();

                string imgPath = Path.Combine(Application.StartupPath + "\\affiches\\" + drrfilm["imgaffiche"].ToString());
                if (File.Exists(imgPath))
                {
                    Image img = Image.FromFile(imgPath);
                    grdFilm[2, grdFilm.RowCount - 1].Value = new Bitmap(img, grdFilm.Columns[2].Width, img.Height * grdFilm.Columns[2].Width / img.Width);
                }
                else
                {

                    Image img = Properties.Resources.noimg;
                    grdFilm[2, grdFilm.RowCount - 1].Value = new Bitmap(img, grdFilm.Columns[2].Width, img.Height * grdFilm.Columns[2].Width / img.Width);
                }

                existenfilm = drrfilm.Read();
            }

            drrfilm.Close();
            cnn.Close();

            grdFilm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void btnImportPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images (*.BMP;*.JPG;*.PNG;*.JPEG)|*.BMP;*.JPG;*.PNG;*.JPEG|" + "All files (*.*)|*.*";
            openFileDialog.InitialDirectory = @Application.StartupPath + "\\affiches\\";
            openFileDialog.Title = "Sélectionner une image";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                string destinationPath = @Application.StartupPath + "\\affiches\\" + Path.GetFileName(filePath);
                namePicture = Path.GetFileName(filePath);
                if (String.Compare(filePath, destinationPath)!=0)
                {
                    File.Copy(filePath, destinationPath, true);
                }
                MessageBox.Show("L'image a été enregistrée");

                pictureBox1.Image = Image.FromFile(@Application.StartupPath + "\\affiches\\" + Path.GetFileName(namePicture));
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }
    }
}