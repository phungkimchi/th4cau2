using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BLL
{
    public class KhachHangBLL
    {
        public KhachHangDAL khdal = new KhachHangDAL();
        public DataTable LayKhachHangBLL()
        {
            return khdal.LayDSKhachHang();
        }

        public bool ThemKhachHangBLL(string makh, string tenkh,string sdt)
        {
            if (khdal.CheckKhachHang(makh))
            {

                khdal.TheKhachHangDAL(makh, tenkh,sdt);
                return true;
            }
            else
            {
                return false;
            }


        }

        public void SuaKhachHangBLL(KhachHangDTO kh)
        {
            khdal.SuaKhachHangDAL(kh);

        }
        public void XoaKhachHangBLL(string makh)
        {
            khdal.XoaKhachHangDAL(makh);
        }
        public List<KhachHangDTO> GetKHBLL()
        {
            return khdal.GetKH();
        }
    }
}
