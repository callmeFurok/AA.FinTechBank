namespace AA.FinTechBank.Domain.Entities
{
    public class EApplicationUser
    {
        public Guid Id { get; set; } = new Guid();
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
