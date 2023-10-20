using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ChiTietPhieuNhapDAL : DatabaseDAL
    {

        public DataTable LayDSPhieuNhap(string mapn)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("select * from dbo.tblChiTietPhieuNhap where MaPN = @mapn", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mapn", mapn);
            cmd.Connection = conn;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;

        }
        public void AddChiTietPhieuNhap(ChiTietPhieuNhapDTO chiTietPhieuNhap)
        {
            OpenConnection();
            string query = "ThemPhieuTTPhieuNhap";
            SqlCommand command = new SqlCommand(query, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@mapn", chiTietPhieuNhap.Mapn);
            command.Parameters.AddWithValue("@masach", chiTietPhieuNhap.Masach);
            command.Parameters.AddWithValue("@gianhap", chiTietPhieuNhap.Gianhap);
            command.Parameters.AddWithValue("@giaban", chiTietPhieuNhap.Giaban);
            command.Parameters.AddWithValue("@soluong", chiTietPhieuNhap.Soluong);
            command.ExecuteNonQuery();

        }
        public bool XoaChiTietPhieuNhap(string mapn, string masach)
        {

            OpenConnection();
            SqlCommand cmd = new SqlCommand("XoaChiTietHoaDonNhap", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@MaHoaDon", mapn);
            cmd.Parameters.AddWithValue("@MaSanPham", masach);
            int kq = cmd.ExecuteNonQuery();
            return kq > 0;

        }

    }
}
