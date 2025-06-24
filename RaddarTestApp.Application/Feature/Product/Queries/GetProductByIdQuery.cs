using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RaddarTestApp.Application.Feature.Product.Queries
{
    public record GetProductByIdQuery(
        [Required] int ProductId    
    ) : IRequest<Domain.Entities.Product>;
}
