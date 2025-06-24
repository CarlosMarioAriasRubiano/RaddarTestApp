using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RaddarTestApp.Domain.Dtos;

namespace RaddarTestApp.Api.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class AppSuccessfulFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context != null && context.Exception == null
                && context.HttpContext.Response.StatusCode >= 200 && context.HttpContext.Response.StatusCode < 300
            )
            {
                if (context.Result is FileContentResult)
                {
                    return;
                }

                ObjectResultDto objectResult = new()
                {
                    Successful = true,
                    Code = (int)context.HttpContext.Response.StatusCode,
                    Message = "Operación exitosa",
                    Data = context.Result is EmptyResult
                        ? null!
                        : (context.Result as ObjectResult)!.Value!
                };

                context.Result = new ObjectResult(objectResult);
            }
        }
    }
}
