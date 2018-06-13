namespace MSOL
{
    partial class DANGNHAP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DANGNHAP));
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTentaikhoan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.btn_dangnhap = new System.Windows.Forms.Button();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.lbthongbao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(160)))), ((int)(((byte)(136)))));
            this.label6.Name = "label6";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // txtTentaikhoan
            // 
            resources.ApplyResources(this.txtTentaikhoan, "txtTentaikhoan");
            this.txtTentaikhoan.Name = "txtTentaikhoan";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // txtMatkhau
            // 
            resources.ApplyResources(this.txtMatkhau, "txtMatkhau");
            this.txtMatkhau.Name = "txtMatkhau";
            // 
            // btn_dangnhap
            // 
            resources.ApplyResources(this.btn_dangnhap, "btn_dangnhap");
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.UseVisualStyleBackColor = true;
            this.btn_dangnhap.Click += new System.EventHandler(this.btn_dangnhap_Click);
            // 
            // picClose
            // 
            this.picClose.BackgroundImage = global::MSOL.Properties.Resources.close;
            resources.ApplyResources(this.picClose, "picClose");
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Name = "picClose";
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // lbthongbao
            // 
            resources.ApplyResources(this.lbthongbao, "lbthongbao");
            this.lbthongbao.ForeColor = System.Drawing.Color.Maroon;
            this.lbthongbao.Name = "lbthongbao";
            // 
            // DANGNHAP
            // 
            this.AcceptButton = this.btn_dangnhap;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(50)))), ((int)(((byte)(63)))));
            this.Controls.Add(this.lbthongbao);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.btn_dangnhap);
            this.Controls.Add(this.txtMatkhau);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTentaikhoan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DANGNHAP";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DANGNHAP_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DANGNHAP_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DANGNHAP_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTentaikhoan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMatkhau;
        private System.Windows.Forms.Button btn_dangnhap;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Label lbthongbao;
    }
}

