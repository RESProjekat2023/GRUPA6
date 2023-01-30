using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatERS.LoadBalancer
{
    public interface ILoadBalancerR
    {
        void Recive(PotrosnjaBrojilo pb);
       
        void UkljuceniWorkeri(bool ukljuceni);
        void UkljuciWorkera();
        void IskljcuiWorkera();
    }
}
