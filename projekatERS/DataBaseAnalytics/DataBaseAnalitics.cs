using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAnalytics
{
    public class DataBaseAnalitics
    {
        private IDataBaseAnaliticsService proxy;

        public DataBaseAnalitics() {
            ChannelFactory<IDataBaseAnaliticsService> channel =
                    new ChannelFactory<IDataBaseAnaliticsService>("ServiceName");
             proxy = channel.CreateChannel();
        }



        public void SviGradovi()
        {
            List<string> lista = GetGradovi();
            foreach (string s in lista)
            {
                Console.WriteLine(s);
            }
        }

        public void SviIdijevi()
        {

            List<int> lista = GetIdijevi();
            string s1 = "";
            foreach (int s in lista)
            {
                s1 += s + "\t";
            }
            Console.WriteLine(s1);
        }



        public void Izvestaj1()
        {
            List<string> lista = GetGradovi();
            int brojac;
            string[] niz = {"Januar","Februar","Mart","April","Maj","Jun","Jul","Avgust","Septembar","Oktobar","Novembar","Decembar" };
            foreach (string s in lista)
            {
                brojac = 0;
                Console.WriteLine($"Grad {s}: ");
                List<int> potrosnja = GetPotrosnjaZaGrad(s);
                foreach (int i in potrosnja)
                {
                    Console.WriteLine($"\t{niz[brojac]}  {i} KWh");
                    brojac++;
                }
            }

        }
        public void Izvestaj2()
        {
            List<int> lista = GetIdijevi();
            int brojac;
            string[] niz = { "Januar", "Februar", "Mart", "April", "Maj", "Jun", "Jul", "Avgust", "Septembar", "Oktobar", "Novembar", "Decembar" };
            foreach (int i in lista)
            {
                brojac = 0;
                Console.WriteLine($"ID {i}: ");
                List<int> potrosnja = GetPotrosnjaBrojilo(i);
                foreach (int j in potrosnja)
                {
                    Console.WriteLine($"\t{niz[brojac]}  {j} KWh");
                    brojac++;
                }
            }

        }


        public List<string> GetGradovi()
        {
          return proxy.GetGradove();

        }
        public List<int> GetIdijevi( )
        {
          return  proxy.GetIdijeve();
        }



        public List<int> GetPotrosnjaBrojilo(int id)
        {
            return proxy.GetPotrosnjaBrojilo(id);
        }

        public List<int> GetPotrosnjaZaGrad(string grad)
        {
            return proxy.GetPotrosnjaZaGrad(grad);
        }



    }
}
