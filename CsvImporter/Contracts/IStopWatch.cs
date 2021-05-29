using System;
using System.Collections.Generic;
using System.Text;

namespace CsvImporter.Contracts
{
    public interface IStopWatch
    {
        void Start();
        void Stop();
        string GetElapsedTime();


    }
}
