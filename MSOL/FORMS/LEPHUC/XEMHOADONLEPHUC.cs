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
    public partial class XEMHOADONLEPHUC : Form
    {
        private List<LePhuc> _lephucList;
        private List<CTHDLePhuc> _cthdlephucList;

        private LePhuc _lephuc;

        public LePhuc Lephuc
        {
            get { return _lephuc; }
            set { _lephuc = value; }
        }
        public XEMHOADONLEPHUC(LePhuc lephuc)
        {
            InitializeComponent();
            this._lephuc = lephuc;
        }

        private void XEMHOADONLEPHUC_Load(object sender, EventArgs e)
        {
            LoadcbbMalp();
            LoadCTHDLephucList(_lephuc.MaLePhuc);
            ChangeSelectedIndexMaLP();
        }

        private void LoadcbbMalp()
        {
            cbbMalp.DisplayMember = "MaLePhuc";
            _lephucList = LePhucDAO.Instance.LoadLephucList();
            cbbMalp.DataSource = _lephucList;
            var malp = _lephuc.MaLePhuc;
            var index = _lephucList.FindIndex(p => p.MaLePhuc == malp);
            cbbMalp.SelectedIndex = index;
        }

        //private void AddCTHD_LEPHUCDatagridheader()
        //{
        //    dgvCTHD_Lephuc.AutoGenerateColumns = false;
        //    dgvCTHD_Lephuc.ColumnCount = 4;
        //    dgvCTHD_Lephuc.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        //    dgvCTHD_Lephuc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dgvCTHD_Lephuc.AutoResizeColumns();

        //    dgvCTHD_Lephuc.Columns[0].Name = "MaLePhuc";
        //    dgvCTHD_Lephuc.Columns[0].HeaderText = "Mã lễ phục";
        //    dgvCTHD_Lephuc.Columns[0].DataPropertyName = "MaLePhuc";
        //    dgvCTHD_Lephuc.Columns[0].Width = 120;

        //    dgvCTHD_Lephuc.Columns[1].Name = "MaCTLP";
        //    dgvCTHD_Lephuc.Columns[1].HeaderText = "Mã CTHD";
        //    dgvCTHD_Lephuc.Columns[1].DataPropertyName = "MaCTLP";
        //    dgvCTHD_Lephuc.Columns[1].Width = 120;

        //    dgvCTHD_Lephuc.Columns[2].Name = "MaHD";
        //    dgvCTHD_Lephuc.Columns[2].HeaderText = "Mã hóa đơn";
        //    dgvCTHD_Lephuc.Columns[2].DataPropertyName = "MaHD";
        //    dgvCTHD_Lephuc.Columns[2].Width = 100;


        //    dgvCTHD_Lephuc.Columns[3].Name = "GiaChoThue";
        //    dgvCTHD_Lephuc.Columns[3].HeaderText = "Giá cho thuê";
        //    dgvCTHD_Lephuc.Columns[3].DataPropertyName = "GiaChoThue";
        //    dgvCTHD_Lephuc.Columns[3].Width = 120;
        //}

        private void LoadCTHDLephucList(int malp)
        {
            cbbMalp.DataBindings.Clear();
            _cthdlephucList = CTHDLePhucDAO.Instance.LoadCTHDLePhucListByMalp(malp);
            if (_cthdlephucList != null)
            {
                dgvCTHD_Lephuc.DataSource = _cthdlephucList;
            }
            txtSoLuotThue.Text = _cthdlephucList.Count.ToString();

        }

        private void dgvCTHD_Lephuc_SelectionChanged(object sender, EventArgs e)
        {
            ChangeSelectedIndexMaLP();
        }

        private void ChangeSelectedIndexMaLP()
        {
            try
            {

                var malp = _cthdlephucList[dgvCTHD_Lephuc.SelectedRows[0].Index].MaLePhuc;
                var index = _lephucList.FindIndex(p => p.MaLePhuc == malp);
                cbbMalp.SelectedIndex = index;
            }
            catch { }
        }

        private void cbbMalp_SelectedIndexChanged(object sender, EventArgs e)
        {
            var malp = Convert.ToInt32((cbbMalp.SelectedItem as LePhuc).MaLePhuc);
            LoadCTHDLephucList(malp);
        }

    }
}
