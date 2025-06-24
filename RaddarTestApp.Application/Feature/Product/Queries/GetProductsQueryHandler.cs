using MediatR;
using RaddarTestApp.Domain.Services;

namespace RaddarTestApp.Application.Feature.Product.Queries
{
    public class GetProductsQueryHandler(ProductService productService) : IRequestHandler<GetProductsQuery, IEnumerable<Domain.Entities.Product>>
    {
        private readonly ProductService _productService = productService;

        public async Task<IEnumerable<Domain.Entities.Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetProductsAsync();
        }
    }
}
