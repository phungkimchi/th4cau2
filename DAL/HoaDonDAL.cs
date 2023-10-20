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
    public class HoaDonDAL : DatabaseDAL
    {

        public List<HoaDonDTO> GetHoaDonDAL()
        {
            OpenConnection();
            List<HoaDonDTO> list = new List<HoaDonDTO>();


            string query = "SELECT * FROM tblHoaDon";
            SqlCommand command = new SqlCommand(query, conn);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                HoaDonDTO hd = new HoaDonDTO();
                hd.Mahd = reader["MaHD"].ToString();
                hd.Ngaylap = Convert.ToDateTime(reader["NgayLap"]);
                hd.Tongtien = Convert.ToSingle(reader["TongTien"]);
                hd.Manv = reader["MaNV"].ToString();
                hd.Makh = reader["MaKH"].ToString();

                list.Add(hd);
            }
            reader.Close();

            return list;

        }
        public void AddHoaDonDAL(HoaDonDTO hd)
        {
            string query = "INSERT INTO tblHoaDon (MaHD, MaKH,MaNV, NgayLap, TongTien) VALUES (@mahd,@makh,@manv, @ngaylap, @tongtien)";
            SqlCommand command = new SqlCommand(query, conn);
            command.Connection = conn;
            command.Parameters.AddWithValue("@mahd", hd.Mahd);
            command.Parameters.AddWithValue("@ngaylap", hd.Ngaylap);
            command.Parameters.AddWithValue("@tongtien", hd.Tongtien);
            command.Parameters.AddWithValue("@makh", hd.Makh);
            command.Parameters.AddWithValue("@manv", hd.Manv);
            command.ExecuteNonQuery();

        }
        public bool XoaHoaDonDAL(string mahd)
        {

            OpenConnection();
            SqlCommand cmd = new SqlCommand("delete from tblHoaDon where MaHD= @mahd", conn);
            cmd.Connection = conn;
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mahd", SqlDbType.Char, 10);
            cmd.Parameters["@mahd"].Value = mahd;
            int kq = cmd.ExecuteNonQuery();
            return kq > 0;

        }
        public bool CheckMaHD(string mahd)
        {
            OpenConnection();
            bool isUnique = false;
            string query = string.Format("SELECT COUNT(*) FROM tblHoaDon WHERE MaHD = '{0}'", mahd);
            SqlCommand command = new SqlCommand(query, conn);
            command.Connection = conn;
            int count = (int)command.ExecuteScalar();
            isUnique = count == 0;
            return isUnique;
        }

        public DataTable SearchNgayLapHD(DateTime ngaylap)
        {

            OpenConnection();
            SqlCommand command = new SqlCommand("SearchNgayLap", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@ngaylap", ngaylap);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;

        }

    }
}
