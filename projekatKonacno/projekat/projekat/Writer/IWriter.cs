using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.writer
{
    public interface IWriter
    {
        string LogMsg(String str);
        void Write(int workerID);
        void WriteManualy(int workerID, int dataSetID, List<WriterData> data, int descriptionID);
        void TurnOnWorker(Worker w);
        void TurnOffWorker(Worker w);
    }
}
