using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelMS.Controllers
{
    public class AjaxMethodsController : Controller
    {
        //
        // POST: /AjaxMethods/User_IDCheck

        [HttpPost]
        public bool User_IDCheck(string User_ID)
        {
            //to do: implement web services workflow
            Console.WriteLine(Request.Params[0].ToString());
            return (User_IDCheckBizLayer.User_IDCheckBiz(User_ID));
        }
        //
        // POST: /AjaxMethods/unlockAccount

        //[HttpPost]
        //public bool unlockAccount(string User_ID)
        //{
        //    Console.WriteLine(Request.Params[0].ToString());
        //    if (AdminPanelBizLayer.unlockAccount(User_ID))
        //        return true;
        //    return false;
        //}
    }
}
