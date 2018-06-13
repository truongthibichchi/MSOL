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

namespace MSOL.FORMS
{
    public partial class CHONLEPHUC : Form
    {
        private List<LePhuc> _lephuclist;
        private List<LoaiLePhuc> _loailplist;
        private LePhuc _lephuchientai;
        private HoaDon _hoadon;

        public HoaDon Hoadon
        {
            get { return _hoadon; }
            set { _hoadon = value; }
        }
        public CHONLEPHUC(HoaDon hoadon)
        {
            InitializeComponent();
            this._hoadon = hoadon;
        }

        private void CHONLEPHUC_Load(object sender, EventArgs e)
        {
            loadcbboxLoaiLephuc();
            loadflpLephucByLoailephucAndTinhtrang(1, 1);
        }

        private void loadcbboxLoaiLephuc()
        {
            // cboxLoaiLP.Items.Clear();
            _loailplist = LoaiLePhucDAO.Instance.GetLoaiLePhucList();
            cboxLoaiLP.DataSource = _loailplist;
            cboxLoaiLP.DisplayMember = "TenLoaiLP";
            cboxLoaiLP.ValueMember = "MaLoaiLP";
        }

        private void loadflpLephucByLoailephucAndTinhtrang(int loailp, int tinhtrang)
        {
            flpLephuc.Controls.Clear();
          
            List<LePhuc> list = LePhucDAO.Instance.getLephucByloaiLephucAndTinhtrang(loailp, tinhtrang);
            _lephuclist = list;
            loadpictureboxInflplephuc();
        }


        PictureBox curPic = null;
        private void loadpictureboxInflplephuc()
        {
           
            if (_lephuclist.Count != 0)
            {
                foreach (LePhuc row in _lephuclist)
                {
                    PictureBox pic = new PictureBox() { Height = 200, Width = 150 };
                    pic.Click += pic_Click;
                    pic.Tag = row;
                    pic.DataBindings.Add("Image", row, "HinhAnh", true, DataSourceUpdateMode.Never);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    pic.Cursor = Cursors.Hand;
                    flpLephuc.Controls.Add(pic);
                }

                _lephuchientai = _lephuclist[0];
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

        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                var malp = Convert.ToInt32(txtMaLP.Text);
                SearchLephuc(malp, 1);
            }
            catch { }
        }

        private void SearchLephuc(int malp, int tinhtrang)
        {
            flpLephuc.Controls.Clear();
            List<LePhuc> list = LePhucDAO.Instance.GetLephuc(malp, tinhtrang);
            _lephuclist = list;
            loadpictureboxInflplephuc();
        }

        private void cboxLoaiLP_SelectedIndexChanged(object sender, EventArgs e)
        {
            flpLephuc.Focus();
            var loailp = (cboxLoaiLP.SelectedItem as LoaiLePhuc).MaLoaiLP;
            loadflpLephucByLoailephucAndTinhtrang(loailp, 1);
        }

        private void picClose_click(object sender, EventArgs e)
        {
            this.Close();
        }


        private event EventHandler<ChonlephucEvent> _chonlephuc;
        public event EventHandler<ChonlephucEvent> Chonlephuc
        {
            add { _chonlephuc += value; }
            remove { _chonlephuc -= value; }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            ChonAnhlephuc();
            
        }

        public void ChonAnhlephuc()
        {
            if (_chonlephuc != null)
            {
                _chonlephuc(this, new ChonlephucEvent(_lephuchientai));
            }
            try
            {
                if (CTHDLePhucDAO.Instance.check(_hoadon.MaHD))
                {
                    MessageBox.Show("Đã vượt quá số lượng lễ phục qui định");
                    return;
                }
                var malp = _lephuchientai.MaLePhuc;
                var giachothue = _lephuchientai.GiaChoThue;
                if (CTHDLePhucDAO.Instance.AddCTHDLephuc(_hoadon.MaHD, malp, giachothue))
                {
                    if (LePhucDAO.Instance.UpdateTinhtrangDaThue(malp))
                    {
                        MessageBox.Show("Thuê lễ phục thành công!");
                        loadflpLephucByLoailephucAndTinhtrang((cboxLoaiLP.SelectedItem as LoaiLePhuc).MaLoaiLP, 1);
                    }
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        } 
        public class ChonlephucEvent : EventArgs
        {
            private LePhuc _lephuc;

            public LePhuc Lephuc
            {
                get { return _lephuc; }
                set { _lephuc = value; }
            }

            public ChonlephucEvent(LePhuc lephuc)
            {
                this.Lephuc = lephuc;
            }
           
        }


    }
}
