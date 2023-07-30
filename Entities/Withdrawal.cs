using System.ComponentModel.DataAnnotations;

namespace Bank.Entities
{
    public class Withdrawal
    {
        [Key]
        public int Id { get; set; }
        public int CoinId { get; set; }
        public double Amount { get; set; }
        public bool WasApprovedByUser2FA { get; set; }
        public string ToAddress { get; set; }
        public Coin Coin { get; set; }
    }
}
