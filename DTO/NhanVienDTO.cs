using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DTO
{
    public class NhanVienDTO
    {
        private string manv;
        private string tennv;
        private string gt;
        private DateTime ngaysinh;
        private string diachi;
        private string sdt;
        private string email;
        private byte[] anh;

        public NhanVienDTO(string manv, string tennv, string gt, DateTime ngaysinh, string diachi, string sdt, string email, byte[] anh)
        {
            this.Manv = manv;
            this.Tennv = tennv;
            this.Gt = gt;
            this.Ngaysinh = ngaysinh;
            this.Diachi = diachi;
            this.Sdt = sdt;
            this.Email = email;
            this.Anh = anh;
        }
        public NhanVienDTO()
        {

        }
        public NhanVienDTO(DataRow row)
        {
            this.Manv = row["MaNV"].ToString();
            this.Tennv = row["TenNV"].ToString();
        }
        public string Manv { get => manv; set => manv = value; }
        public string Tennv { get => tennv; set => tennv = value; }
        public string Gt { get => gt; set => gt = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public byte[] Anh { get => anh; set => anh = value; }
    }
}
