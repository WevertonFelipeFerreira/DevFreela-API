using Microsoft.AspNetCore.Http;
using WFL.Errors.Interfaces;

namespace WFL.Errors.Models
{
    internal class ExceptionError : IError
    {
        public string Title { get; private set; }
        public int Status { get; private set; }
        public string Detail { get; private set; }
        public string Instance { get; private set; }
        public Exception ExceptionDetails { get; set; } = null!;
        public string TraceId { get; private set; }

        public ExceptionError(HttpContext context)
        {
            Title = Messages.INTERNAL_SERVER_ERROR;
            Detail = Messages.UNEXPECTED_ERROR;
            Status = 500;
            Instance = context.Request.Path;
            TraceId = context.TraceIdentifier;
        }
        public ExceptionError(Exception exception, string detail, HttpContext context)
        {
            Title = Messages.UNEXPECTED_ERROR;
            Detail = detail;
            Status = 500;
            Instance = context.Request.Path;
            TraceId = context.TraceIdentifier;
            ExceptionDetails = exception;
        }
    }
}
