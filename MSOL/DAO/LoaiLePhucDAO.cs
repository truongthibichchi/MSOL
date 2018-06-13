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
    public class LoaiLePhucDAO
    {
        private static LoaiLePhucDAO _instance;
        public static LoaiLePhucDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoaiLePhucDAO();
                }
                return _instance;
            }
            private set { _instance = value; }
        }

        private LoaiLePhucDAO() { }

        public List<LoaiLePhuc> GetLoaiLePhucList()
        {
            List<LoaiLePhuc> list = new List<LoaiLePhuc>();
            string query = "select * from LOAILEPHUC";
            DataTable datatable = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in datatable.Rows)
            {
                LoaiLePhuc loailp = new LoaiLePhuc(row);
                list.Add(loailp);
            }
            return list;
        }
    }
}
