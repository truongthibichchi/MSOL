using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSOL.DAO;
using MSOL.DTO;
using System.IO;
using MSOL.UTILITIES;

namespace MSOL
{
    public partial class NHANVIEN : UserControl
    {
        private List<NhanVien> _nhanvienlist;
        private List<ChucVu> _chucvulist;
        private static NHANVIEN _instance;


        BindingSource NhanvienList = new BindingSource();

        public static NHANVIEN Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NHANVIEN();
                return _instance;
            }
        }
        public NHANVIEN()
        {
            InitializeComponent();


        }

        private void NHANVIEN_Load(object sender, EventArgs e)
        {
            loadcbChucvu();
            addNhanvienDatagridHeader();
            dgvNhanVien.DataSource = NhanvienList;
           // ChangeSelectedIndexChucvu();
            loadNhanvienList();
            AddbinddingNhanvienTextbox();
          
        }
        private void loadcbChucvu()
        {
            _chucvulist = ChucVuDAO.Instance.GetChucvuList();
            cbboxChucVu.DataSource = _chucvulist;
            cbboxChucVu.DisplayMember = "TenChucVu";
            cbboxChucVu.ValueMember = "MaChucVu";
        }

        private void addNhanvienDatagridHeader()
        {
            dgvNhanVien.AutoGenerateColumns = false;
            dgvNhanVien.ColumnCount = 5;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNhanVien.AutoResizeColumns();

            dgvNhanVien.Columns[0].Name = "MaNV";
            dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns[0].DataPropertyName = "MaNV";
            dgvNhanVien.Columns[0].Width = 50;

            dgvNhanVien.Columns[1].Name = "TenNV";
            dgvNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dgvNhanVien.Columns[1].DataPropertyName = "TenNV";
            dgvNhanVien.Columns[1].Width = 150;


            dgvNhanVien.Columns[2].Name = "Luong";
            dgvNhanVien.Columns[2].HeaderText = "Lương";
            dgvNhanVien.Columns[2].DataPropertyName = "Luong";
            dgvNhanVien.Columns[2].Width = 70;

            dgvNhanVien.Columns[3].Name = "TenChucVu";
            dgvNhanVien.Columns[3].HeaderText = "Chức vụ";
            dgvNhanVien.Columns[3].DataPropertyName = "TenChucVu";
            dgvNhanVien.Columns[3].Width = 90;

            dgvNhanVien.Columns[4].Name = "TinhTrang";
            dgvNhanVien.Columns[4].HeaderText = "Trình trạng";
            dgvNhanVien.Columns[4].DataPropertyName = "TinhTrang";
            dgvNhanVien.Columns[4].Width = 90;

        }


        private void loadNhanvienList()
        {
            //RemoveBindingNhanvienTextbox();
          NhanvienList.DataSource = NhanVienDAO.Instance.getNhanvienList();
          //  dgvNhanVien.DataSource = _nhanvienlist;

            //for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
            //{
            //    var machucvu = _nhanvienlist[i].ChucVu;
            //    String chucvu = NhanVienDAO.Instance.getTenchucvuByMaCV(machucvu);
            //    dgvNhanVien.Rows[i].Cells["TenChucVu"].Value = chucvu;
            //}

          // AddbinddingNhanvienTextbox();

        }

        //private void RemoveBindingNhanvienTextbox()
        //{
        //    txtMaNV.DataBindings.Clear();
        //    txtTenNV.DataBindings.Clear();
        //    dtimeNgaySinh.DataBindings.Clear();
        //    rdNam.DataBindings.Clear();
        //    rdNu.DataBindings.Clear();
        //    txtCMND.DataBindings.Clear();
        //    txtSDT.DataBindings.Clear();
        //    txtDiaChi.DataBindings.Clear();
        //    cbboxChucVu.DataBindings.Clear();
        //    txtLuong.DataBindings.Clear();
        //    picHinhAnh.DataBindings.Clear();
        //}

        private void AddbinddingNhanvienTextbox()
        {
            txtMaNV.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            txtTenNV.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "TenNV", true, DataSourceUpdateMode.Never));
            dtimeNgaySinh.DataBindings.Add(new Binding("Value", dgvNhanVien.DataSource, "NgaySinh", true, DataSourceUpdateMode.Never));
            txtCMND.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "CMND", true, DataSourceUpdateMode.Never));
            txtSDT.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            txtLuong.DataBindings.Add(new Binding("text", dgvNhanVien.DataSource, "Luong", true, DataSourceUpdateMode.Never));
            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picHinhAnh.DataBindings.Add(new Binding("Image", dgvNhanVien.DataSource, "HinhAnh", true, DataSourceUpdateMode.Never));

        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            ChangeSelectedIndexChucvu();
        }

        private void ChangeSelectedIndexChucvu()
        {
            try
            {
                _nhanvienlist = NhanVienDAO.Instance.getNhanvienList();               
                var machucvu = _nhanvienlist[dgvNhanVien.SelectedRows[0].Index].ChucVu;
                var index = _chucvulist.FindIndex(p => p.MaChucVu == machucvu);
                cbboxChucVu.SelectedIndex = index;

                if (_nhanvienlist[dgvNhanVien.SelectedRows[0].Index].GioiTinh == "Nam")
                {
                    rdNam.Checked = true;
                    rdNu.Checked = false;
                }

                if (_nhanvienlist[dgvNhanVien.SelectedRows[0].Index].GioiTinh == "Nữ")
                {
                    rdNu.Checked = true;
                    rdNam.Checked = false;
                }
            }
            catch { }
        }

        private void picHinhAnh_Click(object sender, EventArgs e)
        {
            ofNhanvien.Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.png; *.jpeg; *.gif; *.bmp";
            ofNhanvien.FilterIndex = 1;
            ofNhanvien.RestoreDirectory = true;
            if (ofNhanvien.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image hinhanhmoi = Image.FromFile(ofNhanvien.FileName);
                picHinhAnh.Image = hinhanhmoi;
                picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private byte[] convertImageToByte(Image hinhanh)
        {
            MemoryStream ms = new MemoryStream();
            hinhanh.Save(ms, hinhanh.RawFormat);
            byte[] result = ms.GetBuffer();
            ms.Close();
            return result;
        }


        private void picADD_Click(object sender, EventArgs e)
        {
            try
            {
                var tennv = txtTenNV.Text;
                var ngaysinh = dtimeNgaySinh.Value;
                string gioitinh;
                if (rdNam.Checked == true) gioitinh = "Nam";
                else gioitinh = "Nữ";

                var cmnd = txtCMND.Text;
                var sdt = txtSDT.Text;
                var diachi = txtDiaChi.Text;
                var chucvu = Convert.ToInt32((cbboxChucVu.SelectedItem as ChucVu).MaChucVu);
                var luong = Convert.ToInt32(txtLuong.Text);
                byte[] hinhanh = convertImageToByte(picHinhAnh.Image);

                if (string.IsNullOrEmpty(tennv) || string.IsNullOrEmpty(cmnd) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diachi))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }

                if (luong < 0)
                {
                    MessageBox.Show("Sai lương ");
                    return;
                }
                if (NhanVienDAO.Instance.AddNhanvien(tennv, ngaysinh, gioitinh, cmnd, sdt, diachi, chucvu, luong, hinhanh))
                {
                    MessageBox.Show("Thêm nhân viên thành công");
                    loadNhanvienList();
                    int rowEnd = dgvNhanVien.Rows.Count;
                    dgvNhanVien.SelectedRows[rowEnd].Selected = true;
                }
                else
                {
                    MessageBox.Show("không thành công");
                }
            }
            catch 
            {
            }
        }

        private void picUPDATE_Click(object sender, EventArgs e)
        {
            //var index = dgvNhanVien.CurrentRow.Index;
            try
            {
                var manv = Convert.ToInt32(txtMaNV.Text);
                var tennv = txtTenNV.Text;
                var ngaysinh = dtimeNgaySinh.Value;
                string gioitinh;
                if (rdNam.Checked == true) gioitinh = "Nam";
                else gioitinh = "Nữ";

                var cmnd = txtCMND.Text;
                var sdt = txtSDT.Text;
                var diachi = txtDiaChi.Text;
                var chucvu = Convert.ToInt32((cbboxChucVu.SelectedItem as ChucVu).MaChucVu);
                var luong = Convert.ToInt32(txtLuong.Text);
                byte[] hinhanh = convertImageToByte(picHinhAnh.Image);

                if (string.IsNullOrEmpty(tennv) || string.IsNullOrEmpty(cmnd) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diachi))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }

                if (luong < 0)
                {
                    MessageBox.Show("Sai lương ");
                    return;
                }
                if (NhanVienDAO.Instance.UpdateNhanvien(manv, tennv, ngaysinh, gioitinh, cmnd, sdt, diachi, chucvu, luong, hinhanh))
                {
                    MessageBox.Show("Sửa nhân viên thành công");
                    loadNhanvienList();
                   

                }
                else
                {
                    MessageBox.Show("không thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picDELETE_Click(object sender, EventArgs e)
        {
            try
            {
                var manv = Convert.ToInt32(txtMaNV.Text);
                if (NhanVienDAO.Instance.DeleteNhanvien(manv))
                {
                    MessageBox.Show("Xóa nhân viên thành công");
                    loadNhanvienList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    loadNhanvienList();
                }
                else
                {
                    NhanvienList.DataSource = searchNhanvien(txtSearch.Text);
                }
            }
            catch { }
        }

        private List<NhanVien> searchNhanvien(string text)
        {
            List<NhanVien> list = NhanVienDAO.Instance.SearchNhanvien(text);
            return list; 
        }


    }
}
