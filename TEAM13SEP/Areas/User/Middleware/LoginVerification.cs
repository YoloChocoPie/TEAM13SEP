
using System.Web.Mvc;

namespace TEAM13SEP.Areas.User.Middleware
{
    public class LoginVerification : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["user-id1"] == null)
            {
                filterContext.Result = new RedirectResult("~/User/Auth/Login");
                return;
            }
        }

    }
}