using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RaddarTestApp.Application.Feature.Product.Commands
{
    public record DeleteProductCommand(
        [Required] int ProductId    
    ) : IRequest;
}
