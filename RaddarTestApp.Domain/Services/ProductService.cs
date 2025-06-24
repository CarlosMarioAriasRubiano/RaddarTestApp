using RaddarTestApp.Domain.Entities;
using RaddarTestApp.Domain.Enums;
using RaddarTestApp.Domain.Exceptions;
using RaddarTestApp.Domain.Helpers;
using RaddarTestApp.Domain.Ports;

namespace RaddarTestApp.Domain.Services
{
    [DomainService]
    public class ProductService(
        IGenericRepository<Product> productRepository,
        IQueryDapper queryDapper
    )
    {
        private readonly IGenericRepository<Product> _productRepository = productRepository;
        private readonly IQueryDapper _queryDapper = queryDapper;

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            productId.ValidateInvalidId();

            Product product = await _queryDapper.QuerySingleAsync<Product>(
                ItemQueryConstants.GetProductById.GetDescription(),
                new { productId }
            ) ?? throw new AppException(string.Format(MessagesExceptions.DontExistProduct, productId));

            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _queryDapper.QueryAsync<Product>(
                ItemQueryConstants.GetProducts.GetDescription()
            );
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            ValidateProduct(product);

            product.CreateDate = DateTime.Now;

            return await _productRepository.CreateAsync(product);
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            ValidateProduct(product);

            return await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int productId)
        {
            Product product = await GetProductByIdAsync(productId);

            await _productRepository.DeleteAsync(product);
        }

        private static void ValidateProduct(Product product)
        {
            product.ValidateNullObject();
            product.Id.ValidateInvalidId();
            product.ValidatePriceGreatherThanZero();
            product.ValidateStockGreatherThanZero();
        }
    }
}
