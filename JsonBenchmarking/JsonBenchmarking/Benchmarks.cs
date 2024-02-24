using BenchmarkDotNet.Attributes;
using JsonBenchmarking.Models;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace JsonBenchmarking
{
    public class Benchmarks
    {
        [Benchmark]
        public void NewtonSoft()
        {
            var people = Newtonsoft.Json.JsonConvert.DeserializeObject<PeopleList>(GetJson());
        }

        [Benchmark]
        public void TextJson()
        {
            var options = new JsonSerializerOptions
            {
                TypeInfoResolver = JsonTypeInfoResolver.Combine(PersonJsonContext.Default, new DefaultJsonTypeInfoResolver())
            };
            var people = System.Text.Json.JsonSerializer.Deserialize<PeopleList>(GetJson());
        }

        private string GetJson()
        {
            using StreamReader srPeople = new StreamReader("data.json");
            return srPeople.ReadToEnd();
        }
    }
}
