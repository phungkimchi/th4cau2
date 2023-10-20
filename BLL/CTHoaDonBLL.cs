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
    public class CTHoaDonBLL
    {

        public CTHoaDonDAL ctdal = new CTHoaDonDAL();
        public DataTable GetDSChiTietHDBLL(string mahd)
        {
            return ctdal.LayDSHoaDonDAL(mahd);
        }
        public void AddChiTietHDBLL(CTHoaDonDTO ct)
        {
            ctdal.AddCTHoaDonDAL(ct);

        }
        public bool XoaCTHoaDonBLL(string mahd, string masach)
        {
            return ctdal.XoaCTHoaDon(mahd, masach);
        }
        public DataTable InHoaDonBLL(string mahd)
        {
            return ctdal.GetDSInHoaDon(mahd);
        }

    }
}
