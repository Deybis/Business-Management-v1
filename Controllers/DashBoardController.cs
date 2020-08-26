using Microsoft.AspNetCore.Mvc;
using BusinessManagment.Entities;
using Microsoft.AspNetCore.Http;

namespace BusinessManagment.Controllers
{
    public class DashBoardController : AccesController
    {
        public up_ADM_DashBoardSelectCollection Get()
        {
            var accountUserName = HttpContext.Session.GetString("AccountLoginUser");//HttpContext.User.Identity.Name;
            up_ADM_DashBoardSelectCollection dashBoardData = new up_ADM_DashBoardSelectCollection();
            if (!string.IsNullOrEmpty(accountUserName))
            {
                dashBoardData = new up_ADM_DashBoardSelectCollection().Select(0,accountUserName);
            }
            return (dashBoardData);
        }

        // public IActionResult Home()
        // {
        //     up_ADM_DashBoardSelectCollection dashBoardData = new up_ADM_DashBoardSelectCollection();
        //     var accountUserName = "dechavez";// HttpContext.User.Identity.Name;
        //     if (!string.IsNullOrEmpty(accountUserName))
        //     {
        //         dashBoardData = new up_ADM_DashBoardSelectCollection().Select(0, accountUserName);
        //     }
        //     return Ok(dashBoardData);
        // }
    }
}