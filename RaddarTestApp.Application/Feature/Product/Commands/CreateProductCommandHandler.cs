using MediatR;
using RaddarTestApp.Domain.Services;

namespace RaddarTestApp.Application.Feature.Product.Commands
{
    public class CreateProductCommandHandler(ProductService productService) : IRequestHandler<CreateProductCommand, Domain.Entities.Product>
    {
        private readonly ProductService _productService = productService;

        public async Task<Domain.Entities.Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = new() { 
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock
            };

            return await _productService.CreateProductAsync(product);
        }
    }
}
