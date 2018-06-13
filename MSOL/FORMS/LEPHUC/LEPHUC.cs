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
using MSOL.UTILITIES;
using System.IO;

namespace MSOL
{
    public partial class LEPHUC : UserControl
    {
        private List<LePhuc> _lephuclist;
        private List<LoaiLePhuc> _loailplist;
        private LePhuc _lephuchientai;

        private static LEPHUC _instance;
        public static LEPHUC Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LEPHUC();
                return _instance;
            }
        }
        public LEPHUC()
        {
            InitializeComponent();
        }




        private void LEPHUC_Load(object sender, EventArgs e)
        {
            loadcbboxLoaiLephuc();
            loadCbboxTinhtrang();

            var loailp = (cboxLoaiLP.SelectedItem as LoaiLePhuc).MaLoaiLP;
            loadflpLephucByLoailephucAndTinhtrang(1, 1);
            if (_lephuchientai != null)
            {
                loadDetail(_lephuchientai);
            }
        }

        private void loadcbboxLoaiLephuc()
        {
            // cboxLoaiLP.Items.Clear();
            _loailplist = LoaiLePhucDAO.Instance.GetLoaiLePhucList();
            cboxLoaiLP.DataSource = _loailplist;
            cboxLoaiLP.DisplayMember = "TenLoaiLP";
            cboxLoaiLP.ValueMember = "MaLoaiLP";


        }

        private void loadCbboxTinhtrang()
        {

            List<TinhTrangLePhuc> list = TinhTrangLePhucDAO.Instance.gettinhtranglist();
            cboxTinhtrang.DataSource = list;
            cboxTinhtrang.DisplayMember = "TenTinhTrang";
            cboxTinhtrang.ValueMember = "MaTinhTrang";
        }

        //private void loadflpLephucByLoailephuc(int loailp)
        //{

        //    flpLephuc.Controls.Clear();
        //    List<LePhuc> list = LePhucDAO.Instance.getLephucByLoaiLephuc(loailp);
        //    _lephuclist = list;
        //    loadpictureboxInflplephuc();
        //}
        private void loadflpLephucByLoailephucAndTinhtrang(int loailp, int tinhtrang)
        {
            flpLephuc.Controls.Clear();
            List<LePhuc> list = LePhucDAO.Instance.getLephucByloaiLephucAndTinhtrang(loailp, tinhtrang);
            _lephuclist = list;
            loadpictureboxInflplephuc();
        }

        private void removeBindingLephuctextbox()
        {
            txtMaLP.DataBindings.Clear();
            picHinhanh.DataBindings.Clear();
            txtMota.DataBindings.Clear();
            txtGiachothue.DataBindings.Clear();
            txtGianhap.DataBindings.Clear();
        }

        PictureBox curPic = null;
        private void loadpictureboxInflplephuc()
        {
            removeBindingLephuctextbox();
            if (_lephuclist.Count != 0)
            {
                foreach (LePhuc row in _lephuclist)
                {
                    PictureBox pic = new PictureBox() { Height = 130, Width = 100 };
                    pic.Click += pic_Click;
                    pic.Tag = row;
                    pic.DataBindings.Add("Image", row, "HinhAnh", true, DataSourceUpdateMode.Never);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    pic.Cursor = Cursors.Hand;
                    flpLephuc.Controls.Add(pic);
                }

                _lephuchientai = _lephuclist[0];
                loadDetail(_lephuchientai);
            }


        }
        void pic_Click(object sender, EventArgs e)
        {
            if (curPic != null)
            {
                //đổi hiệu ứng chọn lại bình thường
                curPic.BackColor = Color.Transparent;
            }

            PictureBox choosingPic = (PictureBox)sender;
            //đổi hiệu ứng pic đang chọn
            choosingPic.BackColor = Color.Aqua;


            curPic = choosingPic;

            _lephuchientai = (LePhuc)((PictureBox)sender).Tag;
            loadDetail(_lephuchientai);

        }

        private void loadDetail(LePhuc lephuc)
        {
            txtMaLP.Text = _lephuchientai.MaLePhuc.ToString();
            dtimeNgaynhap.Text = _lephuchientai.NgayNhap.ToString();
            txtMota.Text = _lephuchientai.MoTa;
            txtGianhap.Text = _lephuchientai.GiaNhap.ToString();
            txtGiachothue.Text = _lephuchientai.GiaChoThue.ToString();
            txtTinhTrang.Text = (string)TinhTrangLePhucDAO.Instance.GetTentihtrangByMatinhtrang((int)_lephuchientai.TinhTrang);
            cboxTinhtrang.Text = (string)TinhTrangLePhucDAO.Instance.GetTentihtrangByMatinhtrang((int)_lephuchientai.TinhTrang);
            picHinhanh.Image = ControlUtils.convertByteToImage(_lephuchientai.HinhAnh);
            picHinhanh.SizeMode = PictureBoxSizeMode.Zoom;

        }


        private void btn_XEMHOADON_click(object sender, EventArgs e)
        {
            Form frm = new XEMHOADONLEPHUC(_lephuchientai);
            //this.Hide();
            frm.Show();
            //this.Show();
        }

        private void picHinhanh_Click(object sender, EventArgs e)
        {
            ofLePhuc.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            ofLePhuc.FilterIndex = 1;
            ofLePhuc.RestoreDirectory = true;
            if (ofLePhuc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image hinhanhmoi = Image.FromFile(ofLePhuc.FileName);
                picHinhanh.Image = hinhanhmoi;
                picHinhanh.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        //private void cbLoaiLePhucIndexchanged(object sender, EventArgs e)
        //{
        //    flpLephuc.Focus();
        //    var loailp = (cboxLoaiLP.SelectedItem as LoaiLePhuc).MaLoaiLP;
        //    var tinhtrang = (cboxTinhtrang.SelectedItem as TinhTrangLePhuc).MaTinhTrang;
        //    loadflpLephucByLoailephucAndTinhtrang(loailp, tinhtrang);
        //}


        private void flpLephuc_MouseHover(object sender, EventArgs e)
        {
            flpLephuc.Focus();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            flpLephuc.Focus();
            var loailp = (cboxLoaiLP.SelectedItem as LoaiLePhuc).MaLoaiLP;
            var tinhtrang = (cboxTinhtrang.SelectedItem as TinhTrangLePhuc).MaTinhTrang;
            loadflpLephucByLoailephucAndTinhtrang(loailp, tinhtrang);
        }

 

        private void picADD_Click(object sender, EventArgs e)
        {

            try
            {
                var ngaynhap = dtimeNgaynhap.Value;
                var mota = txtMota.Text;
                var gianhap = Convert.ToInt32(txtGianhap.Text);
                var giachothue = Convert.ToInt32(txtGiachothue.Text);
                var loai = Convert.ToInt32((cboxLoaiLP.SelectedItem as LoaiLePhuc).MaLoaiLP);
                //var tinhtrang = Convert.ToInt32((cboxTinhtrang.SelectedItem as TinhTrangLePhuc).MaTinhTrang);
                byte[] hinhanh = ControlUtils.convertImageToByte(picHinhanh.Image);

                if (string.IsNullOrEmpty(mota))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }

                if (giachothue < 0 || gianhap < 0)
                {
                    MessageBox.Show("Sai giá ");
                }
                if (LePhucDAO.Instance.AddLephuc(ngaynhap, mota, gianhap, giachothue, loai, hinhanh))
                {
                    MessageBox.Show("Thêm lễ phục thành công");
                    loadflpLephucByLoailephucAndTinhtrang(loai, 1);
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

        private void picUPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                var malp = Convert.ToInt32(txtMaLP.Text);
                var ngaynhap = dtimeNgaynhap.Value;
                var mota = txtMota.Text;
                var gianhap = Convert.ToInt32(txtGianhap.Text);
                var giachothue = Convert.ToInt32(txtGiachothue.Text);
                var loai = Convert.ToInt32((cboxLoaiLP.SelectedItem as LoaiLePhuc).MaLoaiLP);
                var tinhtrang = Convert.ToInt32((cboxTinhtrang.SelectedItem as TinhTrangLePhuc).MaTinhTrang);
                byte[] hinhanh = ControlUtils.convertImageToByte(picHinhanh.Image);

                if (string.IsNullOrEmpty(mota))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }

                if (giachothue < 0 || gianhap < 0)
                {
                    MessageBox.Show("Sai giá ");
                }
                if (LePhucDAO.Instance.UpdateLephuc(malp, ngaynhap, mota, gianhap, giachothue, loai, hinhanh))
                {
                    MessageBox.Show("Sửa lễ phục thành công");
                    loadflpLephucByLoailephucAndTinhtrang(loai, tinhtrang);
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
                var malp = Convert.ToInt32(txtMaLP.Text);
                var loailp = (cboxLoaiLP.SelectedItem as LoaiLePhuc).MaLoaiLP;
                if (MessageBox.Show("Bạn có muốn xóa lễ phục?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if (LePhucDAO.Instance.DeleteLephuc(malp))
                    {
                        MessageBox.Show("Lễ phục không còn được sử dụng");
                        loadflpLephucByLoailephucAndTinhtrang(loailp, 3);

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
