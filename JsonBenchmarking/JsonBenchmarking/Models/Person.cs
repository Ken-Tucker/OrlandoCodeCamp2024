using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JsonBenchmarking.Models
{
    public class Person
    {
        public string name { get; set; }
        public string language { get; set; }
        public string id { get; set; }
        public string bio { get; set; }
        public float version { get; set; }
    }

    [JsonSerializable(typeof(Person))]
    [JsonSerializable(typeof(PeopleList))]
    [JsonSerializable(typeof(List<Person>))]
    public partial class PersonJsonContext : JsonSerializerContext
    {
    }
}
