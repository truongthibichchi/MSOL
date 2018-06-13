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
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO _instance;
        public static TaiKhoanDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TaiKhoanDAO();
                }
                return _instance;
            }
            private set { _instance = value; }
        }

        public bool dangnhap(string tentaikhoan, string matkhau)
        {
            //string query = "Select * from TAIKHOAN where TenTaiKhoan=\'" + tentaikhoan + "\' and MatKhau=\'" + matkhau + "\'";
            //return DataProvider.Instance.ExecuteScalar(query) != null;
            string query = "USP_dangnhap @TenTaiKhoan , @MatKhau";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { tentaikhoan, matkhau });

            return result.Rows.Count > 0;
        }

        public TaiKhoan getTaiKhoanByTenTaiKhoan(string tentaikhoan)
        {
            var query = string.Format("select * from TAIKHOAN where TenTaiKhoan = '{0}'", tentaikhoan);
            var dataTable = DataProvider.Instance.ExecuteQuery(query);

            var account = dataTable.Rows[0];

            if (account != null)
            {
                return new TaiKhoan(account);
            }

            return null;
        }
        public int getMaNVByTaikhoan(int mataikhoan)
        {
            var query = string.Format("select MaNV from TAIKHOAN where MaTaiKhoan ={0}", mataikhoan);
            return (int) DataProvider.Instance.ExecuteScalar(query);
        }
        public int getchucvuBymaNV(int manv)
        {
            var query = string.Format("select ChucVu from NHANVIEN where MaNV= {0}", manv);
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public bool checkDuplicateUserName(string tentaikhoan)
        {
            var query = string.Format("select * from TAIKHOAN where TenTaiKhoan =\'{0}\'", tentaikhoan);
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table.Rows.Count > 0;
   
        }
        public bool UpdateTAIKHOAN(string tentaikhoan, string matkhaumoi)
        {
            int result = 1;
            try
            {

                DataProvider.Instance.OpenTransaction();
                SqlCommand cmd = new SqlCommand("UpdateTAIKHOAN", DataProvider.Instance.Getconnection());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TenTaiKhoan", tentaikhoan);
                cmd.Parameters["@TenTaiKhoan"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@MatKhauMoi", matkhaumoi);
                cmd.Parameters["@MatKhauMoi"].Direction = ParameterDirection.Input;

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

        public List<TaiKhoan> getTaiKhoanList()
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            var query = "select TAIKHOAN.*, NHANVIEN.MaNV, NHANVIEN.TenNV, CHUCVU.TenChucVu from TAIKHOAN, NHANVIEN, CHUCVU where TAIKHOAN.MaNV=NHANVIEN.MaNV and NHANVIEN.ChucVu=CHUCVU.MaChucVu";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                TaiKhoan taikhoan = new TaiKhoan(row);
                list.Add(taikhoan);
            }
            return list;
        }

        public bool InsertTaiKhoan(string tentaikhoan, int manv, string matkhau)
        {
            int result = 1;
            try
            {

                DataProvider.Instance.OpenTransaction();
                SqlCommand cmd = new SqlCommand("InsertTAIKHOAN", DataProvider.Instance.Getconnection());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TenTaiKhoan", tentaikhoan);
                cmd.Parameters["@TenTaiKhoan"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@MaNV", manv);
                cmd.Parameters["@MaNV"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@MatKhau", matkhau);
                cmd.Parameters["@MatKhau"].Direction = ParameterDirection.Input;

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

        public bool DeleteTaiKhoan(string tentaikhoan)
        {
            var result = 0;
            var query = string.Format("delete from TAIKHOAN where TenTaiKhoan=\'{0}\'", tentaikhoan);
            result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
            
        }
    }
}
