using MediatR;

namespace RaddarTestApp.Application.Feature.Product.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Domain.Entities.Product>>;
}
