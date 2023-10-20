using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TheLoaiDTO
    {
        private string matl;
        private string tentl;

        public TheLoaiDTO(string matl, string tentl)
        {
            this.matl = matl;
            this.tentl = tentl;
        }
        public TheLoaiDTO()
        {

        }

        public string Matl { get => matl; set => matl = value; }
        public string Tentl { get => tentl; set => tentl = value; }
        
    }
}
