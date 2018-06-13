using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSOL.DTO;
using MSOL.DAO;
using MSOL.FORMS;

namespace MSOL
{
    public partial class HOADON : UserControl
    {
        BindingSource HoadonList = new BindingSource();
        private List<HoaDon> _hoadonlist;
        List<CTHDLePhuc> _cthdlephuclist;
        List<CTHDGoiChup> _cthdGoichupList;
        List<Album> _albumList;
        private static HOADON _instance;
        public static HOADON Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HOADON();
                return _instance;

            }
        }
        public HOADON()
        {
            InitializeComponent();

        }

        private void HOADON_Load(object sender, EventArgs e)
        {
            addHoaDonDatagridHeader();
            dgvHoaDon.DataSource = HoadonList;
            LoadHoaDonList();
            AddbindingHoaDonTextbox();
            var mahd = Convert.ToInt32(txtMaHD.Text);
            LoadCTHDLePhucList(mahd);
            LoadCTHDGoiChupList(mahd);
            LoadAlbumList(mahd);
        }

        private void LoadCTHDLePhucList (int mahd)
        {
            _cthdlephuclist = CTHDLePhucDAO.Instance.GetCTHD_LephucList(mahd);

        }

        private void LoadCTHDGoiChupList(int mahd)
        {
            _cthdGoichupList = CTHDGoiChupDAO.Instance.GetCTHDGoiChupListByMaHD(mahd);
        }

        private void LoadAlbumList(int mahd)
        {

            _albumList = AlbumDAO.Instance.getAlbumListByMaHD(mahd);
        }

        private void addHoaDonDatagridHeader()
        {
            dgvHoaDon.AutoGenerateColumns = false;
            if(dgvHoaDon.ColumnCount == 0) {
                dgvHoaDon.ColumnCount = 6;
            }
            
            dgvHoaDon.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvHoaDon.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDon.AutoResizeColumns();

            dgvHoaDon.Columns[0].Name = "MaHD";
            dgvHoaDon.Columns[0].HeaderText = "Mã hóa đơn";
            dgvHoaDon.Columns[0].DataPropertyName = "MaHD";
            dgvHoaDon.Columns[0].Width = 50;


            dgvHoaDon.Columns[1].Name = "NgayHD";
            dgvHoaDon.Columns[1].HeaderText = "Ngày hóa đơn ";
            dgvHoaDon.Columns[1].DataPropertyName = "NgayHD";
            dgvHoaDon.Columns[1].Width = 150;

            dgvHoaDon.Columns[2].Name = "TenKH";
            dgvHoaDon.Columns[2].HeaderText = "Tên khách hàng";
            dgvHoaDon.Columns[2].DataPropertyName = "TenKH";
            dgvHoaDon.Columns[2].Width = 100;

            dgvHoaDon.Columns[3].Name = "TongTien";
            dgvHoaDon.Columns[3].HeaderText = "Tổng tiền";
            dgvHoaDon.Columns[3].DataPropertyName = "TongTien";
            dgvHoaDon.Columns[3].Width = 70;

            dgvHoaDon.Columns[4].Name = "ConLai";
            dgvHoaDon.Columns[4].HeaderText = "Còn lại";
            dgvHoaDon.Columns[4].DataPropertyName = "ConLai";
            dgvHoaDon.Columns[4].Width = 70;

            dgvHoaDon.Columns[5].Name = "InHD";
            dgvHoaDon.Columns[5].HeaderText = "Trình trạng";
            dgvHoaDon.Columns[5].DataPropertyName = "InHD";
            dgvHoaDon.Columns[5].Width = 100;

        }


        private void AddbindingHoaDonTextbox()
        {
            txtMaHD.DataBindings.Add(new Binding("Text", dgvHoaDon.DataSource, "MaHD", true, DataSourceUpdateMode.Never));
            dtimeNgayHD.DataBindings.Add(new Binding("Value",  dgvHoaDon.DataSource, "NgayHD", true, DataSourceUpdateMode.Never));
            txtTenKH.DataBindings.Add(new Binding("Text",  dgvHoaDon.DataSource, "TenKH", true, DataSourceUpdateMode.Never));
            txtCMND.DataBindings.Add(new Binding("Text",  dgvHoaDon.DataSource, "CMND", true, DataSourceUpdateMode.Never));
            txtSDT.DataBindings.Add(new Binding("Text",  dgvHoaDon.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text",  dgvHoaDon.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            txtTienLephuc.DataBindings.Add(new Binding("Text", dgvHoaDon.DataSource, "TienLePhuc", true, DataSourceUpdateMode.Never));
            txtTienGoichup.DataBindings.Add(new Binding("Text", dgvHoaDon.DataSource, "TienGoiChup", true, DataSourceUpdateMode.Never));
            txtTienAlbum.DataBindings.Add(new Binding("Text", dgvHoaDon.DataSource, "TienAlbum", true, DataSourceUpdateMode.Never));
            txtTongTien.DataBindings.Add(new Binding("Text",  dgvHoaDon.DataSource, "TongTien", true, DataSourceUpdateMode.Never));
            txtDatcoc.DataBindings.Add(new Binding("Text",  dgvHoaDon.DataSource, "DatCoc", true, DataSourceUpdateMode.Never));
            txtConlai.DataBindings.Add(new Binding("Text",  dgvHoaDon.DataSource, "ConLai", true, DataSourceUpdateMode.Never));
            txtThanhtoan.DataBindings.Add(new Binding("Text",  dgvHoaDon.DataSource, "ThanhToan", true, DataSourceUpdateMode.Never));
        }


        private void LoadHoaDonList()
        {
          
            HoadonList.DataSource = HoaDonDAO.Instance.GetHoaDonList();
            
        }
        private void updateTienLePhuc(int tienlephuc, int mahd)
        {
            if(HoaDonDAO.Instance.updateTienLePhuc(tienlephuc, mahd)){
                MessageBox.Show("Đã cập nhật Tiền Lễ phục");
                LoadHoaDonList();
            }
        }

        private void updateTienGoiChup(int tiengoichup, int mahd)
        {
            if (HoaDonDAO.Instance.updateTienGoiChup(tiengoichup, mahd))
            {
                MessageBox.Show("Đã cập nhật tiền gói chụp");
                LoadHoaDonList();
            }
        }
       

        private void picLephuc_Click(object sender, EventArgs e)
        {
            var mahd = Convert.ToInt32(txtMaHD.Text);
            HoaDon hoadon = HoaDonDAO.Instance.GetHoadonByMaHD(mahd);
            FORM_CTHD_LEPHUC frm = new FORM_CTHD_LEPHUC(hoadon);
            frm.CTHDLephuc += frm_CTHDLephuc;
            frm.Show();
        }

        void frm_CTHDLephuc(object sender, FORM_CTHD_LEPHUC.CTHDLephucEvent e)
        {
          
            var mahd = Convert.ToInt32(txtMaHD.Text);
            updateTienLePhuc(e.Tongtienlephuc, mahd);
        }




        private void picgoichup_Click(object sender, EventArgs e)
        {
            var mahd = Convert.ToInt32(txtMaHD.Text);
            HoaDon hoadon = HoaDonDAO.Instance.GetHoadonByMaHD(mahd);
            FORM_CTHD_GOICHUP frm = new FORM_CTHD_GOICHUP(hoadon);
            frm.CTHDGoichup += frm_CTHDGoichup;
            frm.Show();
        }

        void frm_CTHDGoichup(object sender, FORM_CTHD_GOICHUP.CTHDGoichucEvent e)
        {
           
            var mahd = Convert.ToInt32(txtMaHD.Text);
            updateTienGoiChup(e.Tongtiengoichup, mahd);
        }


        private void picAlbum_Click(object sender, EventArgs e)
        {

            _albumList = AlbumDAO.Instance.getAlbumListByMaHD(Convert.ToInt32(txtMaHD.Text));
            if (_albumList.Count == 0)
            {
                MessageBox.Show("Chưa cập nhật album");
                return;
            }
            FORM_CTHD_ALBUM frm = new FORM_CTHD_ALBUM(_albumList);
            frm.Show();
        }
       

   

        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                _hoadonlist = HoaDonDAO.Instance.GetHoaDonList();
               var mahd = Convert.ToInt32(_hoadonlist[dgvHoaDon.SelectedRows[0].Index].MaHD);

                if ((HoaDonDAO.Instance.DaInHoaDon(mahd)) == false)
                {
                    btnThanhToan.Enabled = true;
                    picADD.Enabled = true;
                    picUPDATE.Enabled = true;
                    picDelete.Enabled = true;
                }
                else
                {
                    btnThanhToan.Enabled = false;
                    picADD.Enabled = false;
                    picUPDATE.Enabled = false;
                    picDelete.Enabled = false;
                }
               
            }


            catch { }
        }



        private void picADD_Click(object sender, EventArgs e)
        {
            try
            {
                var ngaynhap = DateTime.Now; //dtimeNgayHD.Value;
                var tenkh = txtTenKH.Text;
                var cmnd = txtCMND.Text;
                var sdt = txtSDT.Text;
                var diachi = txtDiaChi.Text;
                //var tongtien = Convert.ToInt32(txtTongTien.Text);
                //var datcoc = Convert.ToInt32(txtDatcoc.Text);
                //var thanhtoan = Convert.ToInt32(txtThanhtoan.Text);
                //var conlai = Convert.ToInt32(txtConlai.Text);


                if (string.IsNullOrEmpty(tenkh) || string.IsNullOrEmpty(cmnd) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diachi))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }

                if (HoaDonDAO.Instance.AddHoaDon(ngaynhap, tenkh, cmnd, sdt, diachi))
                {
                    MessageBox.Show("Thêm hóa đơn thành công");
                    LoadHoaDonList();
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

        private void picUPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                var mahd = Convert.ToInt32(txtMaHD.Text);
                var ngaynhap = dtimeNgayHD.Value;
                var tenkh = txtTenKH.Text;
                var cmnd = txtCMND.Text;
                var sdt = txtSDT.Text;
                var diachi = txtDiaChi.Text;

                if (string.IsNullOrEmpty(tenkh) || string.IsNullOrEmpty(cmnd) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diachi))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }

                if (HoaDonDAO.Instance.UpdateHoadon(mahd, ngaynhap, tenkh, cmnd, sdt, diachi))
                {
                    MessageBox.Show("Sửa hóa đơn thành công");
                    LoadHoaDonList();
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



        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            var thanhtoan = Convert.ToInt32(txtThanhtoan.Text);
            var mahd = Convert.ToInt32(txtMaHD.Text);
            if (HoaDonDAO.Instance.UpdateThanhToan(thanhtoan, mahd))
            {
                LoadHoaDonList();
            }
        }

        private void picInhoadon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                return;
            }
            var mahd = Convert.ToInt32(txtMaHD.Text);
            if (HoaDonDAO.Instance.DaInHoaDon(mahd))
            {
                MessageBox.Show("Hóa đơn đã được in");
                return;
            }
            if (MessageBox.Show("Mọi thông tin sẽ không được thay đổi, bạn có muốn tiếp tục?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                int lephuc = 0;
                if (HoaDonDAO.Instance.UpdateInHD(mahd))
                {
                    if (_cthdlephuclist != null)
                    {
                        for (int i = 0; i < _cthdlephuclist.Count; i++)
                        {

                            if (LePhucDAO.Instance.UpdateTinhtrangSansang(_cthdlephuclist[i].MaLePhuc))
                            {
                                lephuc++;
                            }

                            else
                            {
                                MessageBox.Show("cập nhật tình trạng lễ phục không thành công");
                            }
                        }
                    }
                    MessageBox.Show("In hóa đơn thành công, có "+lephuc+" lễ phục đã được cập nhật lại tình trạng");
                    LoadHoaDonList();
                    btnThanhToan.Enabled = false;
                    picADD.Enabled = false;
                    picUPDATE.Enabled = false;
                    picDelete.Enabled = false;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            dtimeNgayHD.Value = DateTime.Now;
            txtTenKH.Text = "";
            txtCMND.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtTienLephuc.Text = "";
            txtTienGoichup.Text = "";
            txtTienAlbum.Text = "";
            txtTongTien.Text = "";
            txtDatcoc.Text = "";
            txtThanhtoan.Text = "";
            txtConlai.Text = "";
            picADD.Enabled = true;
            picUPDATE.Enabled = true;
            picDelete.Enabled = true;
            btnThanhToan.Enabled = true;
            picInhoadon.Enabled = true;
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaHD.Text))
                {
                    return;
                }
                if (Convert.ToInt32(txtTienAlbum.Text) > 0)
                {
                    MessageBox.Show("Album đã được cập nhập, không thể xóa hóa đơn");
                    return;
                }
                else
                {
                    if (MessageBox.Show("Bạn có muốn xóa hóa đơn này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        var mahd = Convert.ToInt32(txtMaHD.Text);
                        int lephuc = 0;
                        int goichup = 0;
                        if (_cthdlephuclist != null)
                        {
                            for (int i = 0; i < _cthdlephuclist.Count; i++)
                            {
                                if (CTHDLePhucDAO.Instance.deleteCTHDLephuc(_cthdlephuclist[i].MaCTLP))
                                {
                                    if (LePhucDAO.Instance.UpdateTinhtrangSansang(_cthdlephuclist[i].MaLePhuc))
                                    {
                                        lephuc++;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Xóa lễ phục không thành công");
                                }
                            }
                        }

                        if (_cthdGoichupList != null)
                        {
                            for (int i = 0; i < _cthdGoichupList.Count; i++)
                            {
                                if (CTHDGoiChupDAO.Instance.DeleteCTGC(_cthdGoichupList[i].MaCTGC))
                                {
                                    goichup++;
                                }
                                else
                                {
                                    MessageBox.Show("Xóa gói chụp không thành công");
                                }
                            }
                        }
                        //int lephuc= (int)CTHDLePhucDAO.Instance.deleteCTHDLephucByMaHD(mahd);
                        //int goichup = (int)CTHDGoiChupDAO.Instance.deleteCTGoichupByMaHD(mahd);
                        if (HoaDonDAO.Instance.deleteHoaDonByMaHD(mahd))
                        {
                            MessageBox.Show(lephuc + " lễ phục và " + goichup + " gói chụp của hóa đơn " + mahd + " đã được xóa");
                            LoadHoaDonList();

                        }
                        else
                        {
                            MessageBox.Show("Xóa hóa đơn không thành công");
                        }
                    }

                }

            }
            catch { }
        }


        private List<HoaDon> SearcHoaDon(string text)
        {
            List<HoaDon> list = HoaDonDAO.Instance.SearchHoaDon(text);
            return list;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    LoadHoaDonList();
                }
                else
                {
                    HoadonList.DataSource = SearcHoaDon(txtSearch.Text);
                }
            }
            catch { }
        }

        private void btnQuyDinh_Click(object sender, EventArgs e)
        {
            Form frm = new QUYDINH();
            frm.Show();
        }
    }
}
