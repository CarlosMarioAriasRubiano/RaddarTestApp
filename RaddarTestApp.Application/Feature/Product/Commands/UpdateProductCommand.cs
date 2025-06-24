using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RaddarTestApp.Application.Feature.Product.Commands
{
    public record UpdateProductCommand(
        [Required] int Id,
        [Required] string Name,
        [Required] string Description,
        [Required] decimal Price,
        [Required] int Stock
    ) : IRequest<Domain.Entities.Product>;
}
