using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AllMark.Code.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class UserViewBagAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var sessionUser = context.HttpContext.User.Identity;
            var controller = context.Controller as Controller;
            if (controller != null)
                controller.ViewBag.User = !string.IsNullOrEmpty(sessionUser.Name) ? sessionUser : null;
            base.OnActionExecuted(context);
        }
    }
}
