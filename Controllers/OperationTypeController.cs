using Microsoft.AspNetCore.Mvc;
using Bank.Entities;
using Bank.Repository;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OperationTypeController : ControllerBase
    {
        private readonly OperationTypeRepository _operationTypeRepository;

        public OperationTypeController(OperationTypeRepository operationTypeRepository)
        {
            _operationTypeRepository = operationTypeRepository;
        }

        [HttpGet(Name = "GetOperationType")]
        public IEnumerable<OperationType> GetAll() => _operationTypeRepository.GetAll();
    }
}