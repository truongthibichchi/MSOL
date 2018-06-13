using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace MSOL.DTO
{
    public class LichPhanCong
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public int MaCTGC { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public DateTime NgayChup { get; set; } 
        public int GiaTien { get; set; }
        public string DiaDiem { get; set; }

        public LichPhanCong(int manv, string tennv, int mactgc, string tenkh, string sdt, DateTime ngaychup, int giatien, string diadiem)
        {
            this.MaNV = manv;
            this.TenNV = tennv;
            this.MaCTGC = mactgc;
            this.TenKH = tenkh;
            this.SDT = sdt;
            this.NgayChup = ngaychup;
            this.GiaTien = giatien;
            this.DiaDiem = diadiem;
        }

        public LichPhanCong(DataRow row)
        {
            this.MaNV = (int)row["MaNV"];
            this.TenNV = row["TenNV"].ToString();
            this.MaCTGC = (int)row["MaCTGC"];
            this.TenKH = row["TenKH"].ToString();
            this.SDT = row["SDT"].ToString();
            this.NgayChup = (DateTime)row["NgayChup"];
            this.GiaTien = (int)row["GiaTien"];
            this.DiaDiem = row["DiaDiem"].ToString();
        }
    }
}
