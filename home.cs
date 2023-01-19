using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace AP_CINE_APPLI
{
    public partial class home : Form
    {
        Film film;
        Genre genre;

        public home()
        {
            InitializeComponent();
            //this.Text = "Outil Pathé Gaumont";
        }

        private void home_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }

        private void filmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (film == null || film.IsDisposed == true)
            {
                film = new Film();
                film.MdiParent = this;
                film.Show();
            }
            else
            {
                film.Activate();
            }
        }

        private void genreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (genre == null || genre.IsDisposed == true)
            {
                genre = new Genre();
                genre.MdiParent = this;
                genre.Show();
            }
            else
            {
                genre.Activate();
            }
        }
    }
}
