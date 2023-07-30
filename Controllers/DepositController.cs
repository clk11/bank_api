using Microsoft.AspNetCore.Mvc;
using Bank.Entities;
using Bank.Repository;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    //[Authorize]
    public class DepositController : ControllerBase
    {
        private readonly DepositRepository _depositRepository;

        public DepositController(DepositRepository depositRepository)
        {
            _depositRepository = depositRepository;
        }

        [HttpGet]
        public IEnumerable<Deposit> GetAll()
        {
            return _depositRepository.GetAll();
        }
        [HttpPost]
        public void AddDeposit([FromBody] FormData data)
        {            
            _depositRepository.AddDeposit(FormData.getDeposit(data));
        }
        [HttpPut]
        public void EditDeposit([FromBody] FormData data)
        {
            var item = FormData.getDeposit(data);
            item.Id = data.Id;
            _depositRepository.EditDeposit(item);
        }
        [HttpGet]
        public Deposit GetDeposit(int id)
        {
            return _depositRepository.GetDeposit(id);
        }
    }
    public class FormData
    {
        public int Id { get; set; }     
        public decimal Amount { get; set; }
        public int CoinId { get; set; }
        public string FromAddress { get; set; }
        public static Deposit getDeposit(FormData data)
        {
            return new Deposit()
            {
                Amount = data.Amount,
                FromAddress = data.FromAddress,
                CoinId = data.CoinId,
            };
        }
    }
}