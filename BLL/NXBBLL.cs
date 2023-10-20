using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;

namespace BLL
{
    public class NXBBLL 
    {
        public NXBDAL nxbdal = new NXBDAL();
        public DataTable LayDanhSachNXBBLL()
        {
            return nxbdal.LayDanhSachNXBDAL();
        }
        public bool XoaNXBBLL(string manxb)
        {
            return nxbdal.XoaNXBDAL(manxb);
        }
        public bool ThemNXBBLL(string manxb, string tennxb, string dc, string sdt)
        {
            if (nxbdal.checkNXB(manxb))
            {
                nxbdal.ThemNXBDAL(manxb, tennxb, dc, sdt);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SuaNXBBLL(string manxb, string tennxb, string dc, string sdt)
        {
           return  nxbdal.SuaNXBDAL(manxb, tennxb, dc, sdt);
        }
        public List<NXBDTO> LayNXBTrongSachBLL()
        {
            return nxbdal.LayNXBTrongSachDAL().ToList();
        }
    }
}
