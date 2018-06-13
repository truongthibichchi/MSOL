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
using MSOL.UTILITIES;
namespace MSOL.FORMS
{
    public partial class FORM_CTHD_LEPHUC : Form
    {

        private LePhuc _lephuchientai;
        private List<CTHDLePhuc> _cthdlephucList;

        private HoaDon _hoadon;

        public HoaDon Hoadon
        {
            get { return _hoadon; }
            set { _hoadon = value; }
        }
        public FORM_CTHD_LEPHUC(HoaDon hoadon)
        {
            InitializeComponent();
            this._hoadon = hoadon;
            if (!(HoaDonDAO.Instance.DaInHoaDon(_hoadon.MaHD)))
            {
                btnDelete.Enabled = true;
                btnChonlp.Enabled = true;
            }
        }

        private void FORM_CTHD_LEPHUC_Load(object sender, EventArgs e)
        {
            txtMaHD.Text = _hoadon.MaHD.ToString();
            AddCTHD_LEPHUCDatagridheader();
            LoadCTHDLephucList(_hoadon.MaHD);
            ChangeSelectedIndexLePhuc();
        }


        private void AddCTHD_LEPHUCDatagridheader()
        {
            dgvCTHD_Lephuc.AutoGenerateColumns = false;
            dgvCTHD_Lephuc.ColumnCount = 4;
            dgvCTHD_Lephuc.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCTHD_Lephuc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCTHD_Lephuc.AutoResizeColumns();

            dgvCTHD_Lephuc.Columns[0].Name = "MaCTLP";
            dgvCTHD_Lephuc.Columns[0].HeaderText = "Mã CTHD";
            dgvCTHD_Lephuc.Columns[0].DataPropertyName = "MaCTLP";
            dgvCTHD_Lephuc.Columns[0].Width = 50;

            dgvCTHD_Lephuc.Columns[1].Name = "MaLePhuc";
            dgvCTHD_Lephuc.Columns[1].HeaderText = "Mã lễ phục";
            dgvCTHD_Lephuc.Columns[1].DataPropertyName = "MaLePhuc";
            dgvCTHD_Lephuc.Columns[1].Width = 50;


            dgvCTHD_Lephuc.Columns[2].Name = "MoTa";
            dgvCTHD_Lephuc.Columns[2].HeaderText = "Mô tả";
            dgvCTHD_Lephuc.Columns[2].DataPropertyName = "MoTa";
            dgvCTHD_Lephuc.Columns[2].Width = 200;

            dgvCTHD_Lephuc.Columns[3].Name = "GiaChoThue";
            dgvCTHD_Lephuc.Columns[3].HeaderText = "Giá cho thuê";
            dgvCTHD_Lephuc.Columns[3].DataPropertyName = "GiaChoThue";
            dgvCTHD_Lephuc.Columns[3].Width = 90;
        }


        private void LoadCTHDLephucList(int mahd)
        {
            RemoveBindingLephucTextbox();
            _cthdlephucList = CTHDLePhucDAO.Instance.GetCTHD_LephucList(mahd);
            if (_cthdlephucList != null)
            {
                dgvCTHD_Lephuc.DataSource = _cthdlephucList;
                AddBindingLephucTextbox();
                var tongtien = 0;
                for (int i = 0; i < dgvCTHD_Lephuc.Rows.Count; i++)
                {
                    var malp = _cthdlephucList[i].MaLePhuc;
                    String mota = LePhucDAO.Instance.getMotaByMaLP(malp);
                    dgvCTHD_Lephuc.Rows[i].Cells["MoTa"].Value = mota;
                    tongtien += (int)dgvCTHD_Lephuc.Rows[i].Cells["GiaChoThue"].Value;
                }

                txtTongtien.Text = tongtien.ToString();
            }

        }
        private void btnChonlp_Click(object sender, EventArgs e)
        {
            CHONLEPHUC frm = new CHONLEPHUC(_hoadon);
            frm.Chonlephuc += frm_Chonlephuc;
            this.Hide();
            frm.ShowDialog();
            this.Show();
            RemoveBindingLephucTextbox();
            LoadLePhuc();
        }

        void frm_Chonlephuc(object sender, CHONLEPHUC.ChonlephucEvent e)
        {
            LoadCTHDLephucList(_hoadon.MaHD);
            ChangeSelectedIndexLePhuc();
            //_lephuchientai = e.Lephuc;
            //btnAdd.Enabled = true;
            //btnDelete.Enabled = false;
        }

