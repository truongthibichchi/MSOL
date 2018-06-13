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
    public partial class MANHINHCHINH : Form
    {
        private TaiKhoan _taikhoan;

        public TaiKhoan Taikhoan
        {
            get { return _taikhoan; }
            set { _taikhoan = value;}
        }

        Form frmMain;
        public MANHINHCHINH(TaiKhoan taikhoan)
        {
            InitializeComponent();

            this._taikhoan = taikhoan;
        }

        private void MANHINHCHINH_Load(object sender, EventArgs e)
        {
            menuList[0, 0] = picHoadon;
            menuList[0, 1] = lb_hoadon;
            menuList[0, 2] = pnHoadon;

            menuList[1, 0] = picLephuc;
            menuList[1, 1] = lb_lephuc;
            menuList[1, 2] = pnLephuc;

            menuList[2, 0] = picAlbum;
            menuList[2, 1] = lb_album;
            menuList[2, 2] = pnAlbum;

            menuList[3, 0] = picNhanvien;
            menuList[3, 1] = lb_nhanvien;
            menuList[3, 2] = pnnhanvien;

            menuList[4, 0] = picDoanhthu;
            menuList[4, 1] = lb_doanhthu;
            menuList[4, 2] = pndoanhthu;

            menuList[5, 0] = picLienhe;
            menuList[5, 1] = lb_lienhe;
            menuList[5, 2] = pnLienhe;


            ChangeAccount(_taikhoan.MaNV);
        }


        private void ChangeAccount(int mataikhoan)
        {
            var chucvu = TaiKhoanDAO.Instance.getchucvuBymaNV(TaiKhoanDAO.Instance.getMaNVByTaikhoan(mataikhoan));
            if (chucvu == 1) return;
            else
            {
                if (chucvu == 2) //tiếp tân
                {
                    int[] menuToHide = { 3, 4 };
                    disableMenu(menuToHide);
                    return;
                }

                if (chucvu == 4) //hậu kì(kho)
                {
                    int[] menuToHide = { 0, 2, 3, 4 };
                    disableMenu(menuToHide);
                    return;
                }

                if (chucvu == 3)
                {
                    int[] menuToHide = { 0, 1, 3, 4 };
                    disableMenu(menuToHide);
                    return;
                }
            }
            return;
        }

     
        private void disableMenu(int[] indexList)
        {
            for (int i = 0; i < indexList.Length; i++)
            {
                menuList[indexList[i], 0].Enabled = false;
                menuList[indexList[i], 1].Enabled = false;
                menuList[indexList[i], 2].Enabled = false;
                menuList[indexList[i], 2].BackColor = Color.DarkSlateGray; //panel color
            }
        }


     
        private Control[,] menuList = new Control[6, 3];
        private UserControl[] ucList = { HOADON.Instance, LEPHUC.Instance, ALBUM.Instance, NHANVIEN.Instance, DOANHTHU.Instance, LIENHE.Instance };
        private void clickOnMenuHandler(object sender, EventArgs e)
        {
            chooseIndex = Int32.Parse((String)(((Control)sender).Tag));
            if (chooseIndex != curIndex)
            {
                veMauChoMenu();
            }
            loadUserControl(ucList[chooseIndex]);
            curIndex = chooseIndex;
        }
        private void loadUserControl(UserControl uc)
        {
            if (!pn_usercontrol.Controls.Contains(uc))
            {
                pn_usercontrol.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
            else
            {
            }
            uc.BringToFront();
        }


        private int chooseIndex = -1;
        private int curIndex = -1;
        private void veMauChoMenu()
        {
            switch (chooseIndex)
            {
                case 0:
                    doiMauChoControl(pnHoadon, Color.Aqua);
                    break;
                case 1:
                    doiMauChoControl(pnLephuc, Color.Aqua);
                    break;
                case 2:
                    doiMauChoControl(pnAlbum, Color.Aqua);
                    break;
                case 3:
                    doiMauChoControl(pnnhanvien, Color.Aqua);
                    break;
                case 4:
                    doiMauChoControl(pndoanhthu, Color.Aqua);
                    break;
                case 5:
                    doiMauChoControl(pnLienhe, Color.Aqua);
                    break;
            }

            switch (curIndex)
            {
                case 0:
                    doiMauChoControl(pnHoadon, Color.Transparent);
                    break;
                case 1:
                    doiMauChoControl(pnLephuc, Color.Transparent);
                    break;
                case 2:
                    doiMauChoControl(pnAlbum, Color.Transparent);
                    break;
                case 3:
                    doiMauChoControl(pnnhanvien, Color.Transparent);
                    break;
                case 4:
                    doiMauChoControl(pndoanhthu, Color.Transparent);
                    break;
                case 5:
                    doiMauChoControl(pnLienhe, Color.Transparent);
                    break;
                
            }

           
        }

        private void doiMauChoControl(Control c, Color color)
        {
            c.BackColor = color;
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Bạn có muốn đăng xuất khỏi chương trình?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (frmMain != null)
                {
                    frmMain.Show();
                    this.Dispose();
                }
                else this.Close();
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void btnTaikhoan_click(object sender, EventArgs e)
        //{
            
        //}


        private int anchorX, anchorY;
        bool isDown = false;

        private void main_mousedown(object sender, MouseEventArgs e)
        {
            anchorX = System.Windows.Forms.Cursor.Position.X - this.Left;
            anchorY = System.Windows.Forms.Cursor.Position.Y - this.Top;
            isDown = true;

        }

        private void main_mouseup(object sender, MouseEventArgs e)
        {
            isDown = false;
        }

        private void main_mousemove(object sender, MouseEventArgs e)
        {

            if (isDown)
            {
                this.Left = System.Windows.Forms.Cursor.Position.X - anchorX;
                this.Top = System.Windows.Forms.Cursor.Position.Y - anchorY;
            }
        }

        private void picMyAccount_click(object sender, EventArgs e)
        {
            Form frm = new THONGTINTAIKHOAN(_taikhoan);
            frm.Show();
        }

        private void lbMyAccount_Click(object sender, EventArgs e)
        {
            Form frm = new THONGTINTAIKHOAN(_taikhoan);
            frm.Show();
        }

    


       

    }
}
