using DevFreela.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace DevFreela.API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorResponse = new ErrorResponseVm("Bad Request", "One or more validation errors ocurred", 400);
                foreach (var modelState in context.ModelState)
                {
                    var errorsMessages = modelState.Value.Errors
                        .Select(x => x.ErrorMessage)
                        .ToList();

                    errorResponse.AddError(modelState.Key.ToLower(), errorsMessages);
                };

                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }
    }
}
