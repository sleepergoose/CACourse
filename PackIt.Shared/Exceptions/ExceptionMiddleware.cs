using Microsoft.AspNetCore.Http;
using PackIt.Shared.Abstractions.Exceptions;
using System.Text.Json;

namespace PackIt.Shared.Exceptions;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next(context);
		}
		catch (CACourseException ex)
		{
			context.Response.StatusCode = 400;
			context.Response.Headers.Add("content-type", "application/json");

			var errorCode = ToUnderscoreCase(ex.GetType().Name.Replace("Exception", string.Empty));
			var json = JsonSerializer.Serialize(new { ErrorCode = errorCode, ex.Message });

			await context.Response.WriteAsync(json);
		}
    }

    private static string ToUnderscoreCase(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return string.Empty;
		}

		return string.Concat((value ?? string.Empty).Select((x, i) => i > 0 && char.IsUpper(x) && !char.IsUpper(value![i - 1]) ? $"_{x}" : x.ToString())).ToLower();
    }
}
