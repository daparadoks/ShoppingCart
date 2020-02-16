using System.Threading.Tasks;

namespace ShoppingCart.Api.Repositories
{
    public interface IRepository<T>
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> FindById(int id);
    }
}