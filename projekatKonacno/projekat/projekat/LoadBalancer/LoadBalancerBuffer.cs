using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projekat.Worker;

namespace projekat.LoadBalancer
{
	public class LoadBalancerBuffer
	{
		private List<IWorker> workers; 
		public List<Description> lbBuff;
		public LoadBalancerBuffer(List<IWorker> wo)
		{
			lbBuff = new List<Description>();
			workers = wo;
		}

		~LoadBalancerBuffer()
		{

		}


		public void SendToWorker(int workerID)
		{
			if (lbBuff != null)
			{
				if (workerID == 0) 
					workerID = 1;
				workers[workerID - 1].WorkerRepack(lbBuff[0]); 
				lbBuff.RemoveAt(0);
			}

		}

		public List<Description> LbBuff { get => lbBuff; set => lbBuff = value; }
	}
}
