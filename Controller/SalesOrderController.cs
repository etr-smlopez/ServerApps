using Microsoft.AspNetCore.Mvc;
using ServerApp.Caching;
using ServerApp.Hubs;

namespace ServerApp.Controller
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private readonly DataCache _dataCache;
        private readonly DataHub _dataHub;

        public SalesOrderController(DataCache dataCache)
        {
            _dataCache = dataCache;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _dataCache.GetCachedSalesOrder();
            return Ok(data);
        }

    }
}
