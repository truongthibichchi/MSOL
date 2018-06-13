using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace MSOL.DTO
{
    public class CTHDLePhuc
    {
        public int MaCTLP { get; set; }
        public int MaHD { get; set; }
        public int MaLePhuc { get; set; }
        public int GiaChoThue { get; set; }

        public CTHDLePhuc(int mactlp, int mahd, int malp, int giachothue)
        {
            this.MaCTLP = mactlp;
            this.MaHD = mahd;
            this.MaLePhuc = malp;
            this.GiaChoThue = giachothue;
        }

        public CTHDLePhuc(DataRow row)
        {
            this.MaCTLP = (int)row["MaCTLP"];
            this.MaHD = (int)row["MaHD"];
            this.MaLePhuc = (int)row["MaLePhuc"];
            this.GiaChoThue = (int)row["GiaChoThue"];
        }
    }
}
