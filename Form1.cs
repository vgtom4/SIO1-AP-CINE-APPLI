using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using System.Data.Odbc;

namespace AP_CINE_APPLI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnafficher_Click(object sender, EventArgs e)
        {
            OdbcConnection cnn = new OdbcConnection();

            OdbcCommand cmd = new OdbcCommand();

            OdbcDataReader drr;

            Boolean existenreg;

            grdgenre.ColumnCount = 2;

            grdgenre.Rows.Clear();

            cnn.ConnectionString = "Driver={MySQL ODBC 8.0 ANSI Driver};SERVER=localhost;Database=bdcinevieillard-lepers;uid=root;pwd=root";

            cnn.Open();

            cmd.CommandText = "select nogenre, libgenre from genre";

            cmd.Connection = cnn;

            drr = cmd.ExecuteReader();

            existenreg = drr.Read();

            while (existenreg == true)

            {

                grdgenre.Rows.Add(drr["nogenre"], drr["libgenre"]);

                existenreg = drr.Read();

            }

            drr.Close();

            cnn.Close();
        }
    }
}
