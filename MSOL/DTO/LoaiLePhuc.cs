using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MSOL.DTO
{
    public class LoaiLePhuc
    {
        public int MaLoaiLP { get; set; }
        public string TenLoaiLP { get; set; }

        public LoaiLePhuc(int maloailp, string tenloailp)
        {
            this.MaLoaiLP=maloailp;
            this.TenLoaiLP=tenloailp;
        }

        public LoaiLePhuc(DataRow row)
        {
            this.MaLoaiLP = (int)row["MaLoaiLP"];
            this.TenLoaiLP = row["TenLoaiLP"].ToString();
        }
    }

}
