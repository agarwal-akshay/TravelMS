using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelMS.Controllers
{
    public class AjaxMethodsController : Controller
    {
        public JsonResult CheckApprover(string First_Level_Approver)
        {

            if (CheckApproverBiz.ApproverIsFirstLevel(First_Level_Approver))
                return Json(true, JsonRequestBehavior.AllowGet);

            return Json("Unauthorized Approver", JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /AjaxMethods/User_IDCheck

        [HttpPost]
        public bool User_IDCheck(string User_ID)
        {
            //to do: implement web services workflow
            Console.WriteLine(Request.Params[0].ToString());
            return (User_IDCheckBizLayer.User_IDCheckBiz(User_ID));
        }
    }
}
