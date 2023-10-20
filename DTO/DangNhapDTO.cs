using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DangNhapDTO
    {
        private string madn;
        private string tendn;
        private string matkhau;
        private string quyen;

        public DangNhapDTO(string madn, string tendn, string matkhau, string quyen)
        {
            this.Madn = madn;
            this.Tendn = tendn;
            this.Matkhau = matkhau;
            this.Quyen = quyen;
        }
        public DangNhapDTO()
        {

        }    

        public string Madn { get => madn; set => madn = value; }
        public string Tendn { get => tendn; set => tendn = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public string Quyen { get => quyen; set => quyen = value; }
    }
}
