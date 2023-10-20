using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DTO
{
    public class SachDTO
    {
        private string masach;
        private string tensach;
        private string matl;
        private string manxb;
        private string matg;
        private int slt;
        private float giaban;

        public string Masach { get => masach; set => masach = value; }
        public string Tensach { get => tensach; set => tensach = value; }
        public string Matl { get => matl; set => matl = value; }
        public string Manxb { get => manxb; set => manxb = value; }
        public string Matg { get => matg; set => matg = value; }
        public int Slt { get => slt; set => slt = value; }
        public float Giaban { get => giaban; set => giaban = value; }

        public SachDTO(string masach, string tensach, string matl, string manxb, string matg, int slt, float giaban)
        {
            this.Masach = masach;
            this.Tensach = tensach;
            this.Matl = matl;
            this.Manxb = manxb;
            this.Matg = matg;
            this.Slt = slt;
            this.Giaban = giaban;
        }
        public SachDTO(DataRow row)
        {
            this.Masach = row["MaSach"].ToString();
            this.Tensach = row["TenSach"].ToString();
        }
        public SachDTO()
        {

        }

     

    }
}
