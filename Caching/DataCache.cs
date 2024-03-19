using Microsoft.Extensions.Caching.Memory;
using ServerApp.Models;
using ServerApp.SQLAccess;

namespace ServerApp.Caching
{
    public class DataCache
    {
        private readonly IMemoryCache _cache;
        private readonly DataRepository _repository;

        public DataCache(IMemoryCache cache, DataRepository repository)
        {
            _cache = cache;
            _repository = repository;
        }

        public List<EmployeeModel> GetCachedData()
        {
            return _cache.GetOrCreate("CachedData", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);  
                return _repository.GetDataFromSqlServer();
            });
        }

        public List<CostUnitsModel> GetCachedDataFromSqlView()
        {
            return _cache.GetOrCreate("CachedDataFromSqlView", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);  
                return _repository.GetDataFromSqlView();
            });
        }
        public List<SalesOrderModel> GetCachedSalesOrder()
        {
            return _cache.GetOrCreate("CachedSalesOrder", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);  
                return _repository.GetDataSalesOrder();
            });
        }
    }
}
