namespace AP_CINE_APPLI
{
    partial class FilmEdit
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
            this.grdFilm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFilm.Location = new System.Drawing.Point(128, 141);
            this.grdFilm.Name = "grdFilm";
            this.grdFilm.RowHeadersWidth = 51;
            this.grdFilm.RowTemplate.Height = 24;
            this.grdFilm.Size = new System.Drawing.Size(534, 141);
            this.grdFilm.TabIndex = 0;
            // 
            // FilmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grdFilm);
            this.Name = "FilmEdit";
            this.Text = "FilmEdit";
            this.Load += new System.EventHandler(this.FilmEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdFilm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdFilm;
    }
}