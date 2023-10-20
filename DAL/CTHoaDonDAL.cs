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
    public class CTHoaDonDAL : DatabaseDAL
    {
        public DataTable LayDSHoaDonDAL(string mahd)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("select * from dbo.tblChiTietHoaDon where MaHD = @mahd", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mahd", mahd);
            cmd.Connection = conn;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;

        }
        public void AddCTHoaDonDAL(CTHoaDonDTO ct)
        {
            OpenConnection();
            string query = "ThemCTHoaDon";
            SqlCommand command = new SqlCommand(query, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@mahd", ct.Mahd);
            command.Parameters.AddWithValue("@masach", ct.Masach);
            command.Parameters.AddWithValue("@soluong", ct.Soluong);
            command.Parameters.AddWithValue("@thanhtien", ct.Thanhtien);
            command.ExecuteNonQuery();

        }
        public bool XoaCTHoaDon(string mahd, string masach)
        {

            OpenConnection();
            SqlCommand cmd = new SqlCommand("XoaCTHoaDon", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@MaHoaDon", mahd);
            cmd.Parameters.AddWithValue("@MaSach", masach);
            int kq = cmd.ExecuteNonQuery();
            return kq > 0;

        }
        public DataTable GetDSInHoaDon(string mahd)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand("PrintHoaDon", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@mahd", mahd);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
