using Microsoft.AspNetCore.Mvc;

namespace WebApplicationTest.Data
{
    public interface IDataService
    {
        public IActionResult GetBirthdayPeopleList(DateTime date);
        public IActionResult GetLatestBuyersList(int days);
        public IActionResult GetPopularCategoriesList(int clientId);
    }
}
