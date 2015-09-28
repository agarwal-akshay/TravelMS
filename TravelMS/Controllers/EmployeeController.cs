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
    [Authorize(Roles="Emp")]
    [InitializeSimpleMembership]
    public class EmployeeController : Controller
    {        
        public ActionResult Index()
        {
            var modelList = TravelBizLayer.GetRequestList();
            ViewBag.capacity = modelList.Count.ToString();
            return View();
        }

        public ActionResult NewTravelRequest()
        {
            ViewBag.UserEmp_ID = TravelBizLayer.TravelUserEmp_IDBiz(User.Identity.Name);
            ViewBag.NextReq_ID = TravelBizLayer.TravelNextReq_IDBiz();
            ViewBag.AgentList = TravelBizLayer.AgentListBiz();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewTravelRequest(NewTravelRequestModel model)
        {
            ViewBag.UserEmp_ID=TravelBizLayer.TravelUserEmp_IDBiz(User.Identity.Name);
            ViewBag.NextReq_ID=TravelBizLayer.TravelNextReq_IDBiz();
            ViewBag.AgentList = TravelBizLayer.AgentListBiz();
            if (ModelState.IsValid)
            {
                try
                {
                    if (!TravelBizLayer.TravelReqBiz(model))
                        return View("Error");

                    ViewBag.Message = "<h3>Travel Request Registered!</h3><br/><a href='Employee/addAcco'>Add accommodation details.</a>  <a href='Employee'>Go to Dashboard</a>";
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

        public ActionResult ViewTravelRequests()
        {
            var modelList = TravelBizLayer.GetRequestList();
            return View(modelList);            
        }

        public ActionResult addAcco()
        {
            ViewBag.lastRequest = AccoBizLayer.getLastRequest();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addAcco(AccoModel model)
        {
            var res = AccoBizLayer.addAccoDetails(model);
            ViewBag.Message = "Accommodation Added. <a href=\"/Employee\">Go to Dashboard.</a>";
            return View("Success");
        }

        public ActionResult cancelRequest()
        {
            var modelList = TravelBizLayer.GetRequestList();
            return View(modelList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult cancelRequest(List<NewTravelRequestModel> modelList, string Travel_Request_ID)
        {
            var res = TravelBizLayer.cancelRequest(Travel_Request_ID);
            ModelState.Clear();
            var updatedmodelList = TravelBizLayer.GetRequestList();
            return View(updatedmodelList);
        }

        public ActionResult ViewApproveRejRequests()
        {
            var modelList = TravelBizLayer.GetApproveRejRequestList();
            return View(modelList);
        }

        [HttpPost]
        public ActionResult ApproveRequests()
        {
            if(!TravelBizLayer.ApproveRejBiz(Request.Params["Req_ID"], 'A'))
                return View("Error");
            return RedirectToAction("ViewApproveRejRequests", "Employee");
        }

        [HttpPost]
        public ActionResult RejRequests()
        {
            if(!TravelBizLayer.ApproveRejBiz(Request.Params["Req_ID"], 'R'))
                return View("Error");
            return RedirectToAction("ViewApproveRejRequests","Employee");
        }

        public ActionResult NewClaimRequest()
        {
            var travelRequests = ClaimRequestsBizLayer.populateTravelRequests(User.Identity.Name);
            ViewBag.nextClaimID = ClaimRequestsBizLayer.nextClaimID();
            ViewBag.travelRequests = travelRequests;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewClaimRequest(ClaimRequestsModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!ClaimRequestsBizLayer.NewClaimRequest(model))
                        return View("Error");

                    return RedirectToAction("Index", "Employee");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult ViewClaimRequests()
        {
            var model = ClaimRequestsBizLayer.ViewClaimRequests();
            return View(model);
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
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
