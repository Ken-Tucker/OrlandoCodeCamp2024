using System.Text.Json.Serialization;

namespace WebApplicationPerformance.Models
{

    public class Person
    {
        public string name { get; set; } = string.Empty;
        public string language { get; set; } = string.Empty;
        public string id { get; set; } = string.Empty;
        public string bio { get; set; } = string.Empty;
        public float version { get; set; }
    }

    [JsonSerializable(typeof(Person))]
    [JsonSerializable(typeof(PeopleList))]
    [JsonSerializable(typeof(List<Person>))]
    public partial class PersonJsonContext : JsonSerializerContext
    {
    }

}
