using MediatR;
using Microsoft.AspNetCore.Authorization;
using RaddarTestApp.Application.Feature.Login.Commands;
using RaddarTestApp.Domain.Dtos;
using RaddarTestApp.Domain.Exceptions;

namespace RaddarTestApp.Api.Filters
{
    public class TokenVerificationMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            var hasAuthorize = endpoint?.Metadata?.GetMetadata<AuthorizeAttribute>() != null;

            if (hasAuthorize)
            {
                var mediator = context.RequestServices.GetService<IMediator>();
                var token = context.Request.Headers.Authorization.FirstOrDefault();

                if (!string.IsNullOrEmpty(token))
                {
                    try
                    {
                        var isValid = await mediator!.Send(new ValidateTokenCommand(token));

                        if (!isValid)
                        {
                            await ReturnError(context, MessagesExceptions.InvalidToken);
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        await ReturnError(context, MessagesExceptions.InvalidToken);
                        return;
                    }
                }
            }

            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                await ReturnError(context, MessagesExceptions.InputToken);
                return;
            }
        }

        private static async Task ReturnError(
            HttpContext context,
            string message
        )
        {
            ObjectResultDto objectResult = new()
            {
                Successful = false,
                Code = StatusCodes.Status401Unauthorized,
                Message = message
            };

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

            await context.Response.WriteAsJsonAsync(objectResult);
        }
    }
}
