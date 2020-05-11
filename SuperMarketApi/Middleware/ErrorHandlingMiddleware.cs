
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Supermarket.API.Exceptions;

namespace Supermarket.API.Middleware
{
  public class ErrorHandlingMiddleware
  {
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task Invoke(HttpContext context, IWebHostEnvironment env)
    {
      try
      {
        await _next(context);
      }
      catch (Exception ex)
      {
        await HandleExceptionAsync(context, ex, env);
      }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment env)
    {
      HttpStatusCode status;
      var stackTrace = String.Empty;

      var exceptionType = exception.GetType();
      string message = exception.Message;

      if (exceptionType == typeof(BadRequestException))
      {
        status = HttpStatusCode.BadRequest;
      }
      else if (exceptionType == typeof(NotFoundException))
      {
        status = HttpStatusCode.NotFound;
      }
      else if (exceptionType == typeof(DuplicateException))
      {
        status = HttpStatusCode.Conflict;
      }
      else
      {
        status = HttpStatusCode.InternalServerError;
        
        if (env.IsEnvironment("Development"))
          stackTrace = exception.StackTrace;
      }

      var result = JsonSerializer.Serialize(new { error = message, stackTrace });
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)status;
      return context.Response.WriteAsync(result);
    }
  }
}