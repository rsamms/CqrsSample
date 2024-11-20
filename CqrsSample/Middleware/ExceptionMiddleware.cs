using CqrsSample.Framework.Models;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace CqrsSample.Middleware
{
    public class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, IWebHostEnvironment hostingEnvironment) : IExceptionHandler
    {
        private readonly ILogger<ExceptionMiddleware> _logger = logger;
        private readonly IWebHostEnvironment _hostingEnvironment = hostingEnvironment;

        public static ErrorDetails CreateErrorDetails(Exception exception, string environmentName, bool showSensitiveInformation = false)
        {
            var errorDetails = new ErrorDetails()
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = showSensitiveInformation ? exception.Message : "An unexpected error occurred",
                StackTrace = showSensitiveInformation ? exception.StackTrace : null
            };


            if (!(exception is ValidationException validationException))
            {
                return errorDetails;
            }

            errorDetails.StatusCode = (int)HttpStatusCode.BadRequest;

            var aggregateErrors = validationException.Errors.GroupBy(err => err.PropertyName).Select(errGroup => new
            {
                Key = errGroup.Key,
                ErrorMessages = errGroup.Select(item => item.ErrorMessage)
            });

            foreach (var aggregateError in aggregateErrors)
            {
                errorDetails.Errors.Add(aggregateError.Key, aggregateError.ErrorMessages.ToList());
            }

            return errorDetails;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
           
            _logger.LogError(exception.ToString());
            await HandleExceptionAsync(httpContext, exception);

            return true;
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            var errorDetails = CreateErrorDetails(exception, _hostingEnvironment.EnvironmentName, showSensitiveInformation: _hostingEnvironment.IsDevelopment());
            httpContext.Response.StatusCode = errorDetails.StatusCode;
            return httpContext.Response.WriteAsync(errorDetails.ToString());
        }
    }
}

