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
    public class HoaDonBLL
    {
        public HoaDonDAL hddal = new HoaDonDAL();
        public List<HoaDonDTO> GetHoaDonBLL()
        {
            return hddal.GetHoaDonDAL();

        }
        public void AddHoaDonBLL(HoaDonDTO hd)
        {
            hddal.AddHoaDonDAL(hd);

        }
        public bool CheckMaHDBLL(string mahd)
        {
            bool isUnique = hddal.CheckMaHD(mahd);
            return isUnique;
        }
        public bool XoaHoaDonBLL(string mahd)
        {
            return hddal.XoaHoaDonDAL(mahd);
        }
        public DataTable SearchNgayLapBLL(DateTime ngaylap)
        {
            return hddal.SearchNgayLapHD(ngaylap);
        }
    }
}
