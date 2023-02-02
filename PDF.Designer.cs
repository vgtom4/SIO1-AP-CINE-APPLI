namespace AP_CINE_APPLI
{
    partial class PDF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button createPDF;
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            createPDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createPDF
            // 
            createPDF.BackColor = System.Drawing.Color.Black;
            createPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.24F, System.Drawing.FontStyle.Bold);
            createPDF.Location = new System.Drawing.Point(216, 271);
            createPDF.Name = "createPDF";
            createPDF.Size = new System.Drawing.Size(327, 64);
            createPDF.TabIndex = 2;
            createPDF.Text = "Générer la fiche ";
            createPDF.UseVisualStyleBackColor = false;
            createPDF.Click += new System.EventHandler(this.createPDF_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.24F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(213, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Générer une fiche avec les projections de la date :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.24F);
            this.dateTimePicker1.Location = new System.Drawing.Point(248, 181);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(264, 21);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // PDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(778, 499);
            this.Controls.Add(createPDF);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.24F);
            this.ForeColor = System.Drawing.Color.Gold;
            this.Name = "PDF";
            this.Text = "PDF";
            this.Load += new System.EventHandler(this.PDF_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}