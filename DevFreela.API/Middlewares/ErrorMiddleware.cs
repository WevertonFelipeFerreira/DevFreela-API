using DevFreela.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DevFreela.API.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorMiddleware(RequestDelegate next)
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
            ErrorResponse errorResponseVm;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                errorResponseVm = new ErrorResponse(ex, $"{ex.Message}");
            }
            else
            {
                errorResponseVm = new ErrorResponse();
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