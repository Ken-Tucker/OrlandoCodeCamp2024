using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using WebApplicationPerformance.Models;

namespace WebApplicationPerformance.Services
{
    public class DefaultGetPeople : IGetPeople
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly JsonSerializerOptions options;

        public DefaultGetPeople(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

            options = new JsonSerializerOptions
            {
                TypeInfoResolver = JsonTypeInfoResolver.Combine(PersonJsonContext.Default, new DefaultJsonTypeInfoResolver())
            };

        }

        public PeopleList GetPeople()
        {
            string filePath = $"{_hostingEnvironment.ContentRootPath}\\App_Data\\data.json";
            using StreamReader srPeople = new StreamReader(filePath);
            string json = srPeople.ReadToEnd();
            var result = JsonSerializer.Deserialize<PeopleList>(json, options);
            return result ?? new PeopleList();
        }
    }
}
