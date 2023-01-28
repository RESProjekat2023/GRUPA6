using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IPotrosnjaBrojilo
    {
        [OperationContract]
         void Recive(PotrosnjaBrojilo pb);
        [OperationContract]
        void UkljuciWorkera();
        [OperationContract]
        void IskljcuiWorkera();
        
    }
}

