﻿namespace ShoppingCart.Api.Domain
{
    public class Campaign: DiscountBase
    {
        public Campaign(Category category, DiscountType discountType, int minimumItem, double discount) : base(discount, discountType)
        {
            Category = category;
            MinimumItem = minimumItem;
        }

        public Category Category { get;}
        public int MinimumItem { get;}

        public int CategoryId { get; set; }
    }
}