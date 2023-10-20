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
    public class PhieuNhapDAL : DatabaseDAL
    {
        public List<PhieuNhapDTO> GetPhieuNhapList()
        {
            OpenConnection();
            List<PhieuNhapDTO> phieuNhapList = new List<PhieuNhapDTO>();


            string query = "SELECT * FROM tblPhieuNhap";
            SqlCommand command = new SqlCommand(query, conn);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                PhieuNhapDTO phieuNhap = new PhieuNhapDTO();
                phieuNhap.Mapn = reader["MaPN"].ToString();
                phieuNhap.Ngaylap = Convert.ToDateTime(reader["NgayLap"]);
                phieuNhap.Tongtien = Convert.ToSingle(reader["TongTien"]);
                phieuNhapList.Add(phieuNhap);
            }
            reader.Close();

            return phieuNhapList;

        }
        public void AddPhieuNhap(PhieuNhapDTO phieuNhap)
        {
            string query = "INSERT INTO tblPhieuNhap (MaPN, NgayLap, TongTien) VALUES (@mapn, @ngaylap, @tongtien)";
            SqlCommand command = new SqlCommand(query, conn);
            command.Connection= conn;
            command.Parameters.AddWithValue("@mapn", phieuNhap.Mapn);
            command.Parameters.AddWithValue("@ngayLap", phieuNhap.Ngaylap);
            command.Parameters.AddWithValue("@tongTien", phieuNhap.Tongtien);
            
            command.ExecuteNonQuery();

        }
        public bool XoaPhieuNhap(string mapn)
        {

            OpenConnection();
            SqlCommand cmd = new SqlCommand("delete from tblPhieuNhap where MaPN= @mapn", conn);
            cmd.Connection = conn;
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mapn", SqlDbType.Char, 10);
            cmd.Parameters["@mapn"].Value = mapn;
            int kq = cmd.ExecuteNonQuery();
            return kq > 0;

        }
        public bool CheckMaPN(string mapn)
        {
            OpenConnection();
            bool isUnique = false;
            string query = string.Format("SELECT COUNT(*) FROM tblPhieuNhap WHERE MaPN = '{0}'", mapn);
            SqlCommand command = new SqlCommand(query, conn);
            command.Connection = conn;
            int count = (int)command.ExecuteScalar();
            isUnique = count == 0;
            return isUnique;
        }

    }
}
