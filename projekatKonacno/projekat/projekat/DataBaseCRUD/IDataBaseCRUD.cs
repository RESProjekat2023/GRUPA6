using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.dataBaseCRUD
{
    public interface IDataBaseCRUD
    {


        void Connect();
        void Close();
        DataTable FindById(int id_brojila);
        int Count();
        void Insert();

        void Update(int id_brojila, string ime_korisnika, string prezime_korisnika, string ulica, int broj, int postanski_broj, string grad);
        void Delete(int id_brojila);


    }   
}
