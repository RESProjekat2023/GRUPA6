using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using projekatERS.DataBaseCRUD;
using projekatERS.LoadBalancer;
using projekatERS.Worker;

namespace UnitTestsLoadBalancer
{
    [TestFixture]
    public class LoadBalancerTest
    {
        private DataBaseCRUDImpl dataBaseCRUD;
        private WorkerPool workerPool;
        private Mock<WorkerPool> workerPoolMock;
        private LoadBalancerImpl loadBalancerImpl;

        [SetUp]
        public void SetUp()
        {
            var dataBaseCRUDV = new Mock<DataBaseCRUDImpl>();
            dataBaseCRUD = dataBaseCRUDV.Object;
            workerPoolMock = new Mock<WorkerPool>(dataBaseCRUDV.Object);
            workerPool = workerPoolMock.Object;
            var loadBalancerV = new LoadBalancerImpl();
            loadBalancerImpl = loadBalancerV;
        }
        
        [Test]
        public void TestRecive()
        {
            // Arrange
           

           // Assert.True(false);

            for(int i = 0; i < 9; i++)
            {
                var potrosnjaBrojilo = new PotrosnjaBrojilo(1, i, 10*i, 2);
                loadBalancerImpl.Recive(potrosnjaBrojilo);
                Assert.True(loadBalancerImpl.GetPotrosnjaBrojilos().Count == i + 1);
                Assert.NotNull(loadBalancerImpl.GetPotrosnjaBrojilos()[i]);

            }
            var potrosnjaBrojilo1 = new PotrosnjaBrojilo(1, 10, 10 * 9, 2);
            loadBalancerImpl.Recive(potrosnjaBrojilo1);
            Assert.True(loadBalancerImpl.GetPotrosnjaBrojilos().Count == 0);



        }
    }
}
