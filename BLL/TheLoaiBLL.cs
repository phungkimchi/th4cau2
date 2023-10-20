using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;

namespace BLL
{
    public class TheLoaiBLL
    {
        public TheLoaiDAL tldal = new TheLoaiDAL();
        public DataTable LayTheLoaiBLL()
        {
            return tldal.LayTheLoaiDAL();
        }
     
        public bool ThemTheLoaiBLL(string matl, string tentl)
        {
            if (tldal.check(matl))
            {
               
                tldal.ThemTheLoaiDAL(matl, tentl);
                return true;
            }
            else
            {
                return false;
            }
            

        }
        
        public void SuaTheLoaiBLL(TheLoaiDTO theloai)
        {
            tldal.SuaTheLoaiDAL(theloai);

        }
        public void XoaTheLoai(string matl)
        {
            tldal.XoaTheLoaiDAL(matl);
        }
        public List<TheLoaiDTO> LayTlTrongSach()
        {
            return tldal.LayTlTrongSachDAL().ToList();
        }
    }
}
