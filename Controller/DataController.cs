﻿using Microsoft.AspNetCore.Mvc;
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

      
    }
}
