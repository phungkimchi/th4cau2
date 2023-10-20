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
    public class TacGiaBLL 

    {
        public TacGiaDAL tgdal = new TacGiaDAL();

        public DataTable LayDanhSachTacGiaBLL()
        {
            return tgdal.LayTacGiaDAL();
        }
        public bool XoaTacGiaBLL(string matg)
        {
            return tgdal.XoaTacGiaDAL(matg);
        }
        public bool ThemTacGiaBLL(string matg, string tentg, string sdt)
        {
            if (tgdal.CheckTacGia(matg))
            {
                tgdal.ThemTacGiaDAL(matg, tentg, sdt);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SuaTacGiaBLL(string manxb, string tennxb, string sdt)
        {
            return tgdal.SuaTacGiaDAL(manxb, tennxb, sdt);
        }

    }
}
