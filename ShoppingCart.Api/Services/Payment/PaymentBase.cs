using System.Threading.Tasks;
using Newtonsoft.Json;
using ShoppingCart.Api.Config;

namespace ShoppingCart.Api.Services.Payment
{
    public class PaymentBase
    {
        public PaymentBase(BankPaymentConfig config) => Config = config;

        public BankPaymentConfig Config { get; }

        public async Task<T> SendRequest<T, R>(R request)
        {
            var httpResponse = "{}";
            return JsonConvert.DeserializeObject<T>(httpResponse);
        }
    }
}