using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ShoppingCart.Api.Config;
using ShoppingCart.Api.Converter;
using ShoppingCart.Api.Dto.Request.Payment;
using ShoppingCart.Api.Dto.Response.Payment;

namespace ShoppingCart.Api.Services.Payment
{
    public class IyzicoPaymetService : PaymentBase, IPaymetService
    {
        private readonly IOptions<ApplicationConfig> _config;
        public IyzicoPaymetService(IOptions<ApplicationConfig> config): base(config.Value.GetIntegrationByType(BankType.Iyizco))
        {
            _config = config;
        }
        
        public async Task<PaymentResponse> Pay(PaymentRequest request)
        {
            var bankRequest = request.ToIyzicoRequest();
            var bankResponse = await SendRequest<IyzicoPaymentResponse, IyzicoPaymentRequest>(bankRequest);
            return bankResponse.ToResponse();
        }

        public async Task<PaymentResponse> PayWith3D(PaymentRequest request)
        {
            var bankRequest = request.ToIyzicoRequest();
            var bankResponse = await SendRequest<IyzicoPaymentResponse, IyzicoPaymentRequest>(bankRequest);
            return bankResponse.ToResponse();
        }
    }
}