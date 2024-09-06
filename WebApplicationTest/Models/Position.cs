namespace WebApplicationTest.Models
{
    public class Position
    {
        public int Id { get; set; }
        public int PurchaseNumber { get; set; }
        public Purchase? Purchase { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Amount { get; set; }
    }
}
