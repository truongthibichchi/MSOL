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
    public class LePhucDAO
    {
        private static LePhucDAO _instance;
        public static LePhucDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LePhucDAO();
                }
                return _instance;
            }
            private set { _instance = value; }
        }
        public List<LePhuc> getlephuclist()
        {
            List<LePhuc> list = new List<LePhuc>();
            var query = "select LEPHUC.*, LOAILEPHUC.TenLoaiLP , TINHTRANG.TenTinhTrang from LEPHUC, LOAILEPHUC, TINHTRANG where LEPHUC.Loai=LOAILEPHUC.MaLoaiLP and TINHTRANG.MaTinhTrang=LEPHUC.TinhTrang";
            DataTable datatable = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in datatable.Rows)
            {
                LePhuc lephuc = new LePhuc(row);
                list.Add(lephuc);
            }
            return list;
            
        }

      

        public List<LePhuc> getLephucByLoaiLephuc(int loailp)
        {
            var list = new List<LePhuc>();
            var query = string.Format("select * from LEPHUC where Loai = {0}", loailp);
            var datatable = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in datatable.Rows)
            {
                var lephuc = new LePhuc(row);
                list.Add(lephuc);
            }
            return list;
        }

        public List<LePhuc> getLephucByloaiLephucAndTinhtrang(int loailp, int tinhtrang)
        {
            var list = new List<LePhuc>();
            var query = string.Format("select * from LEPHUC where Loai = {0} and TinhTrang={1}", loailp, tinhtrang);
            var datatable = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in datatable.Rows)
            {
                var lephuc = new LePhuc(row);
                list.Add(lephuc);
            }
            return list;
        }

        public string getMotaByMaLP(int malp)
        {
            return (string)DataProvider.Instance.ExecuteScalar(string.Format("select MoTa from LEPHUC where MaLePhuc ={0}", malp));
        }

        public LePhuc getLephucByMaLephuc(int malp)
        {
           var table = DataProvider.Instance.ExecuteQuery(string.Format("select * from LEPHUC where MaLePhuc={0}", malp));
           var lephuc = table.Rows[0];
           if (lephuc != null)
           {
               return new LePhuc(lephuc);
           }
           return null;
            
        }

        public bool AddLephuc(DateTime ngaynhap, string mota, int gianhap, int giachothue, int loai, byte[] hinhanh)
        {
                int result = 1;
                try
                {
                  
                    DataProvider.Instance.OpenTransaction();
                    SqlCommand cmd = new SqlCommand("InsertLEPHUC", DataProvider.Instance.Getconnection());
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NgayNhap", SqlDbType.Date);
                    cmd.Parameters["@NgayNhap"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@NgayNhap"].Value = ngaynhap;

                    cmd.Parameters.AddWithValue("@MoTa", mota);
                    cmd.Parameters["@MoTa"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@GiaNhap", gianhap);
                    cmd.Parameters["@GiaNhap"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@GiaChoThue", giachothue);
                    cmd.Parameters["@GiaChoThue"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@Loai", loai);
                    cmd.Parameters["@Loai"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@HinhAnh", SqlDbType.Image);
                    cmd.Parameters["@HinhAnh"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@HinhAnh"].Value = hinhanh;

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

        public bool UpdateLephuc(int malp, DateTime ngaynhap, string mota, int gianhap, int giachothue, int loai, byte[] hinhanh)
        {
            int result = 1;
            try
            {

                DataProvider.Instance.OpenTransaction();
                SqlCommand cmd = new SqlCommand("UpdateLEPHUC", DataProvider.Instance.Getconnection());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaLePhuc", malp);
                cmd.Parameters["@MaLePhuc"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@NgayNhap", SqlDbType.Date);
                cmd.Parameters["@NgayNhap"].Direction = ParameterDirection.Input;
                cmd.Parameters["@NgayNhap"].Value = ngaynhap;

                cmd.Parameters.AddWithValue("@MoTa", mota);
                cmd.Parameters["@MoTa"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@GiaNhap", gianhap);
                cmd.Parameters["@GiaNhap"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@GiaChoThue", giachothue);
                cmd.Parameters["@GiaChoThue"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@Loai", loai);
                cmd.Parameters["@Loai"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@HinhAnh", SqlDbType.Image);
                cmd.Parameters["@HinhAnh"].Direction = ParameterDirection.Input;
                cmd.Parameters["@HinhAnh"].Value = hinhanh;

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

        public bool DeleteLephuc(int malp)
        {
            var query = string.Format("update LEPHUC set TinhTrang=3 where MaLePhuc={0}", malp);
            var result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateTinhtrangDaThue(int malp)
        {
            var query = string.Format("update LEPHUC set Tinhtrang=2 where MaLePhuc={0}", malp);
            var result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateTinhtrangSansang(int malp)
        {
            var query = string.Format("update LEPHUC set Tinhtrang=1 where MaLePhuc={0}", malp);
            var result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<LePhuc> GetLephuc(int malp, int tinhtrang)
        {
            var list = new List<LePhuc>();
            var query = string.Format("select * from LEPHUC where MaLePhuc={0} and TinhTrang ={1}", malp, tinhtrang);
            var datatable = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in datatable.Rows)
            {
                var lephuc = new LePhuc(row);
                list.Add(lephuc);
            }
            return list;

        }

        public List<LePhuc> LoadLephucList()
        {
            var list = new List<LePhuc>();
            var query = string.Format("select * from LEPHUC");
            var datatable = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in datatable.Rows)
            {
                var lephuc = new LePhuc(row);
                list.Add(lephuc);
            }
            return list;
        }
    }
}
