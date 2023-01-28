using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
using projekatERS.DataBaseCRUD;
using projekatERS.Worker;

namespace projekatERS.LoadBalancer
{
    public class LoadBalancerImpl : IPotrosnjaBrojilo
    {
        private List<PotrosnjaBrojilo> potrosnjaBrojilaBuffer = new List<PotrosnjaBrojilo>();
        private static WorkerPool workerPool;
        private readonly object lockObject = new object();
        private bool workeriUkljuceni = true;
        private readonly object lockUkljuceni = new object();

        public void UkljuceniSet(bool vrednost) {
            Monitor.Enter(lockUkljuceni);
            workeriUkljuceni = vrednost;
            Monitor.Exit(lockUkljuceni);
        }
        public bool UkljuceniGet() 
        {
            Monitor.Enter(lockUkljuceni);
            bool vr = workeriUkljuceni; 
            Monitor.Exit(lockUkljuceni);
            return vr;
        }

        
        public LoadBalancerImpl()
        {
            DataBaseCRUDImpl dataBaseCRUDImpl = new DataBaseCRUDImpl();
            Console.WriteLine("AAA");
            if(workerPool== null)
            {
                workerPool = new WorkerPool(dataBaseCRUDImpl);
            }
        }

        public void Recive(PotrosnjaBrojilo pb)
        {
            AddToBuffer(pb);
            if (!UkljuceniGet())      //mora sinhronizacija za bool
            {
                return;
            }
            Monitor.Enter(lockObject);      //gde ce wait da bude u loadbalancer
            if (potrosnjaBrojilaBuffer.Count < 10)
            {
                Monitor.Exit(lockObject);
                return;
            }

            Monitor.Exit(lockObject);
            WorkerImpl worker = workerPool.FindFirstFree();
            worker.RecieveFromLoadBalancer(Get10Potrosnja());


        }

        private void AddToBuffer(PotrosnjaBrojilo pb)
        {
            Monitor.Enter(lockObject);
            Console.WriteLine("ubacena potrosnja trnutni br je " + potrosnjaBrojilaBuffer.Count);
            potrosnjaBrojilaBuffer.Add(pb);
            Monitor.Exit(lockObject);
        }
        private List<PotrosnjaBrojilo> Get10Potrosnja()
        {
            Monitor.Enter(lockObject);
            List<PotrosnjaBrojilo> potrosnje = new List<PotrosnjaBrojilo>(potrosnjaBrojilaBuffer.Take(10));
            potrosnjaBrojilaBuffer.RemoveRange(0, 10);
            Monitor.Exit(lockObject);
            return potrosnje;
        }


        public void UkljuceniWorkeri(bool ukljuceni)
        {
            Monitor.Enter(lockObject);
            Console.WriteLine("Workeri su " + ukljuceni);
            UkljuceniSet(ukljuceni);
            if (ukljuceni)
            {
                while(potrosnjaBrojilaBuffer.Count >= 10)   //zakljucati
                {
                    WorkerImpl worker = workerPool.FindFirstFree();
                    worker.RecieveFromLoadBalancer(Get10Potrosnja());
                }
            }
            Monitor.Exit(lockObject);
        }

        public void UkljuciWorkera()
        {
            UkljuceniWorkeri(true);
        }

        public void IskljcuiWorkera()
        {
            UkljuceniWorkeri(false);
        }
    }

}