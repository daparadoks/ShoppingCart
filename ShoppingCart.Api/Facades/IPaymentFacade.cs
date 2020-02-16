using System.Threading.Tasks;
using ShoppingCart.Api.Dto.Request.Payment;
using ShoppingCart.Api.Dto.Response.Payment;

namespace ShoppingCart.Api.Facades
{
    public interface IPaymentFacade:IFacade
    {
        Task<PaymentResponse> PayWith3D(PaymentRequest request);
    }
}