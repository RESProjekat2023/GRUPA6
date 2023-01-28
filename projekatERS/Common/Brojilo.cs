using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Brojilo
    {
        private int id;
        private string imeKorisnika;
        private string prezimeKorisnika;
        private string ulica;
        private int broj;
        private int postanskiBroj;
        private string grad;

        public Brojilo(int id, string imeKorisnika, string prezimeKorisnika, string ulica, int broj, int postanskiBroj, string grad)
        {
            this.Id = id;
            this.ImeKorisnika = imeKorisnika;
            this.PrezimeKorisnika = prezimeKorisnika;
            this.Ulica = ulica;
            this.Broj = broj;
            this.PostanskiBroj = postanskiBroj;
            this.Grad = grad;
        }
        public Brojilo() { }


        public int Id { get => id; set => id = value; }
        public string ImeKorisnika { get => imeKorisnika; set => imeKorisnika = value; }
        public string PrezimeKorisnika { get => prezimeKorisnika; set => prezimeKorisnika = value; }
        public string Ulica { get => ulica; set => ulica = value; }
        public int Broj { get => broj; set => broj = value; }
        public int PostanskiBroj { get => postanskiBroj; set => postanskiBroj = value; }
        public string Grad { get => grad; set => grad = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("**Brojilo**\n");
            sb.AppendLine($"ID:{Id}\tIME:{imeKorisnika}\tPREZIME:{prezimeKorisnika}\tULICA:{Ulica}\tBROJ:{Broj}\tPOSTANSKI BR.:{postanskiBroj}\tGRAD:{grad}");
            return sb.ToString();
        }
    }
}
