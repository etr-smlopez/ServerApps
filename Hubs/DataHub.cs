using Microsoft.AspNetCore.SignalR;
using ServerApp.Caching;

namespace ServerApp.Hubs
{
    public class DataHub : Hub
    {
        private readonly DataCache _dataCache;

        public DataHub(DataCache dataCache)
        {
            _dataCache = dataCache;
        }

        public async Task UpdateCachedData()
        {
            var cachedData = _dataCache.GetCachedData();
            await Clients.All.SendAsync("ReceiveDataUpdate", cachedData);
        }
    }

}
