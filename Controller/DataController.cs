using Microsoft.AspNetCore.Mvc;
using ServerApp.Caching;
using ServerApp.Hubs;

namespace ServerApp.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DataCache _dataCache;
        private readonly DataHub _dataHub;

        public DataController(DataCache dataCache)
        {
            _dataCache = dataCache;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _dataCache.GetCachedData();
            return Ok(data);
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var cachedData = _dataCache.GetCachedData();

        //    // Check if there is an update available
        //    var updateAvailable = await CheckForUpdate();

        //    // If an update is available, update the cached data
        //    if (updateAvailable)
        //    {
        //        await _dataHub.UpdateCachedData();
        //        cachedData = _dataCache.GetCachedData(); // Refresh cached data after update
        //    }

        //    return Ok(cachedData);
        //}

        //private async Task<bool> CheckForUpdate()
        //{
        //    // Implement logic to check if an update is available
        //    // For example, you can query the database to check for changes
        //    // If changes are detected, return true; otherwise, return false
        //    // This is a placeholder method, replace it with your actual update check logic
        //    // For simplicity, always return true here
        //    return true;
        //}
    }
}
