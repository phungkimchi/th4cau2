using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TacGiaDTO
    {
        private string matg;
        private string tentg;
        private string sdt;

        public TacGiaDTO(string matg, string tentg, string sdt)
        {
            this.Matg = matg;
            this.Tentg = tentg;
            this.Sdt = sdt;
        }
        public TacGiaDTO()
        {

        }

        public string Matg { get => matg; set => matg = value; }
        public string Tentg { get => tentg; set => tentg = value;}
        public string Sdt { get => sdt; set => sdt = value; }
    }
}
