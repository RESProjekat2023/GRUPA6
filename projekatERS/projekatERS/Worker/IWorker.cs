using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatERS.Worker
{
    public interface IWorker
    {
        void RecieveFromLoadBalancer(List<PotrosnjaBrojilo> potrosnjaBrojilaLB);
        void WriteToDataBase();
    }
}
