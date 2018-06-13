using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSOL.DTO;
using System.Data;

namespace MSOL.DAO
{
    public class GoiChupDAO
    {
       private static GoiChupDAO _instance;
       public static GoiChupDAO Instance
       {
           get
           {
               if (_instance == null)
               {
                   _instance = new GoiChupDAO();
               }
               return _instance;
           }
           private set { _instance = value; }
       }

       public List<GoiChup> GetGoichupList()
       {
           List<GoiChup> list = new List<GoiChup>();
           DataTable table = DataProvider.Instance.ExecuteQuery("select MaGoiChup, Loai, DiaDiem, GiaTien, TinhTrang, MaLoaiGC, TenLoaiGC from GOICHUP, LOAIGOICHUP where GOICHUP.Loai=LOAIGOICHUP.MaLoaiGC");
           foreach (DataRow row in table.Rows)
           {
               GoiChup gc = new GoiChup(row);
               list.Add(gc);
           }
           return list;
       }

       public int getLoaigcByMaGoichup(int magc)
       {
           return (int)DataProvider.Instance.ExecuteScalar(string.Format("select Loai from GOICHUP where MaGoiChup = {0}", magc));
       }
       public string GetTenloaigoichupByMaloaigoichup(int maloaigc)
       {
           return (string)DataProvider.Instance.ExecuteScalar(string.Format("select TenLoaiGC from LOAIGOICHUP where MaLoaiGC = {0}", maloaigc));
       }

       public string getDiadiemByMagoichup(int magc)
       {
           return (string)DataProvider.Instance.ExecuteScalar(string.Format("select DiaDiem from GOICHUP where MaGoiChup= {0}", magc));
       }
       public bool checkDuplicateGoichup(string diadiem, int giatien)
       {
           var query = string.Format("select * from GOICHUP where DiaDiem =N\'{0}\' and GiaTien={1} and TinhTrang=N'Đang sử dụng'", diadiem, giatien);
           DataTable table = DataProvider.Instance.ExecuteQuery(query);
           return table.Rows.Count > 0;
       }
       public bool AddGoichup(int loai, string diadiem, int giatien)
       {
           var query = string.Format("insert into GOICHUP(Loai, DiaDiem, GiaTien) values ({0}, N\'{1}\', {2})", loai, diadiem, giatien);
           var result = DataProvider.Instance.ExecuteNonQuery(query);
           return result > 0;
           
       }

       public bool UpdateGoichup(int magoichup, int loai, string diadiem, int giatien)
       {
           var query = string.Format("update GOICHUP set Loai={0}, DiaDiem =N\'{1}\', Giatien ={2} where MaGoiChup ={3}", loai, diadiem, giatien, magoichup);
           var result = DataProvider.Instance.ExecuteNonQuery(query);
           return result > 0;
       }

       public bool DeleteGoichup(int magoichup)
       {
           var query = string.Format("update GOICHUP set TinhTrang=N'Hết sử dụng' where MaGoiChup ={0}", magoichup);
           var result = DataProvider.Instance.ExecuteNonQuery(query);
           return result > 0;
       }

       public List<GoiChup> GetGoichupListByLoaigc(int maloaigc)
       {
           List<GoiChup> list = new List<GoiChup>();
           var query = string.Format("select * from GOICHUP where Loai={0} and TinhTrang=N'Đang sử dụng'", maloaigc);
           DataTable table = DataProvider.Instance.ExecuteQuery(query);
           foreach (DataRow row in table.Rows)
           {
               GoiChup gc = new GoiChup(row);
               list.Add(gc);
           }
           return list;
       }


       //public List<GoiChup> GetGoichupByDiaDiem(int loaigc, string diadiem)
       //{
       //    List<GoiChup> list = new List<GoiChup>();
       //    var query = string.Format("select * from GOICHUP where Loai={0} and DiaDiem=N\'{1}\' and TinhTrang=N'Đang sử dụng'", loaigc, diadiem);
       //    DataTable table = DataProvider.Instance.ExecuteQuery(query);
       //    foreach (DataRow row in table.Rows)
       //    {
       //        GoiChup gc = new GoiChup(row);
       //        list.Add(gc);
       //    }
       //    return list;
       //}

       public GoiChup GetgoichupByMagc(int magc)
       {
           var query = string.Format("select * from GOICHUP where MaGoiCHup = '{0}'", magc);
           var dataTable = DataProvider.Instance.ExecuteQuery(query);

           var goichup = dataTable.Rows[0];

           if (goichup != null)
           {
               return new GoiChup(goichup);
           }

           return null;
       }

    }
}
