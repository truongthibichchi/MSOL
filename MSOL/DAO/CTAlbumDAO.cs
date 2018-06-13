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
   public  class CTAlbumDAO
    {
       private static CTAlbumDAO _instance;
       public static CTAlbumDAO Instance
       {
           get
           {
               if (_instance == null)
               {
                   _instance = new CTAlbumDAO();
               }
               return _instance;
           }
           private set { _instance = value; }
       }

       public List<CTAlbum> GetCTalbumListByMaAlbum(int maAlbum)
       {
           List<CTAlbum> list = new List<CTAlbum>();
           DataTable table = DataProvider.Instance.ExecuteQuery(string.Format("select * from CTALBUM where MaAlbum={0}", maAlbum));
           foreach (DataRow row in table.Rows)
           {
               CTAlbum ctalbum = new CTAlbum(row);
               list.Add(ctalbum);
           }
           return list;
       }

       public bool InsertCTalbum(int MaAlbum, byte[] HinhAnh)
       {

           int result = 0;
           try
           {

               DataProvider.Instance.OpenTransaction();
               SqlCommand cmd = new SqlCommand("InsertCTALBUM", DataProvider.Instance.Getconnection());
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.AddWithValue("@MaAlbum", MaAlbum);
               cmd.Parameters["@MaAlbum"].Direction = ParameterDirection.Input;

               cmd.Parameters.Add("@HinhAnh", SqlDbType.Image);
               cmd.Parameters["@HinhAnh"].Direction = ParameterDirection.Input;
               cmd.Parameters["@HinhAnh"].Value = HinhAnh;

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


       public bool DeleteCTAlbum(int MaCTalbum)
       {
           var query = string.Format("delete from CTALBUM where MaCTAlbum ={0}", MaCTalbum);
           var result = DataProvider.Instance.ExecuteNonQuery(query);
           return result > 0;
       }

    }
}
