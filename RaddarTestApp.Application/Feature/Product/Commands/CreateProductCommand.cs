using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RaddarTestApp.Application.Feature.Product.Commands
{
    public record CreateProductCommand(
        [Required] string Name,
        [Required] string Description,
        [Required] decimal Price,
        [Required] int Stock
    ) : IRequest<Domain.Entities.Product>;
}
