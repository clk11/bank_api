using Bank.Entities;
using Bank.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    //[Authorize]
    public class CoinController : ControllerBase
    {
        private readonly CoinRepository _coinRepository;

        public CoinController(CoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }
        [HttpGet]
        public IEnumerable<Coin> GetAll()
        {
            return _coinRepository.GetAll();
        }
        [HttpPost]
        public void AddCoin(Coin coin)
        {
            _coinRepository.AddCoin(coin);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            _coinRepository.DeleteCoin(id);
        }
        [HttpGet]
        public Coin GetCoin(int id)
        {
            return _coinRepository.GetCoin(id);
        }
        [HttpPut]
        public void EditCoin(Coin c)
        {
            _coinRepository.EditCoin(c);
        }
    }
}
