using System;
using System.Threading.Tasks;
using ShoppingCart.Api.Contexts;
using ShoppingCart.Api.Converter;
using ShoppingCart.Api.Domain;
using ShoppingCart.Api.Dto.Request;
using ShoppingCart.Api.Dto.Response;
using ShoppingCart.Api.Services;

namespace ShoppingCart.Api.Facades
{
    public class CartFacade: Facade, ICartFacade
    {
        private readonly ICartService _cartService;
        private readonly ICouponService _couponService;
        private readonly ICartContext _cartContext;

        public CartFacade(ICartService cartService, ICouponService couponService, ICartContext cartContext)
        {
            _cartService = cartService;
            _couponService = couponService;
            _cartContext = cartContext;
        }

        public async Task<bool> AddItem(UpdateCartItemRequest request)
        {
            if (request.Quantity == 0)
                return false;

            await _cartContext.AddItem(request.ProductId, request.Quantity);
            return true;
        }

        public async Task<bool> UpdateItem(UpdateCartItemRequest request)
        {
            if(!request.CartId.HasValue)
                throw new ArgumentNullException();

            if (request.Quantity == 0)
                _cartContext.RemoveItem(request.ProductId);
            else
                _cartContext.UpdateItem(request.ProductId, request.Quantity);

            return true;
        }

        public async Task<bool> ApplyCoupon(ApplyCouponRequest request) => await _cartContext.ApplyCoupon(request.CouponId);

        public async Task<CartResponse> ApplyCampaign()
        {
            var cart = await _cartContext.ApplyCampaign();
            return cart.ToResponse();
        }

        public async Task<CartResponse> CalculateDeliveryCost()
        {
            var cart = await _cartContext.CalculateDeliveryCost();
            return cart.ToResponse();
        }
    }
}