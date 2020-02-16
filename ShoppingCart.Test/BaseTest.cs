using Xunit.Abstractions;

namespace ShoppingCart.Test
{
    public class BaseTest
    {
        private readonly ITestOutputHelper _output;
        protected BaseTest(ITestOutputHelper output) => _output = output;
    }
}