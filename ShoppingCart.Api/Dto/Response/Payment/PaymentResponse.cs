using ShoppingCart.Api.Dto.Request.Payment;

namespace ShoppingCart.Api.Dto.Response.Payment
{
    public class PaymentResponse
    {
        public PaymentResponse(BankType bankType)
        {
            BankType = bankType;
        }
        public BankType BankType { get; }
    }
}