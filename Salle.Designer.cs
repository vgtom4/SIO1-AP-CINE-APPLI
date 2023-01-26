namespace AP_CINE_APPLI
{
    partial class Salle
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
            this.grdSalle = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEditNum = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEditCapac = new System.Windows.Forms.Button();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.numCapac = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdSalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapac)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSalle
            // 
            this.grdSalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.grdSalle.Location = new System.Drawing.Point(260, 12);
            this.grdSalle.Name = "grdSalle";
            this.grdSalle.RowHeadersWidth = 51;
            this.grdSalle.RowTemplate.Height = 24;
            this.grdSalle.Size = new System.Drawing.Size(304, 426);
            this.grdSalle.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Num";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Capacité";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(61, 118);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(134, 56);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEditNum
            // 
            this.btnEditNum.Location = new System.Drawing.Point(12, 246);
            this.btnEditNum.Name = "btnEditNum";
            this.btnEditNum.Size = new System.Drawing.Size(108, 69);
            this.btnEditNum.TabIndex = 2;
            this.btnEditNum.Text = "Modification numéro";
            this.btnEditNum.UseVisualStyleBackColor = true;
            this.btnEditNum.Click += new System.EventHandler(this.btnEditNum_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(61, 354);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(134, 58);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Supprimer";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEditCapac
            // 
            this.btnEditCapac.Location = new System.Drawing.Point(133, 246);
            this.btnEditCapac.Name = "btnEditCapac";
            this.btnEditCapac.Size = new System.Drawing.Size(108, 69);
            this.btnEditCapac.TabIndex = 4;
            this.btnEditCapac.Text = "Modification capacité";
            this.btnEditCapac.UseVisualStyleBackColor = true;
            this.btnEditCapac.Click += new System.EventHandler(this.btnEditCapac_Click);
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(133, 41);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(92, 22);
            this.txtNum.TabIndex = 5;
            // 
            // numCapac
            // 
            this.numCapac.Location = new System.Drawing.Point(133, 74);
            this.numCapac.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCapac.Name = "numCapac";
            this.numCapac.Size = new System.Drawing.Size(92, 22);
            this.numCapac.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Numéro de salle :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Capacité de salle :";
            // 
            // Salle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numCapac);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.btnEditCapac);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEditNum);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grdSalle);
            this.Name = "Salle";
            this.Text = "Gestion des salles";
            this.Load += new System.EventHandler(this.Salle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdSalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEditNum;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEditCapac;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.NumericUpDown numCapac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}