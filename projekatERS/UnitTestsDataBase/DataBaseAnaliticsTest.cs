using Common;
using Moq;
using NUnit.Framework;
using projekatERS;
using projekatERS.DataBaseCRUD;
using projekatERS.LoadBalancer;
using projekatERS.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writer;

namespace UnitTestsDataBase
{
    [TestFixture]
    public  class DataBaseAnaliticsTest
    {
        private DataBaseCRUDImpl dataBaseCRUD;

        [SetUp]
        public void SetUp()
        {


            var dataBaseCRUDV = new Mock<DataBaseCRUDImpl>();
            dataBaseCRUD = dataBaseCRUDV.Object;



        }


        [Test]
        public void TestGenerisiPodatke()
        {

            dataBaseCRUD.DeleteAllPotrosnjaBrojilo();
            PotrosnjaBrojilo pb = new PotrosnjaBrojilo(1,2,1234,2);
            PotrosnjaBrojilo pb1 = new PotrosnjaBrojilo(2, 2, 1234, 2);
            PotrosnjaBrojilo pb2 = new PotrosnjaBrojilo(1, 4, 1234, 2);
            dataBaseCRUD.InsertPotrosnjaBrojilo(pb);
            dataBaseCRUD.InsertPotrosnjaBrojilo(pb1);
            dataBaseCRUD.InsertPotrosnjaBrojilo(pb2);

            List<string> gradovi=dataBaseCRUD.GetCitiesTest();

            Assert.True(gradovi.Count==1);
            List<int> idijevi = dataBaseCRUD.GetIdBrojila();
            Assert.True(idijevi.Count==10);

            List<int> potrosnje = dataBaseCRUD.PotrosnjaIdBrojila(1);

            Assert.True(potrosnje[0] == pb.Potrosnja + pb2.Potrosnja);










        }

    }
}
