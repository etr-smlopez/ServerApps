using Microsoft.AspNetCore.SignalR;
using ServerApp.Caching;

namespace ServerApp.Hubs
{ 
    public class SalesOrderHub : Hub
    {
        private readonly DataCache _dataCache;

        public SalesOrderHub(DataCache dataCache)
        {
            _dataCache = dataCache;
        }

        public async Task UpdateCachedData()
        {
            var cachedData = _dataCache.GetCachedSalesOrder();
            await Clients.All.SendAsync("ReceiveDataUpdate", cachedData);
        }
    }

}
