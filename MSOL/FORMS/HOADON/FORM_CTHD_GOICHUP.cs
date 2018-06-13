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
using MSOL.FORMS;

namespace MSOL.FORMS
{
    public partial class FORM_CTHD_GOICHUP : Form
    {
        //private List<LoaiGoiChup> _LoaigoichupList;
        private List<GoiChup> _GoichupList;
       // private GoiChup goichup;
        private List<NhanVien> _nhanvienList;
        private List<CTHDGoiChup> _cthdgoichupList;
        private HoaDon _hoadon;

        public HoaDon Hoadon
        {
            get { return _hoadon; }
            set { _hoadon = value; }
        }
        public FORM_CTHD_GOICHUP(HoaDon hoadon)
        {
            InitializeComponent();
            this._hoadon = hoadon;
            if (HoaDonDAO.Instance.DaInHoaDon(_hoadon.MaHD))
            {
                picDelete.Enabled = false;
                picUPDATE.Enabled = false;
            }
        }

        private void FORM_CTHD_GOICHUP_Load(object sender, EventArgs e)
        {
            txtMaHD.Text = _hoadon.MaHD.ToString();
            LoadcbbNhanvien("Thợ chụp ảnh");
            AddCTGoiChupDataGirdHeader();

            LoadCTHDGoiChupList(_hoadon.MaHD);
            
        }

        private void LoadcbbNhanvien(string chucvu)
        {
            cbbMaNV.DisplayMember = "MaNV";
            _nhanvienList = NhanVienDAO.Instance.GetNhanvienByChucvu(chucvu);
            cbbMaNV.DataSource = _nhanvienList;
        }

        private void AddCTGoiChupDataGirdHeader()
        {
            dgvCTHDGoichup.AutoGenerateColumns = false;
            dgvCTHDGoichup.ColumnCount = 4;
            dgvCTHDGoichup.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCTHDGoichup.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCTHDGoichup.AutoResizeColumns();

            dgvCTHDGoichup.Columns[0].Name = "MaCTGC";
            dgvCTHDGoichup.Columns[0].HeaderText = "Mã CTGC";
            dgvCTHDGoichup.Columns[0].DataPropertyName = "MaCTGC";
            dgvCTHDGoichup.Columns[0].Width = 50;

            dgvCTHDGoichup.Columns[1].Name = "MaGoiChup";
            dgvCTHDGoichup.Columns[1].HeaderText = "Mã gói chụp";
            dgvCTHDGoichup.Columns[1].DataPropertyName = "MaGoiChup";
            dgvCTHDGoichup.Columns[1].Width = 50;

            dgvCTHDGoichup.Columns[2].Name = "DiaDiem";
            dgvCTHDGoichup.Columns[2].HeaderText = "Địa điểm";
            dgvCTHDGoichup.Columns[2].DataPropertyName = "DiaDiem";
            dgvCTHDGoichup.Columns[2].Width = 250;


            dgvCTHDGoichup.Columns[3].Name = "GiaTien";
            dgvCTHDGoichup.Columns[3].HeaderText = "Giá tiền";
            dgvCTHDGoichup.Columns[3].DataPropertyName = "GiaTien";
            dgvCTHDGoichup.Columns[3].Width = 200;

        }

        private void RemoveBindingTextbox()
        {
            dtimeNgaychup.DataBindings.Clear();
            txtMaHD.DataBindings.Clear();
            txtTenNV.DataBindings.Clear();
            txtSDT.DataBindings.Clear();

        }

       private void AddBindingTextbox()
       {
           txtTenNV.DataBindings.Add("Text", _nhanvienList, "TenNV", true, DataSourceUpdateMode.Never);
           txtSDT.DataBindings.Add("Text", _nhanvienList, "SDT", true, DataSourceUpdateMode.Never); 
           dtimeNgaychup.DataBindings.Add("Value", _cthdgoichupList, "NgayChup", true, DataSourceUpdateMode.Never);
       }


       private void LoadCTHDGoiChupList(int mahd)
       {
           RemoveBindingTextbox();
           _cthdgoichupList = CTHDGoiChupDAO.Instance.GetCTHDGoiChupListByMaHD(mahd);
           if (_cthdgoichupList != null)
           {
               dgvCTHDGoichup.DataSource = _cthdgoichupList;
               AddBindingTextbox();
               var tongtien = 0;
               for (int i = 0; i < dgvCTHDGoichup.Rows.Count; i++)
               {

                   var magoichup = _cthdgoichupList[i].MaGoiChup;
                   dgvCTHDGoichup.Rows[i].Cells["DiaDiem"].Value = GoiChupDAO.Instance.GetgoichupByMagc(magoichup).DiaDiem;       
                   tongtien += (int)dgvCTHDGoichup.Rows[i].Cells["GiaTien"].Value;
               }
               txtTongtien.Text = tongtien.ToString();
           }
       }

     
       private void dgvCTHDGC_SelectionChanged(object sender, EventArgs e)
       {
           RemoveBindingTextbox();   
           ChangeSelectedIndexMaNV();
       }

       private void ChangeSelectedIndexMaNV()
       {
           try
           {
               var manv = _cthdgoichupList[dgvCTHDGoichup.SelectedRows[0].Index].MaNV;
               var index = _nhanvienList.FindIndex(p => p.MaNV == manv);

               cbbMaNV.SelectedIndex = index;
           }
           catch { }
       }

