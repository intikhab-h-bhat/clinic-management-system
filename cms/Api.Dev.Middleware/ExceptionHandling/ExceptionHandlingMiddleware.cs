using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Api.Dev.Middleware.Ui.ExceptionHandling
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorResponse = new
            {
                message = "An unexpected error occurred.",
                error = exception.Message,
                statusCode = context.Response.StatusCode
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            //Console.WriteLine($"Exception: {exception.Message}"); // Logging
            //return context.Response.WriteAsync(JsonSerializer.Serialize(new
            //{
            //    message = "An error occurred.",
            //    error = exception.Message,
            //    statusCode = 500
            //}));
        }



        //    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        //{
        //    // Set the response content type
        //    context.Response.ContentType = "application/json";

        //    // Determine the status code and error message
        //    var (statusCode, message) = exception switch
        //    {
        //        NotFoundException _ => (HttpStatusCode.NotFound, "Resource not found"),
        //        ValidationException _ => (HttpStatusCode.BadRequest, "Invalid input"),
        //        _ => (HttpStatusCode.InternalServerError, "An error occurred")
        //    };

        //    // Create the error response
        //    var response = new
        //    {
        //        StatusCode = (int)statusCode,
        //        Message = message,
        //        // Include stack trace only in development
        //        Details = context.RequestServices.GetRequiredService<IHostEnvironment>().IsDevelopment()
        //            ? exception.StackTrace
        //            : null
        //    };

        //    // Serialize the response
        //    var jsonResponse = JsonSerializer.Serialize(response);

        //    // Set the HTTP status code
        //    context.Response.StatusCode = (int)statusCode;

        //    // Write the JSON response
        //    await context.Response.WriteAsync(jsonResponse);
        //}
    }
}

    

