using Microsoft.AspNetCore.Mvc;
using Bank.Entities;
using Bank.Repository;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DepositController : ControllerBase
    {
        private readonly DepositRepository _depositRepository;

        public DepositController(DepositRepository depositRepository)
        {
            _depositRepository = depositRepository;
        }

        [HttpGet(Name = "GetDeposit")]
        public IEnumerable<Deposit> Get(int operationTypeId) => _depositRepository
                                                                .GetDepositByOperationTypeId(operationTypeId);
        
    }
}