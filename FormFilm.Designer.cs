namespace AP_CINE_APPLI
{
    partial class FormFilm
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
            this.components = new System.ComponentModel.Container();
            this.lstGenre = new System.Windows.Forms.ListBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.cboPublic = new System.Windows.Forms.ComboBox();
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
            this.txtSynopsis = new System.Windows.Forms.RichTextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.errorProviderTitle = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderActor = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderDirector = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderDuree = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderPublic = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderGenre = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderSynopsis = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImportPicture = new FontAwesome.Sharp.IconButton();
            this.pbAffFilm = new System.Windows.Forms.PictureBox();
            this.cboTitre = new System.Windows.Forms.ComboBox();
            this.lblDirector = new System.Windows.Forms.Label();
            this.lblDuree = new System.Windows.Forms.Label();
            this.lblPublic = new System.Windows.Forms.Label();
            this.btnDeleteFilm = new FontAwesome.Sharp.IconButton();
            this.btnAddFilm = new FontAwesome.Sharp.IconButton();
            this.btnClear = new FontAwesome.Sharp.IconButton();
            this.btnResearch = new FontAwesome.Sharp.IconButton();
            this.lblSynopsis = new System.Windows.Forms.Label();
            this.lblActor = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderActor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDirector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDuree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPublic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderGenre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSynopsis)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAffFilm)).BeginInit();
            this.SuspendLayout();
            // 
            // lstGenre
            // 
            this.lstGenre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstGenre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.lstGenre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstGenre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lstGenre.FormattingEnabled = true;
            this.lstGenre.ItemHeight = 17;
            this.lstGenre.Location = new System.Drawing.Point(470, 35);
            this.lstGenre.Margin = new System.Windows.Forms.Padding(2);
            this.lstGenre.Name = "lstGenre";
            this.lstGenre.Size = new System.Drawing.Size(158, 102);
            this.lstGenre.TabIndex = 4;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(14, 37);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTitle.Size = new System.Drawing.Size(123, 55);
            this.txtTitle.TabIndex = 5;
            // 
            // txtDirector
            // 
            this.txtDirector.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDirector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.txtDirector.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDirector.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirector.Location = new System.Drawing.Point(14, 130);
            this.txtDirector.Margin = new System.Windows.Forms.Padding(2);
            this.txtDirector.Multiline = true;
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDirector.Size = new System.Drawing.Size(123, 51);
            this.txtDirector.TabIndex = 6;
            // 
            // cboPublic
            // 
            this.cboPublic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboPublic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.cboPublic.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboPublic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPublic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPublic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPublic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.cboPublic.FormattingEnabled = true;
            this.cboPublic.Location = new System.Drawing.Point(158, 35);
            this.cboPublic.Margin = new System.Windows.Forms.Padding(2);
            this.cboPublic.Name = "cboPublic";
            this.cboPublic.Size = new System.Drawing.Size(284, 28);
            this.cboPublic.TabIndex = 7;
            // 
            // txtActor
            // 
            this.txtActor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtActor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.txtActor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtActor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActor.Location = new System.Drawing.Point(14, 221);
            this.txtActor.Margin = new System.Windows.Forms.Padding(2);
            this.txtActor.Multiline = true;
            this.txtActor.Name = "txtActor";
            this.txtActor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtActor.Size = new System.Drawing.Size(123, 51);
            this.txtActor.TabIndex = 11;
            // 
            // timeFilm
            // 
            this.timeFilm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timeFilm.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.timeFilm.CustomFormat = "";
            this.timeFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeFilm.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeFilm.Location = new System.Drawing.Point(295, 106);
            this.timeFilm.Margin = new System.Windows.Forms.Padding(2);
            this.timeFilm.Name = "timeFilm";
            this.timeFilm.ShowUpDown = true;
            this.timeFilm.Size = new System.Drawing.Size(133, 32);
            this.timeFilm.TabIndex = 12;
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfo.Location = new System.Drawing.Point(295, 180);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(2);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(133, 27);
            this.txtInfo.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 26);
            this.label1.TabIndex = 14;
            this.label1.Text = "Titre :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 26);
            this.label2.TabIndex = 15;
            this.label2.Text = "Réalisateur :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 190);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 26);
            this.label3.TabIndex = 16;
            this.label3.Text = "Acteurs :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(290, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 26);
            this.label4.TabIndex = 17;
            this.label4.Text = "Durée :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(465, 162);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 26);
            this.label5.TabIndex = 18;
            this.label5.Text = "Synopsis :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(290, 150);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 26);
            this.label6.TabIndex = 19;
            this.label6.Text = "Informations :";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(154, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 26);
            this.label7.TabIndex = 20;
            this.label7.Text = "Type de public : ";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(465, 6);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 26);
            this.label8.TabIndex = 21;
            this.label8.Text = "Genres : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.Location = new System.Drawing.Point(176, 120);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(164, 93);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 18);
            this.label9.TabIndex = 23;
            this.label9.Text = "Aperçu affiche :";
            // 
            // txtSynopsis
            // 
            this.txtSynopsis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSynopsis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.txtSynopsis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSynopsis.EnableAutoDragDrop = true;
            this.txtSynopsis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSynopsis.Location = new System.Drawing.Point(470, 190);
            this.txtSynopsis.Margin = new System.Windows.Forms.Padding(2);
            this.txtSynopsis.Name = "txtSynopsis";
            this.txtSynopsis.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.txtSynopsis.Size = new System.Drawing.Size(158, 82);
            this.txtSynopsis.TabIndex = 24;
            this.txtSynopsis.Text = "";
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(290, 221);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(158, 51);
            this.lblMsg.TabIndex = 26;
            this.lblMsg.Text = "lblMsg";
            // 
            // errorProviderTitle
            // 
            this.errorProviderTitle.ContainerControl = this;
            // 
            // errorProviderActor
            // 
            this.errorProviderActor.ContainerControl = this;
            // 
            // errorProviderDirector
            // 
            this.errorProviderDirector.ContainerControl = this;
            // 
            // errorProviderDuree
            // 
            this.errorProviderDuree.ContainerControl = this;
            // 
            // errorProviderPublic
            // 
            this.errorProviderPublic.ContainerControl = this;
            // 
            // errorProviderGenre
            // 
            this.errorProviderGenre.ContainerControl = this;
            // 
            // errorProviderSynopsis
            // 
            this.errorProviderSynopsis.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.btnImportPicture);
            this.panel1.Controls.Add(this.lblMsg);
            this.panel1.Controls.Add(this.txtSynopsis);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lstGenre);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.timeFilm);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtInfo);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtDirector);
            this.panel1.Controls.Add(this.txtActor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboPublic);
            this.panel1.Location = new System.Drawing.Point(51, 260);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 288);
            this.panel1.TabIndex = 27;
            // 
            // btnImportPicture
            // 
            this.btnImportPicture.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImportPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnImportPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportPicture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnImportPicture.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btnImportPicture.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnImportPicture.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImportPicture.IconSize = 40;
            this.btnImportPicture.Location = new System.Drawing.Point(198, 236);
            this.btnImportPicture.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportPicture.Name = "btnImportPicture";
            this.btnImportPicture.Size = new System.Drawing.Size(34, 37);
            this.btnImportPicture.TabIndex = 37;
            this.btnImportPicture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportPicture.UseVisualStyleBackColor = false;
            this.btnImportPicture.Click += new System.EventHandler(this.btnImportPicture_Click);
            // 
            // pbAffFilm
            // 
            this.pbAffFilm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbAffFilm.Location = new System.Drawing.Point(28, 20);
            this.pbAffFilm.Margin = new System.Windows.Forms.Padding(2);
            this.pbAffFilm.Name = "pbAffFilm";
            this.pbAffFilm.Size = new System.Drawing.Size(112, 177);
            this.pbAffFilm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAffFilm.TabIndex = 27;
            this.pbAffFilm.TabStop = false;
            // 
            // cboTitre
            // 
            this.cboTitre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboTitre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.cboTitre.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboTitre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTitre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.cboTitre.FormattingEnabled = true;
            this.cboTitre.Location = new System.Drawing.Point(173, 20);
            this.cboTitre.Margin = new System.Windows.Forms.Padding(2);
            this.cboTitre.Name = "cboTitre";
            this.cboTitre.Size = new System.Drawing.Size(416, 34);
            this.cboTitre.TabIndex = 27;
            this.cboTitre.SelectedIndexChanged += new System.EventHandler(this.cboTitre_SelectedIndexChanged);
            this.cboTitre.TextChanged += new System.EventHandler(this.cboTitre_TextChanged);
            this.cboTitre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTitre_KeyPress);
            // 
            // lblDirector
            // 
            this.lblDirector.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDirector.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirector.Location = new System.Drawing.Point(170, 83);
            this.lblDirector.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(251, 41);
            this.lblDirector.TabIndex = 27;
            this.lblDirector.Text = "Réalisateur :";
            // 
            // lblDuree
            // 
            this.lblDuree.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDuree.AutoSize = true;
            this.lblDuree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuree.Location = new System.Drawing.Point(605, 31);
            this.lblDuree.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDuree.Name = "lblDuree";
            this.lblDuree.Size = new System.Drawing.Size(61, 20);
            this.lblDuree.TabIndex = 29;
            this.lblDuree.Text = "Durée :";
            // 
            // lblPublic
            // 
            this.lblPublic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPublic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublic.Location = new System.Drawing.Point(431, 83);
            this.lblPublic.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPublic.Name = "lblPublic";
            this.lblPublic.Size = new System.Drawing.Size(266, 41);
            this.lblPublic.TabIndex = 31;
            this.lblPublic.Text = "Type de public :";
            // 
            // btnDeleteFilm
            // 
            this.btnDeleteFilm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeleteFilm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnDeleteFilm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFilm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnDeleteFilm.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnDeleteFilm.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnDeleteFilm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDeleteFilm.Location = new System.Drawing.Point(702, 418);
            this.btnDeleteFilm.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteFilm.Name = "btnDeleteFilm";
            this.btnDeleteFilm.Size = new System.Drawing.Size(38, 41);
            this.btnDeleteFilm.TabIndex = 34;
            this.btnDeleteFilm.UseVisualStyleBackColor = false;
            this.btnDeleteFilm.Click += new System.EventHandler(this.btnDeleteFilm_Click);
            // 
            // btnAddFilm
            // 
            this.btnAddFilm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddFilm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnAddFilm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFilm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnAddFilm.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAddFilm.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnAddFilm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddFilm.Location = new System.Drawing.Point(702, 366);
            this.btnAddFilm.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddFilm.Name = "btnAddFilm";
            this.btnAddFilm.Size = new System.Drawing.Size(38, 41);
            this.btnAddFilm.TabIndex = 33;
            this.btnAddFilm.UseVisualStyleBackColor = false;
            this.btnAddFilm.Click += new System.EventHandler(this.btnAddFilm_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnClear.IconChar = FontAwesome.Sharp.IconChar.Backspace;
            this.btnClear.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnClear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClear.Location = new System.Drawing.Point(9, 418);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(38, 41);
            this.btnClear.TabIndex = 36;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnResearch
            // 
            this.btnResearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnResearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.btnResearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnResearch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnResearch.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnResearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnResearch.Location = new System.Drawing.Point(9, 366);
            this.btnResearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnResearch.Name = "btnResearch";
            this.btnResearch.Size = new System.Drawing.Size(38, 41);
            this.btnResearch.TabIndex = 35;
            this.btnResearch.UseVisualStyleBackColor = false;
            this.btnResearch.Click += new System.EventHandler(this.btnResearch_Click);
            // 
            // lblSynopsis
            // 
            this.lblSynopsis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSynopsis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.lblSynopsis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSynopsis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.lblSynopsis.Location = new System.Drawing.Point(170, 186);
            this.lblSynopsis.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSynopsis.Name = "lblSynopsis";
            this.lblSynopsis.Size = new System.Drawing.Size(526, 64);
            this.lblSynopsis.TabIndex = 37;
            this.lblSynopsis.Text = "Synopsis :";
            // 
            // lblActor
            // 
            this.lblActor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblActor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.lblActor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.lblActor.Location = new System.Drawing.Point(170, 132);
            this.lblActor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblActor.Name = "lblActor";
            this.lblActor.Size = new System.Drawing.Size(252, 41);
            this.lblActor.TabIndex = 38;
            this.lblActor.Text = "Acteur(s) :";
            // 
            // lblGenre
            // 
            this.lblGenre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGenre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.lblGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.lblGenre.Location = new System.Drawing.Point(431, 132);
            this.lblGenre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(266, 41);
            this.lblGenre.TabIndex = 39;
            this.lblGenre.Text = "Genre(s) :";
            // 
            // FormFilm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(750, 569);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblActor);
            this.Controls.Add(this.lblSynopsis);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnResearch);
            this.Controls.Add(this.btnDeleteFilm);
            this.Controls.Add(this.btnAddFilm);
            this.Controls.Add(this.lblPublic);
            this.Controls.Add(this.lblDuree);
            this.Controls.Add(this.lblDirector);
            this.Controls.Add(this.pbAffFilm);
            this.Controls.Add(this.cboTitre);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormFilm";
            this.Text = "Gestion des films";
            this.Load += new System.EventHandler(this.Film_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderActor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDirector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDuree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPublic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderGenre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSynopsis)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAffFilm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstGenre;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.ComboBox cboPublic;
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
        private System.Windows.Forms.RichTextBox txtSynopsis;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.ErrorProvider errorProviderTitle;
        private System.Windows.Forms.ErrorProvider errorProviderActor;
        private System.Windows.Forms.ErrorProvider errorProviderDirector;
        private System.Windows.Forms.ErrorProvider errorProviderDuree;
        private System.Windows.Forms.ErrorProvider errorProviderPublic;
        private System.Windows.Forms.ErrorProvider errorProviderGenre;
        private System.Windows.Forms.ErrorProvider errorProviderSynopsis;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbAffFilm;
        private System.Windows.Forms.ComboBox cboTitre;
        private System.Windows.Forms.Label lblPublic;
        private System.Windows.Forms.Label lblDuree;
        private System.Windows.Forms.Label lblDirector;
        private FontAwesome.Sharp.IconButton btnClear;
        private FontAwesome.Sharp.IconButton btnResearch;
        private FontAwesome.Sharp.IconButton btnDeleteFilm;
        private FontAwesome.Sharp.IconButton btnAddFilm;
        private FontAwesome.Sharp.IconButton btnImportPicture;
        private System.Windows.Forms.Label lblSynopsis;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblActor;
    }
}