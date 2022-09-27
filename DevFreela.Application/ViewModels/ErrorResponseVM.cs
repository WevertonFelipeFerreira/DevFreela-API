using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DevFreela.Application.ViewModels
{
    public class ErrorResponse
    {
        public string Title { get; private set; }
        public int Status { get; private set; }
        public string Detail { get; private set; }
        public IDictionary<string, List<string>> Errors { get; private set; } = null;
        public string TraceId { get; private set; }
        [JsonProperty("exceptionDetails", NullValueHandling = NullValueHandling.Ignore)]
        public Exception ExceptionDetails { get; private set; } = null;

        public ErrorResponse()
        {
            Title = "Internal Server Error";
            Detail = "An unexpected error ocurred";
            Status = 500;
            TraceId = Guid.NewGuid().ToString();
        }
        public ErrorResponse(Exception exception, string detail)
        {
            Title = "Internal Server Error";
            Detail = detail;
            Status = 500;
            TraceId = Guid.NewGuid().ToString();
            ExceptionDetails = exception;
        }

        public ErrorResponse(string title, string detail, int status)
        {
            Title = title;
            Status = status;
            TraceId = Guid.NewGuid().ToString();
            Detail = detail;
        }

        public void AddError(string propertyName, List<string> messages)
        {
            if (Errors is null)
                Errors = new Dictionary<string, List<string>>();

            Errors.Add(propertyName, messages);
        }
    }
}