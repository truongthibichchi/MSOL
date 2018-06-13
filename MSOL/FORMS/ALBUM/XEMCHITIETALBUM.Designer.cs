namespace MSOL
{
    partial class XEMCHITIETALBUM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XEMCHITIETALBUM));
            this.txtMaAlbum = new System.Windows.Forms.TextBox();
            this.ofALBUM = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picChoose = new System.Windows.Forms.PictureBox();
            this.flpCTAlbum = new System.Windows.Forms.FlowLayoutPanel();
            this.picHinhAnh = new System.Windows.Forms.PictureBox();
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.txtMaCTalbum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChoose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaAlbum
            // 
            this.txtMaAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMaAlbum.Location = new System.Drawing.Point(69, 12);
            this.txtMaAlbum.Multiline = true;
            this.txtMaAlbum.Name = "txtMaAlbum";
            this.txtMaAlbum.ReadOnly = true;
            this.txtMaAlbum.Size = new System.Drawing.Size(70, 30);
            this.txtMaAlbum.TabIndex = 0;
            this.txtMaAlbum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ofALBUM
            // 
            this.ofALBUM.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::MSOL.Properties.Resources.insert;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(268, 290);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 34);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.picSave_Click);
            // 
            // picChoose
            // 
            this.picChoose.BackgroundImage = global::MSOL.Properties.Resources.upload_25068__340;
            this.picChoose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picChoose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picChoose.Location = new System.Drawing.Point(564, 12);
            this.picChoose.Name = "picChoose";
            this.picChoose.Size = new System.Drawing.Size(32, 32);
            this.picChoose.TabIndex = 5;
            this.picChoose.TabStop = false;
            this.picChoose.Click += new System.EventHandler(this.picChoose_Click);
            // 
            // flpCTAlbum
            // 
            this.flpCTAlbum.AutoScroll = true;
            this.flpCTAlbum.BackColor = System.Drawing.Color.White;
            this.flpCTAlbum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpCTAlbum.Location = new System.Drawing.Point(12, 330);
            this.flpCTAlbum.Name = "flpCTAlbum";
            this.flpCTAlbum.Size = new System.Drawing.Size(584, 291);
            this.flpCTAlbum.TabIndex = 4;
            // 
            // picHinhAnh
            // 
            this.picHinhAnh.Location = new System.Drawing.Point(12, 71);
            this.picHinhAnh.Name = "picHinhAnh";
            this.picHinhAnh.Size = new System.Drawing.Size(584, 213);
            this.picHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHinhAnh.TabIndex = 7;
            this.picHinhAnh.TabStop = false;
            // 
            // picDelete
            // 
            this.picDelete.BackgroundImage = global::MSOL.Properties.Resources.xoa;
            this.picDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Location = new System.Drawing.Point(328, 293);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(29, 29);
            this.picDelete.TabIndex = 8;
            this.picDelete.TabStop = false;
            this.picDelete.Click += new System.EventHandler(this.picDelete_Click);
            // 
            // txtMaCTalbum
            // 
            this.txtMaCTalbum.Location = new System.Drawing.Point(278, 45);
            this.txtMaCTalbum.Name = "txtMaCTalbum";
            this.txtMaCTalbum.Size = new System.Drawing.Size(53, 20);
            this.txtMaCTalbum.TabIndex = 9;
            this.txtMaCTalbum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mã Album";
            // 
            // XEMCHITIETALBUM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(621, 644);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaCTalbum);
            this.Controls.Add(this.picDelete);
            this.Controls.Add(this.picHinhAnh);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picChoose);
            this.Controls.Add(this.flpCTAlbum);
            this.Controls.Add(this.txtMaAlbum);
            this.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XEMCHITIETALBUM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XEMCHITIETALBUM";
            this.Load += new System.EventHandler(this.XEMCHITIETALBUM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChoose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaAlbum;
        private System.Windows.Forms.FlowLayoutPanel flpCTAlbum;
        private System.Windows.Forms.OpenFileDialog ofALBUM;
        private System.Windows.Forms.PictureBox picChoose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.PictureBox picDelete;
        private System.Windows.Forms.TextBox txtMaCTalbum;
        private System.Windows.Forms.Label label1;
    }
}