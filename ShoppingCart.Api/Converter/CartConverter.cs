using ShoppingCart.Api.Domain;
using ShoppingCart.Api.Dto.Response;

namespace ShoppingCart.Api.Converter
{
    public static class CartConverter
    {
        public static CartResponse ToResponse(this Cart cart)
        {
            return new CartResponse();
        }
    }
}