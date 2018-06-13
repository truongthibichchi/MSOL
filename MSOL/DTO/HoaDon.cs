using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MSOL.DTO
{
    public class HoaDon
    {
        public int MaHD { get; set; }
        public DateTime NgayHD { get; set; }
        public string TenKH { get; set; }
        public string CMND { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public int TienLePhuc { get; set; }
        public int TienGoiChup { get; set; }
        public int TienAlbum { get; set; }
        public int TongTien { get; set; }
        public int DatCoc { get; set; }
        public int ConLai { get; set; }
        public int ThanhToan { get; set; }
        public string InHD { get; set; }


        public HoaDon(int mahd, DateTime ngayhd, string tenkh, string cmnd, string sdt, string diachi, int tienlp, int tiengc, int tienalbum, int tongtien, int datcoc, int thanhtoan, int conlai, string inhd)
        {
            this.MaHD = mahd;
            this.NgayHD = ngayhd;
            this.TenKH = tenkh;
            this.CMND = cmnd;
            this.SDT = sdt;
            this.DiaChi = diachi;
            this.TienLePhuc = tienlp;
            this.TienGoiChup = tiengc;
            this.TienAlbum = tienalbum;
            this.TongTien = tongtien;
            this.DatCoc = datcoc;
            this.ConLai = conlai;
            this.ThanhToan = thanhtoan;
            this.InHD = inhd;
        }

        public HoaDon(DataRow row)
        {
            this.MaHD = (int)row["MaHD"];
            this.NgayHD = (DateTime)row["NgayHD"];
            this.TenKH = row["TenKH"].ToString();
            this.CMND = row["CMND"].ToString();
            this.SDT = row["SDT"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
            this.TienLePhuc = (int)row["TienLePhuc"];
            this.TienGoiChup = (int)row["TienGoiChup"];
            this.TienAlbum = (int)row["TienAlbum"];
            this.TongTien = (int)row["TongTien"];
            this.DatCoc = (int)row["DatCoc"];
            this.ConLai = (int)row["ConLai"];
            this.ThanhToan = (int)row["ThanhToan"];
            this.InHD = row["InHD"].ToString();
        }
    }
}
