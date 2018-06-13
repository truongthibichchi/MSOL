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
    public class HoaDonDAO
    {
        private static HoaDonDAO _instance;

        public static HoaDonDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HoaDonDAO();
                }
                return _instance;
            }
            private set { _instance = value; }
        }

        public List<HoaDon> GetHoaDonList()
        {
            List<HoaDon> list = new List<HoaDon>();
            DataTable table = DataProvider.Instance.ExecuteQuery("select * from HOADON");
            foreach (DataRow row in table.Rows)
            {
                HoaDon nhanvien = new HoaDon(row);
                list.Add(nhanvien);
            }
            return list;
        }

        
        public bool AddHoaDon(DateTime ngayhd, string tenkh, string cmnd, string sdt, string diachi)
        {
            int result = 1;
            try
            {

                DataProvider.Instance.OpenTransaction();
                SqlCommand cmd = new SqlCommand("InsertHOADON", DataProvider.Instance.Getconnection());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NgayHD", SqlDbType.Date);
                cmd.Parameters["@NgayHD"].Direction = ParameterDirection.Input;
                cmd.Parameters["@NgayHD"].Value = ngayhd;

                cmd.Parameters.AddWithValue("@TenKH", tenkh);
                cmd.Parameters["@TenKH"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@CMND", cmnd);
                cmd.Parameters["@CMND"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@SDT", sdt);
                cmd.Parameters["@SDT"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@DiaChi", diachi);
                cmd.Parameters["@DiaChi"].Direction = ParameterDirection.Input;

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

        public bool UpdateHoadon(int mahd, DateTime ngayhd, string tenkh, string cmnd, string sdt, string diachi)
        {
            int result = 0;
            try
            {

                DataProvider.Instance.OpenTransaction();
                SqlCommand cmd = new SqlCommand("UpdateHOADON", DataProvider.Instance.Getconnection());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaHD", mahd);
                cmd.Parameters["@MaHD"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@NgayHD", SqlDbType.Date);
                cmd.Parameters["@NgayHD"].Direction = ParameterDirection.Input;
                cmd.Parameters["@NgayHD"].Value = ngayhd;

                cmd.Parameters.AddWithValue("@TenKH", tenkh);
                cmd.Parameters["@TenKH"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@CMND", cmnd);
                cmd.Parameters["@CMND"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@SDT", sdt);
                cmd.Parameters["@SDT"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@DiaChi", diachi);
                cmd.Parameters["@DiaChi"].Direction = ParameterDirection.Input;


                result = cmd.ExecuteNonQuery();
            }
            catch{ }
            finally
            {
                DataProvider.Instance.CloseTransaction();
            }

            return result > 0;
        }

        public string getTenKHByMaHD(int mahd)
        {
            return (string)DataProvider.Instance.ExecuteScalar(string.Format("select TenKH from HOADON where MaHD={0}", mahd));
        }
        public HoaDon GetHoadonByMaHD(int mahd)
        {
            var query = string.Format("select * from HOADON where MaHD = '{0}'", mahd);
            var dataTable = DataProvider.Instance.ExecuteQuery(query);

            var hoadon = dataTable.Rows[0];

            if (hoadon != null)
            {
                return new HoaDon(hoadon);
            }

            return null;
        }

        public bool updateTienAlbum(int tienalbum, int mahd)
        {
            int tiendatcoc = (int)DataProvider.Instance.ExecuteScalar("select SoTienCoc from QUYDINH");
            var result = DataProvider.Instance.ExecuteNonQuery(string.Format("update HOADON set TienAlbum ={0}, TongTien=TienLePhuc+TienGoiChup+{0},  DatCoc=(TienLePhuc+TienGoiChup+{0})*{2}/100, ConLai=TienLePhuc+TienGoiChup+{0}-ThanhToan where MaHD={1}", tienalbum, mahd, tiendatcoc));
            return result > 0;
        }

        public bool updateTienLePhuc(int tienlephuc, int mahd)
        {

            int tiendatcoc = (int)DataProvider.Instance.ExecuteScalar("select SoTienCoc from QUYDINH");
            var result = DataProvider.Instance.ExecuteNonQuery(string.Format("update HOADON set TienLePhuc ={0}, TongTien={0}+TienGoiChup+TienAlbum,  DatCoc=({0}+TienGoiChup+TienAlbum)*{2}/100, ConLai={0}+TienGoiChup+TienAlbum-ThanhToan where MaHD={1}", tienlephuc, mahd, tiendatcoc));
            return result > 0;
        }

        public bool updateTienGoiChup(int tiengoichup, int mahd)
        {

            int tiendatcoc = (int)DataProvider.Instance.ExecuteScalar("select SoTienCoc from QUYDINH");
            var result = DataProvider.Instance.ExecuteNonQuery(string.Format("update HOADON set TienGoiChup ={0}, TongTien=TienLePhuc+{0}+TienAlbum, DatCoc=(TienLePhuc+{0}+TienAlbum)*{2}/100, ConLai=TienLePhuc+{0}+TienAlbum-ThanhToan where MaHD={1}", tiengoichup, mahd, tiendatcoc));
            return result > 0;
        }
     

        public bool UpdateThanhToan(int thanhtoan, int mahd)
        {

            var result = DataProvider.Instance.ExecuteNonQuery(string.Format("update HOADON set ThanhToan={0}, ConLai=TongTien-{0} where MaHD={1}", thanhtoan, mahd));
            return result>0;
        }

        public bool DaInHoaDon(int mahd)
        {
            var result = (string)DataProvider.Instance.ExecuteScalar(string.Format("select InHD from HOADON where MaHD={0}", mahd));
            if (result == "Đã in") return true;
            return false;
        }

        public bool UpdateInHD(int mahd)
        {
            var result = DataProvider.Instance.ExecuteNonQuery(string.Format("update HOADON set InHD = N'Đã in' where MaHD={0}", mahd));
            return result > 0;
        }

        public bool deleteHoaDonByMaHD(int mahd)
        {
            var result = DataProvider.Instance.ExecuteNonQuery(string.Format("delete from HOADON where MaHD={0}", mahd));
            return result > 0;
        }

        public List<HoaDon> SearchHoaDon(string text)
        {
            List<HoaDon> list = new List<HoaDon>();
            DataTable table = DataProvider.Instance.ExecuteQuery(string.Format("select * from HOADON where TenKH like N'%{0}%' or CMND like N'%{0}%' or SDT like N'%{0}%' or DiaChi like N'%{0}%' or InHD like N'%{0}%'", text));

            foreach (DataRow row in table.Rows)
            {
                HoaDon hd = new HoaDon(row);
                list.Add(hd);
            }
            return list;
        }

        public List<HoaDon> ThongKeDoanhThu(DateTime batdau, DateTime ketthuc)
        {
            List<HoaDon> list = new List<HoaDon>();
            DataTable table= DataProvider.Instance.ExecuteQuery("exec THONGKEDOANHTHU @BatDau , @KetThuc", new object[] { batdau, ketthuc });

            foreach (DataRow row in table.Rows)
            {
                HoaDon hd = new HoaDon(row);
                list.Add(hd);
            }
            return list;
        }

    }
}
