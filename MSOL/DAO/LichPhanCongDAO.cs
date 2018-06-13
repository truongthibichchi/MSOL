using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSOL.DTO;
using System.Data;
using System.Data.SqlClient;

namespace MSOL.DAO
{
    class LichPhanCongDAO
    {
        private static LichPhanCongDAO _instance;
        public static LichPhanCongDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LichPhanCongDAO();
                }
                return _instance;
            }
            private set { _instance = value; }
        }

        public List<LichPhanCong> getlichphanconglist()
        {
            var query = "select ctgc.*, gc.DiaDiem, nv.TenNV, hd.TenKH, hd.SDT from CTHD_GOICHUP ctgc, HOADON hd, GOICHUP gc, NHANVIEN nv where ctgc.MaHD=hd.MaHD and ctgc.MaGoiChup=gc.MaGoiChup and ctgc.MaNV=nv.MaNV order by NgayChup asc, MaCTGC asc ";
            List<LichPhanCong> list = new List<LichPhanCong>();
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
           foreach (DataRow row in table.Rows)
           {
               LichPhanCong lichphancong = new LichPhanCong(row);
               list.Add(lichphancong);
           }
           return list;
        }
       
    }
}
