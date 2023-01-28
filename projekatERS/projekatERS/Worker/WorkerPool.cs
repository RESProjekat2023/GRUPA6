using projekatERS.DataBaseCRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace projekatERS.Worker
{
    public class WorkerPool
    {
        private List<WorkerImpl> workerPool;
        private readonly object lockObject = new object();



        public WorkerPool(DataBaseCRUDImpl dataBaseCRUDImpl)
        {

            workerPool = new List<WorkerImpl>();

            Console.WriteLine("************ trebalo bi jednom");
            for (int i = 0; i < 10; i++)
            {
                WorkerImpl wI = new WorkerImpl(dataBaseCRUDImpl, this);
                workerPool.Add(wI);

            }
        }

        private WorkerImpl GetFirstFreeWorker()
        {
            foreach (WorkerImpl wI in workerPool)
            {
                if (!wI.Zauzet)
                {
                    return wI;
                }
            }
            return null;
        }


        public WorkerImpl FindFirstFree()
        {
            Monitor.Enter(lockObject);
            WorkerImpl worker;
            while (true)
            {
                worker = GetFirstFreeWorker();
                if (worker != null)
                {
                    break;
                }
                Monitor.Wait(lockObject);
            }

            worker.Zauzet = true;
            Monitor.Exit(lockObject);
            return worker;
        }

        public void OneIsFree()
        {
            Monitor.Enter(lockObject);
            Monitor.Pulse(lockObject);
            Monitor.Exit(lockObject);
        }

    }
}