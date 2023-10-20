using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        private string makh;
        private string tenkh;
        private string sdt;
        public KhachHangDTO()
        {

        }    

        public KhachHangDTO(string makh, string tenkh, string sdt)
        {
            this.Makh = makh;
            this.Tenkh = tenkh;
            this.Sdt = sdt;
        }

        public string Makh { get => makh; set => makh = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public string Sdt { get => sdt; set => sdt = value; }
    }
}
