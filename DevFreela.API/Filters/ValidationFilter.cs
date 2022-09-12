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
                var errors = context.ModelState
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToList();

                var badRequest = new
                {
                    title = "Bad Request",
                    status = 400,
                    detail = "One or more validation occurred.",
                    errors = errors
                };

                context.Result = new BadRequestObjectResult(badRequest);
            }
        }
    }
}
