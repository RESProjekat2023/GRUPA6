using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.dataBaseCRUD
{
    public class DataBaseCRUDImpl : IDataBaseCRUD
    {
        public SqliteConnection myConnection1;
        public SqliteConnection myConnection2;
        public DataBaseCRUDImpl()
        {
            try
            {
                myConnection1 = new SqliteConnection("Data Source=.//DataBaseCRUD//inserts.sql");

                myConnection2 = new SqliteConnection("Data Source=.//DataBaseCRUD//tables.sql");



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
