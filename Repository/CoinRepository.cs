using Bank.Entities;
using Bank.Interfaces;
using System.Runtime.InteropServices;

namespace Bank.Repository
{
    public class CoinRepository : ICoinRepository
    {
        private readonly ApplicationDbContext _context;
        public CoinRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCoin(Coin coin)
        {
            coin.When = DateTime.Now;
            coin.Deleted = false;
            coin.Updated = DateTime.Now;
            _context.Coins.Add(coin);
            _context.SaveChanges();
        }

        public void DeleteCoin(int id)
        {
            var item = _context.Coins.FirstOrDefault(x => x.Id == id);
            item.Deleted = true;
            _context.SaveChanges();
        }

        public void EditCoin(Coin c)
        {
            var item = _context.Coins.FirstOrDefault(x => x.Id == c.Id);
            c.Updated = DateTime.Now;
            item.Name = c.Name;
            item.Description = c.Description;
            _context.SaveChanges();
        }

        public List<Coin>? GetAll()
        {
            var list = _context.Coins.Where(x=>x.Deleted == false).ToList();
            return list.Count() != 0 ? list : new List<Coin>();
        }

        public Coin GetCoin(int id)
        {
            return _context.Coins.FirstOrDefault(x => x.Id == id);
        }
    }
}