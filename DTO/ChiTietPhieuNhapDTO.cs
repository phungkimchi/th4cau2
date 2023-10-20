using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPhieuNhapDTO
    {
        private string mapn;
        private string masach;
        private float gianhap;
        private float giaban;
        private int soluong;

        public ChiTietPhieuNhapDTO(string mapn, string masach, float gianhap, float giaban, int soluong)
        {
            this.Mapn = mapn;
            this.Masach = masach;
            this.Gianhap = gianhap;
            this.Giaban = giaban;
            this.Soluong = soluong;
        }
        public ChiTietPhieuNhapDTO()
        {

        }
        public ChiTietPhieuNhapDTO(DataRow row)
        {
            this.Mapn = row["MaPN"].ToString();
            this.Masach = row["MaSach"].ToString();
            this.Soluong = Convert.ToInt32(row["SoLuong"].ToString());
            this.Gianhap = Convert.ToSingle(row["GiaNhap"].ToString());
            this.Giaban = Convert.ToSingle(row["GiaBan"].ToString());

        }


        public string Mapn { get => mapn; set => mapn = value; }
        public string Masach { get => masach; set => masach = value; }
        public float Gianhap { get => gianhap; set => gianhap = value; }
        public float Giaban { get => giaban; set => giaban = value; }
        public int Soluong { get => soluong; set => soluong = value; }
    }
}
