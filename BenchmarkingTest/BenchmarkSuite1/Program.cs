using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace BenchmarkSuite1
{
    public class Program
    {

        public static void Main(string[] args)
        {
#if DEBUG
            var benchMark = new Benchmarks();
            for (int x = 0; x < 100000; x++)
            {
                benchMark.SingletonTest();
                benchMark.PerInstanceTest();
            }
            return;
#endif

            var config = DefaultConfig.Instance;
            var summary = BenchmarkRunner.Run<Benchmarks>(config, args);

            // Use this to select benchmarks from the console:
            // var summaries = BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
        }
    }
}