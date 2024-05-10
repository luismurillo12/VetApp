using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VetApp.Services
{
	public class FilterSecurity : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (context.HttpContext.Session.GetString("UserNickName") == null)
			{
				context.Result = new RedirectToRouteResult(new RouteValueDictionary
				{
					{ "controller","Home"},
					{ "action","Index"}
				});
			}

			base.OnActionExecuting(context);
		}
	}
}
