using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;


namespace BLL
{
 
    public class DangNhapBLL
    {
        //Gọi các phương thức của lớp DataAccessLayer để kiểm tra thông tin đăng nhập và lấy quyền của người dùng.

        public DangNhapDAL dangnhap = new DangNhapDAL();
       
        public bool CheckLoginBLL(string madn, string matkhau)
        {
            return dangnhap.CheckLoginDAL(madn, matkhau);
        }
        public string LayQuyenBLL(string madn)
        {
            return dangnhap.LayQuyenDAL(madn);
        }

    }
}
