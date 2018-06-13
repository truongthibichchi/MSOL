using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Security;
using MSOL.DAO;
using MSOL.DTO;
using MSOL.UTILITIES;
using System.IO;


namespace MSOL
{
    public partial class XEMCHITIETALBUM : Form
    {
        private List<CTAlbum> _CTAblumList;
        private CTAlbum _CTalbum;
        private int _MaAlbum;
        public XEMCHITIETALBUM(int MaAlbum)
        {
            InitializeComponent();
            this._MaAlbum = MaAlbum;
            txtMaAlbum.Text = _MaAlbum.ToString();
        }

       

        private void picChoose_Click(object sender, EventArgs e)
        {
            ofALBUM.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            ofALBUM.FilterIndex = 1;
            ofALBUM.RestoreDirectory = true;
            if (ofALBUM.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image hinhanhmoi = Image.FromFile(ofALBUM.FileName);
                picHinhAnh.Image = hinhanhmoi;
                picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
            //ofALBUM.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            ////ofALBUM.Multiselect = true;

            //DialogResult dr = this.ofALBUM.ShowDialog();
            //if (dr == System.Windows.Forms.DialogResult.OK)
            //{
            //    foreach (string file in ofALBUM.FileNames)
            //    {
            //        try
            //        {
            //            PictureBox pb = new PictureBox();
            //            Image loadedImage = Image.FromFile(file);
            //            pb.Height = 220;
            //            pb.Width = 280;
            //            pb.SizeMode = PictureBoxSizeMode.Zoom;
            //            pb.Image = loadedImage;
            //            pb.Cursor = Cursors.Hand;
            //            flpCTAlbum.Controls.Add(pb);
            //            flpCTAlbum.FlowDirection = FlowDirection.LeftToRight;
            //            flpCTAlbum.Focus();
            //        }
            //        catch (SecurityException ex)
            //        {
            //            // The user lacks appropriate permissions to read files, discover paths, etc.
            //            MessageBox.Show("Security error. Please contact your administrator for details.\n\n" + "Error message: " + ex.Message + "\n\n" + "Details (send to Support):\n\n" + ex.StackTrace);
            //        }
            //        catch (Exception ex)
            //        {
            //            // Could not load the image - probably related to Windows file system permissions.
            //            MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\')) + ". You may not have permission to read the file, or " + "it may be corrupt.\n\nReported error: " + ex.Message);
            //        }
            //    }
            //}
        
        private void XEMCHITIETALBUM_Load(object sender, EventArgs e)
        {
            LoadflpAlbumByMaAlbum(_MaAlbum);
            if (_CTalbum != null)
            {
                Loaddetail(_CTalbum);
            }
        }

        private void removeBindding()
        {
            picHinhAnh.DataBindings.Clear();
            txtMaCTalbum.DataBindings.Clear();
        }

        private void LoadflpAlbumByMaAlbum(int maAlbum)
        {
            flpCTAlbum.Controls.Clear();
            List<CTAlbum> list = CTAlbumDAO.Instance.GetCTalbumListByMaAlbum(maAlbum);
            _CTAblumList = list;
            LoadPictureboxInflpAlbum();
        }

        private void LoadPictureboxInflpAlbum()
        {
            removeBindding();
            if (_CTAblumList.Count != 0)
            {
                foreach (CTAlbum row in _CTAblumList)
                {

                    PictureBox pic = new PictureBox() { Height = 130, Width = 180 };
                    pic.Click += pic_Click;
                    pic.Tag = row;
                    pic.DataBindings.Add("Image", row, "HinhAnh", true, DataSourceUpdateMode.Never);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    pic.Cursor = Cursors.Hand;
                    flpCTAlbum.Controls.Add(pic);
                }

                _CTalbum = _CTAblumList[0];
                Loaddetail(_CTalbum);
            }
        }

        PictureBox curPic = null;
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
            _CTalbum = (CTAlbum)((PictureBox)sender).Tag;
            Loaddetail(_CTalbum);
        }

        private void Loaddetail(CTAlbum ctalbum)
        {
            picHinhAnh.Image = ControlUtils.convertByteToImage(_CTalbum.HinhAnh);
            txtMaCTalbum.Text = _CTalbum.MaCTAlbum.ToString();
        }

        
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void picSave_Click(object sender, EventArgs e)
        {
            try
            {
                var MaAlbum = _MaAlbum;
                byte[] HinhAnh = ControlUtils.convertImageToByte(picHinhAnh.Image);

                if (CTAlbumDAO.Instance.InsertCTalbum(MaAlbum, HinhAnh))
                {
                    MessageBox.Show("Thêm hỉnh ảnh cho album thành công");
                    LoadflpAlbumByMaAlbum(_MaAlbum);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var MaCTalbum = Convert.ToInt32(txtMaCTalbum.Text);
                if (CTAlbumDAO.Instance.DeleteCTAlbum(MaCTalbum))
                {
                    MessageBox.Show("Xóa hình ảnh thành công");
                    LoadflpAlbumByMaAlbum(_MaAlbum);
                }
                else
                {
                    MessageBox.Show("Không thành công");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
