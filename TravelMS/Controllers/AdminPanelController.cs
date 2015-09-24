using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using TravelMS.Filters;
using TravelMS.Models;

namespace TravelMS.Controllers
{
    [Authorize(Roles = "Admin")]
    [InitializeSimpleMembership]
    public class AdminPanelController : Controller
    {
        //
        // GET: /AdminPanel/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult lockedAccounts()
        {
            List<RegisterModel> modelList = AdminPanelBizLayer.lockedAccounts();
            return View(modelList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult lockedAccounts(List<RegisterModel> modelList, string User_ID)
        {
            var res = AdminPanelBizLayer.unlockAccount(User_ID);
            ModelState.Clear();
            List<RegisterModel> updatedmodelList = AdminPanelBizLayer.lockedAccounts();
            return View(updatedmodelList);
        }

        [ValidateAntiForgeryToken]
        public ActionResult reset()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult settle()
        {
            return View();
        }

        public ActionResult closedRequests()
        {
            return View();
        }

        public ActionResult addAgent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addAgent(AgentModel model)
        {
            if (ModelState.IsValid)
            {
                var res = AdminPanelBizLayer.addAgent(model);
            }
            ModelState.Clear();
            ViewBag.Message = "Agent Addition Successful! <a href=\"/Home/Index\">Go to Home page</a>";
            return View("Success");
        }

        [ValidateAntiForgeryToken]
        public ActionResult manageAgent()
        {
            return View();
        }
    }
}
