using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Writer
{
    public class UIImpl
    {
        private WriterImpl writer;
        //private DataBaseAnaliticsImpl dataBaseAnaliticsImpl;

        public UIImpl(WriterImpl writerImpl)
        {
            writer = writerImpl;
        }
        public void Meni()
        {

            bool uslov = true;
            int unos;
            while (uslov)
            {

                Console.WriteLine("Izaberite opciju opciju:");
                Console.WriteLine("1.Random generisanje stanja brojila");
                Console.WriteLine("2.Manuelni unos podataka");
                Console.WriteLine("3.Ukljuci Workera");
                Console.WriteLine("4.Iskljuci Workera");
                Console.WriteLine("5.Izlaz");
                unos = Int32.Parse(Console.ReadLine());


                switch (unos)
                {
                    case 1:
                        {
                            Console.WriteLine("\n**Generisanje podataka zapoceto**\n");
                            writer.GenerisiPodatke();

                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("**Manuelni unos podatka**");
                            writer.ManuelniUnos();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\n**Ukljici Workera**\n");
                            writer.UkjluciWorkera();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("\n**Iskljuci Workera**\n");
                            writer.IskljuciWorkera();
                            break;
                        }
                    case 5:
                        {
                            uslov = false;
                            break;
                        }
                    default:
                        Console.WriteLine("\n**");
                        Console.WriteLine("\n\nUneli ste nepostojecu opciju!!!Pokusajte ponovo.\n\n");
                        Console.WriteLine("**\n");
                        break;
                }
            }
        }
    }
}
