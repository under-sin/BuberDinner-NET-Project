using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    override public void OnException(ExceptionContext context)
    {
        var problemDetails = new ProblemDetails
        {
            Status = (int)HttpStatusCode.InternalServerError,
            Title = context.Exception.Message,
        };

        context.Result = new ObjectResult(problemDetails);

        context.ExceptionHandled = true;
    }
}