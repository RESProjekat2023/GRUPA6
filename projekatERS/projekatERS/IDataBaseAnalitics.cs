using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatERS
{
    public interface IDataBaseAnalitics
    {
        List<string> GetGradove();
        List<int> GetIdijeve();
        List<int> GetPotrosnjaBrojilo(int id);
        List<int> GetPotrosnjaZaGrad(string grad);
    }
}
