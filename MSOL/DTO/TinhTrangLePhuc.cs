using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MSOL.DTO
{
    public class TinhTrangLePhuc
    {
        public int MaTinhTrang { get; set; }
        public string TenTinhTrang { get; set; }

        public TinhTrangLePhuc(int matinhtrang, string tentinhtrang)
        {
            this.MaTinhTrang = matinhtrang;
            this.TenTinhTrang = tentinhtrang;
        }

        public TinhTrangLePhuc(DataRow row)
        {
            this.MaTinhTrang = (int)row["MaTinhTrang"];
            this.TenTinhTrang = row["TenTinhTrang"].ToString();
        }
    }
}
