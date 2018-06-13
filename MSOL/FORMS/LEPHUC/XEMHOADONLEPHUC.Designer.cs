namespace MSOL
{
    partial class XEMHOADONLEPHUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XEMHOADONLEPHUC));
            this.dgvCTHD_Lephuc = new System.Windows.Forms.DataGridView();
            this.cbbMalp = new System.Windows.Forms.ComboBox();
            this.txtSoLuotThue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MaLePhuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCTLP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaChoThue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHD_Lephuc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCTHD_Lephuc
            // 
            this.dgvCTHD_Lephuc.BackgroundColor = System.Drawing.Color.White;
            this.dgvCTHD_Lephuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTHD_Lephuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLePhuc,
            this.MaCTLP,
            this.MaHD,
            this.GiaChoThue});
            this.dgvCTHD_Lephuc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvCTHD_Lephuc.Location = new System.Drawing.Point(29, 61);
            this.dgvCTHD_Lephuc.Name = "dgvCTHD_Lephuc";
            this.dgvCTHD_Lephuc.ReadOnly = true;
            this.dgvCTHD_Lephuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCTHD_Lephuc.Size = new System.Drawing.Size(493, 215);
            this.dgvCTHD_Lephuc.TabIndex = 0;
            this.dgvCTHD_Lephuc.SelectionChanged += new System.EventHandler(this.dgvCTHD_Lephuc_SelectionChanged);
            // 
            // cbbMalp
            // 
            this.cbbMalp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMalp.FormattingEnabled = true;
            this.cbbMalp.Location = new System.Drawing.Point(29, 34);
            this.cbbMalp.Name = "cbbMalp";
            this.cbbMalp.Size = new System.Drawing.Size(149, 21);
            this.cbbMalp.TabIndex = 2;
            this.cbbMalp.SelectedIndexChanged += new System.EventHandler(this.cbbMalp_SelectedIndexChanged);
            // 
            // txtSoLuotThue
            // 
            this.txtSoLuotThue.Location = new System.Drawing.Point(469, 34);
            this.txtSoLuotThue.Name = "txtSoLuotThue";
            this.txtSoLuotThue.ReadOnly = true;
            this.txtSoLuotThue.Size = new System.Drawing.Size(49, 20);
            this.txtSoLuotThue.TabIndex = 3;
            this.txtSoLuotThue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(399, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Số lượt thuê";
            // 
            // MaLePhuc
            // 
            this.MaLePhuc.DataPropertyName = "MaLePhuc";
            this.MaLePhuc.HeaderText = "Mã lễ phục";
            this.MaLePhuc.Name = "MaLePhuc";
            this.MaLePhuc.ReadOnly = true;
            this.MaLePhuc.Width = 110;
            // 
            // MaCTLP
            // 
            this.MaCTLP.DataPropertyName = "MaCTLP";
            this.MaCTLP.HeaderText = "Mã CTHD";
            this.MaCTLP.Name = "MaCTLP";
            this.MaCTLP.ReadOnly = true;
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.HeaderText = "Mã hóa đơn";
            this.MaHD.Name = "MaHD";
            this.MaHD.ReadOnly = true;
            this.MaHD.Width = 120;
            // 
            // GiaChoThue
            // 
            this.GiaChoThue.DataPropertyName = "GiaChoThue";
            this.GiaChoThue.HeaderText = "Giá cho thuê";
            this.GiaChoThue.Name = "GiaChoThue";
            this.GiaChoThue.ReadOnly = true;
            this.GiaChoThue.Width = 120;
            // 
            // XEMHOADONLEPHUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 302);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSoLuotThue);
            this.Controls.Add(this.cbbMalp);
            this.Controls.Add(this.dgvCTHD_Lephuc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XEMHOADONLEPHUC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HÓA ĐƠN LỄ PHỤC";
            this.Load += new System.EventHandler(this.XEMHOADONLEPHUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHD_Lephuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCTHD_Lephuc;
        private System.Windows.Forms.ComboBox cbbMalp;
        private System.Windows.Forms.TextBox txtSoLuotThue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLePhuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTLP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaChoThue;
    }
}