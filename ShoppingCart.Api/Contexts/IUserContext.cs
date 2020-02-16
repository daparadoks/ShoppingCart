using System.Threading.Tasks;

namespace ShoppingCart.Api.Contexts
{
    public interface IUserContext
    {
        Task<int> GetId();
    }
}