using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench;
using TaskManager.EntityModel;
using TaskManager.API;
using TaskManager.API.Controllers;
using System.Net.Http;
using System.Web.Http;


namespace TaskManager.PerformanceTest
{
    public class PerformanceTest
    {
        private const string CounterName = "Counter";
        private Counter counter;
        private int key;
        private const int AcceptableMinThroughput = 100;

        [PerfSetup]
        public void setup(BenchmarkContext context)
        {
            counter = context.GetCounter(CounterName);
            key = 0;
        }

        [PerfBenchmark(NumberOfIterations = 500,RunMode =RunMode.Throughput,RunTimeMilliseconds = 600000,TestMode = TestMode.Measurement)]
        [CounterMeasurement(CounterName)]
        [CounterThroughputAssertion(CounterName,MustBe.GreaterThan,AcceptableMinThroughput)]
        public void BenchMark(BenchmarkContext context)
        {
            var controller = new TaskController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            List<TaskData> Response = controller.Get().ToList();
            counter.Increment();            
        }
    }
}
