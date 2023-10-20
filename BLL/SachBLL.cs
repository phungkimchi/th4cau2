using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAL;

namespace BLL
{
    public class SachBLL
    {
        public SachDAL sdal = new SachDAL();
        public DataTable LayDSSachBLL()
        {
            return sdal.LayDSSach();
        }
        public bool CheckMaSachBLL(string masach)
        {
            // Gọi phương thức từ lớp DataAccess để kiểm tra tính duy nhất của mã sách
            bool isUnique = sdal.CheckMaSach(masach);
            return isUnique;
        }
        public bool ThemSachBLL(SachDTO s)
        {
            return sdal.AddBook(s);

        }
        public void SuaSachBLL(SachDTO sach)
        {
            sdal.SuaSachDAL(sach);
        }
        public bool XoaSachBLL(string masach)
        {
            return sdal.XoaSachDAL(masach);
        }
     
     
        public List<TacGiaDTO> LayDanhSachTacGiaBLL()
        {
            return sdal.GetTacGia();
        }
        public List<SachDTO> GetSachBLL()
        {
            return sdal.GetSach();
        }
     
    }
}
