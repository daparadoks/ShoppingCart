using System.Collections.Generic;

namespace ShoppingCart.Api.Dto.Request
{
    public class UpdateCartItemRequest
    {
        public int? CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        
        public int GetCartId => CartId.HasValue ? CartId.Value:0; 
    }
}