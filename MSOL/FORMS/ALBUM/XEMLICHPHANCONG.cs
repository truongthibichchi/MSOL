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
    public partial class XEMLICHPHANCONG : Form
    {
        private List<LichPhanCong> _lichphanconglist;
        public XEMLICHPHANCONG()
        {
            InitializeComponent();
        }

        private void XEMLICHPHANCONG_Load(object sender, EventArgs e)
        {
            AddDatagridHeader();
            LoadList();
        }

        private void AddDatagridHeader()
        {
            dgvLichPhanCong.AutoGenerateColumns = false;
            dgvLichPhanCong.ColumnCount = 8;
            dgvLichPhanCong.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvLichPhanCong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLichPhanCong.AutoResizeColumns();
            dgvLichPhanCong.AutoResizeRows();

            dgvLichPhanCong.Columns[0].Name = "MaNV";
            dgvLichPhanCong.Columns[0].HeaderText = "Mã nhân viên";
            dgvLichPhanCong.Columns[0].DataPropertyName = "MaNV";
            dgvLichPhanCong.Columns[0].Width = 50;

            dgvLichPhanCong.Columns[1].Name = "TenNV";
            dgvLichPhanCong.Columns[1].HeaderText = "Tên nhân viên";
            dgvLichPhanCong.Columns[1].DataPropertyName = "TenNV";
            dgvLichPhanCong.Columns[1].Width = 130;

            dgvLichPhanCong.Columns[2].Name = "MaCTGC";
            dgvLichPhanCong.Columns[2].HeaderText = "Mã CTHD gói chụp";
            dgvLichPhanCong.Columns[2].DataPropertyName = "MaCTGC";
            dgvLichPhanCong.Columns[2].Width = 50;


            dgvLichPhanCong.Columns[3].Name = "TenKH";
            dgvLichPhanCong.Columns[3].HeaderText = "Tên khách hàng";
            dgvLichPhanCong.Columns[3].DataPropertyName = "TenKh";
            dgvLichPhanCong.Columns[3].Width = 130;

            dgvLichPhanCong.Columns[4].Name = "SDT";
            dgvLichPhanCong.Columns[4].HeaderText = "SDT";
            dgvLichPhanCong.Columns[4].DataPropertyName = "SDT";
            dgvLichPhanCong.Columns[4].Width = 70;

            dgvLichPhanCong.Columns[5].Name = "DiaDiem";
            dgvLichPhanCong.Columns[5].HeaderText = "Địa điểm";
            dgvLichPhanCong.Columns[5].DataPropertyName = "DiaDiem";
            dgvLichPhanCong.Columns[5].Width = 150;

            dgvLichPhanCong.Columns[6].Name = "NgayChup";
            dgvLichPhanCong.Columns[6].HeaderText = "Ngày chụp";
            dgvLichPhanCong.Columns[6].DataPropertyName = "NgayChup";
            dgvLichPhanCong.Columns[6].Width = 150;


            dgvLichPhanCong.Columns[7].Name = "GiaTien";
            dgvLichPhanCong.Columns[7].HeaderText = "Giá gói chụp";
            dgvLichPhanCong.Columns[7].DataPropertyName = "GiaTien";
            dgvLichPhanCong.Columns[7].Width = 70;

          

        }

        private void LoadList()
        {
            _lichphanconglist = LichPhanCongDAO.Instance.getlichphanconglist();
            if (_lichphanconglist != null)
            {
                dgvLichPhanCong.DataSource = _lichphanconglist;
                //for (int i = 0; i < dgvLichPhanCong.Rows.Count; i++)
                //{
                //    var ngaychup = _lichphanconglist[i].NgayChup;
                //    if(Convert.ToInt32(ngaychup)
                //}
            }
        }


    }
}
