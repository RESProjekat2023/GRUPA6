using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.dataBaseCRUD
{
    public class DataBaseCRUDImpl : IDataBaseCRUD
    {
        private SqlConnection connection;
        private string connectionString;
        private string insertScript;

        public DataBaseCRUDImpl()
        {
            connectionString = "Data Source=(local);Initial Catalog=brojila;Integrated Security=True;";
            connection = new SqlConnection(connectionString);
            insertScript = File.ReadAllText("inserts.sql");
        }

        public void Connect()
        {
            connection.Open();
        }

        public void Close()
        {
            connection.Close();
        }

    
    
    public DataTable FindById(int id_brojila)
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM brojilo WHERE id_brojila = @id_brojila";
                    command.Parameters.AddWithValue("@id_brojila", id_brojila);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }

            public int Count()
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT COUNT(*) FROM brojilo";
                    return (int)command.ExecuteScalar();
                }
            }


            public void Insert()
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = insertScript;
                    command.ExecuteNonQuery();
                }
            }
        }
}

