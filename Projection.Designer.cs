namespace AP_CINE_APPLI
{
    partial class Projection
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
            this.grdProjection = new System.Windows.Forms.DataGridView();
            this.dateProj = new System.Windows.Forms.DateTimePicker();
            this.cboSalle = new System.Windows.Forms.ComboBox();
            this.cboFilm = new System.Windows.Forms.ComboBox();
            this.timeProj = new System.Windows.Forms.DateTimePicker();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdProjection)).BeginInit();
            this.SuspendLayout();
            // 
            // grdProjection
            // 
            this.grdProjection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProjection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.grdProjection.Location = new System.Drawing.Point(12, 214);
            this.grdProjection.Name = "grdProjection";
            this.grdProjection.RowHeadersWidth = 51;
            this.grdProjection.RowTemplate.Height = 24;
            this.grdProjection.Size = new System.Drawing.Size(1095, 464);
            this.grdProjection.TabIndex = 0;
            // 
            // dateProj
            // 
            this.dateProj.Location = new System.Drawing.Point(29, 48);
            this.dateProj.Name = "dateProj";
            this.dateProj.Size = new System.Drawing.Size(240, 22);
            this.dateProj.TabIndex = 1;
            // 
            // cboSalle
            // 
            this.cboSalle.FormattingEnabled = true;
            this.cboSalle.Location = new System.Drawing.Point(340, 46);
            this.cboSalle.Name = "cboSalle";
            this.cboSalle.Size = new System.Drawing.Size(121, 24);
            this.cboSalle.TabIndex = 2;
            // 
            // cboFilm
            // 
            this.cboFilm.FormattingEnabled = true;
            this.cboFilm.Location = new System.Drawing.Point(536, 46);
            this.cboFilm.Name = "cboFilm";
            this.cboFilm.Size = new System.Drawing.Size(231, 24);
            this.cboFilm.TabIndex = 3;
            // 
            // timeProj
            // 
            this.timeProj.Location = new System.Drawing.Point(29, 107);
            this.timeProj.Name = "timeProj";
            this.timeProj.Size = new System.Drawing.Size(109, 22);
            this.timeProj.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "N°";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Date";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Heure";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Informations";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Film";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Salle";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(921, 58);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(128, 43);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Projection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 690);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.timeProj);
            this.Controls.Add(this.cboFilm);
            this.Controls.Add(this.cboSalle);
            this.Controls.Add(this.dateProj);
            this.Controls.Add(this.grdProjection);
            this.Name = "Projection";
            this.Text = "Projection";
            this.Load += new System.EventHandler(this.Projection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdProjection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdProjection;
        private System.Windows.Forms.DateTimePicker dateProj;
        private System.Windows.Forms.ComboBox cboSalle;
        private System.Windows.Forms.ComboBox cboFilm;
        private System.Windows.Forms.DateTimePicker timeProj;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btnAdd;
    }
}