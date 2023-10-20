using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        private string mahd;
        private DateTime ngaylap;
        private float tongtien;
        private string makh;
        private string manv;

        public string Mahd { get => mahd; set => mahd = value; }
        public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }
        public float Tongtien { get => tongtien; set => tongtien = value; }
        public string Makh { get => makh; set => makh = value; }
        public string Manv { get => manv; set => manv = value; }

        public HoaDonDTO(string mahd, DateTime ngaylap, float tongtien, string makh, string manv)
        {
            this.Mahd = mahd;
            this.Ngaylap = ngaylap;
            this.Tongtien = tongtien;
            this.Makh = makh;
            this.Manv = manv;
        }
        public HoaDonDTO()
        {

        }


    }
}
