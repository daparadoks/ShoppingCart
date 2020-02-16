using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Api.Dto.Request.Payment;

namespace ShoppingCart.Api.Config
{
    public class ApplicationConfig
    {
        public RedisConfig RedisConfig { get; set; }
        public List<BankPaymentConfig> PaymentIntegrations { get; set; }

        public BankPaymentConfig GetIntegrationByType(BankType bankType) =>
            PaymentIntegrations.FirstOrDefault(x => x.Type == bankType);
    }

    public class BankPaymentConfig
    {
        public BankType Type { get; set; }
        public string Url { get; set; }
    }

    public class RedisConfig
    {
        public int Db { get; set; }

        public string Server { get; set; }
    }
}