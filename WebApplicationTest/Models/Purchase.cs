using Microsoft.EntityFrameworkCore;

namespace WebApplicationTest.Models
{
    [PrimaryKey(nameof(Number))]
    public class Purchase
    {
        public int Number { get; set; }
        public DateTime DatePayment { get; set; }
        public decimal TotalCost { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
