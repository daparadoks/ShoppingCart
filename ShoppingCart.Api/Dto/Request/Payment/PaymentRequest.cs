using System;

namespace ShoppingCart.Api.Dto.Request.Payment
{
    public class PaymentRequest
    {
        public Guid OrderId { get; set; }
        public string CardToken { get; set; }
        public BankType Bank { get; set; }
    }

    public enum BankType
    {
        Abank = 1,
        Bbank = 2,
        Iyizco = 3,
        Other = 99
    }
}