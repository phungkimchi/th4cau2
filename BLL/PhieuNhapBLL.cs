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
    public class PhieuNhapBLL
    {
        PhieuNhapDAL pndal = new PhieuNhapDAL();
        public List<PhieuNhapDTO> GetPhieuNhapBLL()
        {
            return pndal.GetPhieuNhapList();
        
        }
        public void AddPhieuNhapBLL(PhieuNhapDTO pn)
        {
            pndal.AddPhieuNhap(pn);

        }
        public bool CheckMaPNhBLL(string mapn)
        {
            // Gọi phương thức từ lớp DataAccess để kiểm tra tính duy nhất của mã pn
            bool isUnique = pndal.CheckMaPN(mapn);
            return isUnique;
        }
        public bool XoaPNBLL(string mapn)
        {
            return pndal.XoaPhieuNhap(mapn);
        }

    }
}
