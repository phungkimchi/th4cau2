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
    public class TKHoaDonDAL : DatabaseDAL
    {
        public DataTable BaoCaoThang(DateTime ngaystart, DateTime ngayend)
        {
            OpenConnection();
            string sql = "[dbo].[ThongKeHoaDonTheoThang]";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ngaystart", ngaystart);
            cmd.Parameters.AddWithValue("@ngayend", ngayend);

            cmd.Connection = conn;
            DataTable s = new DataTable();
            SqlDataAdapter a = new SqlDataAdapter(cmd);
            a.Fill(s);
            return s;
        }
        public DataTable ThongKeTheoTheLoai(DateTime ngaystart, DateTime ngayend)
        {
            OpenConnection();
            string sql = "[dbo].[ThongKeTheoTheLoai]";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ngaystart", ngaystart);
            cmd.Parameters.AddWithValue("@ngayend", ngayend);

            cmd.Connection = conn;
            DataTable s = new DataTable();
            SqlDataAdapter a = new SqlDataAdapter(cmd);
            a.Fill(s);
            return s;
        }




    }
}
