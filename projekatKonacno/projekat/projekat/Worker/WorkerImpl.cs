using projekat.LoadBalancer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static projekat.writer.writerImpl;

namespace projekat.Worker
{
    public class WorkerImpl : IWorker
    {
        public void WorkerRepack(Description description)
        {
            throw new NotImplementedException();
        }


        private int id;
        public CollectionDescription m_CollectionDescription;
        public Reader m_Reader;
        private bool isOnline = true;
        private bool busy = false;
        private bool doneDataStoring = false;
        private DataBase m_DataBase;
        private Logger logger;
        public Worker(Logger log, int workerID, DataBase db)
        {
            id = workerID;
            m_CollectionDescription = new CollectionDescription();
            m_DataBase = db;
            logger = log;
        }

        ~Worker()
        {

        }

        public bool IsOnline { get => isOnline; set => isOnline = value; }
        public bool Busy { get => busy; set => busy = value; }
        public bool DoneDataStoring { get => doneDataStoring; set => doneDataStoring = value; }
        public int Id { get => id; set => id = value; }

        public void WorkerRepack(Description d)
        {
            CollectionDescription colDesc = new CollectionDescription();
            if (d != null)
            {
                busy = true;
                Console.WriteLine($"Worker{id} is now busy doing some work.");
                colDesc.Id = d.Id;
                colDesc.DataSet = d.DataSet;
                colDesc.AddToHistoricalCollection(d.GetItems());
                Console.WriteLine(LogMsg($"[WORKER: Storing new data in DataBase. | {DateTime.Now}]"));
                m_DataBase.SaveCollectionDescriptions(colDesc, DateTime.Now.ToString());
                doneDataStoring = true;
                busy = false;
            }
        }


        public List<Tuple<string, int>> ReadValueHistoryFromDB(Codes code, DateTime from, DateTime to)
        {
            Console.WriteLine(LogMsg($"[WORKER: Reading from DataBase has been called from Reader. | {DateTime.Now}]"));
            return m_DataBase.RVH(code, from, to);

        }

        public string LogMsg(string str)
        {
            logger.Log(str);
            return str;
        }
    }
}
