using NSubstitute;
using NSubstitute.ReturnsExtensions;
using RaddarTestApp.Domain.Entities;
using RaddarTestApp.Domain.Enums;
using RaddarTestApp.Domain.Exceptions;
using RaddarTestApp.Domain.Helpers;
using RaddarTestApp.Domain.Ports;
using RaddarTestApp.Domain.Services;
using RaddarTestApp.Domain.Tests.DataBuilder;

namespace RaddarTestApp.Domain.Tests.ServiceTest
{
    [TestClass]
    public class ProductServiceTest
    {
        private IGenericRepository<Product> ProductRepository { get; set; } = default!;
        private IQueryDapper QueryDapper { get; set; } = default!;
        private ProductService ProductService { get; set; } = default!;
        private ProductDataBuilder ProductDataBuilder { get; set; } = default!;

        [TestInitialize]
        public void Initialize()
        {
            ProductRepository = Substitute.For<IGenericRepository<Product>>();
            QueryDapper = Substitute.For<IQueryDapper>();

            ProductService = new(
                ProductRepository,
                QueryDapper
            );

            ProductDataBuilder = new();
        }

        [TestMethod]
        public async Task GetProductByIdAsync_Ok()
        {
            // Arrange
            Product product = ProductDataBuilder
                .WithId(1)
                .WithName("Cepillo Colgate")
                .WithDescription("Sirve para cepillar")
                .WithPrice(1000)
                .WithStock(15)
                .Build();

            QueryDapper
                .QuerySingleAsync<Product>(
                    ItemQueryConstants.GetProductById.GetDescription(),
                    new { product.Id }
                )
                .ReturnsForAnyArgs(product);

            // Act
            Product result = await ProductService.GetProductByIdAsync(product.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(product.Id, result.Id);
            await QueryDapper.ReceivedWithAnyArgs(1)
                .QuerySingleAsync<Product>(
                    Arg.Any<string>(),
                    Arg.Any<object>()
                );
        }

        [TestMethod]
        public async Task GetProductByIdAsync_Error_InvalidId()
        {
            // Arrange
            Product product = ProductDataBuilder
                .WithId(-1)
                .Build();

            // Act
            AppException ex = await Assert.ThrowsExceptionAsync<AppException>(async () =>
            {
                await ProductService.GetProductByIdAsync(product.Id);
            });

            // Assert
            Assert.AreEqual(MessagesExceptions.InvalidId, ex.Message);
        }

        [TestMethod]
        public async Task GetProductByIdAsync_Error_DontExistProduct()
        {
            // Arrange
            Product product = ProductDataBuilder
                .WithId(1)
                .Build();

            QueryDapper
                .QuerySingleAsync<Product>(
                    ItemQueryConstants.GetProductById.GetDescription(),
                    new { product.Id }
                )
                .ReturnsNullForAnyArgs();

            // Act
            AppException ex = await Assert.ThrowsExceptionAsync<AppException>(async () =>
            {
                await ProductService.GetProductByIdAsync(product.Id);
            });

            // Assert
            Assert.AreEqual(string.Format(MessagesExceptions.DontExistProduct, product.Id), ex.Message);
            await QueryDapper.ReceivedWithAnyArgs(1)
                .QuerySingleAsync<Product>(
                    Arg.Any<string>(),
                    Arg.Any<object>()
                );
        }
    }
}
