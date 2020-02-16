using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ShoppingCart.Api.Config;
using ShoppingCart.Api.Extensions;
using StackExchange.Redis;

namespace ShoppingCart.Api.Repositories.Redis
{
    public class RedisClient : IRedisClient
    {
        private readonly Lazy<ConnectionMultiplexer> _lazyConnection;
        private ConnectionMultiplexer Connection => _lazyConnection.Value;
        private readonly IDatabase _db;
        private readonly IOptions<ApplicationConfig> _config;

        public RedisClient(IOptions<ApplicationConfig> config)
        {
            _config = config;
            _lazyConnection =
                new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(config.Value.RedisConfig.Server));
            _db = Connection.GetDatabase(config.Value.RedisConfig.Db);
        }

        public T Get<T>(string key)
        {
            byte[] result = _db.StringGet(key);
            return result.Deserialize<T>();
        }

        public async Task<T> GetAndSet<T>(string key, Task<T> acquire)
        {
            byte[] result = await _db.StringGetAsync(key);
            if (result == null)
                return await acquire;

            return result.Deserialize<T>();
        }

        public async Task<T> GetAsync<T>(string key)
        {
            byte[] result = await _db.StringGetAsync(key);
            return result.Deserialize<T>();
        }

        public async Task SetAsync<T>(string key, T value) =>
            await _db.StringSetAsync(key, value.Serialize());

        public async Task RemoveByKey(string key) => await _db.KeyDeleteAsync(key);

        public async Task RemoveAll(string pattern)
        {
            foreach (var ep in Connection.GetEndPoints())
            {
                var server = Connection.GetServer(ep);
                var keys = server.Keys(_config.Value.RedisConfig.Db, pattern + "*").ToArray();
                await _db.KeyDeleteAsync(keys);
            }
        }
    }
}