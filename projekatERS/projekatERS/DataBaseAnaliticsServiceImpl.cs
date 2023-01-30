using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using projekatERS.DataBaseCRUD;

namespace projekatERS
{
    public class DataBaseAnaliticsServiceImpl : IDataBaseAnaliticsService,IDataBaseAnalitics
    {
        private DataBaseCRUDImpl dataBaseCRUDImpl;

        public DataBaseAnaliticsServiceImpl()
        {
            this.dataBaseCRUDImpl = new DataBaseCRUDImpl();
        }

        public List<string> GetGradove()
        {
            List<string> list = new List<string>();
            list = dataBaseCRUDImpl.GetCities();
            return list;

        }

        public List<int> GetIdijeve()
        {
            List<int> list = new List<int>();
            list = dataBaseCRUDImpl.GetIdBrojila();
            return list;
        }

        public List<int> GetPotrosnjaBrojilo(int id)
        {
            List<int> list = new List<int>();  
            list=dataBaseCRUDImpl.PotrosnjaIdBrojila(id);
            return list;
        }

        public List<int> GetPotrosnjaZaGrad(string grad)
        {
            List<int> list = new List<int>();
            list = dataBaseCRUDImpl.PotrosnjaGrad(grad);
            return list;
        }
    }
}
