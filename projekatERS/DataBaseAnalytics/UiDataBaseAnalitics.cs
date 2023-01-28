using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAnalytics
{
    public class UiDataBaseAnalitics
    {
        private DataBaseAnalitics dataBaseAnalitics;
        public UiDataBaseAnalitics()
        {
            dataBaseAnalitics=new DataBaseAnalitics();
        }
        public void Meni()
        {
            bool uslov = true;
            int unos;

            while (uslov)
            {
                Console.WriteLine("Izaberite opciju:");
                Console.WriteLine("1.Izvestaj po gradovima:");
                Console.WriteLine("2.Izvestaj po brojilima:");
                Console.WriteLine("3.Ispisi sve gradove");
                Console.WriteLine("4.Ispisi sve Idijeve bojila");
                Console.WriteLine("5.Izlaz");
                unos = Int32.Parse(Console.ReadLine());

                switch (unos)
                {
                    case 1:
                        {
                            Console.WriteLine("\n*****************Izvestaj po gradovima*****************\n");
                            dataBaseAnalitics.Izvestaj1();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\n*****************Izvestaj po Idijevima brojila*****************\n");
                            dataBaseAnalitics.Izvestaj2();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\n*****************Svi Gradovi*****************\n");
                            dataBaseAnalitics.SviGradovi();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("\n*****************Svi Idijevi Brojila*****************\n");
                            dataBaseAnalitics.SviIdijevi();
                            break;
                        }
                    case 5:
                        {
                            uslov = false;
                            break;
                        } 
                    default:
                        {
                            Console.WriteLine("Uneli ste nepostojecu opciju");
                            break;
                        }


                }

            }
        }
    }
}
