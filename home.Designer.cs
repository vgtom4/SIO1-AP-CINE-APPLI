namespace AP_CINE_APPLI
{
    partial class home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(home));
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnMin = new FontAwesome.Sharp.IconButton();
            this.btnMax = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnPDF = new FontAwesome.Sharp.IconButton();
            this.btnProjection = new FontAwesome.Sharp.IconButton();
            this.btnFilm = new FontAwesome.Sharp.IconButton();
            this.btnSalle = new FontAwesome.Sharp.IconButton();
            this.btnGenre = new FontAwesome.Sharp.IconButton();
            this.btnAccueil = new FontAwesome.Sharp.IconButton();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panelTitleBar.Controls.Add(this.btnMin);
            this.panelTitleBar.Controls.Add(this.btnMax);
            this.panelTitleBar.Controls.Add(this.btnClose);
            this.panelTitleBar.Controls.Add(this.pictureBox1);
            this.panelTitleBar.Controls.Add(this.label1);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1260, 50);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMin.IconChar = FontAwesome.Sharp.IconChar.Subtract;
            this.btnMin.IconColor = System.Drawing.Color.Black;
            this.btnMin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMin.IconSize = 35;
            this.btnMin.Location = new System.Drawing.Point(1119, 3);
            this.btnMin.Name = "btnMin";
            this.btnMin.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.btnMin.Size = new System.Drawing.Size(42, 42);
            this.btnMin.TabIndex = 6;
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnMax
            // 
            this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnMax.FlatAppearance.BorderSize = 0;
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMax.IconChar = FontAwesome.Sharp.IconChar.Square;
            this.btnMax.IconColor = System.Drawing.Color.Black;
            this.btnMax.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMax.IconSize = 35;
            this.btnMax.Location = new System.Drawing.Point(1167, 3);
            this.btnMax.Name = "btnMax";
            this.btnMax.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnMax.Size = new System.Drawing.Size(42, 42);
            this.btnMax.TabIndex = 5;
            this.btnMax.UseVisualStyleBackColor = false;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Multiply;
            this.btnClose.IconColor = System.Drawing.Color.Black;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 35;
            this.btnClose.Location = new System.Drawing.Point(1215, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(42, 42);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AP_CINE_APPLI.Properties.Resources.logo;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(47, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Outil de gestion Pathé Gaumont";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panelMenu.Controls.Add(this.btnPDF);
            this.panelMenu.Controls.Add(this.btnProjection);
            this.panelMenu.Controls.Add(this.btnFilm);
            this.panelMenu.Controls.Add(this.btnSalle);
            this.panelMenu.Controls.Add(this.btnGenre);
            this.panelMenu.Controls.Add(this.btnAccueil);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 50);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(260, 775);
            this.panelMenu.TabIndex = 2;
            // 
            // btnPDF
            // 
            this.btnPDF.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPDF.FlatAppearance.BorderSize = 0;
            this.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnPDF.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            this.btnPDF.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnPDF.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPDF.Location = new System.Drawing.Point(0, 500);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnPDF.Size = new System.Drawing.Size(260, 100);
            this.btnPDF.TabIndex = 5;
            this.btnPDF.Text = "PDF";
            this.btnPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnProjection
            // 
            this.btnProjection.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProjection.FlatAppearance.BorderSize = 0;
            this.btnProjection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjection.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProjection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnProjection.IconChar = FontAwesome.Sharp.IconChar.Ticket;
            this.btnProjection.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnProjection.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProjection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProjection.Location = new System.Drawing.Point(0, 400);
            this.btnProjection.Name = "btnProjection";
            this.btnProjection.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnProjection.Size = new System.Drawing.Size(260, 100);
            this.btnProjection.TabIndex = 4;
            this.btnProjection.Text = "Projection";
            this.btnProjection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProjection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProjection.UseVisualStyleBackColor = true;
            this.btnProjection.Click += new System.EventHandler(this.btnProjection_Click);
            // 
            // btnFilm
            // 
            this.btnFilm.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFilm.FlatAppearance.BorderSize = 0;
            this.btnFilm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnFilm.IconChar = FontAwesome.Sharp.IconChar.Film;
            this.btnFilm.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnFilm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFilm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilm.Location = new System.Drawing.Point(0, 300);
            this.btnFilm.Name = "btnFilm";
            this.btnFilm.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFilm.Size = new System.Drawing.Size(260, 100);
            this.btnFilm.TabIndex = 3;
            this.btnFilm.Text = "Film";
            this.btnFilm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFilm.UseVisualStyleBackColor = true;
            this.btnFilm.Click += new System.EventHandler(this.btnFilm_Click);
            // 
            // btnSalle
            // 
            this.btnSalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalle.FlatAppearance.BorderSize = 0;
            this.btnSalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnSalle.IconChar = FontAwesome.Sharp.IconChar.PeopleRoof;
            this.btnSalle.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnSalle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalle.Location = new System.Drawing.Point(0, 200);
            this.btnSalle.Name = "btnSalle";
            this.btnSalle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSalle.Size = new System.Drawing.Size(260, 100);
            this.btnSalle.TabIndex = 2;
            this.btnSalle.Text = "Salle";
            this.btnSalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalle.UseVisualStyleBackColor = true;
            this.btnSalle.Click += new System.EventHandler(this.btnSalle_Click);
            // 
            // btnGenre
            // 
            this.btnGenre.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGenre.FlatAppearance.BorderSize = 0;
            this.btnGenre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnGenre.IconChar = FontAwesome.Sharp.IconChar.MasksTheater;
            this.btnGenre.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnGenre.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGenre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenre.Location = new System.Drawing.Point(0, 100);
            this.btnGenre.Name = "btnGenre";
            this.btnGenre.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnGenre.Size = new System.Drawing.Size(260, 100);
            this.btnGenre.TabIndex = 1;
            this.btnGenre.Text = "Genre";
            this.btnGenre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenre.UseVisualStyleBackColor = true;
            this.btnGenre.Click += new System.EventHandler(this.btnGenre_Click);
            // 
            // btnAccueil
            // 
            this.btnAccueil.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccueil.FlatAppearance.BorderSize = 0;
            this.btnAccueil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccueil.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccueil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnAccueil.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.btnAccueil.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnAccueil.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAccueil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccueil.Location = new System.Drawing.Point(0, 0);
            this.btnAccueil.Name = "btnAccueil";
            this.btnAccueil.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAccueil.Size = new System.Drawing.Size(260, 100);
            this.btnAccueil.TabIndex = 0;
            this.btnAccueil.Text = "Accueil";
            this.btnAccueil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccueil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccueil.UseVisualStyleBackColor = true;
            this.btnAccueil.Click += new System.EventHandler(this.btnAccueil_Click);
            // 
            // panelDesktop
            // 
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(260, 50);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1000, 775);
            this.panelDesktop.TabIndex = 3;
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(1260, 825);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1222, 825);
            this.Name = "home";
            this.Text = "Outil Pathé Gaumont";
            this.Load += new System.EventHandler(this.home_Load);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnPDF;
        private FontAwesome.Sharp.IconButton btnProjection;
        private FontAwesome.Sharp.IconButton btnFilm;
        private FontAwesome.Sharp.IconButton btnSalle;
        private FontAwesome.Sharp.IconButton btnGenre;
        private FontAwesome.Sharp.IconButton btnAccueil;
        private System.Windows.Forms.Panel panelDesktop;
        private FontAwesome.Sharp.IconButton btnMax;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnMin;
    }
}