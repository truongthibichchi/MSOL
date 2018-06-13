using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MSOL.DTO
{
    public class ChucVu
    {
        public int MaChucVu { get; set; }
        public string TenChucVu { get; set; }

        public ChucVu(int machucvu, string tenchucvu)
        {
            this.MaChucVu = machucvu;
            this.TenChucVu = tenchucvu;
        }

        public ChucVu(DataRow row)
        {
            this.MaChucVu = (int)row["MaChucVu"];
            this.TenChucVu = row["TenChucVu"].ToString();
        }
    }
}
