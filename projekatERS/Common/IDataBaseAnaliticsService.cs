using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IDataBaseAnaliticsService
    {
        [OperationContract]
        List<string> GetGradove();
        [OperationContract]
        List<int> GetIdijeve();
        [OperationContract]
        List<int> GetPotrosnjaZaGrad(string grad);
        [OperationContract]
        List<int> GetPotrosnjaBrojilo(int id);
    }
}
