using projekat.LoadBalancer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.Worker
{
    public interface IWorker
    {
        void WorkerRepack(Description description);
    }
}
