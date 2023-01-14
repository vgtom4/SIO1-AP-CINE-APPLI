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
    public partial class FilmEdit : Form
    {
        public FilmEdit()
        {
            InitializeComponent();
        }

        private void FilmEdit_Load(object sender, EventArgs e)
        {
            grdFilm.AllowUserToAddRows = false;
            grdFilm.ReadOnly = true;
            grdFilm.RowHeadersVisible = false;
            grdFilm.ColumnCount = 9;

            grdFilm.Columns[0].Width = 60;
            grdFilm.Columns[1].Width = 200;
            grdFilm.Columns[2].Width = 100;

            grdFilm.Columns[0].HeaderText = "N°";
            grdFilm.Columns[1].HeaderText = "Titres";
            grdFilm.Columns[2].HeaderText = "Réalisateurs";
            grdFilm.Columns[3].HeaderText = "Acteurs";
            grdFilm.Columns[4].HeaderText = "Durée";
            grdFilm.Columns[5].HeaderText = "Synopsis";
            grdFilm.Columns[6].HeaderText = "Genre";
            grdFilm.Columns[7].HeaderText = "Affiche";
            grdFilm.Columns[8].HeaderText = "Public";


            OdbcConnection cnn = new OdbcConnection();
            OdbcCommand cmd = new OdbcCommand();
            OdbcDataReader drr;
            Boolean existenfilm;
            grdFilm.Rows.Clear();
            cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=root";
            cnn.Open();
            cmd.CommandText = "select * from film natural join public";
            cmd.Connection = cnn;
            drr = cmd.ExecuteReader();
            existenfilm = drr.Read();

            for (int j = 1; j <= grdFilm.ColumnCount - 1; j++)
            {
                grdFilm.Columns[j].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            foreach (DataGridViewColumn column in grdFilm.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }


            int i = 0;
            while (existenfilm == true)
            {
                string synopsis;
                synopsis = Convert.ToString(drr["synopsis"]);
                if (synopsis.Length > 100)
                {
                    synopsis = synopsis.Substring(0, 100) + "...";
                }

                grdFilm.Rows.Add(drr["nofilm"], drr["titre"], null, drr["realisateurs"], drr["acteurs"], drr["duree"], synopsis, drr["infofilm"], drr["libpublic"]);

                grdFilm[2, grdFilm.RowCount - 1] = new DataGridViewImageCell();
                Image img = new Bitmap(Application.StartupPath + "\\affiches\\" + drr["imgaffiche"]);
                grdFilm[2, grdFilm.RowCount - 1].Value = new Bitmap(img, 100, 80);

                i++;
                existenfilm = drr.Read();
            }
            grdFilm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            drr.Close();
            cnn.Close();
        }
    }
}
