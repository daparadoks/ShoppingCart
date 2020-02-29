using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Api.Domain;
using ShoppingCart.Api.Repositories;
using Xunit;
using Xunit.Abstractions;

namespace ShoppingCart.Test
{
    public class RepositoryTest : BaseTest, IClassFixture<TestStartUp>
    {
        private readonly ServiceProvider _serviceProvider;
        
        public RepositoryTest(TestStartUp testStartUp, ITestOutputHelper output) : base(output) =>
            _serviceProvider = testStartUp.ServiceProvider;

        [Fact]
        public void Should_Add_Category()
        {
            var repository = _serviceProvider.GetService<ICategoryRepository>();
            var category = new Category
            {
                Title = "Bilgisayar Bileşenleri"
            };
            repository.Add(category);
            category.Id.Should().BeGreaterThan(0);
        }
        
    }
}