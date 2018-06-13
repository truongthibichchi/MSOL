namespace MSOL
{
    partial class DOANHTHU
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThongke = new System.Windows.Forms.Button();
            this.dtimeKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dtimeBatDau = new System.Windows.Forms.DateTimePicker();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.picInDoanThu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInDoanThu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvDoanhThu.Location = new System.Drawing.Point(27, 140);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.ReadOnly = true;
            this.dgvDoanhThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoanhThu.Size = new System.Drawing.Size(974, 503);
            this.dgvDoanhThu.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(412, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "THỐNG KÊ DOANH THU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Đến ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Từ ngày";
            // 
            // btnThongke
            // 
            this.btnThongke.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongke.Location = new System.Drawing.Point(655, 69);
            this.btnThongke.Name = "btnThongke";
            this.btnThongke.Size = new System.Drawing.Size(75, 46);
            this.btnThongke.TabIndex = 8;
            this.btnThongke.Text = "THỐNG KÊ";
            this.btnThongke.UseVisualStyleBackColor = true;
            this.btnThongke.Click += new System.EventHandler(this.btnThongke_Click);
            // 
            // dtimeKetThuc
            // 
            this.dtimeKetThuc.Location = new System.Drawing.Point(416, 96);
            this.dtimeKetThuc.Name = "dtimeKetThuc";
            this.dtimeKetThuc.Size = new System.Drawing.Size(200, 20);
            this.dtimeKetThuc.TabIndex = 7;
            // 
            // dtimeBatDau
            // 
            this.dtimeBatDau.Location = new System.Drawing.Point(416, 67);
            this.dtimeBatDau.Name = "dtimeBatDau";
            this.dtimeBatDau.Size = new System.Drawing.Size(200, 20);
            this.dtimeBatDau.TabIndex = 6;
            // 
            // txtTongDoanhThu
            // 
            this.txtTongDoanhThu.Location = new System.Drawing.Point(853, 114);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.Size = new System.Drawing.Size(148, 20);
            this.txtTongDoanhThu.TabIndex = 13;
            this.txtTongDoanhThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(887, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tổng doanh thu";
            // 
            // picInDoanThu
            // 
            this.picInDoanThu.BackgroundImage = global::MSOL.Properties.Resources.print;
            this.picInDoanThu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picInDoanThu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picInDoanThu.Location = new System.Drawing.Point(950, 18);
            this.picInDoanThu.Name = "picInDoanThu";
            this.picInDoanThu.Size = new System.Drawing.Size(51, 45);
            this.picInDoanThu.TabIndex = 15;
            this.picInDoanThu.TabStop = false;
            this.picInDoanThu.Click += new System.EventHandler(this.picInDoanThu_Click);
            // 
            // DOANHTHU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.picInDoanThu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTongDoanhThu);
            this.Controls.Add(this.dgvDoanhThu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThongke);
            this.Controls.Add(this.dtimeKetThuc);
            this.Controls.Add(this.dtimeBatDau);
            this.Name = "DOANHTHU";
            this.Size = new System.Drawing.Size(1028, 660);
            this.Load += new System.EventHandler(this.DOANHTHU_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInDoanThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThongke;
        private System.Windows.Forms.DateTimePicker dtimeKetThuc;
        private System.Windows.Forms.DateTimePicker dtimeBatDau;
        private System.Windows.Forms.TextBox txtTongDoanhThu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picInDoanThu;
    }
}
