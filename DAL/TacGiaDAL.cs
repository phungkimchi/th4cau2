using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class TacGiaDAL : DatabaseDAL
    {
        public DataTable LayTacGiaDAL()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("Select * from tblTacGia", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;

        }
        public bool CheckTacGia(string matg)
        {
            string query = string.Format("SELECT COUNT(*) FROM tblTacGia WHERE MaTG = '{0}'", matg);
            SqlCommand command = new SqlCommand(query, conn);
            int count = (int)command.ExecuteScalar();
            return count <= 0;
        }
        public bool ThemTacGiaDAL(string matg, string tentg, string sdt)
        {
            OpenConnection();
            bool isSuccess = false;
            SqlCommand cmd = new SqlCommand("ThemTacGia", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@matg", matg);
            cmd.Parameters.AddWithValue("@tentg", tentg);
            cmd.Parameters.AddWithValue("@sdt", sdt);
            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    isSuccess = true;
                }
            }
            catch
            {
                return false;
            }

            return isSuccess;

        }
        public bool XoaTacGiaDAL(string matg)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "XoaTacGia";
            cmd.Connection = conn;
            cmd.Parameters.Add("@matg", SqlDbType.Char, 10).Value = matg;
            int kq = cmd.ExecuteNonQuery();
            return kq > 0;

        }
        public bool SuaTacGiaDAL(string matg, string tentg, string sdt)
        {
            OpenConnection();
            bool isSuccess = false;
            SqlCommand cmd = new SqlCommand("SuaTacGia", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@matg", matg);
            cmd.Parameters.AddWithValue("@tentg", tentg);
            cmd.Parameters.AddWithValue("@sdt", sdt);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                isSuccess = true;
            }


            return isSuccess;

        }

    }
}
