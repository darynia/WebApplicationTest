using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationTest.Data
{
    public class DataService : IDataService
    {
        private readonly ApplicationDbContext _context;

        public DataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult GetBirthdayPeopleList(DateTime date)
        {
            var birthdayPeople = _context.Client
                .Where(c => c.DateOfBirth.ToLocalTime() == date)
                .Select(c => new { c.Id, c.FullName });

            return new ObjectResult(birthdayPeople);
        }
        public IActionResult GetLatestBuyersList(int days)
        {
            var latestBuyers = _context.Purchase
                .Include(p => p.Client)
                .Where(p => p.DatePayment.ToLocalTime() >= DateTime.Now.AddDays(-days))
                .GroupBy(p => p.ClientId)
                .Select(p => new
                {
                    ClientId = p.Key,
                    FullName = p.First().Client.FullName,
                    DatePaymentMax = p.Max(c => c.DatePayment.ToLocalTime())
                });

            return new ObjectResult(latestBuyers);
        }

        public IActionResult GetPopularCategoriesList(int clientId)
        {
            var popularCategories = _context.Position
                .Include(p => p.Purchase)
                    .ThenInclude(p => p.Client)
                .Include(p => p.Product)
                    .ThenInclude(p => p.Category)
                .Where(p => p.Purchase.Client.Id == clientId)
                .GroupBy(p => p.Product.Category.Id)
                .Select(p => new
                {
                    CategoryName = p.First().Product.Category.Name,
                    Amount = p.Select(c => c.Amount).Sum()
                });

            return new ObjectResult(popularCategories);
        }
    }
}
