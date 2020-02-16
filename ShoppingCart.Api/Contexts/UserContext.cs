using System.Threading.Tasks;

namespace ShoppingCart.Api.Contexts
{
    public class UserContext : IUserContext
    {
        public async Task<int> GetId() => 1;
    }
}