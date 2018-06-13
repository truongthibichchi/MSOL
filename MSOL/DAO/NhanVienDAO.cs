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
    public class NhanVienDAO
    {
        private static NhanVienDAO _instance;
        public static NhanVienDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NhanVienDAO();
                }
                return _instance;
            }
            private set { _instance = value; }
        }

        private NhanVienDAO() { }

        public List<NhanVien> getNhanvienList()
        {
            List<NhanVien> list = new List<NhanVien>();
            DataTable table = DataProvider.Instance.ExecuteQuery("select NHANVIEN.*, CHUCVU.TenChucVu from NHANVIEN, CHUCVU where NHANVIEN.ChucVu=CHUCVU.MaChucVu");
            foreach (DataRow row in table.Rows)
            {
                NhanVien nv = new NhanVien(row);
                list.Add(nv);
            }
            return list;
        }

        public List<NhanVien> getTaiKhoanMaNVList()
        {
            List<NhanVien> list = new List<NhanVien>();
            DataTable table = DataProvider.Instance.ExecuteQuery("select NHANVIEN.*, CHUCVU.TenChucVu from NHANVIEN, CHUCVU where NHANVIEN.ChucVu=CHUCVU.MaChucVu and (ChucVu=1 or ChucVu=2 or ChucVu=3 or ChucVu=4)");
            foreach (DataRow row in table.Rows)
            {
                NhanVien nv = new NhanVien(row);
                list.Add(nv);
            }
            return list;
        }
        public string getTenchucvuByMaCV(int macv)
        {
            string tenchucvu = (string)DataProvider.Instance.ExecuteScalar(string.Format("select TenChucVu from CHUCVU where MaChucVu ={0}", macv));
            return tenchucvu;

        }

        public string getTenNVByMaNV(int manv)
        {
            return (string)DataProvider.Instance.ExecuteScalar(string.Format("select TenNV from NHANVIEN where MaNV={0}", manv));
        }

        public int getMachucvuByMaNV(int manv)
        {
            return (int)DataProvider.Instance.ExecuteScalar(string.Format("select ChucVu from NHANVIEN where MaNV={0}", manv));
        }

        public List<NhanVien> GetNhanvienByChucvu(string chucvu)
        {
            List<NhanVien> list = new List<NhanVien>();
            DataTable table = DataProvider.Instance.ExecuteQuery(string.Format("select NHANVIEN.*, CHUCVU.TenChucVu from NHANVIEN, CHUCVU where NHANVIEN.ChucVu=CHUCVU.MaChucVu and CHUCVU.TenChucVu=N\'{0}\'", chucvu));
            foreach (DataRow row in table.Rows)
            {
                NhanVien nv = new NhanVien(row);
                list.Add(nv);
            }
            return list;
        }


        public List<NhanVien> SearchNhanvien(string text)
        {
            List<NhanVien> list = new List<NhanVien>();
            DataTable table = DataProvider.Instance.ExecuteQuery(string.Format("select NHANVIEN.*, ChucVu.TenChucVu from NHANVIEN, CHUCVU where NHANVIEN.ChucVu=CHUCVU.MaChucVu and ( TenNV like N'%{0}%' or CHUCVU.TenChucVu like N'%{0}%' or DiaChi like N'%{0}%' or SDT like '%{0}%' or GioiTinh like N'%{0}%' or TinhTrang like N'%{0}%' or CMND like '%{0}%')", text));
            foreach (DataRow row in table.Rows)
            {
                NhanVien nv = new NhanVien(row);
                list.Add(nv);
            }
            return list;
        }

        public bool AddNhanvien(string tennv, DateTime ngaysinh, string gioitinh, string cmnd, string sdt, string diachi, int chucvu, int luong, byte[] hinhanh)
        {
            int result = 1;
            try
            {

                DataProvider.Instance.OpenTransaction();
                SqlCommand cmd = new SqlCommand("InsertNHANVIEN", DataProvider.Instance.Getconnection());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TenNV", tennv);
                cmd.Parameters["@TenNV"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@NgaySinh", SqlDbType.Date);
                cmd.Parameters["@NgaySinh"].Direction = ParameterDirection.Input;
                cmd.Parameters["@NgaySinh"].Value = ngaysinh;

                cmd.Parameters.AddWithValue("@GioiTinh", gioitinh);
                cmd.Parameters["@GioiTinh"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@CMND", cmnd);
                cmd.Parameters["@CMND"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@SDT", sdt);
                cmd.Parameters["@SDT"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@DiaChi", diachi);
                cmd.Parameters["@DiaChi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@ChucVu", chucvu);
                cmd.Parameters["@ChucVu"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@Luong", luong);
                cmd.Parameters["@Luong"].Direction = ParameterDirection.Input;

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


        public bool UpdateNhanvien(int manv, string tennv, DateTime ngaysinh, string gioitinh, string cmnd, string sdt, string diachi, int chucvu, int luong, byte[] hinhanh)
        {
            int result = 1;
            try
            {

                DataProvider.Instance.OpenTransaction();
                SqlCommand cmd = new SqlCommand("UpdateNHANVIEN", DataProvider.Instance.Getconnection());
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@MaNV", manv);
                cmd.Parameters["@MaNV"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@TenNV", tennv);
                cmd.Parameters["@TenNV"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@NgaySinh", SqlDbType.Date);
                cmd.Parameters["@NgaySinh"].Direction = ParameterDirection.Input;
                cmd.Parameters["@NgaySinh"].Value = ngaysinh;

                cmd.Parameters.AddWithValue("@GioiTinh", gioitinh);
                cmd.Parameters["@GioiTinh"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@CMND", cmnd);
                cmd.Parameters["@CMND"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@SDT", sdt);
                cmd.Parameters["@SDT"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@DiaChi", diachi);
                cmd.Parameters["@DiaChi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@Luong", luong);
                cmd.Parameters["@Luong"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@ChucVu", chucvu);
                cmd.Parameters["@ChucVu"].Direction = ParameterDirection.Input;

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

        public bool DeleteNhanvien(int manv)
        {
            var query = string.Format("update NHANVIEN set TinhTrang= N'Đã nghỉ việc' where MaNV ={0}", manv);
            var result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
