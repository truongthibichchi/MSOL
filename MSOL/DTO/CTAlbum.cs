using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MSOL.DTO
{
    public class CTAlbum
    {
        public int MaCTAlbum { get; set; }
        public int MaAlbum { get; set; }
        public byte[] HinhAnh { get; set; }

        public CTAlbum(int mactalbum, int maalbum, byte[] hinhanh)
        {
            this.MaCTAlbum = mactalbum;
            this.MaAlbum = maalbum;
            this.HinhAnh = hinhanh;
        }

        public CTAlbum(DataRow row)
        {
            
            this.MaCTAlbum = (int)row["MaCTAlbum"];
            this.MaAlbum = (int)row["MaAlbum"];
            this.HinhAnh = (byte[])row["HinhAnh"];
        }
    }
}
