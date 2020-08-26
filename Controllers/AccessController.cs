using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace BusinessManagment.Controllers
{
    public class AccesController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string accountLoginUser = HttpContext.Session.GetString("AccountLoginUser");
            if(!string.IsNullOrEmpty(accountLoginUser)){
                base.OnActionExecuting(context);
                // return;
            } else {
                // context.Result = new RedirectResult("/"){Permanent = true};    
                context.Result = new UnauthorizedResult();
                base.OnActionExecuting(context);
            }  

            // if(HttpContext.User.Identity.IsAuthenticated){
            //     base.OnActionExecuting(context);
            //     // return;
            // } else {
            //     // context.Result = new RedirectResult("/"){Permanent = true};    
            //     context.Result = new UnauthorizedResult();
            //     base.OnActionExecuting(context);
            // }            
        }
    }    
}