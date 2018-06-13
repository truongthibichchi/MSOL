using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MSOL.DTO;

namespace MSOL.DAO
{
    public class ChucVuDAO
    {
        private static ChucVuDAO _instance;
        public static ChucVuDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ChucVuDAO();
                }
                return _instance;
            }
            private set { _instance = value; }
        }

        private ChucVuDAO() { }

        public List<ChucVu> GetChucvuList()
        {
            var chucvulist = new List<ChucVu>();
            var query = "select * from CHUCVU";
            var datatable = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in datatable.Rows)
            {
                var chucvu = new ChucVu(row);
                chucvulist.Add(chucvu);
            }
            return chucvulist;
        }

        public ChucVu getTenChucVuByMaChucVu(int macv)
        {
            ChucVu chucvu = null;

            string query = "select * from CHUCVU where MaChucVu = " + macv;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                chucvu = new ChucVu(row);
                return chucvu;
            }

            return chucvu;
        }
    }
}
