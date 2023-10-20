using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhapDTO
    {
        private string mapn;
        private DateTime ngaylap;
        private float tongtien;

        public PhieuNhapDTO(string mapn, DateTime ngaylap, float tongtien)
        {
            this.Mapn = mapn;
            this.Ngaylap = ngaylap;
            this.Tongtien = tongtien;
        }
        public PhieuNhapDTO()
        {

        }

        public string Mapn { get => mapn; set => mapn = value; }
        public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }
        public float Tongtien { get => tongtien; set => tongtien = value; }
    }
}
