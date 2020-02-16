using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Api.Dto.Request;
using ShoppingCart.Api.Facades;
using Xunit;
using Xunit.Abstractions;

namespace ShoppingCart.Test
{
    public class MainTest : BaseTest, IClassFixture<TestStartUp>
    {
        private readonly ServiceProvider _serviceProvider;

        public MainTest(TestStartUp testStartUp, ITestOutputHelper output) : base(output) =>
            _serviceProvider = testStartUp.ServiceProvider;

        [Fact]
        public void Should_Test_All()
        {
        }

        [Fact]
        public async void Should_Add_Item()
        {
            var facade = _serviceProvider.GetService<ICartFacade>();
            var request = new UpdateCartItemRequest
            {
                ProductId = 1,
                Quantity = 1,
                UserId = 1
            };
            var result = await facade.AddItem(request);
            result.Should().BeTrue();
        }

        [Fact]
        public async void Should_Not_Add_Item()
        {
            var facade = _serviceProvider.GetService<ICartFacade>();
            var request = new UpdateCartItemRequest
            {
                ProductId = 1,
                Quantity = 0,
                UserId = 1
            };
            var result = await facade.AddItem(request);
            result.Should().BeFalse();
        }

        [Fact]
        public async void Should_Remove_Item()
        {
            var facade = _serviceProvider.GetService<ICartFacade>();
            var request = new UpdateCartItemRequest
            {
                CartId = 1,
                ProductId = 1,
                Quantity = 1,
                UserId = 1
            };
            var result = await facade.UpdateItem(request);
        }

        [Fact]
        public async void Should_Apply_Coupon()
        {
            var facade = _serviceProvider.GetService<ICartFacade>();
            var request = new ApplyCouponRequest
            {
                CartId = 1,
                CouponId = 1,
                UserId = 1
            };
            var result = await facade.ApplyCoupon(request);
        }

        [Fact]
        public void Should_Not_Apply_Coupon()
        {

        }

        [Fact]
        public void Should_Apply_Campaign()
        {
            var facade = _serviceProvider.GetService<ICartFacade>();
            var result = facade.ApplyCampaign();
        }

        [Fact]
        public void Should_Not_Apply_Campaign()
        {

        }

        [Fact]
        public void Should_Calculate_delivery_Cost()
        {
            var facade = _serviceProvider.GetService<ICartFacade>();
            var result = facade.CalculateDeliveryCost();
        }

        [Fact]
        public void Should_Calculate_Total()
        {

        }
    }
}