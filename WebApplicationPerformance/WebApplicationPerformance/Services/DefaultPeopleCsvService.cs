namespace WebApplicationPerformance.Services
{
    public class DefaultPeopleCsvService : IPeopleCsvService
    {
        private readonly IGetPeople _peopleService;

        public DefaultPeopleCsvService(IGetPeople peopleService)
        {
            _peopleService = peopleService;
        }

        public string GetCsv()
        {
            var people = _peopleService.GetPeople();
            string csv = string.Empty;
            string line;
            if (people.Any())
            {
                foreach (var person in people)
                {
                    line = $"\"{person.id}\",\"{person.name}\"";
                    csv += line + "\n";
                }
            }
            return csv;
        }

        //public string GetCsv()
        //{
        //    var people = _peopleService.GetPeople();
        //    string csv = string.Empty;
        //    foreach (var person in people)
        //    {
        //        string line = $"\"{person.id}\",\"{person.name}\"";
        //        csv += line + "\n";
        //    }

        //    return csv;
        //}

        //public string GetCsv()
        //{
        //    var people = _peopleService.GetPeople();
        //    StringBuilder csv = new StringBuilder();
        //    foreach (var person in people)
        //    {
        //        csv.AppendLine($"\"{person.id}\",\"{person.name}\"");
        //    }

        //    return csv.ToString();
        //}
    }
}
