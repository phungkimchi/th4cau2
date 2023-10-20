using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTHoaDonDTO
    {
        private string mahd;
        private string masach;
        private int soluong;
        private float thanhtien;

        public CTHoaDonDTO(string mahd, string masach, int soluong, float thanhtien)
        {
            this.Mahd = mahd;
            this.Masach = masach;
            this.Soluong = soluong;
            this.Thanhtien = thanhtien;
        }
        public CTHoaDonDTO()
        { }
        public string Mahd { get => mahd; set => mahd = value; }
        public string Masach { get => masach; set => masach = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public float Thanhtien { get => thanhtien; set => thanhtien = value; }
    }
}
