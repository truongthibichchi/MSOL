namespace MSOL
{
    partial class XEMLICHPHANCONG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XEMLICHPHANCONG));
            this.dgvLichPhanCong = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichPhanCong)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLichPhanCong
            // 
            this.dgvLichPhanCong.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichPhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichPhanCong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvLichPhanCong.Location = new System.Drawing.Point(24, 58);
            this.dgvLichPhanCong.Name = "dgvLichPhanCong";
            this.dgvLichPhanCong.ReadOnly = true;
            this.dgvLichPhanCong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichPhanCong.Size = new System.Drawing.Size(794, 425);
            this.dgvLichPhanCong.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(301, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "LỊCH PHÂN CÔNG CHỤP HÌNH";
            // 
            // XEMLICHPHANCONG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 509);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLichPhanCong);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XEMLICHPHANCONG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XEMLICHPHANCONG";
            this.Load += new System.EventHandler(this.XEMLICHPHANCONG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichPhanCong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLichPhanCong;
        private System.Windows.Forms.Label label1;
    }
}