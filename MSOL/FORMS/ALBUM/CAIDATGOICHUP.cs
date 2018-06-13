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
using System.IO;

namespace MSOL
{
    public partial class CAIDATGOICHUP : Form
    {
        public CAIDATGOICHUP()
        {
            InitializeComponent();
        }
        private List<GoiChup> _GoichupList;
        private List<LoaiGoiChup> _LoaigoichupList;
        private void CAIDATGOICHUP_Load(object sender, EventArgs e)
        {
            loadcbboxLoai();
            addGoiChupDataGridHeader();
            LoadGoichupList();
            ChangeSelectedIndexLoaiGC();
        }
        private void loadcbboxLoai()
        {
            cbboxLoaiGC.DisplayMember = "TenLoaiGC";
            cbboxLoaiGC.ValueMember = "MaLoaiGC";
            _LoaigoichupList = LoaiGoiChupDAO.Instance.getTenloaiGCList();
            cbboxLoaiGC.DataSource = _LoaigoichupList;

        }



        private void addGoiChupDataGridHeader()
        {
            dgvGoichup.AutoGenerateColumns = false;
            dgvGoichup.ColumnCount = 5;
            dgvGoichup.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvGoichup.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGoichup.AutoResizeColumns();

            dgvGoichup.Columns[0].Name = "MaGoiChup";
            dgvGoichup.Columns[0].HeaderText = "Mã gói chụp";
            dgvGoichup.Columns[0].DataPropertyName = "MaGoiChup";
            dgvGoichup.Columns[0].Width = 100;

            dgvGoichup.Columns[1].Name = "TenLoaiGC";
            dgvGoichup.Columns[1].HeaderText = "Loại gói chụp";
            dgvGoichup.Columns[1].DataPropertyName = "TenLoaiGC";
            dgvGoichup.Columns[1].Width = 70;

            dgvGoichup.Columns[2].Name = "DiaDiem";
            dgvGoichup.Columns[2].HeaderText = "Địa điểm";
            dgvGoichup.Columns[2].DataPropertyName = "DiaDiem";
            dgvGoichup.Columns[2].Width = 100;

            dgvGoichup.Columns[3].Name = "GiaTien";
            dgvGoichup.Columns[3].HeaderText = "GiaTien";
            dgvGoichup.Columns[3].DataPropertyName = "GiaTien";
            dgvGoichup.Columns[3].Width = 120;

            dgvGoichup.Columns[4].Name = "TinhTrang";
            dgvGoichup.Columns[4].HeaderText = "Tình trạng";
            dgvGoichup.Columns[4].DataPropertyName = "TinhTrang";
            dgvGoichup.Columns[4].Width = 120;

        }

        
        private void LoadGoichupList()
        {
            RemoveBindingGoiChupTextbox();
            _GoichupList = GoiChupDAO.Instance.GetGoichupList();
            dgvGoichup.DataSource = _GoichupList;
            
            
            for (int i = 0; i < dgvGoichup.Rows.Count; i++)
            {
                var maloaigc = _GoichupList[i].Loai;
                dgvGoichup.Rows[i].Cells["TenLoaiGC"].Value = GoiChupDAO.Instance.GetTenloaigoichupByMaloaigoichup(maloaigc);
            }
            AddBinddingGoichupTextbox();
        }
        private void RemoveBindingGoiChupTextbox()
        {
            txtMagoichup.DataBindings.Clear();
            txtDiadiem.DataBindings.Clear();
            cbboxLoaiGC.DataBindings.Clear();
            txtGiatien.DataBindings.Clear();
         
        }

        private void AddBinddingGoichupTextbox()
        {
            txtMagoichup.DataBindings.Add("Text", _GoichupList, "MaGoiChup", true, DataSourceUpdateMode.Never);
            txtGiatien.DataBindings.Add("Text", _GoichupList, "GiaTien", true, DataSourceUpdateMode.Never);
            txtDiadiem.DataBindings.Add("Text", _GoichupList, "DiaDiem", true, DataSourceUpdateMode.Never);
          
        }

      
        private void ChangeSelectedIndexLoaiGC()
        {
            try
            {
               
                var maloaigc = _GoichupList[dgvGoichup.SelectedRows[0].Index].Loai;
                var index = _LoaigoichupList.FindIndex(p => p.MaLoaiGC == maloaigc);
                cbboxLoaiGC.SelectedIndex = index;
            }
            catch { }
        }

        private void dgvGoichup_SelectionChanged(object sender, EventArgs e)
        {
            ChangeSelectedIndexLoaiGC();
        }

       
        private void picADD_Click(object sender, EventArgs e)
        {
            try
            {
                var loai = Convert.ToInt32((cbboxLoaiGC.SelectedItem as LoaiGoiChup).MaLoaiGC);
                var diadiem = txtDiadiem.Text;
                var giatien = Convert.ToInt32(txtGiatien.Text);
               

                if (string.IsNullOrEmpty(txtDiadiem.Text))
                {
                    MessageBox.Show("Chưa nhập địa điểm");
                    return;
                }

                if (giatien < 0)
                {
                    MessageBox.Show("Nhập giá tiền");
                    return;
                }
                if (GoiChupDAO.Instance.checkDuplicateGoichup(diadiem, giatien))
                {
                    MessageBox.Show("Gói chụp đã tồn tại, vui lòng thay đổi địa điểm hoặc giá tiền");
                    return;
                }
                if (GoiChupDAO.Instance.AddGoichup(loai, diadiem, giatien))
                {
                    MessageBox.Show("Thêm gói chụp thành công");
                    LoadGoichupList();
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
                var magoichup = Convert.ToInt32(txtMagoichup.Text);
                var loai = Convert.ToInt32((cbboxLoaiGC.SelectedItem as LoaiGoiChup).MaLoaiGC);
                var diadiem = txtDiadiem.Text;
                var giatien = Convert.ToInt32(txtGiatien.Text);
              

                if (string.IsNullOrEmpty(txtDiadiem.Text))
                {
                    MessageBox.Show("Chưa nhập địa điểm");
                    return;
                }

                if (giatien < 0)
                {
                    MessageBox.Show("Nhập giá tiền");
                    return;
                }
               
                if (GoiChupDAO.Instance.UpdateGoichup(magoichup, loai, diadiem, giatien))
                {
                    MessageBox.Show("Sửa gói chụp thành công");
                    LoadGoichupList();
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

        private void picDELETE_Click(object sender, EventArgs e)
        {
            try
            {
                var magoichup = Convert.ToInt32(txtMagoichup.Text);
                if (GoiChupDAO.Instance.DeleteGoichup(magoichup))
                {
                    MessageBox.Show("Xóa gói chụp thành công");
                    LoadGoichupList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
