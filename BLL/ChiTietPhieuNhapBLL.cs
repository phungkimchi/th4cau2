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
    public class ChiTietPhieuNhapBLL
    {
        public ChiTietPhieuNhapDAL ctdal = new ChiTietPhieuNhapDAL();
        public DataTable GetDSChiTietPN(string mapn)
        {
            return ctdal.LayDSPhieuNhap(mapn);
        }
        public void AddChiTietPhieuNhapBLL(ChiTietPhieuNhapDTO ct)
        {
            ctdal.AddChiTietPhieuNhap(ct);

        }
        public bool XoaCTPhieuNhap(string mapn, string masach)
        {
            return ctdal.XoaChiTietPhieuNhap(mapn, masach);
        }

    }
}
