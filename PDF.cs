using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;
using System.Data.Odbc;
using System.Data.Common;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace AP_CINE_APPLI
{
    public partial class PDF : Form
    {

        public PDF()
        {
            InitializeComponent();
        }

        private void PDF_Load(object sender, EventArgs e)
        {
            dateTimePicker1_ValueChanged(sender, e);
        }

        private void createPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog createPDF = new SaveFileDialog();
            createPDF.FileName = "Projections_" + dateTimePicker1.Value.Date.ToString("dd-MM-yyyy");
            createPDF.Filter = "PDF Files|*.pdf";
            createPDF.Title = "Enregistrer le fichier PDF";
            if (createPDF.ShowDialog() == DialogResult.OK)
            {
                string PDFName = createPDF.FileName;

                //génération du PDF
                String titre = ("Liste des projections du : " + dateTimePicker1.Value.Date.ToString("dd-MM-yyyy"));

                OdbcConnection cnn = new OdbcConnection();
                OdbcCommand cmd = new OdbcCommand();
                OdbcDataReader drrpdf;
                Boolean existenproj;
                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(PDFName, FileMode.Create));
                doc.Open();
                PdfContentByte cb = writer.DirectContent;


                // Ajout titre et logo en haut du document pdf
                iTextSharp.text.Image image0 = iTextSharp.text.Image.GetInstance(Properties.Resources.logo, BaseColor.WHITE);

                image0.SetAbsolutePosition(1, 1);
                image0.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
                image0.ScalePercent(30f);

                PdfPTable head = new PdfPTable(new Single[] { 30, 70 });
                Paragraph title = new Paragraph();
                title.Font = FontFactory.GetFont("Arial", 15);
                title.Add(titre);

                head.DefaultCell.Border = 0;
                head.DefaultCell.HorizontalAlignment = 1;
                head.DefaultCell.VerticalAlignment = 1;

                head.AddCell(image0);
                head.AddCell(title);

                doc.Add(head);

                // Ajout tableaux pour chaque projection

                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();
                cmd.CommandText = "select * from projection natural join film where dateproj ='" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' order by dateproj, heureproj, nosalle";
                cmd.Connection = cnn;
                drrpdf = cmd.ExecuteReader();

                existenproj = drrpdf.Read();
                while (existenproj == true)
                {
                    PdfPTable tableau = new PdfPTable(4);
                    tableau.SetWidths(new float[] { 1, 2, 3, 2 });
                    tableau.SpacingBefore = 40f;

                    PdfPCell logFilm = new PdfPCell();
                    logFilm.Image = iTextSharp.text.Image.GetInstance(System.Windows.Forms.Application.StartupPath + "\\affiches\\" + drrpdf["imgaffiche"].ToString());

                    logFilm.Rowspan = 2;
                    logFilm.HorizontalAlignment = Element.ALIGN_CENTER;
                    tableau.AddCell(logFilm);

                    PdfPCell titFilm = new PdfPCell(new Phrase(drrpdf["titre"].ToString()));
                    titFilm.Colspan = 3;
                    titFilm.HorizontalAlignment = (Element.ALIGN_CENTER);
                    tableau.AddCell(titFilm);

                    PdfPCell salFilm = new PdfPCell(new Phrase("Salle " + drrpdf["nosalle"].ToString()));
                    salFilm.HorizontalAlignment = (Element.ALIGN_CENTER);
                    tableau.AddCell(salFilm);

                    PdfPCell hourFilm = new PdfPCell(new Phrase("Horaire : " + DateTime.Parse(drrpdf["heureproj"].ToString()).Hour + "h" + DateTime.Parse(drrpdf["heureproj"].ToString()).ToString("mm")));
                    hourFilm.HorizontalAlignment = (Element.ALIGN_CENTER);
                    tableau.AddCell(hourFilm);

                    PdfPCell infoFilm = new PdfPCell(new Phrase("Informations :\n" + drrpdf["infoproj"].ToString()));
                    infoFilm.HorizontalAlignment = (Element.ALIGN_CENTER);
                    tableau.AddCell(infoFilm);

                    doc.Add(tableau);
                    existenproj = drrpdf.Read();
                }

                //Fermeture différents éléments + ouverture pdf
                drrpdf.Close();
                cnn.Close();

                doc.Close();
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo(PDFName.ToString());
                p.Start();
                p.Dispose();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            OdbcConnection cnn = new OdbcConnection();
            OdbcCommand cmd = new OdbcCommand(); OdbcDataReader drr;

            cnn.ConnectionString = varglob.strconnect;
            cnn.Open();

            cmd.CommandText = "select count(noproj) as nbproj from projection where dateproj = '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "'";
            cmd.Connection = cnn;
            drr = cmd.ExecuteReader();
            drr.Read();

            if (Convert.ToInt32(drr["nbproj"]) > 0)
            {
                lblMsg.Text = "Il y a " + Convert.ToInt32(drr["nbproj"]).ToString() + " projection(s) programmée(s) pour cette date";
            }
            else
            {
                lblMsg.Text = "Aucune projection n'est programmée pour cette date";
            }

            drr.Close();
            cnn.Close();
        }
    }
}