       private void btnChoose_Click(object sender, EventArgs e)
       {
           CHONGOICHUP frm = new CHONGOICHUP();
           frm.Chongoichup += frm_Chongoichup;
           this.Hide();
           frm.ShowDialog();
           this.Show();
          
       }

       void frm_Chongoichup(object sender, CHONGOICHUP.ChonGoiChupEvent e)
       {
           _GoichupList = e.Goichuplist;
           try
           {
               int check = (int)CTHDGoiChupDAO.Instance.check();
               if (_cthdgoichupList != null) // đã chọn gói chụp
               {

                   if ((_cthdgoichupList.Count + _GoichupList.Count) > check)
                   {
                       MessageBox.Show("Chỉ được chọn tối đa " + check + " gói chụp");
                       return;
                   }
                   else AddCTHDGoichup();
               }
               else if (_cthdgoichupList == null)
               {
                   if (_GoichupList.Count > check)
                   {
                       MessageBox.Show("Chỉ được chọn tối đa " + check + " gói chụp");
                       return;
                   }
                   else AddCTHDGoichup();

               }


           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
          
           

       }

       private void AddCTHDGoichup()
       {
           try
           {

               var mahd = _hoadon.MaHD;
               var manv = Convert.ToInt32((cbbMaNV.SelectedItem as NhanVien).MaNV);
               var ngaychup = dtimeNgaychup.Value;
               for (int i = 0; i < _GoichupList.Count; i++)
               {
                   var magoichup = _GoichupList[i].MaGoiChup;
                   var giatien = _GoichupList[i].GiaTien;
                   if (CTHDGoiChupDAO.Instance.InsertCTHDGoichup(mahd, magoichup, giatien, manv, ngaychup))
                   {
                       LoadCTHDGoiChupList(_hoadon.MaHD);
                   }

               }
               MessageBox.Show("Đã đăng kí " + _GoichupList.Count + " gói chụp thành công");
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }

       private void btnCheck_Click(object sender, EventArgs e)
       {
           var NgayChup = dtimeNgaychup.Value;
           var MaNV = Convert.ToInt32((cbbMaNV.SelectedItem as NhanVien).MaNV);

           if (CTHDGoiChupDAO.Instance.checkDuplicateNhanVien(MaNV, NgayChup))
           {

               picAvailable.Visible = false;
               picNotAvaib.Visible = true;
               btnChoose.Enabled = false;
           }

           else
           {
               if (HoaDonDAO.Instance.DaInHoaDon(_hoadon.MaHD))
               {
                   btnChoose.Enabled = false;
                   return;
               }
               else
               {
                   picNotAvaib.Visible = false;
                   picAvailable.Visible = true;
                   btnChoose.Enabled = true;
               }
           }
       }

       private void FORM_CTHD_GOICHUP_FormClosed(object sender, FormClosedEventArgs e)
       {
           this.Close();
           SaveCTHDGoichup();
       }


       private event EventHandler<CTHDGoichucEvent> _cthdGoichup;
       public event EventHandler<CTHDGoichucEvent> CTHDGoichup
       {
           add { _cthdGoichup += value; }
           remove { _cthdGoichup -= value; }
       }

       public void SaveCTHDGoichup()
       {
           if (_cthdGoichup != null)
           {
               var tongtien = Convert.ToInt32(txtTongtien.Text);
               _cthdGoichup(this, new CTHDGoichucEvent(tongtien));
           }
       }


       public class CTHDGoichucEvent : EventArgs
       {
           private int tongtiengoichup;

           public int Tongtiengoichup
           {
               get { return tongtiengoichup; }
               set { tongtiengoichup = value; }
           }

           public CTHDGoichucEvent(int tongtien)
           {
               this.tongtiengoichup = tongtien;
           }
       }

       private void picDelete_Click(object sender, EventArgs e)
       {
           try
           {
               var mactgc = _cthdgoichupList[dgvCTHDGoichup.SelectedRows[0].Index].MaCTGC;
               if (AlbumDAO.Instance.checkDuplicateAlbum(mactgc))
               {
                   MessageBox.Show("Gói chụp đã cập nhật album, không thể xóa");
                   return;
               }
               if (CTHDGoiChupDAO.Instance.DeleteCTGC(mactgc))
               {
                   MessageBox.Show("Xóa thành công");
                   LoadCTHDGoiChupList(_hoadon.MaHD);
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
               var mactgoichup = _cthdgoichupList[dgvCTHDGoichup.SelectedRows[0].Index].MaCTGC;

               var manv = Convert.ToInt32((cbbMaNV.SelectedItem as NhanVien).MaNV);
               var ngaychup = dtimeNgaychup.Value;

               if (CTHDGoiChupDAO.Instance.UpdateCTHDGoiChup(mactgoichup, manv, ngaychup))
               {
                   MessageBox.Show("Sửa thành công");
                   LoadCTHDGoiChupList(_hoadon.MaHD);
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

       private void FORM_CTHD_GOICHUP_FormClosing(object sender, FormClosingEventArgs e)
       {
           if (!HoaDonDAO.Instance.DaInHoaDon(_hoadon.MaHD))
           {
               if (MessageBox.Show("Chọn OK để cập nhật hóa đơn!", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
               {
                   SaveCTHDGoichup();
               }
           }
       }

    }
}
