using MediatR;
using RaddarTestApp.Domain.Services;

namespace RaddarTestApp.Application.Feature.Product.Commands
{
    public class UpdateProductCommandHandler(ProductService productService) : IRequestHandler<UpdateProductCommand, Domain.Entities.Product>
    {
        private readonly ProductService _productService = productService;

        public async Task<Domain.Entities.Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = new()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock
            };

            return await _productService.UpdateProductAsync(product);
        }
    }
}
