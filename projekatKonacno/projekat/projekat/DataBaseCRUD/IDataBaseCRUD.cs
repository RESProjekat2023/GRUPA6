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



    }   
}
