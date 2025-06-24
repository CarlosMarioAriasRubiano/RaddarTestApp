using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RaddarTestApp.Domain.Dtos;
using RaddarTestApp.Domain.Exceptions;
using System.Net;

namespace RaddarTestApp.Api.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class AppExceptionFilterAttribute(ILogger<AppExceptionFilterAttribute> _logger) : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context != null && context.Exception != null)
            {
                string errorMessage = context.Exception.Message;

                var statusCode = context.Exception switch
                {
                    ArgumentNullException or AppException => HttpStatusCode.BadRequest,
                    UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                    _ => HttpStatusCode.InternalServerError,
                };

                context.HttpContext.Response.StatusCode = (int)statusCode;

                _logger.LogError(context.Exception, errorMessage);

                ObjectResultDto objectResult = new()
                {
                    Successful = false,
                    Code = (int)statusCode,
                    Message = errorMessage
                };

                context.Result = new ObjectResult(objectResult);
            }
        }
    }
}
