using MSOL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSOL.DAO
{
    public class CTHDLePhucDAO
    {
        private static CTHDLePhucDAO _instance;
        public static CTHDLePhucDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CTHDLePhucDAO();
                }
                return _instance;
            }
            private set { _instance = value; }
        }

        public List<CTHDLePhuc> GetCTHD_LephucList(int mahd)
        {
            List<CTHDLePhuc> list = new List<CTHDLePhuc>();
            var query = string.Format("select CTHD_LEPHUC.* from CTHD_LEPHUC, HOADON where CTHD_LEPHUC.MaHD= HOADON.MaHD and CTHD_LEPHUC.MaHD={0}", mahd);
            DataTable table = DataProvider.Instance.ExecuteQuery(query);    
            foreach (DataRow row in table.Rows)
            {
                CTHDLePhuc ct = new CTHDLePhuc(row);
                list.Add(ct);
            }
            return list;
        }

        public List<CTHDLePhuc> LoadCTHDLePhucListByMalp(int malp)
        {
            List<CTHDLePhuc> list = new List<CTHDLePhuc>();
            var query = string.Format("select CTHD_LEPHUC.* from CTHD_LEPHUC,LEPHUC where CTHD_LEPHUC.MaLePhuc= LEPHUC.MaLePhuc and CTHD_LEPHUC.MaLePhuc={0}", malp);
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                CTHDLePhuc ct = new CTHDLePhuc(row);
                list.Add(ct);
            }
            return list;
        }
        public bool AddCTHDLephuc(int mahd, int malp, int giachothue)
        {
            var query = string.Format("insert into CTHD_LEPHUC(MaHD, MaLePhuc, GiaChoThue) values ({0}, {1}, {2})", mahd, malp, giachothue);
            var result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }


        public bool deleteCTHDLephuc(int macthdlephuc)
        {
            var query = string.Format("delete from CTHD_LEPHUC where MaCTLP={0}", macthdlephuc);
            var result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool check(int mahoadon)
        {
             List<CTHDLePhuc> list = new List<CTHDLePhuc>();
            var query = string.Format("select * from CTHD_LEPHUC where MaHD={0}", mahoadon);
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                CTHDLePhuc ct = new CTHDLePhuc(row);
                list.Add(ct);
            }
            int count= list.Count;
            int check =(int) DataProvider.Instance.ExecuteScalar("select SoLePhucToiDa from QUYDINH");
            return count >= check;
        }
    }
    
}
