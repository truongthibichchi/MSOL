using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MSOL.DAO
{
    public class DataProvider
    {
        private static DataProvider instance; 

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        //private string connectionSTR = "Data Source=.\\sqlexpress;Initial Catalog=MSOL;Integrated Security=True";
         public static string sqlServerType { get; set; }
         private string connectionSTR = "Data Source=" +".\\SQLEXPRESS" + "; AttachDbFilename=" + Application.StartupPath + "\\QUANLYTHUVIEN_Nhom7_14521100_15520048_15520062_15520115.mdf" + ";Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";

        //----  insert, update for tables (use sqlcommand to saved image to database)
        public SqlConnection conn = new SqlConnection();
        private DataProvider() 
        {
            conn = createConnection();
        }

        private SqlConnection createConnection()
        {
            return new SqlConnection(connectionSTR);
        }


        public SqlConnection Getconnection()
        {
            return conn;
        }

        public bool OpenTransaction()
        {
            try
            {
                conn.Open();
            }
            catch //(Exception e)
            {
                conn.Close();
                return false;
            }
            return true;
        }

        public void CloseTransaction()
        {
            conn.Close();
        }
        
        //-------end--------
        

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }
    }
}
