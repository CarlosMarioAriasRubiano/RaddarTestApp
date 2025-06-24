using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaddarTestApp.Application.Feature.Product.Commands;
using RaddarTestApp.Application.Feature.Product.Queries;
using RaddarTestApp.Domain.Entities;

namespace RaddarTestApp.Api.Controllers
{
    [Authorize]
    [Route("api/products")]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{id}")]
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _mediator.Send(
                new GetProductByIdQuery(id)
            );
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _mediator.Send(new GetProductsQuery());
        }

        [HttpPost]
        public async Task<Product> CreateProductAsync(
            [FromBody] CreateProductCommand command
        )
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<Product> UpdateProductAsync(
            [FromBody] UpdateProductCommand command
        )
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task DeleteProductAsync(
            int id
        )
        {
            await _mediator.Send(new DeleteProductCommand(id));
        }
    }
}
