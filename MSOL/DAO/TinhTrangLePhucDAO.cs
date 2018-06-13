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
    
     public class TinhTrangLePhucDAO
    {
         private static TinhTrangLePhucDAO _instance;
         public static TinhTrangLePhucDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TinhTrangLePhucDAO();
                }
                return _instance;
            }
            private set { _instance = value; }
        }

         private TinhTrangLePhucDAO() { }

         public List<TinhTrangLePhuc> gettinhtranglist()
         {
             List<TinhTrangLePhuc> list = new List<TinhTrangLePhuc>();
             var query = "select * from TINHTRANG ";
              DataTable data =DataProvider.Instance.ExecuteQuery(query);
             foreach (DataRow row in data.Rows)
             {
                 TinhTrangLePhuc tinhtrang = new TinhTrangLePhuc(row);
                 list.Add(tinhtrang);
             }
             return list;
         }

         
         public string GetTentihtrangByMatinhtrang(int matinhtrang)
         {
            
             var query = string.Format("select TenTinhTrang from TINHTRANG where MaTinhTrang = {0}", matinhtrang);
             return (string)DataProvider.Instance.ExecuteScalar(query);
           
         }
    }
}
