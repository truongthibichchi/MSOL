namespace MSOL
{
    partial class CHONGOICHUP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CHONGOICHUP));
            this.dgvGoichup = new System.Windows.Forms.DataGridView();
            this.MaGoiChup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnChoose = new System.Windows.Forms.Button();
            this.cbbLoaiGC = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoichup)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGoichup
            // 
            this.dgvGoichup.AllowUserToAddRows = false;
            this.dgvGoichup.AllowUserToDeleteRows = false;
            this.dgvGoichup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoichup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaGoiChup,
            this.DiaDiem,
            this.GiaTien,
            this.dataGridViewCheckBoxColumn1});
            this.dgvGoichup.Location = new System.Drawing.Point(12, 60);
            this.dgvGoichup.Name = "dgvGoichup";
            this.dgvGoichup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoichup.Size = new System.Drawing.Size(443, 406);
            this.dgvGoichup.TabIndex = 160;
            // 
            // MaGoiChup
            // 
            this.MaGoiChup.DataPropertyName = "MaGoiChup";
            this.MaGoiChup.HeaderText = "Mã gói chụp";
            this.MaGoiChup.Name = "MaGoiChup";
            this.MaGoiChup.Width = 50;
            // 
            // DiaDiem
            // 
            this.DiaDiem.DataPropertyName = "DiaDiem";
            this.DiaDiem.HeaderText = "Địa điểm";
            this.DiaDiem.Name = "DiaDiem";
            this.DiaDiem.Width = 200;
            // 
            // GiaTien
            // 
            this.GiaTien.DataPropertyName = "GiaTien";
            this.GiaTien.HeaderText = "Giá tiền";
            this.GiaTien.Name = "GiaTien";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FalseValue = "0";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Chọn";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.TrueValue = "1";
            this.dataGridViewCheckBoxColumn1.Width = 50;
            // 
            // btnChoose
            // 
            this.btnChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnChoose.ForeColor = System.Drawing.Color.Black;
            this.btnChoose.Location = new System.Drawing.Point(193, 472);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(88, 30);
            this.btnChoose.TabIndex = 159;
            this.btnChoose.Text = "CHỌN";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // cbbLoaiGC
            // 
            this.cbbLoaiGC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLoaiGC.FormattingEnabled = true;
            this.cbbLoaiGC.Location = new System.Drawing.Point(12, 33);
            this.cbbLoaiGC.Name = "cbbLoaiGC";
            this.cbbLoaiGC.Size = new System.Drawing.Size(291, 21);
            this.cbbLoaiGC.TabIndex = 158;
            this.cbbLoaiGC.SelectedIndexChanged += new System.EventHandler(this.cbbLoaiGC_SelectedIndexChanged);
            // 
            // CHONGOICHUP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 514);
            this.Controls.Add(this.dgvGoichup);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.cbbLoaiGC);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CHONGOICHUP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHỌN GÓI CHỤP";
            this.Load += new System.EventHandler(this.CHONGOICHUP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoichup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.ComboBox cbbLoaiGC;
        public System.Windows.Forms.DataGridView dgvGoichup;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaGoiChup;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaTien;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
    }
}