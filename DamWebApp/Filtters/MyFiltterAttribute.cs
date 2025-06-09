using Microsoft.AspNetCore.Mvc.Filters;

namespace DamWebApp.Filtters
{
    public class MyFiltterAttribute : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //logic 
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           //logic
        }
    }
}
