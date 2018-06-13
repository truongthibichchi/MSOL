using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MSOL.DTO
{
    public class CTHDGoiChup
    {
        public int MaCTGC { get; set; }
        public int MaHD { get; set; }
        public int MaGoiChup { get; set; }
        public int MaNV { get; set; }
        public DateTime NgayChup { get; set; }
        public int GiaTien { get; set; }
       

        public CTHDGoiChup(int mactgc, int mahd, int magc, int manv, DateTime ngaychup, int giatien, string mota)
        {
            this.MaCTGC = mactgc;
            this.MaHD = mahd;
            this.MaGoiChup = magc;
            this.MaNV = manv;
            this.NgayChup = ngaychup;
            this.GiaTien = giatien;
    
        }

        public CTHDGoiChup(DataRow row)
        {
            this.MaCTGC = (int)row["MaCTGC"];
            this.MaHD = (int)row["MaHD"];
            this.MaGoiChup = (int)row["MaGoiChup"];
            this.MaNV = (int)row["MaNV"];
            this.NgayChup = (DateTime)row["NgayChup"];
            this.GiaTien = (int)row["GiaTien"];
            
        }

    }
}
