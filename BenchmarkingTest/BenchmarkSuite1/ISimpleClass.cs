namespace BenchmarkSuite1
{
    public interface ISimpleClass
    {
        void DoNothing();
    }

    public class SimpleClass : ISimpleClass
    {
        public void DoNothing()
        {

        }
    }


    public class BasicClass : ISimpleClass
    {
        public void DoNothing()
        {

        }
    }
}