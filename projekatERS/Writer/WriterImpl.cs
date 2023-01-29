using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;
using System.Threading;

namespace Writer
{
    public class WriterImpl
    {
       
        
        private IPotrosnjaBrojilo proxy= null;
        public WriterImpl() {
            ChannelFactory<IPotrosnjaBrojilo> channel =
                new ChannelFactory<IPotrosnjaBrojilo>("ServiceName");
            proxy = channel.CreateChannel();
        }

        public WriterImpl(IPotrosnjaBrojilo iPotrosnja)
        {

            proxy = iPotrosnja;
        }
        public void GenerisiPodatke()
        {
            
               

            

            int potrosnja;
            Random random = new Random();
            bool uslov = true;
            while (uslov)
            {
                int idBrojila = random.Next(1, 11);
                int idPotrosnja = 0;
                for (int i = 1; i < 13; i++)
                {
                    if (Console.KeyAvailable)
                    {
                        uslov = false;
                        Console.ReadKey(false);
                        break;
                    }
                    potrosnja = random.Next(100, 1000);
                    PotrosnjaBrojilo pb = new PotrosnjaBrojilo(idBrojila, idPotrosnja, potrosnja, i);
                    Recieve(pb, proxy);
                    Console.WriteLine(pb.ToString());
                    Thread.Sleep(400);
                }

            }
        }

        public void GenerisiPodatkeTest(IPotrosnjaBrojilo balancer)
        {

            int potrosnja;
            Random random = new Random();
            bool uslov = true;
            int brojac = 0;
            while (uslov)
            {
                int idBrojila = random.Next(1, 11);
                int idPotrosnja = 0;
                for (int i = 1; i < 13; i++)
                {
                    
                    
                    potrosnja = random.Next(100, 1000);
                    PotrosnjaBrojilo pb = new PotrosnjaBrojilo(idBrojila, idPotrosnja, potrosnja, i);
                    balancer.Recive(pb);
                    Console.WriteLine(pb.ToString());
                    Thread.Sleep(400);
                    brojac++;
                    if (brojac == 15)
                    {
                        uslov = false;
                        break;
                    }
                }

            }
        }

        public void ManuelniUnos()
        {

            PotrosnjaBrojilo pb = new PotrosnjaBrojilo();


            Console.WriteLine("Unesite id brojila");
            pb.IdBrojila = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Unesite potrosnju");
            pb.Potrosnja = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Unesite mesec");
            pb.Mesec = Int32.Parse(Console.ReadLine());
            validacijaManual(pb.IdBrojila, pb.Mesec, pb.Potrosnja);
            Recieve(pb,proxy);
            //loadBalancerImpl.Recive(pb);
            Console.WriteLine(pb.ToString());


        }

        public void validacijaManual(int idBrojila, int mesec, int potrosnja)
        {
            // int id = DataBaseCRUDImpl.Count();

            if (idBrojila < 0 || idBrojila > 10)
            {
                Console.WriteLine("Neispravna vrednost id brojila");
                return;
            }
            else if (mesec < 0 || mesec > 12)
            {

                Console.WriteLine("Nesipravna vrednost mesec");
                return;
            }
            else if (potrosnja < 0)
            {
                Console.WriteLine("Neispravna vrednost potrosnja");
                return;
            }

        }

        public void Recieve(PotrosnjaBrojilo pb, IPotrosnjaBrojilo proxy)
        {
            proxy.Recive(pb);
        }

        public void UkjluciWorkera() {
            proxy.UkljuciWorkera();
        }
        public void IskljuciWorkera() {

            proxy.IskljcuiWorkera();

        }
    }
}
