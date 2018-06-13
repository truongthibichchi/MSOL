using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MSOL.DTO
{
    public class LoaiGoiChup
    {
        public int MaLoaiGC { get; set; }
        public string TenLoaiGC { get; set; }

        public LoaiGoiChup(int maloaigc, string tenloaigc)
        {
            this.MaLoaiGC = maloaigc;
            this.TenLoaiGC = tenloaigc;

        }

        public LoaiGoiChup(DataRow row)
        {
            this.MaLoaiGC = (int)row["MaLoaiGC"];
            this.TenLoaiGC = row["TenLoaiGC"].ToString();
        }
    
    }
}
