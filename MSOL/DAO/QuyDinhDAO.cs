using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MSOL.DAO
{
    public class QuyDinhDAO
    {
        private static QuyDinhDAO _instance;
        public static QuyDinhDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new QuyDinhDAO();
                }
                return _instance;
            }
            private set { _instance = value; }
        }

        public int Sotiencoc()
        {
            return (int)DataProvider.Instance.ExecuteScalar("select SoTienCoc from QUYDINH");

        }

        public int SoLePhucToiDa()
        {
            return (int)DataProvider.Instance.ExecuteScalar("select SoLePhucToiDa from QUYDINH");
        }

        public int SoGoiChupToiDa()
        {
            return (int)DataProvider.Instance.ExecuteScalar("select SoGoiChupToiDa from QUYDINH");
        }

        public bool Update(int sotiencoc, int solephuc, int sogoichup)
        {

            int result = 0;
            try
            {

                DataProvider.Instance.OpenTransaction();
                SqlCommand cmd = new SqlCommand("UpdateQUYDINH", DataProvider.Instance.Getconnection());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SoTienCoc", sotiencoc);
                cmd.Parameters["@SoTienCoc"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@SoLePhucToiDa", solephuc);
                cmd.Parameters["@SoLePhucToiDa"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@SoGoiChupToiDa", sogoichup);
                cmd.Parameters["@SoGoiChupToiDa"].Direction = ParameterDirection.Input;


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
