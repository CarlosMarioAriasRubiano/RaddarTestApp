using MediatR;
using RaddarTestApp.Domain.Services;

namespace RaddarTestApp.Application.Feature.Product.Commands
{
    public class DeleteProductCommandHandler(ProductService productService) : AsyncRequestHandler<DeleteProductCommand>
    {
        private readonly ProductService _productService = productService;

        protected override async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.DeleteProductAsync(request.ProductId);
        }
    }
}
