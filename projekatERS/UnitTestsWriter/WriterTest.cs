using Moq;
using NUnit.Framework;
using projekatERS.DataBaseCRUD;
using projekatERS.LoadBalancer;
using projekatERS.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Writer;
using System.ServiceModel;
using projekatERS;

namespace UnitTestsWriter
{
    [TestFixture]
    public class WriterTest
    {
        private DataBaseCRUDImpl dataBaseCRUD;
        private WorkerPool workerPool;
        private Mock<WorkerPool> workerPoolMock;
        private LoadBalancerImpl loadBalancerImpl;
        private Mock<WriterImpl> writerImplMock;
        private WriterImpl writer;
        private Service service;

        [SetUp]
        public void SetUp()
        {
            
            
            var dataBaseCRUDV = new Mock<DataBaseCRUDImpl>();
            dataBaseCRUD = dataBaseCRUDV.Object;
            workerPoolMock = new Mock<WorkerPool>(dataBaseCRUDV.Object);
            workerPool = workerPoolMock.Object;
            var loadBalancerV = new LoadBalancerImpl();
            loadBalancerImpl = loadBalancerV;
            service = new Service(loadBalancerImpl);




            writer = new WriterImpl(null);
            
        }


        [Test]
        public void TestGenerisiPodatke()
        {


            Assert.True(loadBalancerImpl.GetPotrosnjaBrojilos().Count == 0);
            // Act
            writer.GenerisiPodatkeTest(service);
            Assert.True(loadBalancerImpl.GetPotrosnjaBrojilos().Count == 5);

            Assert.True(workerPool.AllFree());

            
        }
        
    }
}
