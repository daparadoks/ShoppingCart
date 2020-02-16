using System.Threading.Tasks;
using ShoppingCart.Api.Dto.Request.Payment;
using ShoppingCart.Api.Dto.Response.Payment;
using ShoppingCart.Api.Services.Payment;

namespace ShoppingCart.Api.Facades
{
    public class PaymentFacade : Facade, IPaymentFacade
    {
        private readonly PaymentServiceHandler _paymentServiceHandler;

        public PaymentFacade(PaymentServiceHandler paymentServiceHandler)
        {
            _paymentServiceHandler = paymentServiceHandler;
        }

        public async Task<PaymentResponse> PayWith3D(PaymentRequest request)
        {
            var handler = _paymentServiceHandler(request.Bank);
            return await handler.PayWith3D(request);
        }
    }
}