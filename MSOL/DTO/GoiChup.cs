using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MSOL.DTO
{
    public class GoiChup
    {
        public int MaGoiChup { get; set; }
        public int Loai { get; set; }
        public string DiaDiem { get; set; }
        public int GiaTien { get; set; }
        public string TinhTrang { get; set; }
   

        public GoiChup(int magoichup, int loai, string diadiem, int giatien, string tinhtrang)
        {
            this.MaGoiChup = magoichup;
            this.Loai = loai;
            this.DiaDiem = diadiem;
            this.GiaTien = giatien;
            this.TinhTrang = tinhtrang;
        }

        public GoiChup(DataRow row)
        {
            this.MaGoiChup = (int)row["MaGoiChup"];
            this.Loai = (int)row["Loai"];
            this.DiaDiem = row["DiaDiem"].ToString();
            this.GiaTien = (int)row["GiaTien"];
            this.TinhTrang = row["TinhTrang"].ToString();
        }
    }


}
