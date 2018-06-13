using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSOL.DAO;
using MSOL.DTO;

namespace MSOL
{
    public partial class THONGTINTAIKHOAN : Form
    {
        private TaiKhoan _taikhoan;

        public TaiKhoan Taikhoan
        {
            get { return _taikhoan; }
            set { _taikhoan = value; }
        }
        public THONGTINTAIKHOAN(TaiKhoan taikhoan)
        {
            InitializeComponent();
            _taikhoan = taikhoan;
        }

        private void THONGTINTAIKHOAN_Load(object sender, EventArgs e)
        {
            txtTenTK.Text = _taikhoan.TenTaiKhoan;
            var chucvu = TaiKhoanDAO.Instance.getchucvuBymaNV(TaiKhoanDAO.Instance.getMaNVByTaikhoan(_taikhoan.MaTaiKhoan));
            if (chucvu == 1)
            {
                btnTaoTK.Visible = true;
            }
        }

        private void UpdatePassword()
        {
            string tentaikhoan = _taikhoan.TenTaiKhoan;
            string matkhau = txtMatKhau.Text;
            string matkhaumoi = txtMatkhaumoi.Text;
            string nhaplaiMK = txtNhapLaiMK.Text;

            if (string.IsNullOrEmpty(matkhau) || string.IsNullOrEmpty(matkhaumoi) || string.IsNullOrEmpty(nhaplaiMK))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            if (matkhau != _taikhoan.MatKhau)
            {
                MessageBox.Show("Sai mật khẩu, nhập lại");
                reload();
                return;
            }
            if (!matkhaumoi.Equals(nhaplaiMK))
            {
                MessageBox.Show("Nhập lại mật khẩu không khớp mật khẩu mới");
                return;
            }
           
            else
            {
                if (TaiKhoanDAO.Instance.UpdateTAIKHOAN(tentaikhoan, matkhaumoi))
                {
                    MessageBox.Show("Đã cập nhật mật khẩu mới");
                    reload();
                }
                else
                {
                    MessageBox.Show("Không thành công");
                    reload();
                    return;
                }
            }
        }

        private void reload()
        {
            txtMatKhau.Clear();
            txtMatkhaumoi.Clear();
            txtNhapLaiMK.Clear();
        }
        private void btn_Taotaikhoan_Click(object sender, EventArgs e)
        {
            Form frm = new DANHSACHTAIKHOAN();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            UpdatePassword();
        }


        private int anchorX, anchorY;
        bool isDown = false;
        private void THONGTINTAIKHOAN_MouseDown(object sender, MouseEventArgs e)
        {
            anchorX = System.Windows.Forms.Cursor.Position.X - this.Left;
            anchorY = System.Windows.Forms.Cursor.Position.Y - this.Top;
            isDown = true;
        }

        private void THONGTINTAIKHOAN_MouseMove(object sender, MouseEventArgs e)
        {
            isDown = false;
        }

        private void THONGTINTAIKHOAN_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                this.Left = System.Windows.Forms.Cursor.Position.X - anchorX;
                this.Top = System.Windows.Forms.Cursor.Position.Y - anchorY;
            }
        }

       

    }
}
