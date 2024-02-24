using Microsoft.AspNetCore.Mvc;
using WebApplicationPerformance.Models;
using WebApplicationPerformance.Services;

namespace WebApplicationPerformance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : Controller
    {
        private readonly IGetPeople _peopleService;
        private readonly IPeopleCsvService _peopleCsvService;
        public PeopleController(IGetPeople peopleService,
            IPeopleCsvService peopleCsvService)
        {
            _peopleService = peopleService;
            _peopleCsvService = peopleCsvService;
        }
        [HttpGet]
        public PeopleList Index()
        {
            return _peopleService.GetPeople();
        }

        [HttpPost]
        public string GetCsv()
        {
            return _peopleCsvService.GetCsv();
        }
    }
}
