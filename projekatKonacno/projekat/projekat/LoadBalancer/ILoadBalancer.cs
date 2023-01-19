using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projekat.LoadBalancer;
using projekat.Worker;
using projekat.writer;

namespace projekat.loadBalancer
{
    public interface ILoadBalancer
    {
        void StoreInDescriptionList(Item it, int ID);
        Description LoadFromBuffer();
        string LogMsg(String str);
        void StoreInBuffer(DescriptionList descList, int workerID);
        bool TurnOffWorker(IWorker wk);
        bool TurnOnWorker(IWorker wk);


    }
}
