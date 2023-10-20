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
    public class NXBDAL : DatabaseDAL
    {
        public DataTable LayDanhSachNXBDAL()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("Select * from tblNXB", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;

        }
        public bool checkNXB(string manxb)
        {
            string query = string.Format("SELECT COUNT(*) FROM tblNXB WHERE MaNXB = '{0}'", manxb);
            SqlCommand command = new SqlCommand(query, conn);
            int count = (int)command.ExecuteScalar();
            return count <= 0;
        }
        public bool ThemNXBDAL(string manxb, string tennxb,string dc, string sdt)
        {
            OpenConnection();
            bool isSuccess = false;
            SqlCommand cmd = new SqlCommand("ThemNXB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@manxb", manxb);
            cmd.Parameters.AddWithValue("@tennxb", tennxb);
            cmd.Parameters.AddWithValue("@diachi", dc);
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
        public bool XoaNXBDAL(string manxb)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "XoaNXB";
            cmd.Connection = conn;
            cmd.Parameters.Add("@manxb", SqlDbType.Char, 10).Value = manxb;
            int kq = cmd.ExecuteNonQuery();
            return kq > 0;

        }
        public bool SuaNXBDAL(string manxb, string tennxb, string dc, string sdt)
        {
            OpenConnection();
            bool isSuccess = false;
            SqlCommand cmd = new SqlCommand("SuaNXB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@manxb", manxb);
            cmd.Parameters.AddWithValue("@tennxb", tennxb);
            cmd.Parameters.AddWithValue("@diachi",dc );
            cmd.Parameters.AddWithValue("@sdt", sdt);
           
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    isSuccess = true;
                }
         
        
            return isSuccess;
           
        }
        public List<NXBDTO> LayNXBTrongSachDAL()
        {

            OpenConnection();
            List<NXBDTO> nxb = new List<NXBDTO>();

            string query = "Select MaNXB,TenNXB from tblNXB";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                NXBDTO tl = new NXBDTO()
                {
                    MaNXB = reader["MaNXB"].ToString(),
                    TenNXB = reader["TenNXB"].ToString(),
                };
                nxb.Add(tl);
            }
            return nxb;


        }

    }

}
