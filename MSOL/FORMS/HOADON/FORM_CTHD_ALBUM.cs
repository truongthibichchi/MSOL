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
namespace MSOL.FORMS
{
    public partial class FORM_CTHD_ALBUM : Form
    {
        //private List<Album> _AlbumList;
        private List<CTAlbum> _CTAblumList;
        private List<Album> _AlbumList;

        public List<Album> AlbumList
        {
            get { return _AlbumList; }
            set { _AlbumList = value; }
        }


        public FORM_CTHD_ALBUM(List<Album> albumList)
        {
            InitializeComponent();
            this._AlbumList = albumList;
            txtMaHD.Text = _AlbumList[0].MaHD.ToString();
        }

        private void FORM_CTHD_ALBUM_Load(object sender, EventArgs e)
        {
            LoadcbbMaAlbum();
            if (_AlbumList != null)
            {
                var _MaAlbum = _AlbumList[0].MaAlbum;
                LoadflpAlbumByMaAlbum(_MaAlbum);
            }
        }


        private void LoadcbbMaAlbum()
        {
            cbbMaAlbum.DisplayMember = "MaAlbum";
            cbbMaAlbum.DataSource = _AlbumList;
            var tongtien=0;
            for (int i = 0; i < _AlbumList.Count; i++)
            {
                tongtien += _AlbumList[i].GiaAlbum;
            }
            txtTongtien.Text = tongtien.ToString();
            AddBinding();
            

        }

        private void AddBinding()
        {
            txtMaCTGC.DataBindings.Add("Text", _AlbumList, "MaCTGC", true, DataSourceUpdateMode.Never);
            txtDiadiem.DataBindings.Add("Text", _AlbumList, "DiaDiem", true, DataSourceUpdateMode.Never);
            txtGiagoichup.DataBindings.Add("Text", _AlbumList, "GiaTien", true, DataSourceUpdateMode.Never);
            dtimeNgayAlbum.DataBindings.Add("Value", _AlbumList, "NgayNhap", true, DataSourceUpdateMode.Never);
            txtGiaAlbum.DataBindings.Add("Text", _AlbumList, "GiaAlbum", true, DataSourceUpdateMode.Never);

        }

        private void LoadflpAlbumByMaAlbum(int maAlbum)
        {
            flpAlbum.Controls.Clear();
            List<CTAlbum> list = CTAlbumDAO.Instance.GetCTalbumListByMaAlbum(maAlbum);
            _CTAblumList = list;
            LoadPictureboxInflpAlbum();
        }

        private void LoadPictureboxInflpAlbum()
        {
            if (_CTAblumList.Count != 0)
            {
                foreach (CTAlbum row in _CTAblumList)
                {

                    PictureBox pic = new PictureBox() { Height = 130, Width = 100 };
                    pic.Tag = row;
                    pic.DataBindings.Add("Image", row, "HinhAnh", true, DataSourceUpdateMode.Never);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    //pic.Cursor = Cursors.Hand;
                    flpAlbum.Controls.Add(pic);
                }
               
            }
        }

        private void cbbMaAlbum_SelectedIndexChanged(object sender, EventArgs e)
        {
            var maAlbum = Convert.ToInt32((cbbMaAlbum.SelectedItem as Album).MaAlbum);
            LoadflpAlbumByMaAlbum(maAlbum);
        }

        //private void cbbMaAlbum_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    AddBinding();
            
        //}

    }
}
