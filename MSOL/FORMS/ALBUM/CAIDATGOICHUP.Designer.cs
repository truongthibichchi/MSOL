namespace MSOL
{
    partial class CAIDATGOICHUP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAIDATGOICHUP));
            this.txt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMagoichup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbboxLoaiGC = new System.Windows.Forms.ComboBox();
            this.txtDiadiem = new System.Windows.Forms.TextBox();
            this.txtGiatien = new System.Windows.Forms.TextBox();
            this.dgvGoichup = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.picDELETE = new System.Windows.Forms.PictureBox();
            this.picADD = new System.Windows.Forms.PictureBox();
            this.picUPDATE = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoichup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDELETE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picADD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUPDATE)).BeginInit();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Location = new System.Drawing.Point(32, 107);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(71, 13);
            this.txt.TabIndex = 149;
            this.txt.Text = "Loại gói chụp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 151;
            this.label2.Text = "Địa điểm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 153;
            this.label1.Text = "Giá tiền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 149;
            this.label3.Text = "Mã gói chụp";
            // 
            // txtMagoichup
            // 
            this.txtMagoichup.Location = new System.Drawing.Point(123, 71);
            this.txtMagoichup.Multiline = true;
            this.txtMagoichup.Name = "txtMagoichup";
            this.txtMagoichup.ReadOnly = true;
            this.txtMagoichup.Size = new System.Drawing.Size(124, 24);
            this.txtMagoichup.TabIndex = 154;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 149;
            this.label4.Text = "Mã gói chụp";
            // 
            // cbboxLoaiGC
            // 
            this.cbboxLoaiGC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxLoaiGC.FormattingEnabled = true;
            this.cbboxLoaiGC.Location = new System.Drawing.Point(123, 107);
            this.cbboxLoaiGC.Name = "cbboxLoaiGC";
            this.cbboxLoaiGC.Size = new System.Drawing.Size(124, 21);
            this.cbboxLoaiGC.TabIndex = 155;
            // 
            // txtDiadiem
            // 
            this.txtDiadiem.Location = new System.Drawing.Point(336, 68);
            this.txtDiadiem.Multiline = true;
            this.txtDiadiem.Name = "txtDiadiem";
            this.txtDiadiem.Size = new System.Drawing.Size(202, 24);
            this.txtDiadiem.TabIndex = 154;
            // 
            // txtGiatien
            // 
            this.txtGiatien.Location = new System.Drawing.Point(336, 104);
            this.txtGiatien.Multiline = true;
            this.txtGiatien.Name = "txtGiatien";
            this.txtGiatien.Size = new System.Drawing.Size(202, 20);
            this.txtGiatien.TabIndex = 154;
            // 
            // dgvGoichup
            // 
            this.dgvGoichup.BackgroundColor = System.Drawing.Color.White;
            this.dgvGoichup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoichup.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvGoichup.Location = new System.Drawing.Point(12, 227);
            this.dgvGoichup.Name = "dgvGoichup";
            this.dgvGoichup.ReadOnly = true;
            this.dgvGoichup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoichup.Size = new System.Drawing.Size(588, 259);
            this.dgvGoichup.TabIndex = 156;
            this.dgvGoichup.SelectionChanged += new System.EventHandler(this.dgvGoichup_SelectionChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(208, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 17);
            this.label5.TabIndex = 158;
            this.label5.Text = "DANH SÁCH GÓI CHỤP";
            // 
            // picDELETE
            // 
            this.picDELETE.BackgroundImage = global::MSOL.Properties.Resources._058;
            this.picDELETE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picDELETE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDELETE.Location = new System.Drawing.Point(336, 170);
            this.picDELETE.Name = "picDELETE";
            this.picDELETE.Size = new System.Drawing.Size(37, 36);
            this.picDELETE.TabIndex = 184;
            this.picDELETE.TabStop = false;
            this.picDELETE.Click += new System.EventHandler(this.picDELETE_Click);
            // 
            // picADD
            // 
            this.picADD.BackgroundImage = global::MSOL.Properties.Resources.insert;
            this.picADD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picADD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picADD.Location = new System.Drawing.Point(191, 170);
            this.picADD.Name = "picADD";
            this.picADD.Size = new System.Drawing.Size(35, 36);
            this.picADD.TabIndex = 183;
            this.picADD.TabStop = false;
            this.picADD.Click += new System.EventHandler(this.picADD_Click);
            // 
            // picUPDATE
            // 
            this.picUPDATE.BackgroundImage = global::MSOL.Properties.Resources.update;
            this.picUPDATE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picUPDATE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUPDATE.Location = new System.Drawing.Point(260, 170);
            this.picUPDATE.Name = "picUPDATE";
            this.picUPDATE.Size = new System.Drawing.Size(36, 36);
            this.picUPDATE.TabIndex = 185;
            this.picUPDATE.TabStop = false;
            this.picUPDATE.Click += new System.EventHandler(this.picUPDATE_Click);
            // 
            // CAIDATGOICHUP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 518);
            this.Controls.Add(this.picDELETE);
            this.Controls.Add(this.picADD);
            this.Controls.Add(this.picUPDATE);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvGoichup);
            this.Controls.Add(this.cbboxLoaiGC);
            this.Controls.Add(this.txtGiatien);
            this.Controls.Add(this.txtDiadiem);
            this.Controls.Add(this.txtMagoichup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CAIDATGOICHUP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CÀI ĐẶT GÓI CHỤP";
            this.Load += new System.EventHandler(this.CAIDATGOICHUP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoichup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDELETE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picADD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUPDATE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMagoichup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbboxLoaiGC;
        private System.Windows.Forms.TextBox txtDiadiem;
        private System.Windows.Forms.TextBox txtGiatien;
        private System.Windows.Forms.DataGridView dgvGoichup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picDELETE;
        private System.Windows.Forms.PictureBox picADD;
        private System.Windows.Forms.PictureBox picUPDATE;
    }
}