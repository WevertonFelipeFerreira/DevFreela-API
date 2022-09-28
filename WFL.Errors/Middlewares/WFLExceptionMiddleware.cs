using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using WFL.Errors.Models;

namespace WFL.Errors.Middlewares
{
    public class WFLExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public WFLExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ExceptionError errorResponseVm;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                errorResponseVm = new ExceptionError(ex, $"{ex.Message}", context);
            }
            else
            {
                errorResponseVm = new ExceptionError(context);
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(errorResponseVm,
                                                    Formatting.None,
                                                    new JsonSerializerSettings
                                                    {
                                                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                                                        NullValueHandling = NullValueHandling.Ignore
                                                    });

            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
