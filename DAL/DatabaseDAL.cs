using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DatabaseDAL
    {
        string sql = @"Data Source=Admin\MSSQLSERVER01;Initial Catalog=Đồ_Án_1_Test_2;Integrated Security=True";
        protected SqlConnection conn = null;
        public void OpenConnection()
        {
            if (conn == null)
            {
                conn = new SqlConnection(sql);
            }    
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }    
        }
        public void CloseConnection()
        {
            if (conn != null && conn.State==ConnectionState.Open)
            {
                conn.Close();
            }    
        }
    }
}
