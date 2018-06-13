namespace MSOL.FORMS
{
    partial class CHONLEPHUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CHONLEPHUC));
            this.cboxLoaiLP = new System.Windows.Forms.ComboBox();
            this.flpLephuc = new System.Windows.Forms.FlowLayoutPanel();
            this.btnChon = new System.Windows.Forms.Button();
            this.txtMaLP = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboxLoaiLP
            // 
            this.cboxLoaiLP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxLoaiLP.FormattingEnabled = true;
            this.cboxLoaiLP.Location = new System.Drawing.Point(29, 22);
            this.cboxLoaiLP.Name = "cboxLoaiLP";
            this.cboxLoaiLP.Size = new System.Drawing.Size(177, 21);
            this.cboxLoaiLP.TabIndex = 4;
            this.cboxLoaiLP.SelectedIndexChanged += new System.EventHandler(this.cboxLoaiLP_SelectedIndexChanged);
            // 
            // flpLephuc
            // 
            this.flpLephuc.AutoScroll = true;
            this.flpLephuc.BackColor = System.Drawing.Color.White;
            this.flpLephuc.Location = new System.Drawing.Point(29, 49);
            this.flpLephuc.Name = "flpLephuc";
            this.flpLephuc.Size = new System.Drawing.Size(533, 496);
            this.flpLephuc.TabIndex = 5;
            // 
            // btnChon
            // 
            this.btnChon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChon.ForeColor = System.Drawing.Color.Black;
            this.btnChon.Location = new System.Drawing.Point(260, 551);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(75, 31);
            this.btnChon.TabIndex = 6;
            this.btnChon.Text = "CHỌN";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // txtMaLP
            // 
            this.txtMaLP.Location = new System.Drawing.Point(428, 25);
            this.txtMaLP.Name = "txtMaLP";
            this.txtMaLP.Size = new System.Drawing.Size(63, 20);
            this.txtMaLP.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(506, 23);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // CHONLEPHUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(593, 594);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtMaLP);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.flpLephuc);
            this.Controls.Add(this.cboxLoaiLP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CHONLEPHUC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHỌN LỄ PHỤC";
            this.Load += new System.EventHandler(this.CHONLEPHUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxLoaiLP;
        private System.Windows.Forms.FlowLayoutPanel flpLephuc;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.TextBox txtMaLP;
        private System.Windows.Forms.Button btnOK;
    }
}