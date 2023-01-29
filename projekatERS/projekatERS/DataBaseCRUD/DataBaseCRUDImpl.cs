using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Common;

namespace projekatERS.DataBaseCRUD
{
    public class DataBaseCRUDImpl
    {
        private SqlConnection connection;
        private string connectionString;
        private string insertScript;
        private readonly object bazaLock = new object();

        public DataBaseCRUDImpl()
        {
            connectionString = "Data Source=DESKTOP-I7H8N20\\SQLEXPRESS;Initial Catalog=brojila;Integrated Security=True;";
            connection = new SqlConnection(connectionString);
            connection.Open();
            insertScript = File.ReadAllText("C:\\Users\\Helena\\Desktop\\GRUPA6\\inserts.sql");
        }

        public void Connect()
        {
            connection.Open();
        }
        public SqlConnection ConnectAnalitics()
        {
            
            return connection;
        }

        public void Close()
        {
            connection.Close();
        }



        public DataTable FindById(int id_brojila)
        {
            lock (bazaLock)
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

        public int CountPotrosnja()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM potrosnja_brojila";
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

        public void InsertBrojilo(Brojilo brojilo)
        {


            using (SqlCommand command = new SqlCommand())
            {

                command.Connection = connection;
                command.CommandText = "INSERT INTO brojilo (id_brojila,ime_korisnika,prezime_korisnika,ulica,broj,postanski_broj,grad) VALUES (@id_brojila,@ime_korisnika,@prezime_korisnika,@ulica,broj,@postanski_broj,@grad)";
                command.Parameters.AddWithValue("@id_brojila", brojilo.Id);
                command.Parameters.AddWithValue("@ime_korisnika", brojilo.ImeKorisnika);
                command.Parameters.AddWithValue("@prezime_korisnika", brojilo.PrezimeKorisnika);
                command.Parameters.AddWithValue("@ulica", brojilo.Ulica);
                command.Parameters.AddWithValue("@broj", brojilo.Broj);
                command.Parameters.AddWithValue("@postanski_broj", brojilo.PostanskiBroj);
                command.Parameters.AddWithValue("@grad", brojilo.Grad);

                connection.Open();
                int result = command.ExecuteNonQuery();

                // Check Error
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");
            }

        }

        public void UpdateBrojilo(Brojilo brojilo)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UPDATE brojilo SET ime_korisnika = @ime_korisnika, prezime_korisnika = @prezime_korisnika, ulica = @ulica, broj = @broj, postanski_broj = @postanski_broj, grad = @grad WHERE id_brojila = @id_brojila";
                command.Parameters.AddWithValue("@ime_korisnika", brojilo.ImeKorisnika);
                command.Parameters.AddWithValue("@prezime_korisnika", brojilo.PrezimeKorisnika);
                command.Parameters.AddWithValue("@ulica", brojilo.Ulica);
                command.Parameters.AddWithValue("@broj", brojilo.Broj);
                command.Parameters.AddWithValue("@postanski_broj", brojilo.PostanskiBroj);
                command.Parameters.AddWithValue("@grad", brojilo.Grad);
                command.Parameters.AddWithValue("@id_brojila", brojilo.Id);
                command.ExecuteNonQuery();
            }
        }
        public void DeleteBrojilo(int idBrojila)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM brojilo WHERE id_brojila = @id_brojila";
                command.Parameters.AddWithValue("@id_brojila", idBrojila);
                command.ExecuteNonQuery();
            }
        }

        public void InsertPotrosnjaBrojilo(PotrosnjaBrojilo potrosnjaBrojila)
        {
            using (SqlCommand command = new SqlCommand())
            {

                command.Connection = connection;
                command.CommandText = "INSERT INTO potrosnja_brojila (id_brojila,potrosnja,mesec) VALUES (@id_brojila,@potrosnja,@mesec)";
                command.Parameters.AddWithValue("@id_brojila", potrosnjaBrojila.IdBrojila);
                // command.Parameters.AddWithValue("@id_potrosnja", potrosnjaBrojila.Id);
                command.Parameters.AddWithValue("@potrosnja", potrosnjaBrojila.Potrosnja);
                command.Parameters.AddWithValue("@mesec", potrosnjaBrojila.Mesec);



                int result = command.ExecuteNonQuery();
               
                // Check Error
               // if (result < 0)
                    //Console.WriteLine("Error inserting data into Database!");
            }
        }

        public void UpdatePotrosnjaBrojilo(PotrosnjaBrojilo potrosnjaBrojila)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UPDATE brojilo SET id_brojila=@id_brojila,id_potrosnja=@id_potrosnja,potrosnja=@potrosnja,mesec=@mesec WHERE id_brojila = @id_brojila";
                command.Parameters.AddWithValue("@id_brojila", potrosnjaBrojila.IdBrojila);
                command.Parameters.AddWithValue("@id_potrosnja", potrosnjaBrojila.Id);
                command.Parameters.AddWithValue("@potrosnja", potrosnjaBrojila.Potrosnja);
                command.Parameters.AddWithValue("@mesec", potrosnjaBrojila.Mesec);

                command.ExecuteNonQuery();
            }
        }
        public void DeletePotrosnjaBrojilo(int idPotrosnjaBrojila)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM potrosnja_brojilo WHERE id_brojila = @id_brojila";
                command.Parameters.AddWithValue("@id_brojila", idPotrosnjaBrojila);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAllPotrosnjaBrojilo()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM potrosnja_brojila";
                command.ExecuteNonQuery();
            }
        }
        public List<String> GetCities()
        {

            using (SqlCommand command = new SqlCommand())
            {
                List<String> gradovi = new List<string>();
                command.Connection = connection;
                command.CommandText = "SELECT distinct(grad) FROM brojilo";
                using (SqlDataReader reader= command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        gradovi.Add(reader.GetString(0));
                    }
                    return gradovi;
                }




                
                // Check Error
               
            }
        }
        public List<String> GetCitiesTest()
        {

            using (SqlCommand command = new SqlCommand())
            {
                List<String> gradovi = new List<string>();
                command.Connection = connection;
                command.CommandText = "SELECT distinct(grad) FROM brojilo b,potrosnja_brojila pb where b.id_brojila=pb.id_brojila";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        gradovi.Add(reader.GetString(0));
                    }
                    return gradovi;
                }





                // Check Error

            }
        }

        public List<int> GetIdBrojila()
        {
            
            using (SqlCommand command = new SqlCommand())
            {
                List<int> idijevi = new List<int>(); 
                command.Connection= connection;
                command.CommandText = "SELECT id_brojila FROM brojilo ";
                using (SqlDataReader reader=command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idijevi.Add(reader.GetInt32(0));
                    }
                    return idijevi;
                }
            }
        }

        public List<int> PotrosnjaGrad(string grad)
        {
            using (SqlCommand command = new SqlCommand())
            {
                List<int> potrosnje=new List<int>();
                command.Connection = connection;
                command.CommandText = "SELECT sum(potrosnja) FROM brojilo b,potrosnja_brojila pb WHERE grad=@grad and b.id_brojila=pb.id_brojila group by mesec ";
                command.Parameters.AddWithValue("@grad",grad);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        potrosnje.Add(reader.GetInt32(0));
                    }
                    return potrosnje;
                }
            }


            
        }

        public List<int> PotrosnjaIdBrojila(int id)
        {
            using (SqlCommand command = new SqlCommand())
            {
                List<int> potrosnje = new List<int>();
                command.Connection = connection;
                command.CommandText = "SELECT sum(potrosnja) FROM brojilo b,potrosnja_brojila pb WHERE b.id_brojila=@id_brojila and b.id_brojila=pb.id_brojila group by mesec ";
                command.Parameters.AddWithValue("@id_brojila", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        potrosnje.Add(reader.GetInt32(0));
                    }
                    return potrosnje;
                }
            }


            
        }

        public int PotrosnjaGrad()
        {
            return 0;
        }




    }
}
