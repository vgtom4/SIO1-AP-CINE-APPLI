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
            this.components = new System.ComponentModel.Container();
            this.grdSalle = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.numCapac = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.errorProviderNumSalle = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderCapac = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdSalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNumSalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCapac)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSalle
            // 
            this.grdSalle.BackgroundColor = System.Drawing.Color.Wheat;
            this.grdSalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.grdSalle.Location = new System.Drawing.Point(200, 147);
            this.grdSalle.Name = "grdSalle";
            this.grdSalle.RowHeadersVisible = false;
            this.grdSalle.RowHeadersWidth = 51;
            this.grdSalle.RowTemplate.Height = 24;
            this.grdSalle.Size = new System.Drawing.Size(304, 426);
            this.grdSalle.TabIndex = 0;
            this.grdSalle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSalle_CellClick);
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
            this.btnAdd.BackColor = System.Drawing.Color.YellowGreen;
            this.btnAdd.Location = new System.Drawing.Point(569, 342);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(134, 56);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.Location = new System.Drawing.Point(569, 500);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(134, 58);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Supprimer";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(586, 180);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(92, 22);
            this.txtNum.TabIndex = 5;
            // 
            // numCapac
            // 
            this.numCapac.Location = new System.Drawing.Point(586, 240);
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
            this.label1.Location = new System.Drawing.Point(583, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Numéro de salle :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(583, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Capacité de salle :";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(547, 277);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(44, 16);
            this.lblMsg.TabIndex = 9;
            this.lblMsg.Text = "label3";
            // 
            // errorProviderNumSalle
            // 
            this.errorProviderNumSalle.ContainerControl = this;
            // 
            // errorProviderCapac
            // 
            this.errorProviderCapac.ContainerControl = this;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Yellow;
            this.btnEdit.Location = new System.Drawing.Point(569, 419);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(134, 56);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Modifier";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // Salle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(982, 728);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numCapac);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grdSalle);
            this.Name = "Salle";
            this.Text = "Gestion des salles";
            this.Load += new System.EventHandler(this.Salle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNumSalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCapac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdSalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.NumericUpDown numCapac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.ErrorProvider errorProviderNumSalle;
        private System.Windows.Forms.ErrorProvider errorProviderCapac;
        private System.Windows.Forms.Button btnEdit;
    }
}