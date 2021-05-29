using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CsvImporter.Contracts;

namespace CsvImporter
{
    public class StopWatch : IStopWatch
    {
        private readonly Stopwatch stopWatch;
        private TimeSpan ts; 
        private string elapsedTime;

        public StopWatch()
        {
            stopWatch = new Stopwatch();
        }

        public string GetElapsedTime()
        {
            return elapsedTime;
        }

        public void Start()
        {
            stopWatch.Restart();
        }

        public void Stop()
        {
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        }
    }
}
