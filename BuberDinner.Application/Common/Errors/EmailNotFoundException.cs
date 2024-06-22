using System.Net;

namespace BuberDinner.Application.Common.Errors;

public class EmailNotFoundException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

    public string ErrorMessage => "User with given email does not exist.";
}