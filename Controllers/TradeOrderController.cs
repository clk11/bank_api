using Microsoft.AspNetCore.Mvc;
using Bank.Entities;
using Bank.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    //[Authorize]
    public class TradeOrderController : ControllerBase
    {
        private readonly TradeOrderRepository _tradeOrderRepository;

        public TradeOrderController(TradeOrderRepository tradeOrderRepository)
        {
            _tradeOrderRepository = tradeOrderRepository;
        }
        [HttpGet]
        public IEnumerable<TradeOrder> Get(int operationTypeId) => _tradeOrderRepository
                                                                .GetTradeOrderByOperationTypeId(operationTypeId);
        
    }
}