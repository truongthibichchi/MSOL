using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MSOL.DTO
{
    public class Album
    {
        public int MaAlbum { get; set; }
        public int MaHD { get; set; }
        public int MaCTGC { get; set; }
        public DateTime NgayChup { get; set; }
        public DateTime NgayNhap { get; set; }
        public int GiaAlbum { get; set; }
        public string TenKH { get; set; }
        public int GiaTien { get; set; }
        public string DiaDiem { get; set; }
        

        public Album(int maalbum, int mahd, int mactgc, DateTime ngaychup, DateTime ngaynhap, int giatien, string tenkh, string diadiem, int giaalbum)
        {
            this.MaAlbum = maalbum;
            this.MaHD = mahd;
            this.NgayChup = ngaychup;
            this.MaCTGC = mactgc;
            this.NgayNhap = ngaynhap;
            this.TenKH = tenkh;
            this.DiaDiem = diadiem;
            this.GiaTien = giatien;
            this.GiaAlbum = giaalbum;
        }

        public Album(DataRow row)
        {
            this.MaAlbum = (int)row["MaAlbum"];
            this.MaHD = (int)row["MaHD"];
            this.MaCTGC = (int)row["MaCTGC"];
            this.NgayChup = (DateTime)row["NgayChup"];
            this.NgayNhap = (DateTime)row["NgayNhap"];
            this.TenKH = row["TenKH"].ToString();
            this.DiaDiem = row["DiaDiem"].ToString();
            this.GiaTien = (int)row["GiaTien"];
            this.GiaAlbum = (int)row["GiaAlbum"];
        }
    }
}
