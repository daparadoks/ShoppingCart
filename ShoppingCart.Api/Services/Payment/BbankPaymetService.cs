using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ShoppingCart.Api.Config;
using ShoppingCart.Api.Converter;
using ShoppingCart.Api.Dto.Request.Payment;
using ShoppingCart.Api.Dto.Response.Payment;

namespace ShoppingCart.Api.Services.Payment
{
    public class BbankPaymetService : PaymentBase, IPaymetService
    {
        private readonly IOptions<ApplicationConfig> _config;
        public BbankPaymetService(IOptions<ApplicationConfig> config): base(config.Value.GetIntegrationByType(BankType.Bbank))
        {
            _config = config;
        }
        
        public async Task<PaymentResponse> Pay(PaymentRequest request)
        {
            var bankRequest = request.ToBbankRequest();
            var bankResponse = await SendRequest<BbankPaymentResponse, BbankPaymentRequest>(bankRequest);
            return bankResponse.ToResponse();
        }

        public async Task<PaymentResponse> PayWith3D(PaymentRequest request)
        {
            var bankRequest = request.ToBbankRequest();
            var bankResponse = await SendRequest<BbankPaymentResponse, BbankPaymentRequest>(bankRequest);
            return bankResponse.ToResponse();
        }
    }
}