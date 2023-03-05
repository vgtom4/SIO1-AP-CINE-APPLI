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
using System.Globalization;

namespace AP_CINE_APPLI
{
    public partial class FormPDF : Form
    {

        public FormPDF()
        {
            InitializeComponent();
        }

        private void PDF_Load(object sender, EventArgs e)
        {
            dateTimePicker1_ValueChanged(sender, e);
        }

        // Permet de créer un PDF des projections programmées à la date saisie dans "dateTimePicker1" par l'utilisateur
        private void createPDF_Click(object sender, EventArgs e)
        {
            try
            {
                // Demande à l'utilisateur l'emplacement d'enregistrement du PDF
                SaveFileDialog createPDF = new SaveFileDialog();
                createPDF.FileName = "Projections_" + dateTimePicker1.Value.Date.ToString("dd-MM-yyyy");
                createPDF.Filter = "PDF Files|*.pdf";
                createPDF.Title = "Enregistrer le fichier PDF";
                if (createPDF.ShowDialog() == DialogResult.OK)
                {
                    string PDFName = createPDF.FileName;

                    #region Génération du PDF
                    // Création du document PDF
                    Document doc = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(PDFName, FileMode.Create));
                    doc.Open();
                    PdfContentByte cb = writer.DirectContent;

                    // Instanciation du logo du cinéma
                    iTextSharp.text.Image image0 = iTextSharp.text.Image.GetInstance(Properties.Resources.logo, BaseColor.WHITE);
                    image0.SetAbsolutePosition(1, 1);
                    image0.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
                    image0.ScalePercent(30f);

                    // Le titre de la page contient la date de projection saisie par l'utilisateur
                    String titre = "Liste des projections du : " + dateTimePicker1.Value.Date.ToString("dd-MM-yyyy");
                    Paragraph title = new Paragraph();
                    title.Font = FontFactory.GetFont("Arial", 15);
                    title.Add(titre);
                    
                    // Modification de l'apparence de l'en-tête de page
                    PdfPTable head = new PdfPTable(new Single[] { 30, 70 });
                    head.DefaultCell.Border = 0;
                    head.DefaultCell.HorizontalAlignment = 1;
                    head.DefaultCell.VerticalAlignment = 1;

                    // Ajout du logo et du titre en haut du document PDF
                    head.AddCell(image0);
                    head.AddCell(title);
                    doc.Add(head);

                    // Connexion à la base de données
                    OdbcConnection cnn = new OdbcConnection();
                    cnn.ConnectionString = varglob.strconnect;
                    cnn.Open();
                    
                    // Recherche des projections datées de la date saisie par l'utilisateur
                    OdbcCommand cmd = new OdbcCommand(); OdbcDataReader drrpdf; Boolean existenproj;
                    cmd.CommandText = "select * from projection natural join film where dateproj ='" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' order by dateproj, heureproj, nosalle";
                    cmd.Connection = cnn;
                    drrpdf = cmd.ExecuteReader();
                    existenproj = drrpdf.Read();
                    
                    // Création d'un tableau contenant toutes leurs informations de chaques projections
                    while (existenproj == true)
                    {
                        // Création du tableau à 4 colonnes
                        PdfPTable tableau = new PdfPTable(4);
                        tableau.SetWidths(new float[] { 1, 2, 3, 2 });
                        tableau.SpacingBefore = 10f;

                        // Insertion de l'affiche du film projeté dans le tableau
                        PdfPCell logFilm = new PdfPCell();
                        logFilm.Image = iTextSharp.text.Image.GetInstance(System.Windows.Forms.Application.StartupPath + 
                                        "\\affiches\\" + drrpdf["imgaffiche"].ToString());
                        logFilm.Rowspan = 2;
                        logFilm.HorizontalAlignment = Element.ALIGN_CENTER;
                        tableau.AddCell(logFilm);

                        // Insertion du titre du film projeté dans le tableau
                        PdfPCell titFilm = new PdfPCell(new Phrase(drrpdf["titre"].ToString()));
                        titFilm.Colspan = 3;
                        titFilm.HorizontalAlignment = (Element.ALIGN_CENTER);
                        tableau.AddCell(titFilm);

                        // Insertion du numéro de la salle de projection dans le tableau
                        PdfPCell salFilm = new PdfPCell(new Phrase("Salle " + drrpdf["nosalle"].ToString()));
                        salFilm.HorizontalAlignment = (Element.ALIGN_CENTER);
                        tableau.AddCell(salFilm);

                        
                        // Pour l'affiche des horaires de projections sous la forme "heure_de_début - heure_de_fin"
                        DateTime debutProj = DateTime.ParseExact(DateTime.Parse(drrpdf["heureproj"].ToString()).ToString("t"), "HH:mm", CultureInfo.InvariantCulture);
                        DateTime dureeFilm = DateTime.ParseExact(DateTime.Parse(drrpdf["duree"].ToString()).ToString("t"), "HH:mm", CultureInfo.InvariantCulture);
                        DateTime finProj = DateTime.MinValue.Add(debutProj.TimeOfDay.Add(dureeFilm.TimeOfDay));
                        String horaireProj = debutProj.ToString("t").Replace(":", "h") + " - " + finProj.ToString("t").Replace(":", "h");
                        
                        // Insertion de l'heure de projection dans le tableau
                        PdfPCell hourFilm = new PdfPCell(new Phrase("Horaire :\n" + horaireProj));
                        hourFilm.HorizontalAlignment = (Element.ALIGN_CENTER);
                        tableau.AddCell(hourFilm);

                        // Insertion des informations de la projection dans le tableau
                        PdfPCell infoFilm = new PdfPCell(new Phrase("Informations :\n" + drrpdf["infoproj"].ToString()));
                        infoFilm.HorizontalAlignment = (Element.ALIGN_CENTER);
                        tableau.AddCell(infoFilm);

                        // Si la tableau n'a pas assez de place sur la page, il ira sur une autre
                        tableau.KeepTogether= true;

                        // Ajout du tableau au document PDF
                        doc.Add(tableau);
                        existenproj = drrpdf.Read();
                    }
                    #endregion

                    //Fermeture différents éléments + ouverture pdf
                    drrpdf.Close();
                    cnn.Close();
                    doc.Close();
                    
                    // Ouverture automatique du PDF créé
                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo = new System.Diagnostics.ProcessStartInfo(PDFName.ToString());
                    p.Start();
                    p.Dispose();
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(System.Windows.Forms.@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                // Connexion à la base de données
                OdbcConnection cnn = new OdbcConnection();
                cnn.ConnectionString = varglob.strconnect;
                cnn.Open();

                // Recherche du nombre de projection prévue à la date saisie par l'utilisateur
                OdbcCommand cmd = new OdbcCommand(); OdbcDataReader drr;
                cmd.CommandText = "select count(noproj) as nbproj from projection where dateproj = '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "'";
                cmd.Connection = cnn;
                drr = cmd.ExecuteReader();
                drr.Read();

                // Affichage du nombre de projection prévue à la date saisie par l'utilisateur
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
            catch (Exception ex)
            {
                // En cas d'erreur, création du fichier log
                using (StreamWriter writer = File.AppendText(System.Windows.Forms.@Application.StartupPath + "\\ErrorLogs\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")) { writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message + "\n"); }
                MessageBox.Show("Une erreur est survenu. Erreur enregistrée dans le dossier ErrorLog.");
            }
        }
    }
}