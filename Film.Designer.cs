namespace AP_CINE_APPLI
{
    partial class Film
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
            this.btnAddFilm = new System.Windows.Forms.Button();
            this.btnDeleteFilm = new System.Windows.Forms.Button();
            this.lstGenre = new System.Windows.Forms.ListBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.cboPublic = new System.Windows.Forms.ComboBox();
            this.txtSynopsis = new System.Windows.Forms.TextBox();
            this.btnResearch = new System.Windows.Forms.Button();
            this.btnImportPicture = new System.Windows.Forms.Button();
            this.txtActor = new System.Windows.Forms.TextBox();
            this.timeFilm = new System.Windows.Forms.DateTimePicker();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdFilm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdFilm
            // 
            this.grdFilm.BackgroundColor = System.Drawing.Color.Wheat;
            this.grdFilm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFilm.Location = new System.Drawing.Point(12, 206);
            this.grdFilm.Name = "grdFilm";
            this.grdFilm.RowHeadersWidth = 51;
            this.grdFilm.RowTemplate.Height = 24;
            this.grdFilm.Size = new System.Drawing.Size(1280, 579);
            this.grdFilm.TabIndex = 0;
            // 
            // btnAddFilm
            // 
            this.btnAddFilm.BackColor = System.Drawing.Color.YellowGreen;
            this.btnAddFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFilm.Location = new System.Drawing.Point(1326, 597);
            this.btnAddFilm.Name = "btnAddFilm";
            this.btnAddFilm.Size = new System.Drawing.Size(177, 83);
            this.btnAddFilm.TabIndex = 1;
            this.btnAddFilm.Text = "Ajouter un film";
            this.btnAddFilm.UseVisualStyleBackColor = false;
            this.btnAddFilm.Click += new System.EventHandler(this.btnAddFilm_Click);
            // 
            // btnDeleteFilm
            // 
            this.btnDeleteFilm.BackColor = System.Drawing.Color.Crimson;
            this.btnDeleteFilm.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDeleteFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteFilm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteFilm.Location = new System.Drawing.Point(1326, 702);
            this.btnDeleteFilm.Name = "btnDeleteFilm";
            this.btnDeleteFilm.Size = new System.Drawing.Size(177, 83);
            this.btnDeleteFilm.TabIndex = 3;
            this.btnDeleteFilm.Text = "Supprimer un film";
            this.btnDeleteFilm.UseVisualStyleBackColor = false;
            this.btnDeleteFilm.Click += new System.EventHandler(this.btnDeleteFilm_Click);
            // 
            // lstGenre
            // 
            this.lstGenre.FormattingEnabled = true;
            this.lstGenre.ItemHeight = 16;
            this.lstGenre.Location = new System.Drawing.Point(1326, 206);
            this.lstGenre.Name = "lstGenre";
            this.lstGenre.Size = new System.Drawing.Size(177, 212);
            this.lstGenre.TabIndex = 4;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(31, 48);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(170, 79);
            this.txtTitle.TabIndex = 5;
            // 
            // txtDirector
            // 
            this.txtDirector.Location = new System.Drawing.Point(389, 46);
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.Size = new System.Drawing.Size(164, 22);
            this.txtDirector.TabIndex = 6;
            // 
            // cboPublic
            // 
            this.cboPublic.FormattingEnabled = true;
            this.cboPublic.Location = new System.Drawing.Point(1108, 44);
            this.cboPublic.Name = "cboPublic";
            this.cboPublic.Size = new System.Drawing.Size(395, 24);
            this.cboPublic.TabIndex = 7;
            // 
            // txtSynopsis
            // 
            this.txtSynopsis.Location = new System.Drawing.Point(590, 46);
            this.txtSynopsis.Multiline = true;
            this.txtSynopsis.Name = "txtSynopsis";
            this.txtSynopsis.Size = new System.Drawing.Size(221, 134);
            this.txtSynopsis.TabIndex = 8;
            // 
            // btnResearch
            // 
            this.btnResearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnResearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResearch.Location = new System.Drawing.Point(1326, 484);
            this.btnResearch.Name = "btnResearch";
            this.btnResearch.Size = new System.Drawing.Size(177, 51);
            this.btnResearch.TabIndex = 9;
            this.btnResearch.Text = "Rechercher";
            this.btnResearch.UseVisualStyleBackColor = false;
            this.btnResearch.Click += new System.EventHandler(this.btnResearch_Click);
            // 
            // btnImportPicture
            // 
            this.btnImportPicture.Location = new System.Drawing.Point(64, 137);
            this.btnImportPicture.Name = "btnImportPicture";
            this.btnImportPicture.Size = new System.Drawing.Size(102, 45);
            this.btnImportPicture.TabIndex = 10;
            this.btnImportPicture.Text = "Importer une image";
            this.btnImportPicture.UseVisualStyleBackColor = true;
            this.btnImportPicture.Click += new System.EventHandler(this.btnImportPicture_Click);
            // 
            // txtActor
            // 
            this.txtActor.Location = new System.Drawing.Point(389, 119);
            this.txtActor.Multiline = true;
            this.txtActor.Name = "txtActor";
            this.txtActor.Size = new System.Drawing.Size(164, 63);
            this.txtActor.TabIndex = 11;
            // 
            // timeFilm
            // 
            this.timeFilm.CustomFormat = "";
            this.timeFilm.Location = new System.Drawing.Point(844, 48);
            this.timeFilm.Name = "timeFilm";
            this.timeFilm.Size = new System.Drawing.Size(99, 22);
            this.timeFilm.TabIndex = 12;
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(844, 119);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(204, 63);
            this.txtInfo.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Titre :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Réalisateur :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(386, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Acteurs :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(841, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Durée :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(587, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Synopsis :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(841, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Informations supplémentaires :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1106, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Type de public : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1326, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Genres : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(238, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 136);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(235, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Aperçu affiche :";
            // 
            // Film
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1530, 797);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.timeFilm);
            this.Controls.Add(this.txtActor);
            this.Controls.Add(this.btnImportPicture);
            this.Controls.Add(this.btnResearch);
            this.Controls.Add(this.txtSynopsis);
            this.Controls.Add(this.cboPublic);
            this.Controls.Add(this.txtDirector);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lstGenre);
            this.Controls.Add(this.btnDeleteFilm);
            this.Controls.Add(this.btnAddFilm);
            this.Controls.Add(this.grdFilm);
            this.Name = "Film";
            this.Text = "Gestion des films";
            this.Load += new System.EventHandler(this.Film_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdFilm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdFilm;
        private System.Windows.Forms.Button btnAddFilm;
        private System.Windows.Forms.Button btnDeleteFilm;
        private System.Windows.Forms.ListBox lstGenre;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.ComboBox cboPublic;
        private System.Windows.Forms.TextBox txtSynopsis;
        private System.Windows.Forms.Button btnResearch;
        private System.Windows.Forms.Button btnImportPicture;
        private System.Windows.Forms.TextBox txtActor;
        private System.Windows.Forms.DateTimePicker timeFilm;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
    }
}