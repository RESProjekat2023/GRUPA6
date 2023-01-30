using Moq;
using NUnit.Framework;
using projekatERS.DataBaseCRUD;
using projekatERS.LoadBalancer;
using projekatERS.Worker;
using projekatERS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writer;
using Common;

namespace UnitTestsLoadBalancer
{
    [TestFixture]
    public class WorkerTest
    {
        
        
        
            private DataBaseCRUDImpl dataBaseCRUD;
            private WorkerPool workerPool;
            private Mock<WorkerPool> workerPoolMock;
            private LoadBalancerImpl loadBalancerImpl;
            private Mock<WriterImpl> writerImplMock;
            private WriterImpl writer;
            private Service service;
            private WorkerImpl worker;

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
            worker = new WorkerImpl(dataBaseCRUD,workerPool);
               
               



                

            }


            [Test]
            public void UkljucenIskljucen()
            {


            Assert.True(loadBalancerImpl.UkljuceniGet());
            dataBaseCRUD.DeleteAllPotrosnjaBrojilo();
            Assert.True(loadBalancerImpl.GetPotrosnjaBrojilos().Count == 0);
            for (int i = 0; i < 10; i++)
            {
                var potrosnjaBrojilo = new PotrosnjaBrojilo(1, i, 10 * i, 2);
                loadBalancerImpl.Recive(potrosnjaBrojilo);
               

            }
            Assert.True(loadBalancerImpl.GetPotrosnjaBrojilos().Count == 0);



        }

        }
    }

