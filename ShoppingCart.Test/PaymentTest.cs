using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Api.Dto.Request.Payment;
using ShoppingCart.Api.Facades;
using Xunit;
using Xunit.Abstractions;

namespace ShoppingCart.Test
{
    public class PaymentTest : BaseTest, IClassFixture<TestStartUp>
    {
        private readonly ServiceProvider _serviceProvider;
        
        public PaymentTest(TestStartUp testStartUp, ITestOutputHelper output) : base(output) =>
            _serviceProvider = testStartUp.ServiceProvider;

        [Fact]
        public async void Should_Pay_With_Abank()
        {
            var facade = _serviceProvider.GetService<IPaymentFacade>();
            var request = new PaymentRequest
            {
                Bank = BankType.Abank
            };
            var response = await facade.PayWith3D(request);
            response.Should().NotBeNull();
            response.BankType.Should().Be(BankType.Abank);
        }
        
        [Fact]
        public async void Should_Pay_With_Bbank()
        {
            var facade = _serviceProvider.GetService<IPaymentFacade>();
            var request = new PaymentRequest
            {
                Bank = BankType.Bbank
            };
            var response = await facade.PayWith3D(request);
            response.Should().NotBeNull();
            response.BankType.Should().Be(BankType.Bbank);
        }
        
        [Fact]
        public async void Should_Pay_With_Iyzico()
        {
            var facade = _serviceProvider.GetService<IPaymentFacade>();
            var request = new PaymentRequest
            {
                Bank = BankType.Iyizco
            };
            var response = await facade.PayWith3D(request);
            response.Should().NotBeNull();
            response.BankType.Should().Be(BankType.Iyizco);
        }
    }
}