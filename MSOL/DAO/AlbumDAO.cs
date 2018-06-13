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
    public class AlbumDAO
    {
        private static AlbumDAO _instance;
        public static AlbumDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AlbumDAO();
                }
                return _instance;
            }
            private set { _instance = value; }
        }

        public List<Album> getAlbumList()
        {
            List<Album> list = new List<Album>();
            DataTable table = DataProvider.Instance.ExecuteQuery("select ALBUM.*, HOADON.MaHD, HOADON.TenKH, GOICHUP.DiaDiem, CTHD_GOICHUP.* from ALBUM, HOADON, GOICHUP, CTHD_GOICHUP where ALBUM.MaCTGC=CTHD_GOICHUP.MaCTGC and CTHD_GOICHUP.MaGoiChup=GOICHUP.MaGoiChup and CTHD_GOICHUP.MaHD=HOADON.MaHD");
            foreach (DataRow row in table.Rows)
            {
                Album album = new Album(row);
                list.Add(album);
            }
            return list;
        }

        public bool checkDuplicateAlbum(int mactgc)
        {
            var query = string.Format("select * from ALBUM where MaCTGC={0}", mactgc);
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }

        public Album getAlbumByMaCTGC(int mactgc)
        {
            var query = string.Format("select ALBUM.*, HOADON.MaHD, HOADON.TenKH, GOICHUP.DiaDiem, CTHD_GOICHUP.* from ALBUM, HOADON, GOICHUP, CTHD_GOICHUP where ALBUM.MaCTGC=CTHD_GOICHUP.MaCTGC and CTHD_GOICHUP.MaGoiChup=GOICHUP.MaGoiChup and CTHD_GOICHUP.MaHD=HOADON.MaHD and CTHD_GOICHUP.MaCTGC={0}", mactgc);
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
    
            if (table!=null)
            {
                return new Album(table.Rows[0]);
            }
            return null;
        }

        public List<Album> getAlbumListByMaHD(int mahd)
        {
            var query = string.Format("select al.*, hd.MaHD, hd.TenKH, gc.DiaDiem, ctgc.* from ALBUM al, HOADON hd, CTHD_GOICHUP ctgc, GOICHUP gc where al.MaCTGC= ctgc.MaCTGC and ctgc.MaHD=hd.MaHD and ctgc.MaGoiChup=gc.MaGoiChup and hd.MaHD={0}", mahd);
            List<Album> list = new List<Album>();
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                Album album = new Album(row);
                list.Add(album);
            }
            return list;
        }


        public List<Album> searchAlbum(string text)
        {
            var query = string.Format("select ALBUM.*, HOADON.MaHD, HOADON.TenKH, GOICHUP.DiaDiem, CTHD_GOICHUP.* from ALBUM, HOADON, GOICHUP, CTHD_GOICHUP where ALBUM.MaCTGC=CTHD_GOICHUP.MaCTGC and CTHD_GOICHUP.MaGoiChup=GOICHUP.MaGoiChup and CTHD_GOICHUP.MaHD=HOADON.MaHD and (TenKH like N'%{0}%' or DiaDiem like N'%{0}%'", text);
            List<Album> list = new List<Album>();
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                Album album = new Album(row);
                list.Add(album);
            }
            return list;
        }
        public bool InsertCTAlbum(int mactgc, DateTime ngaynhap, int giaAlbum)
        {
            int result = 0;
            try
            {

                DataProvider.Instance.OpenTransaction();
                SqlCommand cmd = new SqlCommand("InsertCTALBUM", DataProvider.Instance.Getconnection());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaCTGC", mactgc);
                cmd.Parameters["@MaCTGC"].Direction = ParameterDirection.Input;


                cmd.Parameters.AddWithValue("@GiaAlbum", giaAlbum);
                cmd.Parameters["@GiaAlbum"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@NgayNhap", SqlDbType.Date);
                cmd.Parameters["@NgayNhap"].Direction = ParameterDirection.Input;
                cmd.Parameters["@NgayNhap"].Value = ngaynhap;

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

        public bool UpdateAlbum(int maAlbum, int mactgc, DateTime ngaynhap, int giaAlbum)
        {
            int result = 0;
            try
            {

                DataProvider.Instance.OpenTransaction();
                SqlCommand cmd = new SqlCommand("UpdateALBUM", DataProvider.Instance.Getconnection());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaAlbum", maAlbum);
                cmd.Parameters["@MaAlbum"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@MaCTGC", mactgc);
                cmd.Parameters["@MaCTGC"].Direction = ParameterDirection.Input;


                cmd.Parameters.AddWithValue("@GiaAlbum", giaAlbum);
                cmd.Parameters["@GiaAlbum"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@NgayNhap", SqlDbType.Date);
                cmd.Parameters["@NgayNhap"].Direction = ParameterDirection.Input;
                cmd.Parameters["@NgayNhap"].Value = ngaynhap;

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
    }
}
