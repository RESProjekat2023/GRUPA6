using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatERS
{
    public interface IDataBaseCrud
    {
        void Connect();
        SqlConnection ConnectAnalitics();
        void Close();
        DataTable FindById(int id_brojila);
        int Count();
        int CountPotrosnja();
        void Insert();
        void InsertBrojilo(Brojilo brojilo);
        void UpdateBrojilo(Brojilo brojilo);
        void DeleteBrojilo(int idBrojila);
        void InsertPotrosnjaBrojilo(PotrosnjaBrojilo potrosnjaBrojila);
        void UpdatePotrosnjaBrojilo(PotrosnjaBrojilo potrosnjaBrojila);
        void DeletePotrosnjaBrojilo(int idPotrosnjaBrojila);
        void DeleteAllPotrosnjaBrojilo();
        List<String> GetCities();
        List<String> GetCitiesTest();
        List<int> GetIdBrojila();
        List<int> PotrosnjaGrad(string grad);
        List<int> PotrosnjaIdBrojila(int id);
    }
}
