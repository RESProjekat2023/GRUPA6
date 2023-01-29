using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using projekatERS.LoadBalancer;
using System.Threading.Tasks;

namespace projekatERS
{
    public class Service : IPotrosnjaBrojilo
    {   
        private static LoadBalancerImpl load = null;


        public Service()
        {
            if (load == null)
            {
                load = new LoadBalancerImpl();
            }
        }

        public Service(LoadBalancerImpl loada)
        {
            if(load == null)
            {
                load = loada;
            }
        }

        public void IskljcuiWorkera()
        {
            load.UkljuciWorkera();
        }

        public void Recive(PotrosnjaBrojilo pb)
        {
            load.Recive(pb);
        }

        public void UkljuciWorkera()
        {
            load.IskljcuiWorkera();
        }

        public LoadBalancerImpl GetLoadBalancer() { return load; }
    }
}
