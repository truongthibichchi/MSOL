namespace MSOL.FORMS
{
    partial class FORM_CTHD_ALBUM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_CTHD_ALBUM));
            this.flpCTAlbum = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaCTGC = new System.Windows.Forms.TextBox();
            this.txtGiaAlbum = new System.Windows.Forms.TextBox();
            this.txtGiagoichup = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbbMaAlbum = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtimeNgayAlbum = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiadiem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.flpAlbum = new System.Windows.Forms.FlowLayoutPanel();
            this.txtTongtien = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpCTAlbum
            // 
            this.flpCTAlbum.AutoScroll = true;
            this.flpCTAlbum.BackColor = System.Drawing.Color.White;
            this.flpCTAlbum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpCTAlbum.Location = new System.Drawing.Point(469, 3);
            this.flpCTAlbum.Name = "flpCTAlbum";
            this.flpCTAlbum.Size = new System.Drawing.Size(233, 470);
            this.flpCTAlbum.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtMaCTGC);
            this.panel1.Controls.Add(this.txtGiaAlbum);
            this.panel1.Controls.Add(this.txtGiagoichup);
            this.panel1.Controls.Add(this.flpCTAlbum);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.cbbMaAlbum);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtimeNgayAlbum);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDiadiem);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label10);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(24, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 352);
            this.panel1.TabIndex = 198;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 197;
            this.label9.Text = "Mã Album";
            // 
            // txtMaCTGC
            // 
            this.txtMaCTGC.Location = new System.Drawing.Point(143, 84);
            this.txtMaCTGC.Name = "txtMaCTGC";
            this.txtMaCTGC.ReadOnly = true;
            this.txtMaCTGC.Size = new System.Drawing.Size(177, 20);
            this.txtMaCTGC.TabIndex = 196;
            // 
            // txtGiaAlbum
            // 
            this.txtGiaAlbum.Location = new System.Drawing.Point(143, 303);
            this.txtGiaAlbum.Multiline = true;
            this.txtGiaAlbum.Name = "txtGiaAlbum";
            this.txtGiaAlbum.ReadOnly = true;
            this.txtGiaAlbum.Size = new System.Drawing.Size(177, 23);
            this.txtGiaAlbum.TabIndex = 151;
            // 
            // txtGiagoichup
            // 
            this.txtGiagoichup.Location = new System.Drawing.Point(143, 188);
            this.txtGiagoichup.Name = "txtGiagoichup";
            this.txtGiagoichup.ReadOnly = true;
            this.txtGiagoichup.Size = new System.Drawing.Size(177, 20);
            this.txtGiagoichup.TabIndex = 194;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(35, 195);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 195;
            this.label14.Text = "Giá gói chụp";
            // 
            // cbbMaAlbum
            // 
            this.cbbMaAlbum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaAlbum.FormattingEnabled = true;
            this.cbbMaAlbum.Location = new System.Drawing.Point(143, 27);
            this.cbbMaAlbum.MaxDropDownItems = 4;
            this.cbbMaAlbum.Name = "cbbMaAlbum";
            this.cbbMaAlbum.Size = new System.Drawing.Size(177, 21);
            this.cbbMaAlbum.TabIndex = 178;
            this.cbbMaAlbum.SelectedIndexChanged += new System.EventHandler(this.cbbMaAlbum_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 165;
            this.label6.Text = "Giá Album";
            // 
            // dtimeNgayAlbum
            // 
            this.dtimeNgayAlbum.Enabled = false;
            this.dtimeNgayAlbum.Location = new System.Drawing.Point(143, 252);
            this.dtimeNgayAlbum.Name = "dtimeNgayAlbum";
            this.dtimeNgayAlbum.Size = new System.Drawing.Size(177, 20);
            this.dtimeNgayAlbum.TabIndex = 164;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 163;
            this.label5.Text = "Ngày nhập";
            // 
            // txtDiadiem
            // 
            this.txtDiadiem.Location = new System.Drawing.Point(143, 138);
            this.txtDiadiem.Name = "txtDiadiem";
            this.txtDiadiem.ReadOnly = true;
            this.txtDiadiem.Size = new System.Drawing.Size(177, 20);
            this.txtDiadiem.TabIndex = 177;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 150;
            this.label3.Text = "Địa điểm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 174;
            this.label10.Text = "Mã CTHD Gói chụp";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMaHD.Location = new System.Drawing.Point(377, 28);
            this.txtMaHD.Multiline = true;
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(78, 34);
            this.txtMaHD.TabIndex = 196;
            this.txtMaHD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 161;
            this.label4.Text = "Mã hóa đơn";
            // 
            // flpAlbum
            // 
            this.flpAlbum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpAlbum.Location = new System.Drawing.Point(377, 93);
            this.flpAlbum.Name = "flpAlbum";
            this.flpAlbum.Size = new System.Drawing.Size(377, 400);
            this.flpAlbum.TabIndex = 199;
            // 
            // txtTongtien
            // 
            this.txtTongtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTongtien.ForeColor = System.Drawing.Color.Red;
            this.txtTongtien.Location = new System.Drawing.Point(237, 463);
            this.txtTongtien.Multiline = true;
            this.txtTongtien.Name = "txtTongtien";
            this.txtTongtien.ReadOnly = true;
            this.txtTongtien.Size = new System.Drawing.Size(108, 23);
            this.txtTongtien.TabIndex = 198;
            this.txtTongtien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(165, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 200;
            this.label1.Text = "Tổng tiền";
            // 
            // FORM_CTHD_ALBUM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 519);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTongtien);
            this.Controls.Add(this.flpAlbum);
            this.Controls.Add(this.txtMaHD);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FORM_CTHD_ALBUM";
            this.Text = "ALBUM";
            this.Load += new System.EventHandler(this.FORM_CTHD_ALBUM_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCTAlbum;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.TextBox txtGiaAlbum;
        private System.Windows.Forms.TextBox txtGiagoichup;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbbMaAlbum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtimeNgayAlbum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiadiem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaCTGC;
        private System.Windows.Forms.FlowLayoutPanel flpAlbum;
        private System.Windows.Forms.TextBox txtTongtien;
        private System.Windows.Forms.Label label1;
    }
}