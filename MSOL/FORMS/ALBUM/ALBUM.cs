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

namespace MSOL
{
    public partial class ALBUM : UserControl
    {
        BindingSource albumList = new BindingSource();
        private HoaDon _hoadon;
        private List<CTHDGoiChup> _CTGoichupList;
        private CTHDGoiChup _CTgoichup;
        private static ALBUM _instance;
        public static ALBUM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ALBUM();
                return _instance;
            }
        }
        public ALBUM()
        {
            InitializeComponent();
        }

        private void btnCaidatgoichup_Click(object sender, EventArgs e)
        {
            Form frm = new CAIDATGOICHUP();
            frm.Show();
        }

        private void picAlbum_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaAlbum.Text))
            {
                MessageBox.Show("Chưa có Album");
                return;
            }
            var MaAlbum = Convert.ToInt32(txtMaAlbum.Text);
            XEMCHITIETALBUM frm = new XEMCHITIETALBUM(MaAlbum);
            frm.Show();
        }

        private void picProperties_Click(object sender, EventArgs e)
        {
            Form frm = new CAIDATGOICHUP();
            frm.Show();
        }

        private void ALBUM_Load(object sender, EventArgs e)
        {
            loadcbbMaCTGC();
            AddAlbumDatagridHeader();
            dgvAlbum.DataSource = albumList;
            ChangeSelectedIndexMaCTGC();
            LoadAlbumList();
            
        }

      

        private void loadcbbMaCTGC()
        {
            cbbMaCTGC.DisplayMember = "MaCTGC";
            _CTGoichupList = CTHDGoiChupDAO.Instance.GetCTHDGoichupList();
            cbbMaCTGC.DataSource = _CTGoichupList;
        }


        private void cbbMaCTGC_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mactgc = (cbbMaCTGC.SelectedItem as CTHDGoiChup).MaCTGC;
            _CTgoichup = CTHDGoiChupDAO.Instance.GetCTgoichupByMaCTGC(mactgc);
            txtMaGC.Text = _CTgoichup.MaGoiChup.ToString();
            txtDiadiem.Text = GoiChupDAO.Instance.getDiadiemByMagoichup(_CTgoichup.MaGoiChup).ToString();
            txtGiagoichup.Text = _CTgoichup.GiaTien.ToString();
            dtimeNgaychup.Value = _CTgoichup.NgayChup;
            _hoadon = HoaDonDAO.Instance.GetHoadonByMaHD(_CTgoichup.MaHD);
            txtMaHD.Text = _hoadon.MaHD.ToString();
            txtTenKH.Text = _hoadon.TenKH.ToString();
            txtSDT.Text = _hoadon.SDT.ToString();
            LoadAlbumByMaCTGC((cbbMaCTGC.SelectedItem as CTHDGoiChup).MaCTGC);
            
        }


        private void LoadAlbumByMaCTGC(int mactgc)
        {
            if (AlbumDAO.Instance.checkDuplicateAlbum(mactgc))
            {
                var album = AlbumDAO.Instance.getAlbumByMaCTGC(mactgc);
                {
                    txtMaAlbum.Text = album.MaAlbum.ToString();
                    dtimeNgayAlbum.Text = album.NgayNhap.ToString();
                    txtGiaAlbum.Text = album.GiaAlbum.ToString();
                }
            }
          
            else
            {
                txtMaAlbum.Text = "";
                dtimeNgayAlbum.Text = "";
                txtGiaAlbum.Text = "";
            }

        }

        //private void RemoveBindingAlbumTextbox()
        //{
        //    cbbMaCTGC.DataBindings.Clear();
        //    txtMaGC.DataBindings.Clear();
        //    txtDiadiem.DataBindings.Clear();
        //    txtMaHD.DataBindings.Clear();
        //    txtTenKH.DataBindings.Clear();
        //    txtSDT.DataBindings.Clear();
        //    dtimeNgayAlbum.DataBindings.Clear();
        //    txtGiaAlbum.DataBindings.Clear();
        //}


        private void AddAlbumDatabindingtextbox()
        {
            txtMaAlbum.DataBindings.Add(new Binding("Text", dgvAlbum.DataSource, "MaAlbum", true, DataSourceUpdateMode.Never));
            dtimeNgayAlbum.DataBindings.Add(new Binding("Value", dgvAlbum.DataSource, "NgayNhap", true, DataSourceUpdateMode.Never));
            txtGiaAlbum.DataBindings.Add(new Binding("Text", dgvAlbum.DataSource, "GiaAlbum", true, DataSourceUpdateMode.Never));
        }

        private void AddAlbumDatagridHeader()
        {
            dgvAlbum.AutoGenerateColumns = false;
            dgvAlbum.ColumnCount = 5;
            dgvAlbum.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvAlbum.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAlbum.AutoResizeColumns();
            dgvAlbum.AutoResizeRows();

            dgvAlbum.Columns[0].Name = "MaAlbum";
            dgvAlbum.Columns[0].HeaderText = "Mã Album";
            dgvAlbum.Columns[0].DataPropertyName = "MaAlbum";
            dgvAlbum.Columns[0].Width = 50;

            dgvAlbum.Columns[1].Name = "TenKH";
            dgvAlbum.Columns[1].HeaderText = "Tên khách hàng";
            dgvAlbum.Columns[1].DataPropertyName = "TenKh";
            dgvAlbum.Columns[1].Width = 150;

            dgvAlbum.Columns[2].Name = "DiaDiem";
            dgvAlbum.Columns[2].HeaderText = "Địa điểm";
            dgvAlbum.Columns[2].DataPropertyName = "DiaDiem";
            dgvAlbum.Columns[2].Width = 150;

            dgvAlbum.Columns[3].Name = "GiaAlbum";
            dgvAlbum.Columns[3].HeaderText = "Giá Album";
            dgvAlbum.Columns[3].DataPropertyName = "GiaAlbum";
            dgvAlbum.Columns[3].Width = 70;

            dgvAlbum.Columns[4].Name = "NgayNhap";
            dgvAlbum.Columns[4].HeaderText = "Ngày nhập Album";
            dgvAlbum.Columns[4].DataPropertyName = "NgayNhap";
            dgvAlbum.Columns[4].Width = 150;

        }

        private void LoadAlbumList()
        {
            albumList.DataSource = AlbumDAO.Instance.getAlbumList();
            //RemoveBindingAlbumTextbox();
            //_albumList = AlbumDAO.Instance.getAlbumList();
            //if (_albumList != null)
            //{
            //    dgvAlbum.DataSource=_albumList;
            //    //AddAlbumDatabindingtextbox();  
            //}
        }

        private void dgvAlbum_SelectionChanged(object sender, EventArgs e)
        {
            ChangeSelectedIndexMaCTGC();

        }
        private void ChangeSelectedIndexMaCTGC()
        {
            try
            {
                List<Album> _albumList = AlbumDAO.Instance.getAlbumList();
                var mactgc = _albumList[dgvAlbum.SelectedRows[0].Index].MaCTGC;
                var index = _CTGoichupList.FindIndex(p => p.MaCTGC == mactgc);
                cbbMaCTGC.SelectedIndex = index;
                
            }
            catch { }
        }

        private void picADD_Click(object sender, EventArgs e)
        {
            try
            {
                var mactgc = Convert.ToInt32((cbbMaCTGC.SelectedItem as CTHDGoiChup).MaCTGC);
                var ngaynhap = dtimeNgayAlbum.Value;
                var giaAlbum = Convert.ToInt32(txtGiaAlbum.Text);

                if (giaAlbum<0)
                {
                    MessageBox.Show("Lỗi! Nhập lại giá album");
                    return;
                }
                if (AlbumDAO.Instance.checkDuplicateAlbum(mactgc))
                {
                    MessageBox.Show("Album đã tồn tại, vui lòng thay đổi Mã Chi tiết hóa đơn gói chụp");
                    return;
                }
                if (MessageBox.Show("Các thông tin sẽ không được thay đổi, bạn muốn tiếp tục?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if (AlbumDAO.Instance.InsertCTAlbum(mactgc, ngaynhap, giaAlbum))
                    {
                        MessageBox.Show("Thêm Album thành công");
                        LoadAlbumList();
                        var index = _CTGoichupList.FindIndex(p => p.MaCTGC == mactgc);
                        cbbMaCTGC.SelectedIndex = index;
                    }
                    else
                    {
                        MessageBox.Show("Không thành công");
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picXemlichchup_Click(object sender, EventArgs e)
        {
            XEMLICHPHANCONG frm = new XEMLICHPHANCONG();
            frm.ShowDialog();
            this.Show();
        }

        private void picUPDATE_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(txtMaAlbum.Text))
                {
                    return;
                }
                var mahd = Convert.ToInt32(txtMaHD.Text);
                var maAlbum = Convert.ToInt32(txtMaAlbum.Text);
                var mactgc = Convert.ToInt32((cbbMaCTGC.SelectedItem as CTHDGoiChup).MaCTGC);
                var ngaynhap = dtimeNgayAlbum.Value;
                var giaAlbum = Convert.ToInt32(txtGiaAlbum.Text);

                if (HoaDonDAO.Instance.DaInHoaDon(mahd))
                {
                    MessageBox.Show("Hóa đơn này đã in, không thể thay đổi thông tin");
                    return;
                }
                if (giaAlbum < 0)
                {
                    MessageBox.Show("Lỗi! Nhập lại giá album");
                    return;
                }
                if (AlbumDAO.Instance.UpdateAlbum(maAlbum, mactgc, ngaynhap, giaAlbum))
                {
                    var TongtienAlbum = 0;
                   List<Album> albumList = AlbumDAO.Instance.getAlbumListByMaHD(mahd);
                   for (int i = 0; i < albumList.Count; i++)
                   {
                       TongtienAlbum += albumList[i].GiaAlbum;
                   }
                   if (HoaDonDAO.Instance.updateTienAlbum(TongtienAlbum, mahd))
                   {

                       MessageBox.Show("Sửa Album thành công");
                       LoadAlbumList();
                       var index = _CTGoichupList.FindIndex(p => p.MaCTGC == mactgc);
                       cbbMaCTGC.SelectedIndex = index;
                   }

                }
                else
                {
                    MessageBox.Show("Không thành công");
                }

            }
            catch { }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private List<Album> SearchAlbum(string text)
        {
            List<Album> list = AlbumDAO.Instance.searchAlbum(text);
            return list;
        }

    }
}
