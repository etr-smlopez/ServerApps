using Microsoft.AspNetCore.SignalR;
using ServerApp.Caching;

namespace ServerApp.Hubs
{
    public class CostUnitsHub : Hub
    {
        private readonly DataCache _dataCache;

        public CostUnitsHub(DataCache dataCache)
        {
            _dataCache = dataCache;
        }

        public async Task UpdateCachedData()
        {
            var cachedData = _dataCache.GetCachedDataFromSqlView();
            await Clients.All.SendAsync("ReceiveDataUpdate", cachedData);
        }
    }

 

}
