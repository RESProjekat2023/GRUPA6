using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writer
{
    class Program
    {
        static void Main(string[] args)
        {
            WriterImpl writerImpl = new WriterImpl();
            UIImpl uIImpl = new UIImpl(writerImpl);
            uIImpl.Meni();

        }
    }
}
