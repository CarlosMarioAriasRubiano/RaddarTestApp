using MediatR;
using RaddarTestApp.Domain.Services;

namespace RaddarTestApp.Application.Feature.Product.Queries
{
    public class GetProductByIdQueryHandler(ProductService productService) : IRequestHandler<GetProductByIdQuery, Domain.Entities.Product>
    {
        private readonly ProductService _productService = productService;

        public async Task<Domain.Entities.Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetProductByIdAsync(request.ProductId);
        }
    }
}
