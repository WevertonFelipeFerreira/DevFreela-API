using System;
using System.Collections.Generic;

namespace DevFreela.Application.ViewModels
{
    public class ErrorResponseVm
    {
        public string Title { get; private set; }
        public int Status { get; private set; }
        public string Detail { get; private set; }
        public IDictionary<string, List<string>> Errors { get; private set; }
        public string TraceId { get; private set; }

        public ErrorResponseVm()
        {
            Title = "Internal Server Error";
            Detail = "An unexpected error ocurred";
            Status = 500;
            TraceId = Guid.NewGuid().ToString();
            Errors = new Dictionary<string, List<string>>();
        }

        public ErrorResponseVm(string title, string detail, int status)
        {
            Title = title;
            Status = status;
            TraceId = Guid.NewGuid().ToString();
            Detail = detail;
            Errors = new Dictionary<string, List<string>>();
        }

        public void AddError(string propertyName, List<string> messages)
        {
            Errors.Add(propertyName, messages);
        }
    }
}