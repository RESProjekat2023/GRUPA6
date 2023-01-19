using projekat.LoadBalancer;
using projekat.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.loadBalancer
{
    public class LoadBalancerImpl : ILoadBalancer
    {
        public DescriptionList m_DescriptionList;
        public LoadBalancerBuffer m_LoadBalancerBuffer;
        private Random rnd = new Random();
        public List<int> takenIds;

        public void StoreInDescriptionList(Item it, int ID)
        {
            throw new NotImplementedException();
        }

        public Description LoadFromBuffer()
        {
            throw new NotImplementedException();
        }

        public string LogMsg(string str)
        {
            throw new NotImplementedException();
        }

        public void StoreInBuffer(DescriptionList descList, int workerID)
        {
            throw new NotImplementedException();
        }

        public bool TurnOffWorker(IWorker wk)
        {
            throw new NotImplementedException();
        }

        public bool TurnOnWorker(IWorker wk)
        {
            throw new NotImplementedException();
        }
    }
}
