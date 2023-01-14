namespace AP_CINE_APPLI
{
    partial class FilmView
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
            this.grdFilm = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdFilm)).BeginInit();
            this.SuspendLayout();
            // 
            // grdFilm
            // 
            this.grdFilm.AllowUserToAddRows = false;
            this.grdFilm.AllowUserToDeleteRows = false;
            this.grdFilm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFilm.BackgroundColor = System.Drawing.Color.DarkSeaGreen;
            this.grdFilm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFilm.Location = new System.Drawing.Point(12, 76);
            this.grdFilm.Name = "grdFilm";
            this.grdFilm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdFilm.RowHeadersWidth = 51;
            this.grdFilm.RowTemplate.Height = 24;
            this.grdFilm.Size = new System.Drawing.Size(1480, 652);
            this.grdFilm.TabIndex = 0;
            // 
            // FilmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1514, 756);
            this.Controls.Add(this.grdFilm);
            this.Name = "FilmView";
            this.Text = "FilmView";
            this.Load += new System.EventHandler(this.FilmView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdFilm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdFilm;
    }
}