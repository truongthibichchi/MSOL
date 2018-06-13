namespace MSOL
{
    partial class QUYDINH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QUYDINH));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTiendatcoc = new System.Windows.Forms.TextBox();
            this.txtSolephuc = new System.Windows.Forms.TextBox();
            this.txtSoGoiChup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(146, 195);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 34);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tiền đặt cọc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số lễ phục cho thuê tối đa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số gói chụp đăng kí tối đa";
            // 
            // txtTiendatcoc
            // 
            this.txtTiendatcoc.Location = new System.Drawing.Point(205, 48);
            this.txtTiendatcoc.Name = "txtTiendatcoc";
            this.txtTiendatcoc.Size = new System.Drawing.Size(100, 20);
            this.txtTiendatcoc.TabIndex = 2;
            // 
            // txtSolephuc
            // 
            this.txtSolephuc.Location = new System.Drawing.Point(205, 93);
            this.txtSolephuc.Name = "txtSolephuc";
            this.txtSolephuc.Size = new System.Drawing.Size(100, 20);
            this.txtSolephuc.TabIndex = 2;
            // 
            // txtSoGoiChup
            // 
            this.txtSoGoiChup.Location = new System.Drawing.Point(205, 136);
            this.txtSoGoiChup.Name = "txtSoGoiChup";
            this.txtSoGoiChup.Size = new System.Drawing.Size(100, 20);
            this.txtSoGoiChup.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(311, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "%";
            // 
            // QUYDINH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 241);
            this.Controls.Add(this.txtSoGoiChup);
            this.Controls.Add(this.txtSolephuc);
            this.Controls.Add(this.txtTiendatcoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QUYDINH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUYDINH";
            this.Load += new System.EventHandler(this.QUYDINH_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTiendatcoc;
        private System.Windows.Forms.TextBox txtSolephuc;
        private System.Windows.Forms.TextBox txtSoGoiChup;
        private System.Windows.Forms.Label label4;
    }
}