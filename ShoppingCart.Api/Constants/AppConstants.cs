namespace ShoppingCart.Api.Constants
{
    public static class AppConstants
    {
        public static string CartId(int userId) => $"Cart:UserId_{userId}";
    }
}