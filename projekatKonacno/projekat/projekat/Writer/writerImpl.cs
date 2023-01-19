using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;


namespace projekat.writer
{
    public class writerImpl : IWriter
    {
        public enum Codes
        {
            CODE_ERROR, CODE_ANALOG, CODE_DIGITAL, CODE_CUSTOM, CODE_LIMITSET,
            CODE_SINGLENODE, CODE_MULTIPLENODE, CODE_CONSUMER, CODE_SOURCE
        };

        public LoadBalancer m_LoadBalancer;
       // private Logger logger;

        public Writer(Logger log, LoadBalancer lb)
        {
            logger = log;
            m_LoadBalancer = lb;
        }


        ~Writer()
        {

        }


        public string LogMsg(String str)
        {
            logger.Log(str);
            return str;
        }


        public void Write(int workerID)
        {
            WriterData data = new WriterData();
            Random rnd = new Random();
            data.Code = rnd.Next(1, 9);
            if (data.Code == 2)
                data.Value = rnd.Next(0, 1);
            else
                data.Value = rnd.Next(1, 1000);
            Console.WriteLine(LogMsg($"\n[WRITER: New WriterData item created CODE:" + data.Code + "|VALUE:" + data.Value + " | " + DateTime.Now + "]\n"));
            m_LoadBalancer.RecieveData(data, workerID);
            Thread.Sleep(500);
        }

        public void WriteManualy(int workerID, int dataSetID, List<WriterData> data, int descriptionID) // unosimo podatke i saljemo LoadBalanceru za prepakivanje u njegovu strukturu
        {
            m_LoadBalancer.RecieveDataSet(dataSetID, data, workerID, descriptionID);
        }

        public void TurnOnWorker(Worker w)
        {
            m_LoadBalancer.TurnOnWorker(w);
        }

        public void TurnOffWorker(Worker w)
        {
            m_LoadBalancer.TurnOffWorker(w);
        }

    }
}
