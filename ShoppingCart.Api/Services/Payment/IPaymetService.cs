using System.Threading.Tasks;
using ShoppingCart.Api.Dto.Request.Payment;
using ShoppingCart.Api.Dto.Response.Payment;

namespace ShoppingCart.Api.Services.Payment
{
    public interface IPaymetService
    {
        Task<PaymentResponse> Pay(PaymentRequest request);
        Task<PaymentResponse> PayWith3D(PaymentRequest request);
    }
}