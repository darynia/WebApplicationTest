namespace WebApplicationTest.Models
{
    public class Client
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}
