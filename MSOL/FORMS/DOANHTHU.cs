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
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace MSOL
{
    public partial class DOANHTHU : UserControl
    {
        private List<HoaDon> list;
        private static DOANHTHU _instance;
        public static DOANHTHU Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DOANHTHU();
                return _instance;
            }
        }
        public DOANHTHU()
        {
            InitializeComponent();
        }

        private void DOANHTHU_Load(object sender, EventArgs e)
        {
            addHoaDonDatagridHeader();
        }
        private void addHoaDonDatagridHeader()
        {
            dgvDoanhThu.AutoGenerateColumns = false;
            dgvDoanhThu.ColumnCount = 9;


            dgvDoanhThu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvDoanhThu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDoanhThu.AutoResizeColumns();

            dgvDoanhThu.Columns[0].Name = "MaHD";
            dgvDoanhThu.Columns[0].HeaderText = "Mã hóa đơn";
            dgvDoanhThu.Columns[0].DataPropertyName = "MaHD";
            dgvDoanhThu.Columns[0].Width = 50;


            dgvDoanhThu.Columns[1].Name = "NgayHD";
            dgvDoanhThu.Columns[1].HeaderText = "Ngày hóa đơn ";
            dgvDoanhThu.Columns[1].DataPropertyName = "NgayHD";
            dgvDoanhThu.Columns[1].Width = 150;

            dgvDoanhThu.Columns[2].Name = "TenKH";
            dgvDoanhThu.Columns[2].HeaderText = "Tên khách hàng";
            dgvDoanhThu.Columns[2].DataPropertyName = "TenKH";
            dgvDoanhThu.Columns[2].Width = 150;

            dgvDoanhThu.Columns[3].Name = "TienLePhuc";
            dgvDoanhThu.Columns[3].HeaderText = "Tổng tiền lễ phục";
            dgvDoanhThu.Columns[3].DataPropertyName = "TienLePhuc";
            dgvDoanhThu.Columns[3].Width = 100;

            dgvDoanhThu.Columns[4].Name = "TienGoiChup";
            dgvDoanhThu.Columns[4].HeaderText = "Tổng tiền gói chụp";
            dgvDoanhThu.Columns[4].DataPropertyName = "TienGoiChup";
            dgvDoanhThu.Columns[4].Width = 100;

            dgvDoanhThu.Columns[5].Name = "TienAlbum";
            dgvDoanhThu.Columns[5].HeaderText = "Tổng tiền Album";
            dgvDoanhThu.Columns[5].DataPropertyName = "TienAlbum";
            dgvDoanhThu.Columns[5].Width = 100;

            dgvDoanhThu.Columns[6].Name = "TongTien";
            dgvDoanhThu.Columns[6].HeaderText = "Tổng trị giá";
            dgvDoanhThu.Columns[6].DataPropertyName = "TongTien";
            dgvDoanhThu.Columns[6].Width = 100;


            dgvDoanhThu.Columns[7].Name = "ThanhToan";
            dgvDoanhThu.Columns[7].HeaderText = "Thanh toán";
            dgvDoanhThu.Columns[7].DataPropertyName = "ThanhToan";
            dgvDoanhThu.Columns[7].Width = 100;


            dgvDoanhThu.Columns[8].Name = "ConLai";
            dgvDoanhThu.Columns[8].HeaderText = "Còn lại";
            dgvDoanhThu.Columns[8].DataPropertyName = "ConLai";
            dgvDoanhThu.Columns[8].Width = 100;

        }



        private void btnThongke_Click(object sender, EventArgs e)
        {
           
            try
            {
                var tongdoanhthu=0;
                var batdau = dtimeBatDau.Value;
                var ketthuc = dtimeKetThuc.Value;
                list = HoaDonDAO.Instance.ThongKeDoanhThu(batdau, ketthuc);
                dgvDoanhThu.DataSource = list;
                for(int i=0; i<list.Count; i++){
                    tongdoanhthu += list[i].TongTien;
                }
                txtTongDoanhThu.Text = tongdoanhthu.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void picInDoanThu_Click(object sender, EventArgs e)
        {
            try
            {
                
                Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!");
                    return;
                }
                Excel.Workbook xlWorkBook;

                Excel.Worksheet xlWorkSheet;

                object misValue = System.Reflection.Missing.Value;

                xlWorkBook = xlApp.Workbooks.Add(misValue);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                xlWorkSheet.Cells[1, 4] = " THỐNG KÊ DOANH THU ";

                xlWorkSheet.Cells[2, 1] = "Mã hóa đơn ";

                xlWorkSheet.Cells[2, 2] = "Ngày hóa đơn";

                xlWorkSheet.Cells[2, 3] = "Tên khách hàng";

                xlWorkSheet.Cells[2, 4] = "Tiền lễ phục";

                xlWorkSheet.Cells[2, 5] = "Tiền gói chụp ";

                xlWorkSheet.Cells[2, 6] = "Tiền Album";

                xlWorkSheet.Cells[2, 7] = "Tổng trị giá";

                xlWorkSheet.Cells[2, 8] = "Đã thanh toán";

                xlWorkSheet.Cells[2, 9] = "Còn lại";

                xlWorkSheet.Cells[2, 10] = "In hóa đơn";

                for (int i = 9;  (i-9) <list.Count(); i++)
                {
                    xlWorkSheet.Cells[i, 1] = list[i - 9].MaHD;
                    xlWorkSheet.Cells[i, 2] = list[i - 9].NgayHD;
                    xlWorkSheet.Cells[i, 3] = list[i - 9].TenKH;
                    xlWorkSheet.Cells[i, 4] = list[i - 9].TienLePhuc;
                    xlWorkSheet.Cells[i, 5] = list[i - 9].TienGoiChup;
                    xlWorkSheet.Cells[i, 6] = list[i - 9].TienAlbum;
                    xlWorkSheet.Cells[i, 7] = list[i - 9].TongTien;
                    xlWorkSheet.Cells[i, 8] = list[i - 9].ThanhToan;
                    xlWorkSheet.Cells[i, 9] = list[i - 9].ConLai;
                    xlWorkSheet.Cells[i, 10]= list[i - 9].InHD;

                }
                var tongdoanhthu = 0;
                if (!string.IsNullOrEmpty(txtTongDoanhThu.Text))
                {
                    tongdoanhthu = Convert.ToInt32(txtTongDoanhThu.Text);
                }
                xlWorkSheet.Cells[list.Count()+10, 10] = "Tổng doanh thu";
                xlWorkSheet.Cells[list.Count()+10, 11] = tongdoanhthu;
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = " (.xls)|*.xls";

                if (dlg.ShowDialog() ==
                    System.Windows.Forms.DialogResult.OK)
                {
                    string ext = dlg.FileName.ToString();
                    xlApp.DisplayAlerts = false;
                    xlWorkBook.SaveAs(ext,
                        Excel.XlFileFormat.xlWorkbookNormal,
                        misValue, misValue, misValue, misValue,
                        Excel.XlSaveAsAccessMode.xlExclusive,
                        misValue, misValue, misValue, misValue, misValue);

                }
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);

                Marshal.ReleaseComObject(xlWorkBook);

                Marshal.ReleaseComObject(xlApp);

                foreach (System.Diagnostics.Process ClsProcess in System.Diagnostics.Process.GetProcesses())
                {
                    if (ClsProcess.ProcessName.Equals("EXCEL"))
                        ClsProcess.Kill();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
