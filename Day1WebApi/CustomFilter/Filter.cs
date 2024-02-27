using Day1WebApi.Model.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Day1WebApi.CustomFilter
{
    public class Filter :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Department dept = (Department)context.ActionArguments["Dept"];

            if (dept.Location != "EG" && dept.Location != "USA")
            {
                context.Result = new BadRequestObjectResult("A department can only be in EG or USA");
            }
        }
    }
}
