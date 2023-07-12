using Microsoft.AspNetCore.Mvc;
using Bank.Entities;
using Bank.Repository;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TradeOrderController : ControllerBase
    {
        private readonly TradeOrderRepository _tradeOrderRepository;

        public TradeOrderController(TradeOrderRepository tradeOrderRepository)
        {
            _tradeOrderRepository = tradeOrderRepository;
        }

        public IEnumerable<TradeOrder> Get(int operationTypeId) => _tradeOrderRepository
                                                                .GetTradeOrderByOperationTypeId(operationTypeId);
        
    }
}