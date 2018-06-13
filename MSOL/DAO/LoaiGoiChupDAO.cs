using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MSOL.DTO;

namespace MSOL.DAO
{
    public class LoaiGoiChupDAO
    {
        private static LoaiGoiChupDAO _instance;
        public static LoaiGoiChupDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoaiGoiChupDAO();
                }
                return _instance;
            }
            private set { _instance = value; }
        }

        public List<LoaiGoiChup> getTenloaiGCList()
        {
            List<LoaiGoiChup> list = new List<LoaiGoiChup>();
            DataTable datatable = DataProvider.Instance.ExecuteQuery("select * from LOAIGOICHUP");
            foreach (DataRow row in datatable.Rows)
            {
                LoaiGoiChup loaigc = new LoaiGoiChup(row);
                list.Add(loaigc);
            }
            return list;
        }
    }
}
