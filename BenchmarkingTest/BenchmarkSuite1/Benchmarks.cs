using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace BenchmarkSuite1
{

    public interface IComponent { }
    public interface IDependency1 { }
    public interface IDependency2 { }
    public interface IEnumerableDependency { }
    public class TwoConstructors
    {
        public int Value { get; set; }

        public TwoConstructors()
        {
            this.Value = 42;
        }

        public TwoConstructors(int value)
        {
            Value = value;
        }
    }
    public class Component : IComponent
    {
        public IDependency1 Dependency1 { get; set; }
        public NonInterfaceDependency NonInterfaceDependency { get; set; }
    }

    public class Dependency1 : IDependency1
    {
        public IDependency2 Dependency2 { get; set; }
        public IList<IEnumerableDependency> EnumerableDependencies { get; set; }
    }

    public class Dependency2 : IDependency2 { }

    public class EnumerableDependency1 : IEnumerableDependency
    {
        public IDependency2 Dependency2 { get; set; }
    }

    public class EnumerableDependency2 : IEnumerableDependency { }

    public class NonInterfaceDependency { }

    public class SecondDependency1 : Dependency1 { }
    public class Benchmarks
    {
        private readonly SimpleContainer _container;

        public Benchmarks()
        {
            _container = new SimpleContainer();
            _container.RegisterSingleton(typeof(ISingleton), string.Empty, typeof(Singleton));
            _container.RegisterSingleton(typeof(TwoConstructors), string.Empty, typeof(TwoConstructors));
            _container.RegisterPerRequest(typeof(ISimpleClass), "Simple", typeof(SimpleClass));
            _container.RegisterPerRequest(typeof(ISimpleClass), "Basic", typeof(BasicClass));
            _container.RegisterPerRequest(typeof(IComponent), null, typeof(Component));

            _container.RegisterPerRequest(typeof(IDependency1), null, typeof(Dependency1));
            _container.RegisterPerRequest(typeof(IDependency2), null, typeof(Dependency2));
            _container.RegisterPerRequest(typeof(NonInterfaceDependency), null, typeof(NonInterfaceDependency));
            _container.RegisterPerRequest(typeof(IEnumerableDependency), null, typeof(EnumerableDependency1));
            _container.RegisterPerRequest(typeof(IEnumerableDependency), null, typeof(EnumerableDependency2));
        }

        [Benchmark]
        public void SingletonTest()
        {
            var instance = _container.GetInstance(typeof(ISingleton), string.Empty);
            var inst = _container.GetInstance(typeof(TwoConstructors), string.Empty) as TwoConstructors;
            if (inst.Value != 42)
            {
                throw new Exception("Value Not 42");
            }
        }

        [Benchmark]
        public void PerInstanceTest()
        {
            // Implement your benchmark here
            var simple = _container.GetInstance(typeof(ISimpleClass), "Simple");
            var basic = _container.GetInstance(typeof(ISimpleClass), "Basic");

        }
    }
}
