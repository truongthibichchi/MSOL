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
    public class CTHDGoiChupDAO
    {
        private static CTHDGoiChupDAO _instance;
        public static CTHDGoiChupDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CTHDGoiChupDAO();
                }
                return _instance;
            }
            private set { _instance = value; }
        }

        public List<CTHDGoiChup> GetCTHDGoichupList()
        {
            List<CTHDGoiChup> list = new List<CTHDGoiChup>();
            DataTable table = DataProvider.Instance.ExecuteQuery("select * from CTHD_GOICHUP");
            foreach (DataRow row in table.Rows)
            {
                CTHDGoiChup ct = new CTHDGoiChup(row);
                list.Add(ct);
            }
            return list;
        }

        public List<CTHDGoiChup> GetCTHDGoichupListDetail()
        {
            List<CTHDGoiChup> list = new List<CTHDGoiChup>();
            DataTable table = DataProvider.Instance.ExecuteQuery("select * from CTHD_GOICHUP");
            foreach (DataRow row in table.Rows)
            {
                CTHDGoiChup ct = new CTHDGoiChup(row);
                list.Add(ct);
            }
            return list;
        }


        public List<CTHDGoiChup> GetCTHDGoiChupListByMaHD(int mahd)
        {
            List<CTHDGoiChup> list = new List<CTHDGoiChup>();
            DataTable table = DataProvider.Instance.ExecuteQuery(string.Format("select CTHD_GOICHUP.* from CTHD_GOICHUP, HOADON where CTHD_GOICHUP.MaHD= HOADON.MaHD and CTHD_GOICHUP.MaHD={0}", mahd));
             foreach (DataRow row in table.Rows)
            {
                CTHDGoiChup ct = new CTHDGoiChup(row);
                list.Add(ct);
            }
            return list;
        }

        public int getMaGCByMaCTGC(int mactgc)
        {
            int magc = (int)DataProvider.Instance.ExecuteScalar(string.Format("select MaGoiChup from CTHD_GOICHUP where MaCTGC={0}", mactgc));
            return magc;
        }

        public CTHDGoiChup GetCTgoichupByMaCTGC(int mactgc)
        {
            var datatable = DataProvider.Instance.ExecuteQuery(string.Format("select * from CTHD_GOICHUP where MaCTGC={0}", mactgc));
            var CTGoichup = datatable.Rows[0];
            if (CTGoichup != null)
            {
                return new CTHDGoiChup(CTGoichup);
            }
            return null;
        }

        public int getMaHDByMaCTGC(int mactgc)
        {
            return (int)DataProvider.Instance.ExecuteScalar(string.Format("select MaHD from CTHD_GOICHUP where MaCTGC={0}", mactgc));
        }

        public bool checkDuplicateNhanVien(int MaNV, DateTime NgayChup)
        {
            var query = string.Format("select * from CTHD_GOICHUP where MaNV =N\'{0}\' and DAY(NgayChup) = {1} and MONTH(NgayChup)= {2} and YEAR(NgayChup)={3}", MaNV, NgayChup.Day, NgayChup.Month, NgayChup.Year);
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }

        

        public bool InsertCTHDGoichup(int mahd, int magc, int giatien, int manv, DateTime ngaychup)
        {
            int result = 1;
            try
            {

                DataProvider.Instance.OpenTransaction();
                SqlCommand cmd = new SqlCommand("InsertCTHDGoiChup", DataProvider.Instance.Getconnection());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaHD", mahd);
                cmd.Parameters["@MaHD"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@MaGoiChup", magc);
                cmd.Parameters["@MaGoiChup"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@GiaTien", giatien);
                cmd.Parameters["@GiaTien"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@MaNV", manv);
                cmd.Parameters["@MaNV"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@NgayChup", SqlDbType.Date);
                cmd.Parameters["@NgayChup"].Direction = ParameterDirection.Input;
                cmd.Parameters["@NgayChup"].Value = ngaychup;

                result = cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                DataProvider.Instance.CloseTransaction();
            }

            return result > 0;
        }

        public bool UpdateCTHDGoiChup(int mactgc, int manv, DateTime ngaychup)
        {

            int result = 1;
            try
            {

                DataProvider.Instance.OpenTransaction();
                SqlCommand cmd = new SqlCommand("UpdateCTHDGoiChup", DataProvider.Instance.Getconnection());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaCTGC", mactgc);
                cmd.Parameters["@MaCTGC"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@MaNV", manv);
                cmd.Parameters["@MaNV"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@NgayChup", SqlDbType.Date);
                cmd.Parameters["@NgayChup"].Direction = ParameterDirection.Input;
                cmd.Parameters["@NgayChup"].Value = ngaychup;

                result = cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                DataProvider.Instance.CloseTransaction();
            }

            return result > 0;
        }

        public bool DeleteCTGC(int mactgc)
        {
            var query = string.Format("delete from CTHD_GOICHUP where MaCTGC ={0}", mactgc);
            var result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public int deleteCTGoichupByMaHD(int mahd)
        {
            int result = 0;
            result =(int) DataProvider.Instance.ExecuteNonQuery(string.Format("delete from CTHD_GOICHUP where MaHD={0}", mahd));
            return result;
        }

        public int check()
        {
            return (int)DataProvider.Instance.ExecuteScalar("select SoGoiChupToiDa from QUYDINH");

        }
    }
}
