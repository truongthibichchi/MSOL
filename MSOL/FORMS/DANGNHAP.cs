using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MSOL.DTO;
using MSOL.DAO;

namespace MSOL
{
    public partial class DANGNHAP : Form
    {
        public DANGNHAP()
        {
            InitializeComponent();
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            if (txtTentaikhoan.Text == "" || txtMatkhau.Text == "")
            {
                lbthongbao.Text = "Vui lòng nhập đầy đủ thông tin";
            }
            else
            {
                var tentaikhoan = txtTentaikhoan.Text;
                var matkhau = txtMatkhau.Text;

                if (dangnhapthanhcong(tentaikhoan, matkhau))
                {
                   TaiKhoan taikhoan = TaiKhoanDAO.Instance.getTaiKhoanByTenTaiKhoan(tentaikhoan);
                    Form frm = new MANHINHCHINH(taikhoan);
                    txtTentaikhoan.Clear();
                    txtMatkhau.Clear();
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    lbthongbao.Text = "Sai tài khoản hoặc mật khẩu";
                }
            }

        }


        private bool dangnhapthanhcong(string tentaikhoan, string matkhau)
        {
            return TaiKhoanDAO.Instance.dangnhap(tentaikhoan, matkhau);
        }
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private int anchorX, anchorY;
        bool isDown = false;

        private void DANGNHAP_MouseDown(object sender, MouseEventArgs e)
        {
            anchorX = System.Windows.Forms.Cursor.Position.X - this.Left;
            anchorY = System.Windows.Forms.Cursor.Position.Y - this.Top;
            isDown = true;
        }

        private void DANGNHAP_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                this.Left = System.Windows.Forms.Cursor.Position.X - anchorX;
                this.Top = System.Windows.Forms.Cursor.Position.Y - anchorY;
            }
        }

        private void DANGNHAP_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }
    }
}
