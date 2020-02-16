using System;
using System.Threading.Tasks;

namespace ShoppingCart.Api.Repositories.Redis
{
    public interface IRedisClient
    {
        T Get<T>(string key);
        Task<T> GetAndSet<T>(string key, Task<T> acquire);
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value);
        Task RemoveByKey(string key);
        Task RemoveAll(string pattern);
    }
}