        private void RemoveBindingLephucTextbox()
        {
            txtMaLP.DataBindings.Clear();
            txtMota.DataBindings.Clear();
            txtGiachothue.DataBindings.Clear();
            picHinhanh.DataBindings.Clear();
        }

        private void LoadLePhuc()
        {
            if (_lephuchientai != null)
            {
                txtMaLP.DataBindings.Add("Text", _lephuchientai, "MaLePhuc", true, DataSourceUpdateMode.Never);
                picHinhanh.SizeMode = PictureBoxSizeMode.Zoom;
                picHinhanh.DataBindings.Add("Image", _lephuchientai, "HinhAnh", true, DataSourceUpdateMode.Never);
                txtMota.DataBindings.Add("Text", _lephuchientai, "MoTa", true, DataSourceUpdateMode.Never);
                //txtGiachothue.DataBindings.Add("Text", _lephuchientai, "GiaChoThue", true, DataSourceUpdateMode.Never);
                txtGiachothue.Text = _cthdlephucList[dgvCTHD_Lephuc.SelectedRows[0].Index].GiaChoThue.ToString();
            }
        }
        private void AddBindingLephucTextbox()
        {
            txtMaLP.DataBindings.Add("Text", _cthdlephucList, "MaLePhuc", true, DataSourceUpdateMode.Never);
            txtGiachothue.DataBindings.Add("Text", _cthdlephucList, "GiaChoThue", true, DataSourceUpdateMode.Never);

        }





        private void picClose_click(object sender, EventArgs e)
        {
            this.Close();
        }

    
        private void ChangeSelectedIndexLePhuc()
        {
            try
            {
                var malp = _cthdlephucList[dgvCTHD_Lephuc.SelectedRows[0].Index].MaLePhuc;
                _lephuchientai = LePhucDAO.Instance.getLephucByMaLephuc(malp);
                picHinhanh.Image = ControlUtils.convertByteToImage(_lephuchientai.HinhAnh);
                txtMota.Text = _lephuchientai.MoTa.ToString();
                if (!(HoaDonDAO.Instance.DaInHoaDon(_hoadon.MaHD)))
                {
                   // btnAdd.Enabled = false;
                    btnDelete.Enabled = true;
                }

            }
            catch { }
        }


        private event EventHandler<CTHDLephucEvent> _cthdlephuc;
        public event EventHandler<CTHDLephucEvent> CTHDLephuc
        {
            add { _cthdlephuc += value; }
            remove { _cthdlephuc -= value; }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCTHDLephuc();
            this.Close();
        }

        public void SaveCTHDLephuc()
        {
            if (_cthdlephuc != null)
            {
                var tongtien = Convert.ToInt32(txtTongtien.Text);
                _cthdlephuc(this, new CTHDLephucEvent(tongtien));
            }
        }

        public class CTHDLephucEvent : EventArgs
        {
            private int tongtienlephuc;

            public int Tongtienlephuc
            {
                get { return tongtienlephuc; }
                set { tongtienlephuc = value; }
            }

            public CTHDLephucEvent(int tongtien)
            {
                this.tongtienlephuc = tongtien;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var mactlp = _cthdlephucList[dgvCTHD_Lephuc.SelectedRows[0].Index].MaCTLP;
                var malp = _cthdlephucList[dgvCTHD_Lephuc.SelectedRows[0].Index].MaLePhuc;

                if (CTHDLePhucDAO.Instance.deleteCTHDLephuc(mactlp))
                {
                    if (LePhucDAO.Instance.UpdateTinhtrangSansang(malp))
                    {
                        MessageBox.Show("Xóa thành công");
                        LoadCTHDLephucList(_hoadon.MaHD);
                    }
                }
            }
            catch { }
        }

        private void FORM_CTHD_LEPHUC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!HoaDonDAO.Instance.DaInHoaDon(_hoadon.MaHD))
            {
                if (MessageBox.Show("Chọn OK để cập nhật lại hóa đơn", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    SaveCTHDLephuc();
                }
            }
        }

        private void dgvCTHD_Lephuc_SelectionChanged_1(object sender, EventArgs e)
        {
            ChangeSelectedIndexLePhuc();
        }

       

    }
}
