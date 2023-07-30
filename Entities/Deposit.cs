using Azure;

namespace Bank.Entities
{
    public class Deposit
    {
        public int Id { get; set; }
        public int CoinId { get; set; }
        public decimal Amount { get; set; }
        public string FromAddress { get; set; }
        public Coin Coin { get; set; }
    }
}
