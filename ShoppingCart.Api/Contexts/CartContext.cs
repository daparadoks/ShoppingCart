using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain;
using ShoppingCart.Api.Dto.Response;
using ShoppingCart.Api.Services;

namespace ShoppingCart.Api.Contexts
{
    public class CartContext : ICartContext
    {
        private readonly IUserContext _userContext;
        private readonly ICartService _cartService;
        private readonly ICouponService _couponService;

        public CartContext(IUserContext userContext, ICartService cartService, ICouponService couponService)
        {
            _userContext = userContext;
            _cartService = cartService;
            _couponService = couponService;
        }

        public async Task<Cart> Get() => await _cartService.GetOrAddCart(await GetId(), await _userContext.GetId());
        public async Task<int?> GetId() => await _cartService.GetIdByUserId(await _userContext.GetId());
        public async Task AddItem(int productId, int quantity)
        {
            var cart = await Get();
            var item = cart.Items.FirstOrDefault(x => x.ProductId == productId);
            if (item == null)
                return;

            item.Quantity = quantity;
            await _cartService.Update(cart);
        }

        public async Task RemoveItem(int productId)
        {
            var cart = await Get();
            cart.Items = cart.Items.Where(x => x.ProductId != productId).ToList();
            await _cartService.Update(cart);
        }

        public async Task UpdateItem(int productId, int quantity)
        {
            var cart = await Get();
            var cartItem = cart.Items.FirstOrDefault(x => x.ProductId == productId);
            if (cartItem == null)
                return;

            cartItem.Quantity = quantity;
            await _cartService.Update(cart);
        }

        public async Task<bool> ApplyCoupon(int couponId)
        {
            var cartTask = Get();
            var couponTask = _couponService.Get(couponId);

            await Task.WhenAll(cartTask, couponTask);

            var cart = cartTask.Result;
            var coupon = couponTask.Result;

            //apply coupon to cart
            await _cartService.Update(cart);
            return true;
        }

        public async Task<Cart> ApplyCampaign()
        {
            var cart = await Get();
            //apply campaing update total etc
            _cartService.Update(cart);
            return cart;
        }

        public async Task<Cart> CalculateDeliveryCost()
        {
            var cart = await Get();
            //calculate delivery etc
            _cartService.Update(cart);
            return cart;
        }
    }
}