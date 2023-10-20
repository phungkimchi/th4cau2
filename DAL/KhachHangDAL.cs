using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangDAL : DatabaseDAL
    {
        public DataTable LayDSKhachHang()
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("LayDSKhachHang", conn);
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

        public bool CheckKhachHang(string makh)
        {
            string query = string.Format("SELECT COUNT(*) FROM tblKhachHang WHERE MaKH = '{0}'", makh);
            SqlCommand command = new SqlCommand(query, conn);
            int count = (int)command.ExecuteScalar();
            return count <= 0;
        }


        public void TheKhachHangDAL(string makh, string tenkh, string sdt)
        {

            OpenConnection();
            SqlCommand cmd = new SqlCommand("ThemKhachHang", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@makh", makh);
            cmd.Parameters.AddWithValue("@tenkh", tenkh);
            cmd.Parameters.AddWithValue("@sdt", sdt);
            cmd.ExecuteNonQuery();
            conn.Close();


        }
        public void SuaKhachHangDAL(KhachHangDTO kh)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("SuaKhachHang", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@makh", SqlDbType.Char, 10);
            cmd.Parameters.Add("@tenkh", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar, 50);

            cmd.Parameters["@makh"].Value = kh.Makh;
            cmd.Parameters["@tenkh"].Value = kh.Tenkh;
            cmd.Parameters["@sdt"].Value = kh.Sdt;

            cmd.ExecuteNonQuery();
            conn.Close();


        }
        public void XoaKhachHangDAL(string makh)
        {

            OpenConnection();
            SqlCommand cmd = new SqlCommand("XoaKhachHang", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@makh", SqlDbType.Char, 10);
            cmd.Parameters["@makh"].Value = makh;
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public List<KhachHangDTO> GetKH()
        {

            List<KhachHangDTO> ds = new List<KhachHangDTO>();

            OpenConnection();
            string query = "SELECT MaKH, TenKH FROM tblKhachHang";

            SqlCommand command = new SqlCommand(query, conn);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                KhachHangDTO s = new KhachHangDTO();
                s.Makh = reader["MaKH"].ToString();
                s.Tenkh = reader["TenKH"].ToString();
                ds.Add(s);
            }

            reader.Close();


            return ds;
        }
    }
}