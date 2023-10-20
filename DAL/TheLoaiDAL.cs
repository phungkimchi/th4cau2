using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
    public class TheLoaiDAL : DatabaseDAL
    {
        public DataTable LayTheLoaiDAL()
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("LayTheLoai", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public List<TheLoaiDTO> LayTlTrongSachDAL()
        {

            OpenConnection();
            List<TheLoaiDTO> theLoaiList = new List<TheLoaiDTO>();

            string query = "LayTheLoai";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                TheLoaiDTO tl = new TheLoaiDTO()
                {
                    Matl = reader["MaTL"].ToString(),
                    Tentl =reader["TenTL"].ToString(),
                };
                theLoaiList.Add(tl);
            }
            return theLoaiList;


        }

        public bool check(string matl)
        {
            string query = string.Format("SELECT COUNT(*) FROM tblTheLoai WHERE MaTL = '{0}'", matl);
            SqlCommand command = new SqlCommand(query, conn);
            int count = (int)command.ExecuteScalar();
            return count <= 0;
        }


        public void ThemTheLoaiDAL(string matl, string tentl)
        {

            OpenConnection();
            SqlCommand cmd = new SqlCommand("ThemTheLoai", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@matl", matl);
            cmd.Parameters.AddWithValue("@tentl", tentl);
            cmd.ExecuteNonQuery();
            conn.Close();


        }
        public void SuaTheLoaiDAL(TheLoaiDTO theloai)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("SuaDanhSachTheLoai", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@matl", SqlDbType.Char, 10);
            cmd.Parameters.Add("@tentl", SqlDbType.NVarChar, 20);
            cmd.Parameters["@matl"].Value = theloai.Matl;
            cmd.Parameters["@tentl"].Value = theloai.Tentl;
            cmd.ExecuteNonQuery();
            conn.Close();


        }
        public void XoaTheLoaiDAL(string matl)
        {

            OpenConnection();
            SqlCommand cmd = new SqlCommand("XoaTheLoai", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@matl", SqlDbType.Char, 10);
            cmd.Parameters["@matl"].Value = matl;
            cmd.ExecuteNonQuery();
            conn.Close();

        }

    }
}
