using Microsoft.AspNetCore.Mvc;
using WebApplicationTest.Data;

namespace WebApplicationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private IDataService _dataService;

        public HomeController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("get-birthday-people/{date}")]
        public IActionResult GetBirthdayPeople(DateTime date)
        {
            return _dataService.GetBirthdayPeopleList(date); 
        }

        [HttpGet("get-latest-buyers/{days}")]
        public IActionResult GetLatestBuyers(int days)
        {
            return _dataService.GetLatestBuyersList(days);
        }

        [HttpGet("get-popular-categories/{clientId}")]
        public IActionResult GetPopularCategories(int clientId)
        {
            return _dataService.GetPopularCategoriesList(clientId);
        }
    }
}
