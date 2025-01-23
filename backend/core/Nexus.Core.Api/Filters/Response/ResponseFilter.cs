using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Nexus.Core.Api.Filters.Response;

public sealed class ResponseFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var result = await next(context);

        var response = GetResponseBase(result, out var statusCode, out var location);

        var url = context.HttpContext.Request.GetDisplayUrl();

        result = statusCode switch
        {
            Status200OK => Results.Ok(response),
            Status201Created => Results.Created($"{url}/{location}", response),
            Status202Accepted => Results.Accepted(url, response),
            Status204NoContent => Results.NoContent(),
            Status400BadRequest => Results.BadRequest(response),
            Status404NotFound => Results.NotFound(response),
            Status500InternalServerError => Results.InternalServerError(response),
            _ => result
        };

        return result;
    }

    private static ResponseBase<object?> GetResponseBase(object? result, out int? statusCode, out string? location)
    {
        object? value = null;

        if (result is IValueHttpResult<object?> httpResult)
        {
            if (httpResult is ProblemHttpResult problemResult)
                value = problemResult.ProblemDetails.Detail;
            else
                value = httpResult?.Value;
        }

        statusCode = (result as IStatusCodeHttpResult)?.StatusCode;
        var isSuccess = statusCode is >= Status200OK and <= Status204NoContent;

        if (statusCode is Status201Created or Status202Accepted)
            location = result?.GetType().GetProperties()
                .FirstOrDefault(p => p.Name == "Location")?.GetValue(result)?.ToString();
        else
            location = null;

        if (isSuccess)
            return new ResponseBase<object?>(value);
        else
        {
            var errorMessage = (value is not null) ? value.ToString() : ((HttpStatusCode)statusCode!).ToString();
            return new ResponseBase<object?>(errorMessage);
        }
    }
}