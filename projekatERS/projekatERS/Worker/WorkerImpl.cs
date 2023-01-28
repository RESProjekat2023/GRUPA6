using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Threading;
using projekatERS.DataBaseCRUD;

namespace projekatERS.Worker
{
    public class WorkerImpl
    {
        private bool zauzet;

        private List<PotrosnjaBrojilo> potrosnjaBrojila;
        private DataBaseCRUDImpl dataBaseCRUDImpl;
        private Thread workerThread;
        private WorkerPool WorkerPool { get; set; }

        private readonly object lockObject = new object();

        public bool Zauzet { get => zauzet; set => zauzet = value; }
        public List<PotrosnjaBrojilo> PotrosnjaBrojila { get => potrosnjaBrojila; set => potrosnjaBrojila = value; }
        public WorkerImpl(DataBaseCRUDImpl dataBaseCRUDImpl, WorkerPool workerPool)
        {
            this.Zauzet = false;
            this.PotrosnjaBrojila = new List<PotrosnjaBrojilo>();
            this.dataBaseCRUDImpl = dataBaseCRUDImpl;
            WorkerPool = workerPool;
            workerThread = new Thread(WorkerLoop);
            workerThread.Start();
        }

        private void WorkerLoop()
        {
            while (true)
            {
                Monitor.Enter(lockObject);
                WriteToDataBase();
                Monitor.Wait(lockObject);
                Monitor.Exit(lockObject);

            }
        }

        public void RecieveFromLoadBalancer(List<PotrosnjaBrojilo> potrosnjaBrojilaLB)
        {

           
            if (potrosnjaBrojilaLB == null)
            {

                return;
            }
            if (potrosnjaBrojilaLB.Count() != 10)
            {
                Console.WriteLine(potrosnjaBrojilaLB.Count());
                Console.WriteLine("Nije poslato 10 komada");
                return;
            }
            Monitor.Enter(lockObject);
            PotrosnjaBrojila.AddRange(potrosnjaBrojilaLB);
            Zauzet = true;
            Monitor.Pulse(lockObject);
            Monitor.Exit(lockObject);


        }

        public void WriteToDataBase()
        {
            if (dataBaseCRUDImpl == null)
            {
                Console.WriteLine("Database je null u workeru");
                return;
            }
            if (potrosnjaBrojila.Count() != 0)
            {

                foreach (PotrosnjaBrojilo pb in potrosnjaBrojila)
                {
                    dataBaseCRUDImpl.InsertPotrosnjaBrojilo(pb);
                    
                }
                potrosnjaBrojila.Clear();
                Zauzet = false;
                WorkerPool.OneIsFree();
            }


        }
    }
}