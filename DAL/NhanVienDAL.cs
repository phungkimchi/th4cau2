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
    public class NhanVienDAL : DatabaseDAL
    {
        public DataTable LayDanhSachNVDAL()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("LayDSNhanVienVer2", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;

        }
        public bool CheckNV(string manv)
        {
            bool isUnique = false;
            OpenConnection();
            string query = string.Format("SELECT COUNT(*) FROM tblNhanVien WHERE MaNV = '{0}'", manv);
            SqlCommand command = new SqlCommand(query, conn);
            int count = (int)command.ExecuteScalar();
            isUnique = count == 0;
            return isUnique;


        }
        public bool ThemNhanVienDAL(NhanVienDTO nv)
        {
            OpenConnection();
            bool isSuccess = false;
            SqlCommand cmd = new SqlCommand("ThemNV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@manv", nv.Manv);
            cmd.Parameters.AddWithValue("@tennv", nv.Tennv);
            cmd.Parameters.AddWithValue("@gt", nv.Gt);
            cmd.Parameters.AddWithValue("@ngaysinh", nv.Ngaysinh);
            cmd.Parameters.AddWithValue("@diachi", nv.Diachi);
            cmd.Parameters.AddWithValue("@sdt", nv.Sdt);
            cmd.Parameters.AddWithValue("@email", nv.Email);
            cmd.Parameters.AddWithValue("@anh", nv.Anh);

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
            conn.Close();
            return isSuccess;

        }
        public void SuaNhanVienDAL(NhanVienDTO nv)
        {
            OpenConnection();

            SqlCommand cmd = new SqlCommand("SuaNVVer3", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@manv", nv.Manv);
            cmd.Parameters.AddWithValue("@tennv", nv.Tennv);
            cmd.Parameters.AddWithValue("@gt", nv.Gt);
            cmd.Parameters.AddWithValue("@ngaysinh", nv.Ngaysinh);
            cmd.Parameters.AddWithValue("@diachi", nv.Diachi);
            cmd.Parameters.AddWithValue("@sdt", nv.Sdt);
            cmd.Parameters.AddWithValue("@email", nv.Email);
            cmd.Parameters.AddWithValue("@anh", nv.Anh);
            cmd.ExecuteNonQuery();

        }
        public bool XoaNhanVienDAL(string manv)
        {

            OpenConnection();
            SqlCommand cmd = new SqlCommand("XoaNV", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@manv", SqlDbType.Char, 10);
            cmd.Parameters["@manv"].Value = manv;
            int kq = cmd.ExecuteNonQuery();
            return kq > 0;

        }
        public List<NhanVienDTO> GetNV()
        {

            List<NhanVienDTO> ds = new List<NhanVienDTO>();

            OpenConnection();
            string query = "SELECT MaNV, TenNV FROM tblNhanVien";

            SqlCommand command = new SqlCommand(query, conn);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                NhanVienDTO s = new NhanVienDTO();
                s.Manv = reader["MaNV"].ToString();
                s.Tennv = reader["TenNV"].ToString();
                ds.Add(s);
            }

            reader.Close();


            return ds;
        }
    }
}
