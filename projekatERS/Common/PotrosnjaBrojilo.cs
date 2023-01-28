using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PotrosnjaBrojilo
    {
        private int idBrojila;
        private int id;
        private int potrosnja;
        private int mesec;

        public PotrosnjaBrojilo(int idBrojila, int id, int potrosnja, int mesec)
        {
            this.IdBrojila = idBrojila;
            this.Id = id;
            this.Potrosnja = potrosnja;
            this.Mesec = mesec;
        }
        public PotrosnjaBrojilo() { }

        public int IdBrojila { get => idBrojila; set => idBrojila = value; }
        public int Id { get => id; set => id = value; }
        public int Potrosnja { get => potrosnja; set => potrosnja = value; }
        public int Mesec { get => mesec; set => mesec = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("**Potrosnja**");
            sb.AppendLine($"ID BROJILA:{idBrojila}\tID:{id}\tPOTROSNJA:{potrosnja}\tMESEC:{mesec}");
            return sb.ToString();
        }
    }
}
