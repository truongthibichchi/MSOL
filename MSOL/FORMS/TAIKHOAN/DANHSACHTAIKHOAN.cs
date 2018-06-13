using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSOL.DTO;
using MSOL.DAO;

namespace MSOL
{
    public partial class DANHSACHTAIKHOAN : Form
    {
        private static List<NhanVien> _nhanvienList;
        private static List<TaiKhoan> _taikhoanList;
        public DANHSACHTAIKHOAN()
        {
            InitializeComponent();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DANHSACHTAIKHOAN_Load(object sender, EventArgs e)
        {
            loadCbMaNV();
            addTaiKhoanDataGridHeader();
            loadTaiKhoanList();

        }

        private void loadCbMaNV()
        {
            _nhanvienList = NhanVienDAO.Instance.getTaiKhoanMaNVList();
            cbMaNV.DataSource = _nhanvienList;
            cbMaNV.ValueMember = "MaNV";
            cbMaNV.DisplayMember = "MaNV";
        }

        private void RemoveBindingTaiKhoanTextbox()
        {
            cbMaNV.DataBindings.Clear();
            txtTenNV.DataBindings.Clear();
            txtChucVu.DataBindings.Clear();
            txtTenTaiKhoan.DataBindings.Clear();
            txtMatkhau.DataBindings.Clear();
        }
        private void AddbindingTaiKhoanTextbox()
        {
            txtTenTaiKhoan.DataBindings.Add("Text", _taikhoanList, "TenTaiKhoan", true, DataSourceUpdateMode.Never);
            cbMaNV.DataBindings.Add("Text", _taikhoanList, "MaNV", true, DataSourceUpdateMode.Never);
            txtTenNV.DataBindings.Add("Text", _nhanvienList, "TenNV", true, DataSourceUpdateMode.Never);
            txtChucVu.DataBindings.Add("Text", _nhanvienList, "TenChucVu", true, DataSourceUpdateMode.Never);
        }

        private void addTaiKhoanDataGridHeader()
        {
            dgvTaiKhoan.AutoGenerateColumns = false;
            dgvTaiKhoan.ColumnCount = 3;
            dgvTaiKhoan.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTaiKhoan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTaiKhoan.AutoResizeColumns();

            dgvTaiKhoan.Columns[0].Name = "TenTaiKhoan";
            dgvTaiKhoan.Columns[0].HeaderText = "Tên tài khoản";
            dgvTaiKhoan.Columns[0].DataPropertyName = "TenTaiKhoan";
            dgvTaiKhoan.Columns[0].Width = 150;

            dgvTaiKhoan.Columns[1].Name = "TenNV";
            dgvTaiKhoan.Columns[1].HeaderText = "Tên nhân viên";
            dgvTaiKhoan.Columns[1].DataPropertyName = "TenNV";
            dgvTaiKhoan.Columns[1].Width = 150;

            dgvTaiKhoan.Columns[2].Name = "TenChucVu";
            dgvTaiKhoan.Columns[2].HeaderText = "Chức vụ";
            dgvTaiKhoan.Columns[2].DataPropertyName = "TenChucVu";
            dgvTaiKhoan.Columns[2].Width = 150;
        }

        private void loadTaiKhoanList()
        {
            RemoveBindingTaiKhoanTextbox();
            _taikhoanList = TaiKhoanDAO.Instance.getTaiKhoanList();
            dgvTaiKhoan.DataSource = _taikhoanList;

            for (int i = 0; i < dgvTaiKhoan.Rows.Count; i++)
            {
                var manv = _taikhoanList[i].MaNV;
                dgvTaiKhoan.Rows[i].Cells["TenNV"].Value = NhanVienDAO.Instance.getTenNVByMaNV(manv);
                dgvTaiKhoan.Rows[i].Cells["TenChucVu"].Value = NhanVienDAO.Instance.getTenchucvuByMaCV(NhanVienDAO.Instance.getMachucvuByMaNV(manv));
            }
            AddbindingTaiKhoanTextbox();

        }


        private void btnAdd_click(object sender, EventArgs e)
        {
            try
            {
                var tentaikhoan = txtTenTaiKhoan.Text;
                var manv = Convert.ToInt32((cbMaNV.SelectedItem as NhanVien).MaNV);
                var matkhau = txtMatkhau.Text;
                var chucvu = txtChucVu.Text;
                if (chucvu == "Bảo vệ")
                {
                    MessageBox.Show("Nhân viên này không có quyền truy cập vào hệ thống");
                    return;
                }

                if (TaiKhoanDAO.Instance.checkDuplicateUserName(tentaikhoan))
                {

                    lbThongbao.Text = "Tên tài khoản đã tồn tại, vui lòng nhập lại";
                    return;
                }
                if (string.IsNullOrEmpty(tentaikhoan) || string.IsNullOrEmpty(matkhau))
                {
                    lbThongbao.Text = "Tên tài khoản hoặc mật khẩu trống";
                    return;
                }
                if (TaiKhoanDAO.Instance.InsertTaiKhoan(tentaikhoan, manv, matkhau))
                {
                    MessageBox.Show("Thêm tài khoản thành công");
                    loadTaiKhoanList();
                }
                else
                {
                    MessageBox.Show("Không thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnDelete_click(object sender, EventArgs e)
        {
            try
            {
                var tentaikhoan = txtTenTaiKhoan.Text;
                if (string.IsNullOrEmpty(tentaikhoan))
                {
                    lbThongbao.Text = "Tên tài khoản trống";
                    return;
                }
                if (MessageBox.Show("Xác nhận xóa tài khoản", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if (TaiKhoanDAO.Instance.DeleteTaiKhoan(tentaikhoan))
                    {
                        MessageBox.Show("Xóa thành công");
                        loadTaiKhoanList();
                    }

                    else
                    {
                        MessageBox.Show("Không thành công");
                    }
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private int anchorX, anchorY;
        bool isDown = false;
        private void DANHSACHTAIKHOAN_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }

        private void DANHSACHTAIKHOAN_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                this.Left = System.Windows.Forms.Cursor.Position.X - anchorX;
                this.Top = System.Windows.Forms.Cursor.Position.Y - anchorY;
            }
        }

        private void DANHSACHTAIKHOAN_MouseDown(object sender, MouseEventArgs e)
        {
            anchorX = System.Windows.Forms.Cursor.Position.X - this.Left;
            anchorY = System.Windows.Forms.Cursor.Position.Y - this.Top;
            isDown = true;

        }

    }
}
