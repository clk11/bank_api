using Bank.Entities;
using Bank.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Bank.Repository
{
    public class DepositRepository : IDepositRepository
    {
        private readonly ApplicationDbContext _context;
        public DepositRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddDeposit(Deposit deposit)
        {
            _context.Add(deposit);
            _context.SaveChanges();
        }

        public void EditDeposit(Deposit d)
        {
            Deposit item = _context.Deposits.FirstOrDefault(x => x.Id == d.Id);
            item.FromAddress = d.FromAddress;
            item.Amount = d.Amount;
            item.CoinId = d.CoinId;
            _context.SaveChanges();
        }

        public List<Deposit> GetAll()
        {
            //ThenInclude is not working
            List<Deposit> deposits = _context.Deposits.Include(x=>x.Coin)
            .ToList();
            return deposits;
        }

        public Deposit GetDeposit(int id)
        {
            return _context.Deposits.Include(x=>x.Coin).FirstOrDefault(x => x.Id == id);
        }
    }
}
