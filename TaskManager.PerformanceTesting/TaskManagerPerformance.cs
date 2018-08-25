using System;

namespace TaskManager.PerformanceTesting
{
    public class TaskManagerPerformance
    {
        [PerfBenchmark(NumberOfIterations = 1, RunMode = RunMode.Throughput,
TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        public void Benchmark_Performance_ElaspedTime()
        {
            //Write your code to be benchmarked here
        }
    }
}
