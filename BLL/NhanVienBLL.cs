using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;
using System.IO;
using System.Text.RegularExpressions;

namespace BLL
{
    public class NhanVienBLL
    {
        public NhanVienDAL nvdal = new NhanVienDAL();

        public DataTable LayDanhSachNVBLL()
        {
            return nvdal.LayDanhSachNVDAL();
        }
        public bool CheckMaNVBLL(string manv)
        {
            // Gọi phương thức từ lớp DataAccess để kiểm tra tính duy nhất của mã nhân viên
            bool isUnique = nvdal.CheckNV(manv);
            return isUnique;
        }
        public bool ThemNVBLL(NhanVienDTO nv)
        {
                if (nvdal.ThemNhanVienDAL(nv))
                {
                    return true;
                }
                else
                {
                    return false;
                }
           
        }
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^\d{10}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
        public bool IsValidEmail(string email)
        {
            string pattern = @"@gmail\.com$";
            return Regex.IsMatch(email, pattern);
        }
        public void SuaNVBLL(NhanVienDTO nv)
        {
            nvdal.SuaNhanVienDAL(nv);
        }
        public bool XoaNVBLL(string manv)
        {
            return nvdal.XoaNhanVienDAL(manv);
        }
        public List<NhanVienDTO> GetNVBLL()
        {
            return nvdal.GetNV();
        }
    }
}
