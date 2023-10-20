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
    public class SachDAL : DatabaseDAL
    {
        public DataTable LayDSSach()
        {
            OpenConnection();
            string sql = "SELECT * FROM tblSach";
            SqlCommand cmd = new SqlCommand(sql, conn);
            // cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
        public bool CheckMaSach(string masach)
        {
            OpenConnection();
            bool isUnique = false;

            string query = string.Format("SELECT COUNT(*) FROM tblSach WHERE MaSach = '{0}'", masach);
            SqlCommand command = new SqlCommand(query, conn);
            int count = (int)command.ExecuteScalar();
            isUnique = count == 0;
            return isUnique;

        }
        public bool AddBook(SachDTO book)
        {
            OpenConnection();
          

            string query = "INSERT INTO tblSach (MaSach, TenSach, MaTL,MaNXB,MaTG,SLTon,GiaBan) VALUES (@masach, @tensach, @matl,@manxb,@matg,@slt,@giaban)";

            SqlCommand command = new SqlCommand(query, conn);
            command.Connection = conn;
            command.Parameters.AddWithValue("@masach", book.Masach);
            command.Parameters.AddWithValue("@tensach", book.Tensach);
            command.Parameters.AddWithValue("@matl", book.Matl);
            command.Parameters.AddWithValue("@manxb", book.Manxb);
            command.Parameters.AddWithValue("@matg", book.Matg);
            command.Parameters.AddWithValue("@slt", book.Slt);
            command.Parameters.AddWithValue("@giaban", book.Giaban);


            int rowsAffected = command.ExecuteNonQuery();

            // Kiểm tra số dòng bị ảnh hưởng để xác định kết quả
            if (rowsAffected > 0)
            {
                return true; // Thêm sách thành công
            }
            else
            {
                return false; // Thêm sách thất bại
            }

        }
        public bool SuaSachDAL(SachDTO sach)
        {
            OpenConnection();

            SqlCommand cmd = new SqlCommand("SuaSach", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@masach", sach.Masach);
            cmd.Parameters.AddWithValue("@tensach", sach.Tensach);
            cmd.Parameters.AddWithValue("@matl", sach.Matl);
            cmd.Parameters.AddWithValue("@manxb", sach.Manxb);
            cmd.Parameters.AddWithValue("@matg", sach.Matg);
            cmd.Parameters.AddWithValue("@slt", sach.Slt);
            cmd.Parameters.AddWithValue("@giaban", sach.Giaban);

            int rowsAffected = cmd.ExecuteNonQuery();

            // Kiểm tra số dòng bị ảnh hưởng để xác định kết quả
            if (rowsAffected > 0)
            {
                return true; // Thêm sách thành công
            }
            else
            {
                return false; // Thêm sách thất bại
            }
        }
        public bool XoaSachDAL(string masach)
        {

            OpenConnection();
            SqlCommand cmd = new SqlCommand("XoaSach", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@masach", SqlDbType.Char, 10);
            cmd.Parameters["@masach"].Value = masach;
            int kq = cmd.ExecuteNonQuery();
            return kq > 0;

        }

        public List<TacGiaDTO> GetTacGia()
        {

            List<TacGiaDTO> danhSachTacGia = new List<TacGiaDTO>();

            OpenConnection();
            string query = "SELECT MaTG, TenTG FROM tblTacGia";

            SqlCommand command = new SqlCommand(query, conn);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TacGiaDTO tacGia = new TacGiaDTO();
                tacGia.Matg = reader["MaTG"].ToString();
                tacGia.Tentg = reader["TenTG"].ToString();
                danhSachTacGia.Add(tacGia);
            }

            reader.Close();


            return danhSachTacGia;
        }
        public string GetMaTacGiaFromTenTacGia(string tentg)
        {
            // Truy vấn cơ sở dữ liệu để lấy mã tác giả dựa trên tên tác giả
            OpenConnection();
            string matg = string.Empty;

            string query = "SELECT MaTG FROM tblTacGia WHERE TenTG = @TenTG";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@TenTG", tentg);
            command.Connection = conn;

            object result = command.ExecuteScalar();
            if (result != null)
            {
                matg = result.ToString();
            }


            return matg;
        }

        public List<SachDTO> GetSach()
        {

            List<SachDTO> ds = new List<SachDTO>();

            OpenConnection();
            string query = "SELECT MaSach, TenSach,GiaBan FROM tblSach";

            SqlCommand command = new SqlCommand(query, conn);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SachDTO s = new SachDTO();
                s.Masach = reader["MaSach"].ToString();
                s.Tensach = reader["TenSach"].ToString();
                s.Giaban = Convert.ToSingle(reader["GiaBan"].ToString());
                ds.Add(s);
            }

            reader.Close();


            return ds;
        }
    }
}
