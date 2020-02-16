using ShoppingCart.Api.Dto.Request.Payment;

namespace ShoppingCart.Api.Services.Payment
{
    public delegate IPaymetService PaymentServiceHandler(BankType key);
}