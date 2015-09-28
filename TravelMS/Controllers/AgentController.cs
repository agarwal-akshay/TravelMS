using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelMS.Filters;
using TravelMS.Models;

namespace TravelMS.Controllers
{
    [Authorize(Roles="Agent")]
    [InitializeSimpleMembership]
    public class AgentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewBookingRequests()
        {
            var modelList = TravelBizLayer.GetAgentRequestList();
            return View(modelList);
        }

        public ActionResult BookTicket()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookTicket(TicketBooking model)
        {
            //ViewBag.Emp_ID = Emp_ID; //(ViewBag unused)
            //ViewBag.Mode_of_Travel = Mode_of_Travel;
            //ViewBag.Travel_Class = Travel_Class;
            //ViewBag.Travel_Date = Travel_Date;
            //ViewBag.Travel_Time_hh = Travel_Time_hh;
            //ViewBag.Travel_Time_mm = Travel_Time_mm;
            //ViewBag.Remarks = Remarks;
            if (ModelState.IsValid)
            {
                try
                {
                    if (!AgentBizLayer.BookTicketBiz(model))
                        return View("Error");

                    ViewBag.Message = "Ticket Booking Successful! <a href=\"/Agent\">Go to Home page</a>";
                    return View("Success");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {

            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }
}
