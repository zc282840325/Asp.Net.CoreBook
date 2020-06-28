using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagerWeb.Filert
{
    public class SampleActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)((Microsoft.AspNetCore.Mvc.Routing.UrlHelperBase)((Microsoft.AspNetCore.Mvc.ControllerBase)context.Controller).Url).ActionContext.ActionDescriptor).ControllerName;
            var action = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)((Microsoft.AspNetCore.Mvc.Routing.UrlHelperBase)((Microsoft.AspNetCore.Mvc.ControllerBase)context.Controller).Url).ActionContext.ActionDescriptor).ActionName;
            if (controller=="Home"&&action=="Login")
            {
              
            }
            else
            {
                var token = context.HttpContext.Request.Cookies["token"];
                if (token == null)
                {
                    context.HttpContext.Response.Redirect("Home/Login");
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           
        }
    }
}
