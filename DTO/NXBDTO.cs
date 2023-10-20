using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NXBDTO
    {
        private string maNXB;
        private string tenNXB;
        private string diachi;
        private string sdt;

        public string MaNXB { get => maNXB; set => maNXB = value; }
        public string TenNXB { get => tenNXB; set => tenNXB = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public NXBDTO()
        {

        }

        public NXBDTO(string maNXB, string tenNXB, string diachi, string sdt)
        {
            this.maNXB = maNXB;
            this.tenNXB = tenNXB;
            this.diachi = diachi;
            this.sdt = sdt;
        }
    }
}
