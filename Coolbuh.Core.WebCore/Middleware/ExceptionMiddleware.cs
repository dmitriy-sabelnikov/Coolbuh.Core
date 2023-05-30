using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.UseCases.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Coolbuh.Core.WebCore.Middleware
{
    /// <summary>
    /// Промежуточное ПО обработки ошибок
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode;
            string message;

            if (exception is NotValidEntityEntityException || exception is DomainException
                || exception is NotFoundEntityUseCaseException || exception is UseCaseException)
            {
                if(exception is NotFoundEntityUseCaseException)
                {
                    statusCode = (int)HttpStatusCode.NotFound;
                }
                else
                {
                    statusCode = (int)HttpStatusCode.BadRequest;
                }

                message = exception.Message;

                LogWarning(statusCode.ToString(), message, context.Request.Path, context.Request.Method);
            }
            else
            {
                statusCode = (int)HttpStatusCode.InternalServerError;
                message = @"Внутрішня помилка сервера";
                var exceptionMessage = exception.Message;

                if (exception.InnerException != null)
                {
                    if (exception.InnerException is SqlException && context.Request.Method == "DELETE")
                    {
                        message += @". Можливо є посилання на на цей запис в інших таблицях";
                    }

                    exceptionMessage += Environment.NewLine;
                    exceptionMessage += "InnerException: " + exception.InnerException.Message;
                }

                LogException(statusCode.ToString(), message, context.Request.Path,
                    context.Request.Method, exceptionMessage, exception.StackTrace);
            }

            context.Response.ContentType = "text/plain charset=utf-8";
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(message);
        }

        private void LogWarning(string statusCode, string message, string controller, string method)
        {
            _logger.LogWarning(
                "StatusCode: {statusCode} \n" +
                "Message: {message} \n" +
                "Controller: {controller} \n" +
                "Method: {method}",
                statusCode, message, controller, method);
        }

        private void LogException(string statusCode, string message, string controller, string method,
            string exceptionMessage, string stackTrace)
        {
            _logger.LogError(
                "StatusCode: {statusCode}\n" +
                "Message: {message}\n" +
                "Controller: {controller}\n" +
                "Method: {method}\n" +
                "Exception message: {exceptionMessage}\n" +
                "StackTrace: {stackTrace}",
                statusCode, message, controller, method, exceptionMessage, stackTrace);
        }
    }

    /// <summary>
    /// Подключение промежуточного ПО обработки ошибок
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
