namespace BankApplication.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public string AccountHolder { get; set; }
    }
}
