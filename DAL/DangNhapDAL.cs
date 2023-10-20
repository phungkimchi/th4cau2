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
    public class DangNhapDAL : DatabaseDAL
    {

        public string LayQuyenDAL(string madn)
        {

            OpenConnection();
            string query = "SELECT Quyen FROM DangNhap WHERE MaDN = @madn";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@madn", madn);

            string quyen = (string)command.ExecuteScalar();
            return quyen;

        }
        public bool CheckLoginDAL(string madn, string matkhau)
        {
            
            OpenConnection();
            string query = "SELECT COUNT(*) FROM DangNhap WHERE MaDN = @madn AND MatKhau = @matkhau ";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@madn", madn);
            cmd.Parameters.AddWithValue("@matkhau", matkhau);

            //cmd.Parameters.AddWithValue("@quyen", quyen);
            cmd.Connection = conn;
            int count = (int)cmd.ExecuteScalar();
            return count > 0;


        }

    }

}

