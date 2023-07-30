using Microsoft.AspNetCore.Mvc;
using Bank.Entities;
using Bank.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    //[Authorize]
    public class WithdrawalController : ControllerBase
    {
        private readonly WithdrawalRepository _withdrawalRepository;

        public WithdrawalController(WithdrawalRepository withdrawalRepository)
        {
            _withdrawalRepository = withdrawalRepository;
        }

        [HttpGet(Name = "GetWithdrawal")]
        public IEnumerable<Withdrawal> Get(int operationTypeId) => 
                                        _withdrawalRepository.GetWithdrawalByOperationTypeId(operationTypeId);
        
    }
}