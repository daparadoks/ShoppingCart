using ShoppingCart.Api.Dto.Request.Payment;
using ShoppingCart.Api.Dto.Response.Payment;

namespace ShoppingCart.Api.Converter
{
    public static class PaymentConverter
    {
        public static AbankPaymentRequest ToAbankRequest(this PaymentRequest request)
        {
            return new AbankPaymentRequest();
        }
        
        public static BbankPaymentRequest ToBbankRequest(this PaymentRequest request)
        {
            return new BbankPaymentRequest();
        }
        
        public static IyzicoPaymentRequest ToIyzicoRequest(this PaymentRequest request)
        {
            return new IyzicoPaymentRequest();
        }
        
        public static PaymentResponse ToResponse(this AbankPaymentResponse response) => new PaymentResponse(BankType.Abank);
        public static PaymentResponse ToResponse(this BbankPaymentResponse response) => new PaymentResponse(BankType.Bbank);
        public static PaymentResponse ToResponse(this IyzicoPaymentResponse response) => new PaymentResponse(BankType.Iyizco);
    }
}